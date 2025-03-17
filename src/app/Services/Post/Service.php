<?php

namespace App\Services\Post;

use App\Models\Post;

class Service
{
    public function store($data)
    {
        $tags = $data['tag_ids'];
        unset($data['tag_ids']);

        // создаем новый объект в БД, который по ключам заполняем данными от пользователя
        $post = Post::create($data);

        $post->tags()->attach($tags);
    }

    public function update($data, $post)
    {
        $tags = $data['tag_ids'];
        unset($data['tag_ids']);


        $post->update($data);
        // добавление новых и удаление старых записей
        $post->tags()->sync($tags);
    }
}
