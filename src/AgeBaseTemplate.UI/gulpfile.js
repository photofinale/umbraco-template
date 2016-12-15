var gulp = require("gulp");
var $ = require('gulp-load-plugins')({ lazy: true });

gulp.task('default', ['debug'], function() { });

gulp.task('debug', function() {
    return gulp.src('sass/**/*.scss')
        .pipe($.sourcemaps.init())
        .pipe($.sass().on('error', $.sass.logError))
        .pipe($.sourcemaps.write('.'))
        .pipe(gulp.dest('../AgeBaseTemplate/css'));
});

gulp.task('release', function() {
    return gulp.src('sass/**/*.scss')
        .pipe($.sass().on('error', $.sass.logError))
        .pipe(gulp.dest('../AgeBaseTemplate/css'));
});