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
        if ( this.expanded || this.animating ) return;
        this.animating = true;

        if ( this.readMoreBtn ) {
            this.readMoreBtn.style.display = "none";
        }

        // --- Step 1: Get an accurate height measurement ---

        // To measure correctly, we need the final width, as it affects text wrapping.
        const viewportWidth = window.innerWidth;
        let maxWidth;
        if ( viewportWidth <= 768 ) {
            maxWidth = viewportWidth * 0.95;
        } else if ( viewportWidth <= 1200 ) {
            maxWidth = Math.min( viewportWidth * 0.8, 700 );
        } else {
            maxWidth = Math.min( viewportWidth * 0.6, 900 );
        }

        // Temporarily apply final styles to a clone to measure its natural height
        const clone = this.cardContentEl.cloneNode( true );
        clone.style.visibility = "hidden";
        clone.style.position = "absolute";
        clone.style.left = "-9999px"; // Move it off-screen
        clone.style.width = `${ maxWidth }px`; // Set final width
        clone.style.height = "auto"; // Let height be natural
        clone.style.fontSize = "1.5rem"; // Set final font size

        const cloneExpandedContent = clone.querySelector( "[expandedContent]" );
        cloneExpandedContent.style.visibility = "visible";
        cloneExpandedContent.style.position = "relative"; // Let it take up space

        document.body.appendChild( clone );
        const actualNeededHeight = clone.offsetHeight; // The one true height!
        document.body.removeChild( clone );

        console.log( "Final calculated height:", actualNeededHeight );

        // --- Step 2: Now, run the animation with the correct height ---

        this.backdropEl.style.position = "fixed";
        this.backdropEl.style.top = "0px";
        this.backdropEl.style.left = "0px";
        this.backdropEl.style.right = "0px";
        this.backdropEl.style.bottom = "0px";
        this.backdropEl.style.opacity = "0";
        this.backdropEl.style.zIndex = 9;
        document.body.appendChild( this.backdropEl );

        const cardRect = this.cardContentEl.getBoundingClientRect();
        this.placeholderEl.style.height = `${ cardRect.height }px`;

        this.cardContentEl.style.position = "fixed";
        this.cardContentEl.style.zIndex = 10;
        this.cardContentEl.style.top = `0px`;
        this.cardContentEl.style.left = `0px`;
        this.cardContentEl.style.width = `${ cardRect.width }px`;
        this.cardContentEl.style.height = `${ cardRect.height }px`;
        this.cardContentEl.style.transform = `translate(${ cardRect.left }px, ${ cardRect.top }px)`;

        this.expandedContentEl.style.visibility = "visible";

        const viewportHeight = window.innerHeight;
        const iconOffset = 100;
        const verticalMargin = ( viewportHeight - actualNeededHeight ) / 2;
        const horizontalMargin = ( viewportWidth - maxWidth ) / 2;

        const targetRect = {
            left: horizontalMargin,
            top: Math.max( iconOffset, verticalMargin ),
            width: maxWidth,
            height: actualNeededHeight, // Use our perfect measurement
        };

        this.cardContentEl.addEventListener( "click", () => this.collapse() );

        const promises = [
            anime( {
                targets: this.cardContentEl,
                height: [ cardRect.height, targetRect.height ],
                translateX: [ cardRect.left, targetRect.left ],
                translateY: [ cardRect.top, targetRect.top ],
                width: [ cardRect.width, targetRect.width ],
                fontSize: "1.5rem", // Animate font size smoothly
                boxShadow:
                    "0 0 1px 0 rgba(33,43,54,.08), 0 8px 10px 0 rgba(33,43,54,.2)",
                duration: duration,
                easing: "easeOutCubic",
            } ).finished,
            anime( {
                targets: this.expandedContentEl,
                translateY: [ 16, 0 ],
                opacity: [ 0, 1 ],
                delay: 100,
                duration: duration,
                easing: "easeOutCubic",
            } ).finished,
            anime( {
                targets: this.backdropEl,
                opacity: [ 0, 0.33 ],
                duration: duration,
                easing: "easeOutCubic",
            } ),
        ];

        return Promise.all( promises ).then( () => {
            this.animating = false;
            this.expanded = true;
        } );
    }
    collapse() {
        if ( !this.expanded || this.animating ) {
            return;
        }
        this.animating = true;

        const placeholderRect = this.placeholderEl.getBoundingClientRect();
        const cardContentRect = this.cardContentEl.getBoundingClientRect();
        const expandedContentHeight = this.expandedContentEl.offsetHeight;
        const fromHeight = cardContentRect.height;
        const toHeight = fromHeight - expandedContentHeight;

        this.cardContentEl.addEventListener( "click", () => { } );

        const promises = [
            anime( {
                targets: this.cardContentEl,
                height: [ fromHeight, toHeight ],
                translateX: [ cardContentRect.left, placeholderRect.left ],
                translateY: [ cardContentRect.top, placeholderRect.top ],
                width: [ cardContentRect.width, placeholderRect.width ],
                boxShadow: "0 2px 2px 1px rgba(0, 0, 0, 0.1)",
                duration: leaveDuration,
                delay: 0,
                easing: "easeInQuad",
            } ).finished,
            anime( {
                targets: this.expandedContentEl,
                translateY: [ 0, 16 ],
                opacity: [ 1, 0 ],
                duration: leaveDuration,
                easing: "easeInQuad",
            } ).finished,
            anime( {
                targets: this.backdropEl,
                opacity: [ 0.33, 0 ],
                duration: leaveDuration,
                easing: "easeInQuad",
            } ),
        ];

        return Promise.all( promises ).then( () => {
            this.animating = false;
            this.expanded = false;

            if ( this.readMoreBtn ) {
                this.readMoreBtn.style.display = "";
            }

            this.placeholderEl.style.height = "0px";
            this.cardContentEl.style.position = "relative";
            this.cardContentEl.style.zIndex = null;
            this.cardContentEl.style.top = null;
            this.cardContentEl.style.left = null;
            this.cardContentEl.style.width = null;
            this.cardContentEl.style.height = null;
            this.cardContentEl.style.transform = null;
            this.cardContentEl.style.overflowY = null; // Reset overflow
            this.expandedContentEl.style.visibility = "hidden";
            document.body.removeChild( this.backdropEl );
        } );
    }
 
}

var c = new ExpandableCard(document.querySelector("#profile-1"));
var c = new ExpandableCard(document.querySelector("#profile-2"));
var c = new ExpandableCard(document.querySelector("#profile-3"));
