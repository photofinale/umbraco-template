var gulp = require('gulp');
var $ = require('gulp-load-plugins')({ lazy: true });

var cssDestination = '../AgeBaseTemplate/css';
var fontsDestination = '../AgeBaseTemplate/fonts';
var imagesDestination = '../AgeBaseTemplate/images';
var jsDestination = '../AgeBaseTemplate/js';

var cssSources = ['app/sass/**/*.scss'];
var jsSources = ['app/js/**/*.js'];

gulp.task('vendor', function() {

    var fontsVendors = [];
    var imagesVendors = ['node_modules/flag-icon-css/**/*.svg'];
    var jsVendors = [];

    gulp.src(fontsVendors)
        .pipe(gulp.dest(fontsDestination));

    gulp.src(imagesVendors)
        .pipe(gulp.dest(imagesDestination));

    gulp.src(jsVendors)
        .pipe(gulp.dest(jsDestination));
});

gulp.task('debug', ['vendor'], function() {

    gulp.src(cssSources)
        .pipe($.sourcemaps.init())
        .pipe($.sass().on('error', $.sass.logError))
        .pipe($.sourcemaps.write('.'))
        .pipe(gulp.dest(cssDestination));

    gulp.src(jsSources)
        .pipe($.sourcemaps.init())
        .pipe($.concat('main.js'))
        .pipe($.sourcemaps.write('.'))
        .pipe(gulp.dest(jsDestination));
});

gulp.task('release', ['vendor'], function() {

    gulp.src(cssSources)
        .pipe($.sass().on('error', $.sass.logError))
        .pipe($.cleanCss({ level:{ 1:{ specialComments:'remove' }}}))
        .pipe(gulp.dest(cssDestination));

    gulp.src(jsSources)
        .pipe($.concat('main.js'))
        .pipe($.uglify())
        .pipe(gulp.dest(jsDestination));
});

gulp.task('default', ['debug'], function() { });