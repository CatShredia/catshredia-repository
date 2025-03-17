<?php

namespace App\Http\Controllers\Post;


use Illuminate\Http\Request;
use App\Models\Post;


class ShowController extends BaseController
{
    // что-то типо конструтора
    public function __invoke(Post $post)
    {
        return view('posts.show', compact('post'));
    }
}
