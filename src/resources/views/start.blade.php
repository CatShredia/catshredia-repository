@extends('layouts.main')
@section('content')
    <div class="container">
        <div class="row">
            <div>
                <p class="about-text">Добро Пожаловать!</p>
                {{-- {{ Auth::user()->name }} --}}
            </div>
        </div>
    </div>
@endsection
