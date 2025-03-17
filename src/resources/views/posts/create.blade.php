@extends('layouts.main')
@section('content')
    <div class="container">
        <div class="row">
            <h1 class="create-title">Creating post</h1>
        </div>
        <div class="row">
            <div class="col">
                <form action="{{ route('post.store') }}" method="post">
                    @csrf
                    @method('post')
                    <div class="mb-3">
                        <label for="titleInput" class="form-label">Title</label>
                        <input name="title" type="text" class="form-control" id="titleInput" placeholder="Title"
                            value="{{ old('title') }}">

                        @error('title')
                            <p class="error text-danger" style="margin: 10px">{{ $message }}</p>
                        @enderror
                    </div>
                    <div class="mb-3">
                        <label for="titleInput" class="form-label">Content</label>
                        <textarea name="content" type="text" class="form-control" id="titleInput" placeholder="Content">{{ old('content') }}</textarea>

                        @error('content')
                            <p class="error text-danger" style="margin: 10px">{{ $message }}</p>
                        @enderror
                    </div>
                    <div class="mb-3">
                        <label for="titleInput" class="form-label">Likes</label>
                        <input name="likes" type="number" class="form-control" id="titleInput" placeholder="100"
                            value="{{ old('likes') }}">

                        @error('likes')
                            <p class="error text-danger" style="margin: 10px">{{ $message }}</p>
                        @enderror
                    </div>
                    <select required name="category_id" class="form-select" aria-label="Default select example"
                        style="margin-bottom:10px">

                        @foreach ($categories as $category)
                            {{ old('category_id') == $category->id ? 'selected' : '' }}
                            <option value="{{ $category->id }}">{{ $category->title }}</option>
                        @endforeach
                    </select>
                    <select name="tag_ids[]" class="form-select" size="3" multiple
                        aria-label="Multiple select example" style="margin-bottom:10px">
                        @foreach ($tags as $tag)
                            <option value="{{ $tag->id }}">{{ $tag->title }}</option>
                        @endforeach
                    </select>
                    <button type="submit" class="btn btn-dark">OK</button>
                </form>

            </div>
        </div>
    </div>
@endsection
