-- Drop ==========================================================================================================================================
DROP TABLE IF EXISTS basket;
DROP TABLE IF EXISTS order_item;
DROP TABLE IF EXISTS shop_order;
DROP TABLE IF EXISTS login;
DROP TABLE IF EXISTS user_address;
DROP TABLE IF EXISTS role_permission;
DROP TABLE IF EXISTS street;
DROP TABLE IF EXISTS product;
DROP TABLE IF EXISTS city;
DROP TABLE IF EXISTS role;

-- Create ==========================================================================================================================================

-- Создание базы данных (выполняется отдельно, не внутри транзакции)
-- CREATE DATABASE shopdb; -- Выполните эту команду отдельно, если нужно

-- Подключение к базе

-- Включение расширения для генерации UUID, если понадобится (не обязательно сейчас)
-- CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Таблица City
CREATE TABLE city (
    id_city SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

-- Таблица Street
CREATE TABLE street (
    id_street SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    id_city INT NOT NULL,
    FOREIGN KEY (id_city) REFERENCES city(id_city) ON UPDATE CASCADE ON DELETE CASCADE
);

-- Таблица Role
CREATE TABLE role (
    id_role SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

-- Таблица User (в PostgreSQL "user" — зарезервированное слово, поэтому используем "app_user")
CREATE TABLE app_user (
    id_user SERIAL PRIMARY KEY,
    surname VARCHAR(50),
    name VARCHAR(50) NOT NULL,
    description TEXT,
    phone VARCHAR(50),
    id_role INT NOT NULL,
    FOREIGN KEY (id_role) REFERENCES role(id_role) ON UPDATE CASCADE ON DELETE CASCADE
);

-- Таблица Login
CREATE TABLE login (
    id_login SERIAL PRIMARY KEY,
    login VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    id_user INT NOT NULL,
    FOREIGN KEY (id_user) REFERENCES app_user(id_user) ON UPDATE CASCADE ON DELETE CASCADE
);

-- Таблица Product
CREATE TABLE product (
    id_product SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    price INT NOT NULL CHECK (price >= 0),
    provider VARCHAR(50),
    image_path VARCHAR(50)
);

-- Таблица Basket
CREATE TABLE basket (
    id_basket SERIAL PRIMARY KEY,
    id_user INT NOT NULL,
    id_product INT NOT NULL,
    count INT NOT NULL DEFAULT 0 CHECK (count >= 0),
    FOREIGN KEY (id_user) REFERENCES app_user(id_user) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (id_product) REFERENCES product(id_product) ON UPDATE CASCADE ON DELETE CASCADE
);

-- Таблица Order (order — зарезервированное слово → используем "shop_order")
CREATE TABLE shop_order (
    id_order SERIAL PRIMARY KEY,
    id_user INT NOT NULL,
    is_paid BOOLEAN NOT NULL DEFAULT FALSE,
    is_delivered BOOLEAN NOT NULL DEFAULT FALSE,
    FOREIGN KEY (id_user) REFERENCES app_user(id_user) ON UPDATE CASCADE ON DELETE CASCADE
);

-- Таблица Order_list → order_item (лучше по смыслу)
CREATE TABLE order_item (
    id_order_item SERIAL PRIMARY KEY,
    id_order INT NOT NULL,
    id_product INT NOT NULL,
    FOREIGN KEY (id_order) REFERENCES shop_order(id_order) ON DELETE CASCADE,
    FOREIGN KEY (id_product) REFERENCES product(id_product) ON DELETE RESTRICT
);

-- Таблица RolePermission
CREATE TABLE role_permission (
    id_role INT NOT NULL,
    permission_name VARCHAR(50) NOT NULL,
    PRIMARY KEY (id_role, permission_name),
    FOREIGN KEY (id_role) REFERENCES role(id_role) ON DELETE CASCADE
);

-- Таблица UserAdresses → user_address (с исправлением опечатки и регистра)
CREATE TABLE user_address (
    id_user_address SERIAL PRIMARY KEY,
    id_user INT NOT NULL,
    id_street INT NOT NULL,
    home VARCHAR(3) NOT NULL,
    apartment INT,
    FOREIGN KEY (id_user) REFERENCES app_user(id_user) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (id_street) REFERENCES street(id_street) ON UPDATE CASCADE ON DELETE CASCADE
);