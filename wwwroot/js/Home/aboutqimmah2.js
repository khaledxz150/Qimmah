const duration = 300;
const leaveDuration = 250;
class ExpandableCard {
    constructor(node) {
        this.backdropEl = document.createElement("DIV");
        this.backdropEl.className = "ptc-logs-expanding-card--backdrop";
        this.backdropEl.addEventListener("click", () => {
            this.collapse();
        });
        this.hostEl = node;
        this.placeholderEl = document.createElement("DIV");
        this.placeholderEl.className = "ptc-logs-expanding-card--placeholder";
        this.hostEl.appendChild(this.placeholderEl);
        this.cardContentEl = node.querySelector("[cardContent]");
        this.collapsedContentEl = node.querySelector("[collapsedContent]");
        this.expandedContentEl = node.querySelector("[expandedContent]");
        this.readMoreBtn = node.querySelector(".read-more-btn"); // Add this line
        this.expanded = false;
        this.animatingFlag = false;
        // Modify the click event to only trigger on the button if it exists
        if (this.readMoreBtn) {
            this.readMoreBtn.addEventListener("click", (e) => {
                e.stopPropagation(); // Prevent event bubbling
                this.expand();
            });
        } else {
            // Keep the original behavior for cards without the button
            this.hostEl.addEventListener("click", () => {
                this.expand();
            });
        }
        this.hostEl.addEventListener("click", () => {
            this.expand();
        });
    }

    expand() {
        if (this.expanded || this.animating) {
            return;
        }
        this.animating = true;

        // Hide the read more button
        if (this.readMoreBtn) {
            this.readMoreBtn.style.display = 'none';
        }

        this.backdropEl.style.position = "fixed";
        this.backdropEl.style.top = "0px";
        this.backdropEl.style.left = "0px";
        this.backdropEl.style.right = "0px";
        this.backdropEl.style.bottom = "0px";
        this.backdropEl.style.opacity = "0";

        this.backdropEl.style.zIndex = 9;

        document.body.appendChild(this.backdropEl);

        const cardBoundingRect = this.cardContentEl.getBoundingClientRect();

        this.placeholderEl.style.height = `${cardBoundingRect.height}px`;
        this.cardContentEl.style.position = "fixed";
        this.cardContentEl.style.zIndex = 10;
        this.cardContentEl.style.top = `${0}px`;
        this.cardContentEl.style.left = `${0}px`;
        this.cardContentEl.style.width = null;
        this.cardContentEl.style.height = null;
        this.cardContentEl.style.transform = `translate(${cardBoundingRect.left
            }px), ${cardBoundingRect.top}px)`;
        this.expandedContentEl.style.visibility = "visible";

        const fromHeight = this.staticHeight(this.cardContentEl);
        const expandedContentHeight = this.staticHeight(this.expandedContentEl);
        const toHeight = fromHeight + expandedContentHeight;

        const targetBoundingRect = {
            left: window.innerWidth / 4,
            top: window.innerHeight / 4,
            width: window.innerWidth /2,
            height: toHeight
        };
        const promises = [
            anime({
                targets: this.cardContentEl,
                height: [fromHeight, toHeight],
                translateX: [cardBoundingRect.left, targetBoundingRect.left],
                translateY: [cardBoundingRect.top, targetBoundingRect.top],
                width: [cardBoundingRect.width, targetBoundingRect.width],
                boxShadow:
                    "0 0 1px 0 rgba(33,43,54,.08), 0 8px 10px 0 rgba(33,43,54,.2)",
                duration: duration,
                easing: 'easeOutCubic'
            }).finished,
            anime({
                targets: this.expandedContentEl,
                translateY: [16, 0],
                opacity: [0, 1],
                delay: 100,
                duration: duration,
                easing: 'easeOutCubic'
            }).finished,
            anime({
                targets: this.backdropEl,
                opacity: [0, 0.33],
                duration: duration,
                easing: 'easeOutCubic'
            })
        ];
        return Promise.all(promises).then(() => {
            this.animating = false;
            this.expanded = true;
        });
    }

    collapse() {
        if (!this.expanded || this.animating) {
            return;
        }
        this.animating = true;

        const placeholderRect = this.placeholderEl.getBoundingClientRect();
        const cardContentRect = this.cardContentEl.getBoundingClientRect();
        const expandedContentHeight = this.expandedContentEl.offsetHeight;
        const fromHeight = cardContentRect.height;
        //debugger;
        const toHeight = fromHeight - expandedContentHeight;
        const promises = [
            anime({
                targets: this.cardContentEl,
                height: [fromHeight, toHeight],
                translateX: [cardContentRect.left, placeholderRect.left],
                translateY: [cardContentRect.top, placeholderRect.top],
                width: [cardContentRect.width, placeholderRect.width],
                boxShadow: "0 2px 2px 1px rgba(0, 0, 0, 0.1)",
                duration: leaveDuration,
                delay: 0,
                easing: 'easeInQuad'
            }).finished,
            anime({
                targets: this.expandedContentEl,
                translateY: [0, 16],
                opacity: [1, 0],
                duration: leaveDuration,
                easing: 'easeInQuad'
            }).finished,
            anime({
                targets: this.backdropEl,
                opacity: [0.33, 0],
                duration: leaveDuration,
                easing: 'easeInQuad'
            })
        ];
        return Promise.all(promises).then(() => {
            this.animating = false;
            this.expanded = false;
            if (this.readMoreBtn) {
                this.readMoreBtn.style.display = '';
            }
            this.placeholderEl.style.height = '0px';
            this.cardContentEl.style.position = "relative";
            this.cardContentEl.style.zIndex = null;
            this.cardContentEl.style.top = null;
            this.cardContentEl.style.left = null;
            this.cardContentEl.style.width = null;
            this.cardContentEl.style.height = null;
            this.cardContentEl.style.transform = null;
            this.expandedContentEl.style.visibility = "hidden";
            document.body.removeChild(this.backdropEl);
        });
    }

    staticHeight(node) {
        const height = node.offsetHeight;
        node.style.height = `${height}px`;
        return height;
    }
}

var c = new ExpandableCard(document.querySelector("#profile-1"));
var c = new ExpandableCard(document.querySelector("#profile-2"));
var c = new ExpandableCard(document.querySelector("#profile-3"));



