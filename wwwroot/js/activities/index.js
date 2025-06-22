let isLoading = false;
let currentProgramData = null;
let loadingTimeout;
function loadPrograms(page = 1) {
    if (isLoading) return;

    isLoading = true;
    showLoading();

    const filters = getCurrentFilters();

    // Get the data (single database query)
    $.post(API_ENDPOINTS.getProgramData, {
        page: page,
        pageSize: 9,
        search: filters.search,
        orderBy: filters.orderBy,
        categories: filters.categories
    })
        .done(function (response) {
            if (response.success) {
                currentProgramData = response.data;
                const metadata = response.metadata;


                // Step 2: Render pagination FIRST (prioritized)
                $.ajax({
                    url: API_ENDPOINTS.renderPagination,
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify({
                        TotalCount: metadata.totalCount,
                        CurrentPage: metadata.currentPage,
                        PageSize: metadata.pageSize,
                        CurrentlyViewingCount: metadata.currentlyViewingCount
                    }),
                    success: function (html) {
                        $('.pagination-container').html(html);

                        // Step 3: Then render cards
                        renderProgramCards();
                    },
                    error: function () {
                        $('.pagination-container').html(`<div class="alert alert-warning">${window.AppLocalization.errorMessage}</div>`);
                        renderProgramCards(); // Still try to render cards
                    }
                });

            } else {
                $('#program-cards-container').html(`<div class="alert alert-danger text-center">${response.message}</div>`);
                $('.pagination-container').html('');
                hideLoading();
            }
        })
        .fail(function () {
            $('#program-cards-container').html(`<div class="alert alert-danger text-center">${window.AppLocalization.errorMessage}</div>`);
            $('.pagination-container').html('');
            hideLoading();
        })
        .always(function () {
            isLoading = false;
        });
}
function getCurrentFilters() {
    return {
        search: $('[name="Search"]').val() || '',
        orderBy: $('[name="OrderBy"]').val() || '1',
        categories: $('[name="CategoryFilter"]').val() ? $('[name="CategoryFilter"]').val().join(',') : ''
    };
}

function renderProgramCards() {
    if (!currentProgramData) return;

    $.ajax({
        url: API_ENDPOINTS.renderProgramCards,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ Items: currentProgramData.items }),
        success: function (html) {
            $('#program-cards-container').html(html);
        },
        error: function () {
            $('#program-cards-container').html(`<div class="alert alert-danger">${window.AppLocalization.errorMessage}</div>`);
        },
        complete: function () {
            hideLoading();

            // Smooth scroll to results
            setTimeout(function () {
                $('html, body').animate({
                    scrollTop: $("#program-cards-container").offset().top - 100
                }, 500);
            }, 100);
        }
    });
}

$(document).ready(function () {
    // Event handlers
    $(document).on('click', '.pagination-link:not(.disabled)', function (e) {
        e.preventDefault();
        const page = $(this).data('page');
        if (page && page > 0) {
            loadPrograms(page);
        }
    });

    let searchTimeout;
    $('[name="Search"]').on('input', function () {
        clearTimeout(searchTimeout);
        searchTimeout = setTimeout(() => loadPrograms(1), 500);
    });

    $('[name="OrderBy"], [name="Filter"]').on('change', function () {
        loadPrograms(1);
    });

    $(document).ajaxStart(function () {
        $('[name="Search"], [name="OrderBy"], [name="Filter"]').prop('disabled', true);
    });

    $(document).ajaxStop(function () {
        $('[name="Search"], [name="OrderBy"], [name="Filter"]').prop('disabled', false);
    });
});