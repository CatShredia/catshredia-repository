<?php

namespace App\Http\Controllers\Admin\Post;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;

use App\Http\Filters\PostFilter; // Импортируем фильтр для постов
use App\Http\Requests\Post\FilterRequest; // Импортируем запрос для фильтрации
use App\Models\Post; // Импортируем модель Post

class IndexAdminController extends Controller
{
    // Метод __invoke используется для обработки входящих запросов
    public function __invoke(FilterRequest $request)
    {
        // Валидируем данные запроса
        $data = $request->validated();

        // Создаем экземпляр фильтра с параметрами запроса
        $filter = app()->make(PostFilter::class, ['queryParams' => array_filter($data)]);

        // Применяем фильтр к модели Post и пагинируем результаты
        $posts = Post::filter($filter)->paginate(10);

        return view('admin.post.index', compact('posts', 'data'));
    }
}