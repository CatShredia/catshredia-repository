<?php

namespace Database\Seeders;

use App\Models\User;
use App\Models\Post;
use App\Models\Tag;
use App\Models\Category;

// use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        // просто создает массивы
        // $posts = Post::factory(10)->make();
        // добавляет элементы в базу, в этом случае 10 штук
        $category = Category::factory(10)->create();
        $tags = Tag::factory(50)->create();
        $posts = Post::factory(100)->create();

        foreach ($posts as $post) {
            $tagsIds = $tags->random(5)->pluck('id');

            $post->tags()->attach($tagsIds);
        }
    }
}
