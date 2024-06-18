const gulp = require('gulp');
const sass = require('gulp-sass')(require('sass'));

// Sass Task
gulp.task('sass', function() {
    return gulp.src('./Assets/scss/entry/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest('./wwwroot/css'));
});