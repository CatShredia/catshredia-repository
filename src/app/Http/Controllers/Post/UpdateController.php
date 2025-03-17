<?php

namespace App\Http\Controllers\Post;

use App\Http\Requests\Post\UpdateRequest;
use Illuminate\Http\Request;

use App\Models\Post;


class UpdateController extends BaseController
{
    // что-то типо конструтора
    public function __invoke(Post $post, UpdateRequest $request)
    {
        $data = $request->validated();

        $this->service->update($data, $post);

        return redirect()->route('post.show', $post);
    }
}
