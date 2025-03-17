<?php

namespace App\Http\Filters;

use Illuminate\Database\Eloquent\Builder;

abstract class AbstractFilter implements InterfaceFilter
{
    /**
     * Summary of queryParams
     * @var array
     */
    // параметры, передаваемые в конструктор
    private $queryParams = [];

    /**
     * AbstractFilter contsructor
     *
     * @param array $queryParams;
     */

    public function __construct(array $queryParams)
    {
        $this->queryParams = $queryParams;
    }

    // возвращает обратные вызовы
    abstract protected function getCallbacks(): array;

    public function apply(Builder $builder)
    {
        $this->before($builder);

        // получаем обратные вызовы и обрабатываем их
        foreach ($this->getCallbacks() as $name => $callback) {
            // проверяем, есть ли в параметрах обратный вызов по имени
            if (isset($this->queryParams[$name])) {
                // зарезервированная функция php, которая берет запрос, php объект билдера и значения параметров
                call_user_func($callback, $builder, $this->queryParams[$name]);
            }
        }
    }

    /**
     * @param Builder $builder
     */
    public function before(Builder $builder)
    {

    }
    /**
     * @param string $key
     * @param mixed|null $default
     *
     * @return mixed|null
     */
    protected function getQueryParam(string $key, $default = null)
    {
        return $this->queryParams[$key] ?? $default;
    }

    /**
     * @param string[] $keys
     *
     * @return AbstractFilter
     */
    protected function removeQueryParam(string ...$keys)
    {
        foreach ($keys as $key) {
            unset($this->queryParams[$key]);
        }

        return $this;
    }
}