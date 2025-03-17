@extends('layouts.main')
@section('content')
    <div class="container">
        <div class="row">
            <div class="col">
                @foreach ($posts as $post)
                    <a href="{{ route('post.show', $post->id) }}" class="post-link">
                        <div class="post-title btn">{{ $post->title }}
                        </div>
                    </a>
                    <br>
                @endforeach
            </div>
            <div class="col" style="display: flex; flex-direction: column; gap: 15px;">
                <a class="create_post_button" href="{{ route('create.create') }}">Создать пост</a>
                <div class="pagination">
                    {{ $posts->links() }}
                </div>
            </div>
        </div>
    </div>
@endsection
