<?php
namespace App\Http\Controllers\Post;

use App\Http\Filters\PostFilter; // Импортируем фильтр для постов
use App\Http\Requests\Post\FilterRequest; // Импортируем запрос для фильтрации
use Illuminate\Http\Request; // Импортируем класс Request
use App\Models\Post; // Импортируем модель Post

class IndexController extends BaseController
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

        // Возвращаем представление с постами
        return view('posts.index', compact('posts'));
    }
}
