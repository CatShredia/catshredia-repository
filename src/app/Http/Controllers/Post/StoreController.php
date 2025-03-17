<?php

namespace App\Http\Controllers\Post;


use App\Http\Requests\Post\StoreRequest;
use Illuminate\Http\Request;

use App\Models\Post;


class StoreController extends BaseController
{
    // что-то типо конструтора
    public function __invoke(Post $post, StoreRequest $request)
    {
        $data = $request->validated();

        $this->service->store($data);

        // возвращаемся на страницу с постами через название роута
        return redirect()->route('post.index');
    }
}
