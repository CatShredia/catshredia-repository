<?php

namespace App\Http\Controllers\Post;

use Illuminate\Http\Request;

use App\Models\Category;
use App\Models\Tag;


class CreateController extends BaseController
{
    // что-то типо конструтора
    public function __invoke()
    {
        $categories = Category::All();
        $tags = Tag::All();

        return view('posts.create', compact('categories', 'tags'));
    }
}
