FROM php:8.2-fpm-alpine

WORKDIR /var/www/laravel

# npm for bootstrap
RUN apk update && apk add --no-cache \
    git \
    zip \
    unzip \
    nodejs \
    npm 

# pdo for mysql
RUN docker-php-ext-install pdo pdo_mysql