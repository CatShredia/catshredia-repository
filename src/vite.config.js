import { defineConfig } from "vite";
import laravel from "laravel-vite-plugin";

export default defineConfig({
    plugins: [
        laravel({
            input: ["resources/sass/app.scss", "resources/js/app.js"],
            refresh: true,
        }),
    ],
    server: {
        hmr: {
            host: "localhost", // Или ваш домен, если не localhost
        },
        host: "localhost", // Или ваш домен, если не localhost
        cors: true, //  Включаем CORS для сервера Vite
        origin: "http://localhost:8080", // Или ваш домен, где размещено приложение
    },
});
