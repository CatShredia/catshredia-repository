<?php
require __DIR__ . '/Controller.php';

class FormPageController extends Controller
{
    public function index()
    {
        require __DIR__ . "/../views/FormPage.php";
    }
}
