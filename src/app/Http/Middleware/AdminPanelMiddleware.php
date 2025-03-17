<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Http\Request;
use Symfony\Component\HttpFoundation\Response;

class AdminPanelMiddleware
{
    /**
     * Handle an incoming request.
     *
     * @param  \Closure(\Illuminate\Http\Request): (\Symfony\Component\HttpFoundation\Response)  $next
     */
    public function handle(Request $request, Closure $next): Response
    {

        // вытягивает из таблицы users авторизированного пользователя
        // (именно на активной страницы вашего ПК)

        if (auth()->user()->role !== "admin") {
            return redirect()->route('home');
        } else {
            return $next($request);
        }

    }
}