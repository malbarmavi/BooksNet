/// <binding BeforeBuild='build' Clean='clean' ProjectOpened='watch' />
'use strict';

const gulp = require('gulp');
const sass = require('gulp-sass');
const autoprefixer = require('gulp-autoprefixer');
const cssnano = require('gulp-cssnano');
const concat = require('gulp-concat');
const rename = require('gulp-rename');
const strip = require('gulp-strip-css-comments');
const clean = require('gulp-clean');
const uglify = require('gulp-uglify');
const stripjs = require('gulp-strip-comments');

const config = {
    admin: {
        css: {
            dest: 'areas/admin/content',
            files: ['areas/admin/content/material-dashboard.css', 'areas/admin/content/app.css'],
            minifyFiles: ['areas/admin/content/material-dashboard.min.css', 'areas/admin/content/app.min.css'],
            cleanFiles: ["areas/admin/content/*.css", "!areas/admin/content/material-dashboard.css", "!areas/admin/content/file-upload.css"],
            sass: {
                src: 'areas/admin/content/*.scss'

            }
        }
    },
    css: {
        dest: 'content',
        files: ['content/material-kit.css','content/chosen.css', 'content/books-app.css'],
        minifyFiles: ['content/material-kit.min.css', 'content/books-app.min.css'],
        sass: {
            src: 'content/*.scss'
        }
    },
    js: {
        dest: 'scripts',
        files: ['scripts/app.js','scripts/material-kit.js'],
        minifyFiles: ['scripts/material.min.js', 'scripts/material-kit.min.js', 'scripts/angular.min.js', 'scripts/angular-route.min.js','scripts/app.min.js']
    }
}

// admin
gulp.task('clean',function () {
    return gulp.src(config.admin.css.cleanFiles)
        .pipe(clean({ force: true }))
});

gulp.task('admin:sass', ['clean'], function () {
    return gulp
        .src(config.admin.css.sass.src)
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer())
        .pipe(gulp.dest(config.admin.css.dest));
});

gulp.task('admin:minify',['admin:sass'], function () {
    return gulp.src(config.admin.css.files)
        .pipe(strip())
        .pipe(cssnano())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(config.admin.css.dest));
});

gulp.task('admin:strip', ['admin:minify'], function () {
    return gulp.src(config.admin.css.minifyFiles)
        .pipe(strip({ preserve: false }))
        .pipe(gulp.dest(config.admin.css.dest));
});

gulp.task('admin:concat', ['admin:strip'], function () {
    return gulp.src(config.admin.css.minifyFiles)
        .pipe(concat('admin.css'))
        .pipe(gulp.dest(config.admin.css.dest));
});

// app
gulp.task('app:sass', function () {
    return gulp
        .src(config.css.sass.src)
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer())
        .pipe(gulp.dest(config.css.dest));
});
gulp.task('app:minify', ['app:sass'], function () {
    return gulp.src(config.css.files)
        .pipe(strip())
        .pipe(cssnano())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(config.css.dest));
});

gulp.task('app:strip', ['app:minify'], function () {
    return gulp.src(config.css.minifyFiles)
        .pipe(strip({ preserve: false }))
        .pipe(gulp.dest(config.css.dest));
});

gulp.task('app:concat', ['app:strip'], function () {
    return gulp.src(config.css.minifyFiles)
        .pipe(concat('app.css'))
        .pipe(gulp.dest(config.css.dest));
}); 

gulp.task('appjs:minify', function () {
    return gulp.src(config.js.files)
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(config.js.dest));
});


gulp.task('appjs', ['appjs:minify'], function () {
    return gulp.src(config.js.minifyFiles)
        .pipe(stripjs())
        .pipe(concat('build.js'))
        .pipe(gulp.dest(config.js.dest));
});

// global
gulp.task('watch', function () {
    gulp.watch(config.css.sass.src, ['build']);
    gulp.watch(config.admin.css.sass.src, ['build']);
});

gulp.task('build', ['admin:concat','app:concat']);

gulp.task('default',['build']);