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
        Schema::create('post_tags', function (Blueprint $table) {
            $table->id();

            // создаем колонку в таблице для id категории (с ней бцдет происходит основная работа)
            $table->unsignedBigInteger('post_id')->default(0);
            $table->unsignedBigInteger('tag_id')->default(0);

            // создаем индекс, по которому происходит связывание таблиц
            $table->index('post_id', 'post_tag_post_index');
            $table->index('tag_id', 'post_tag_tag_index');

            // создаем "чужой" индекс для таблиц (сама связь происходит через него)
            // колонка, где сохраняем id,
            // название foreign ключа
            // таблица, которую нужно связать
            // колонка в другой таблицы, для связи
            $table->foreign('post_id', 'post_tag_post_fk')->on('posts')->references('id');
            $table->foreign('tag_id', 'post_tag_tag_fk')->on('tags')->references('id');


            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('post_tags');
    }
};
