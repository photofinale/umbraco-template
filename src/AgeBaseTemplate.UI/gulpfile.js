var gulp = require("gulp");
var $ = require('gulp-load-plugins')({ lazy: true });

gulp.task('default', ['styles'], function() { });

gulp.task('styles', function() {

    return gulp.src('app/assets/sass/**/*.scss')
        .pipe($.sourcemaps.init())
        .pipe($.sass().on('error', $.sass.logError))
        .pipe($.sourcemaps.write('.'))
        .pipe(gulp.dest('../AgeBaseTemplate/css'));

});