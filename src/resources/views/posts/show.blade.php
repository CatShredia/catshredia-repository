@extends('layouts.main')
@section('content')
    <div class="container">
        <div class="row">
            <h1 class="show-title">{{ $post->title }}</h1>
        </div>
        <div class="row">
            <p class="show-title">{{ $post->content }}</p>
            <p class="show-title">{{ $post->likes }} - likes</p>
            <h2 class="show-category">Category: <b>{{ $post->category->title }}</b></h2>
            <h4 class="show-title">Tags:</h4>

            <ul class="show-tags">
                @foreach ($post->tags as $tag)
                    <li class="show-tag">{{ $tag->title }}</li>
                @endforeach
            </ul>

            <a href="{{ route('post.edit', $post->id) }}" class="edit btn btn-dark" style="margin-bottom: 10px">Edit
                post</a>
            <form action="{{ route('post.delete', $post->id) }}" method="post">
                @csrf
                @method('delete')
                <button type="submit" class="delete btn btn-dark" style="margin-bottom: 10px">Delete</button>
            </form>
            <a href="{{ route('post.index') }}" class="show-back btn btn-dark">Back</a>
        </div>
    </div>
@endsection
