<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Category;
use App\Models\Post;
use App\Models\Tag;
use App\Models\PostTag;

use App\Http\Requests\Post\FilterRequest;


class DevController extends Controller
{
    public function __invoke(FilterRequest $filterRequest)
    {
        // ! не правильный фильтр
        // $posts = Post::where('isPublished', 1)->where('category_id', '1')->get();

        // вызов запроса, которому передаем данные ч/з валидатор
        $data = $filterRequest->validated();
        // форма записи запроса, типо where, обычно
        $query = Post::query();


        // ! такой способ уже устарел
        // ? проверка на id категории
        if (isset($data['category_id'])) {
            // указываем запрос
            $query->where('category_id', $data['category_id']);
        }

        // ? проверка на название
        if (isset($data['title'])) {
            // указываем запрос
            $query->where('title', 'like', "%{$data['title']}%");
        }

        // ? проверка на контент
        if (isset($data['content'])) {
            // указываем запрос
            $query->where('content', 'like', "%{$data['content']}%");
        }
        // ? проверка на is_published
        if (isset($data['isPublished'])) {
            // указываем запрос
            $query->where('isPublished', $data['isPublished']);
        }

        // сохраняем найденные посты
        $posts = $query->get();

        dump($posts);
    }
}
