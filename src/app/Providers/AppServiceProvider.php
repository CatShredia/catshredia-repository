<?php

namespace App\Providers;

// механизм авторизации
use Illuminate\Support\Facades\Gate;

use Illuminate\Support\ServiceProvider;
use Illuminate\Pagination\Paginator;

// adminPolicy и модель User
use App\Policies\AdminPolicy;
use App\Models\User;

class AppServiceProvider extends ServiceProvider
{
    /**
     * Register any application services.
     */
    public function register(): void
    {
        //
    }

    /**
     * Bootstrap any application services.
     */
    public function boot(): void
    {
        // устанавливаем пагинатор из bootstrap файла
        Paginator::defaultView('vendor/pagination/bootstrap-4');

        Gate::policy(User::class, AdminPolicy::class);
    }
}