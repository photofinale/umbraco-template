var gulp = require('gulp');
var $ = require('gulp-load-plugins')({ lazy: true });

var cssDestination = '../AgeBaseTemplate/css';
var fontsDestination = '../AgeBaseTemplate/fonts';
var imagesDestination = '../AgeBaseTemplate/images';
var jsDestination = '../AgeBaseTemplate/js';

var cssSources = ['sass/**/*.scss'];
var jsSources = ['js/**/*.js'];

// Tasks

gulp.task('vendor', function() {

    var fontsVendors = ['bower_components/bootstrap-sass/assets/fonts/bootstrap/**/*'];
    var imagesVendors = ['bower_components/country-flags/images/**/*'];
    var jsVendors = ['bower_components/bootstrap-sass/assets/javascripts/bootstrap.min.js'];

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