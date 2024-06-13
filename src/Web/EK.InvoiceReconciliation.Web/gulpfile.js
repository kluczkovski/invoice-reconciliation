const gulp = require('gulp');
const sass = require('gulp-sass')(require('sass'));

// Sass Task
gulp.task('sass', function() {
    return gulp.src('./assets/scss/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest('./wwwroot/css'));
});