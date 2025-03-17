<?php

namespace App\Http\Controllers\Post;


use Illuminate\Http\Request;

use App\Models\Category;
use App\Models\Tag;
use App\Models\Post;


class EditController extends BaseController
{
    // что-то типо конструтора
    public function __invoke(Post $post)
    {
        $categories = Category::All();
        $tags = Tag::All();

        return view('posts.edit', compact('post', 'categories', 'tags'));
    }
}
