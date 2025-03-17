<?php

namespace App\Models;

use App\Models\Traits\Filterable;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Post extends Model
{
    // для того, чтобы можно было использовать фабрику
    use HasFactory;
    // для того, чтобы была мягкая очистка
    use SoftDeletes;
    // появляется метод filter из filterable - scopeFilter
    use Filterable;

    protected $table = 'posts';
    // для того, чтобы свободно добавлять элементы
    protected $guarded = [];
    // для того, чтобы свободно добавлять элементы, указанные в атрибуте
    // protected $fullable = [];

    // one to one
    public function category()
    {
        return $this->belongsTo(Category::class, 'category_id', 'id');
    }

    public function tags()
    {
        return $this->belongsToMany(Tag::class, 'post_tags', 'post_id', 'tag_id');
    }
}