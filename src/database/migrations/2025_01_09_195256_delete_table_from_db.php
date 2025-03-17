<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        // Schema::dropIfExists('posts');
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        // Schema::create('posts', function (Blueprint $table) {
        //     $table->id();

        //     $table->string('title'); // создаем пользовательскую колонку
        //     $table->text('content'); // создаем пользовательскую колонку с текстом
        //     $table->string('image_url')->nullable(); // вроде не может иметь null

        //     $table->unsignedBigInteger('likes'); // создаем пользовательскую колонку только числа

        //     $table->boolean('isPublished')->default(0); // создаем пользовательскую колонку булево, по умолча-нию -> false

        //     $table->timestamps(); // две колонки: когда внесли в таблицу, дата

        //     $table->softDeletes(); // для мягкого удаления

        // });
    }
};
