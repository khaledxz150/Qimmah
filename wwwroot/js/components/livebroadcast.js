// Configuration
const YOUTUBE_API_KEY = 'AIzaSyBgTNBpl8e9xbEg1q0Sd4pbFVmLdZSQ-lo'; // Replace with your actual API key
const THUMBNAIL_CACHE = new Map(); // Cache thumbnails to avoid repeated API calls

// Your existing API function
async function getYouTubeThumbnailFromAPI( videoId, apiKey ) {
    try {
        const response = await fetch(
            `https://www.googleapis.com/youtube/v3/videos?id=${ videoId }&key=${ apiKey }&part=snippet`
        );
        const data = await response.json();

        if ( data.items && data.items.length > 0 ) {
            const thumbnails = data.items[ 0 ].snippet.thumbnails;
            return thumbnails.maxres?.url ||
                thumbnails.high?.url ||
                thumbnails.medium?.url ||
                thumbnails.default?.url;
        }
    } catch ( error ) {
        console.error( 'Error fetching YouTube thumbnail:', error );
    }
    return null;
}

// Enhanced function with caching and fallbacks
async function getYouTubeThumbnail( youtubeLink, useAPI = true ) {
    const videoId = extractYouTubeVideoId( youtubeLink );
    if ( !videoId ) return null;

    // Check cache first
    if ( THUMBNAIL_CACHE.has( videoId ) ) {
        return THUMBNAIL_CACHE.get( videoId );
    }

    let thumbnailUrl = null;

    // Try API first if enabled and API key is available
    if ( useAPI && YOUTUBE_API_KEY && YOUTUBE_API_KEY !== 'YOUR_YOUTUBE_API_KEY_HERE' ) {
        thumbnailUrl = await getYouTubeThumbnailFromAPI( videoId, YOUTUBE_API_KEY );
    }

    // Fallback to direct URL if API fails or is not available
    if ( !thumbnailUrl ) {
        thumbnailUrl = `https://img.youtube.com/vi/${ videoId }/maxresdefault.jpg`;

        // Verify the direct URL works
        const isValid = await verifyImageExists( thumbnailUrl );
        if ( !isValid ) {
            // Try alternative qualities
            const fallbackQualities = [ 'hqdefault', 'mqdefault', 'sddefault', 'default' ];
            for ( const quality of fallbackQualities ) {
                const fallbackUrl = `https://img.youtube.com/vi/${ videoId }/${ quality }.jpg`;
                if ( await verifyImageExists( fallbackUrl ) ) {
                    thumbnailUrl = fallbackUrl;
                    break;
                }
            }
        }
    }

    // Cache the result
    if ( thumbnailUrl ) {
        THUMBNAIL_CACHE.set( videoId, thumbnailUrl );
    }

    return thumbnailUrl;
}

// Helper function to verify if image URL exists
async function verifyImageExists( url ) {
    return new Promise( ( resolve ) => {
        const img = new Image();
        img.onload = () => resolve( true );
        img.onerror = () => resolve( false );
        img.src = url;

        // Timeout after 3 seconds
        setTimeout( () => resolve( false ), 3000 );
    } );
}

// Update card background with YouTube thumbnail
async function updateCardThumbnail( programId, youtubeLink, fallbackImageUrl ) {
    const card = document.querySelector( `[data-program-id="${ programId }"]` );
    const cardBackground = card?.querySelector( '.card-background' );

    if ( !cardBackground ) return;

    // Show loading state (optional)
    cardBackground.style.opacity = '0.7';

    try {
        const thumbnailUrl = await getYouTubeThumbnail( youtubeLink );

        if ( thumbnailUrl ) {
            cardBackground.style.backgroundImage = `url('${ thumbnailUrl }')`;
        } else if ( fallbackImageUrl ) {
            cardBackground.style.backgroundImage = `url('${ fallbackImageUrl }')`;
        }
    } catch ( error ) {
        console.error( 'Error updating card thumbnail:', error );
        // Use fallback image on error
        if ( fallbackImageUrl ) {
            cardBackground.style.backgroundImage = `url('${ fallbackImageUrl }')`;
        }
    } finally {
        // Remove loading state
        cardBackground.style.opacity = '1';
    }
}

// Initialize all thumbnails when page loads
async function initializeYouTubeThumbnails() {
    const cards = document.querySelectorAll( '.live-broadcast-card[data-program-id]' );
    const promises = [];

    cards.forEach( card => {
        const programId = card.getAttribute( 'data-program-id' );
        const youtubeLink = card.getAttribute( 'data-youtube-link' ); // You'll need to add this attribute
        const currentBg = card.querySelector( '.card-background' ).style.backgroundImage;

        // Extract current background image URL as fallback
        const fallbackUrl = currentBg ? currentBg.slice( 5, -2 ) : null;

        promises.push( updateCardThumbnail( programId, youtubeLink, fallbackUrl ) );
    } );

    // Wait for all thumbnails to load
    await Promise.allSettled( promises );
    console.log( 'YouTube thumbnails initialized' );
}

// Your existing functions (updated)
function toggleYouTubePlayer( youtubeLink, programId ) {
    const card = document.querySelector( `[data-program-id="${ programId }"]` );
    const playerContainer = document.getElementById( `youtube-player-${ programId }` );
    const playButton = card.querySelector( '.play-button' );
    const iframe = playerContainer.querySelector( '.youtube-iframe' );

    if ( playerContainer.classList.contains( 'd-none' ) ) {
        // Show player
        const videoId = extractYouTubeVideoId( youtubeLink );
        const embedUrl = `https://www.youtube.com/embed/${ videoId }?autoplay=1&rel=0&modestbranding=1&controls=1`;

        iframe.src = embedUrl;
        playerContainer.classList.remove( 'd-none' );
        setTimeout( () => playerContainer.classList.add( 'show' ), 10 );

        card.classList.add( 'player-active' );
        playButton.style.display = 'none';

        // Pause carousel
        const carousel = bootstrap.Carousel.getInstance( document.getElementById( 'liveBroadcastCarousel' ) );
        if ( carousel ) carousel.pause();
    }
}

function closeYouTubePlayer( programId ) {
    const card = document.querySelector( `[data-program-id="${ programId }"]` );
    const playerContainer = document.getElementById( `youtube-player-${ programId }` );
    const playButton = card.querySelector( '.play-button' );
    const iframe = playerContainer.querySelector( '.youtube-iframe' );

    // Hide player
    playerContainer.classList.remove( 'show' );
    setTimeout( () => {
        playerContainer.classList.add( 'd-none' );
        iframe.src = ''; // Stop the video
    }, 400 );

    card.classList.remove( 'player-active' );
    playButton.style.display = 'flex';

    // Resume carousel
    const carousel = bootstrap.Carousel.getInstance( document.getElementById( 'liveBroadcastCarousel' ) );
    if ( carousel ) carousel.cycle();
}

function extractYouTubeVideoId( url ) {
    const regExp = /^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|&v=)([^#&?]*).*/;
    const match = url.match( regExp );
    return ( match && match[ 2 ].length === 11 ) ? match[ 2 ] : null;
}

// Enhanced initialization
document.addEventListener( 'DOMContentLoaded', async function () {
    // Initialize carousel
    const carouselElement = document.getElementById( 'liveBroadcastCarousel' );
    if ( carouselElement ) {
        new bootstrap.Carousel( carouselElement, {
            interval: 6000,
            wrap: true,
            pause: 'hover'
        } );
    }

    // Initialize YouTube thumbnails
    await initializeYouTubeThumbnails();
} );

// Close player on escape key
document.addEventListener( 'keydown', function ( e ) {
    if ( e.key === 'Escape' ) {
        const activePlayer = document.querySelector( '.youtube-player-container.show' );
        if ( activePlayer ) {
            const programId = activePlayer.id.replace( 'youtube-player-', '' );
            closeYouTubePlayer( programId );
        }
    }
} );

// Utility function to manually refresh a specific thumbnail
async function refreshThumbnail( programId, youtubeLink ) {
    const videoId = extractYouTubeVideoId( youtubeLink );
    if ( videoId && THUMBNAIL_CACHE.has( videoId ) ) {
        THUMBNAIL_CACHE.delete( videoId ); // Clear cache
    }

    const card = document.querySelector( `[data-program-id="${ programId }"]` );
    const currentBg = card.querySelector( '.card-background' ).style.backgroundImage;
    const fallbackUrl = currentBg ? currentBg.slice( 5, -2 ) : null;

    await updateCardThumbnail( programId, youtubeLink, fallbackUrl );
}

// Export functions for external use
window.YouTubeThumbnails = {
    getYouTubeThumbnail,
    updateCardThumbnail,
    refreshThumbnail,
    initializeYouTubeThumbnails
};