<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

use App\Models\Post;
use App\Models\Category;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\=Post>
 */
class PostFactory extends Factory
{
    protected $model = Post::class;
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
            // обращаемся к специальному классу-константе,
            // который возврашает рандомные названия и не только
            'title' => $this->faker->name(),
            'content' => $this->faker->text(100),
            'image_url' => $this->faker->imageUrl(),
            // рандомим количество лайков
            'likes' => random_int(1, 10000),
            'isPublished' => random_int(0, 1),
            // рандомим id категорий
            'category_id' => Category::get()->random()->id
        ];
    }
}
