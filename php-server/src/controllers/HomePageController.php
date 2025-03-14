<?php
require __DIR__ . '/Controller.php';

class HomePageController extends Controller
{
    public function index()
    {
        require __DIR__ . "/../views/HomePage.php";
    }
}
