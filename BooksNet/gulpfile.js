/// <binding BeforeBuild='build' Clean='clean' />
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
            cleanFiles: ["areas/admin/content/*.css", "!areas/admin/content/material-dashboard.css"],
            sass: {
                src: 'areas/admin/content/*.scss'

            }
        }
    }
}

gulp.task('clean',function () {
    return gulp.src(config.admin.css.cleanFiles)
        .pipe(clean({ force: true }))
});

gulp.task('sass', ['clean'], function () {
    return gulp
        .src(config.admin.css.sass.src)
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer())
        .pipe(gulp.dest(config.admin.css.dest));
});

gulp.task('minify',['sass'], function () {
    return gulp.src(config.admin.css.files)
        .pipe(strip())
        .pipe(cssnano())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(config.admin.css.dest));
});

gulp.task('strip', ['minify'], function () {
    return gulp.src(config.admin.css.minifyFiles)
        .pipe(strip({ preserve: false }))
        .pipe(gulp.dest(config.admin.css.dest));
});

gulp.task('concat', ['strip'], function () {
    return gulp.src(config.admin.css.minifyFiles)
        .pipe(concat('admin.css'))
        .pipe(gulp.dest(config.admin.css.dest));
});


gulp.task('build', ['concat']);

gulp.task('default',['build']);