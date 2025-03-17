<?php

namespace App\Http\Filters;

use Illuminate\Database\Eloquent\Builder;

class PostFilter extends AbstractFilter
{
    public const TITLE = 'title';
    public const LIKES = 'likes';
    public const ISPUBLISHED = 'isPublished';
    public const CATEGORYID = 'category_id';

    protected function getCallbacks(): array
    {
        return [
            self::TITLE => [$this,'title'],
            self::CATEGORYID => [$this,'categoryId']
        ];
    }

    // ? title запрос
    public function title(Builder $builder, $value)
    {
        $builder->where('title', 'like', "%{$value}%");
    }

    // // ? likes запрос
    // public function likes(Builder $builder, $value)
    // {
    //     $builder->where('likes','like',"%{$value}%");
    // }

    // ? category_id запрос
    public function categoryId(Builder $builder, $value)
    {
        $builder->where('category_id', $value);
    }
}