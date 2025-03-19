@extends('layouts.main')
@section('content')
    <form action="{{ route('') }}" method="POST">
        @csrf
        <label for="text">Title:</label>
        <input type="text" name="title" id="title">

        <button type="submit">Button</button>
    </form>
@endsection