var gulp = require("gulp");
var $ = require('gulp-load-plugins')({ lazy: true });

gulp.task('default', ['styles'], function() { });

gulp.task('styles', function() {

    return gulp.src('app/assets/sass/**/*.scss')
        .pipe($.sass().on('error', $.sass.logError))
        .pipe(gulp.dest('dist/assets/css'));

});