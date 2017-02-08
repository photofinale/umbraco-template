var gulp = require('gulp');
var $ = require('gulp-load-plugins')({ lazy: true });

gulp.task('default', ['debug'], function() { });

var cssFiles = [
    'sass/**/*.scss'
];

var jsFiles = [
    'bower_components/jquery/dist/jquery.js',
    'js/**/*.js'
];

var cssDestination = '../AgeBaseTemplate/css';
var jsDestination = '../AgeBaseTemplate/js';

gulp.task('debug', function() {

    gulp.src(jsFiles)
        .pipe($.sourcemaps.init())
        .pipe($.concat('main.js'))
        .pipe($.sourcemaps.write('.'))
        .pipe(gulp.dest(jsDestination));

    gulp.src(cssFiles)
        .pipe($.sourcemaps.init())
        .pipe($.sass().on('error', $.sass.logError))
        .pipe($.sourcemaps.write('.'))
        .pipe(gulp.dest(cssDestination));
});

gulp.task('release', function() {

    gulp.src(jsFiles)
        .pipe($.concat('main.js'))
        .pipe($.uglify())
        .pipe(gulp.dest(jsDestination));

    gulp.src(cssFiles)
        .pipe($.sass().on('error', $.sass.logError))
        .pipe($.cleanCss({ level:{ 1:{ specialComments:'remove' }}}))
        .pipe(gulp.dest(cssDestination));
});