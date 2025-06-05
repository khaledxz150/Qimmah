const gulp = require('gulp');
const rtlcss = require('gulp-rtlcss');
const rename = require('gulp-rename');

// Task to generate site.rtl.css from site.css
gulp.task('rtl', function () {
    return gulp.src('wwwroot/css/site.css')       // Source LTR file
        .pipe(rtlcss())                              // Convert to RTL
        .pipe(rename({ suffix: '.rtl' }))            // Rename to site.rtl.css
        .pipe(gulp.dest('wwwroot/css'));             // Output to the same directory
});

gulp.task('watch-rtl', function () {
  gulp.watch('wwwroot/css/site.css', gulp.series('rtl'));
});