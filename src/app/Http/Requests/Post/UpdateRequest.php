<?php

namespace App\Http\Requests\Post;

use Illuminate\Foundation\Http\FormRequest;

class UpdateRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            // это строчка нужна для проверки ключей, которые должны совпадать с name в форме и колонками в таблицы sql
            'title' => 'string',
            'content' => 'string',
            'likes' => 'integer',
            'category_id' => 'integer',
            'tag_ids' => 'required|array',
            'tag_ids.*' => 'integer'
        ];
    }
}
