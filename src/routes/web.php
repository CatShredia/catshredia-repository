<?php

use App\Http\Controllers\StartController;
use Illuminate\Support\Facades\Route;

Route::get('/', [StartController::class, '__invoke'])->name('start');
Route::post('/create', [StartController::class, 'Create'])->name('create');
