<?php

namespace App\Http\Controllers\Post;


use Illuminate\Http\Request;
use App\Models\Post;


class DeleteController extends BaseController
{
    // что-то типо конструтора
    public function __invoke(Post $post)
    {
        $post->delete();

        return redirect()->route('post.index');
    }
}
