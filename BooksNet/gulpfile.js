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
        files: ['content/material-kit.css', 'content/books-app.css'],
        minifyFiles: ['content/material-kit.min.css', 'content/books-app.min.css'],
        sass: {
            src: 'content/*.scss'
        }
    }
}

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

gulp.task('watch', function () {
    gulp.watch(config.css.sass.src, ['build']);
    gulp.watch(config.admin.css.sass.src, ['build']);
});
gulp.task('build', ['admin:concat','app:concat']);

gulp.task('default',['build']);