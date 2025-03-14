<?php

class FormPageController extends Controller
{
    public function index()
    {
        $page = 'FormPage.php';

        include __DIR__ . "/../views/Main.php";
    }
}
