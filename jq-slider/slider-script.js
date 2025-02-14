function CreatingSlider() {
  console.log("Creating a new slider");
  // кол-во слайдов на странице - countSlideOnPage
  //   установка свойств
  sliders = $(".slider-obj");
  $(".slider__inner").css(
    "grid-template-columns",
    "1fr ".repeat(countSlideOnPage).trim()
  );
  displaySlides();
}

let sliders;
let displaySlidesArray = [0, 2]; // Начальные индексы для отображения слайдов
let countSlideOnPage = 3; // Количество слайдов на странице
let totalSlides = $(".slider-obj").length; // Общее количество слайдов

CreatingSlider();

// событие на левую кнопку
$("#arr-left").click(function (e) {
  e.preventDefault();
  if (displaySlidesArray[0] > 0) {
    displaySlidesArray[0]--;
    displaySlidesArray[1]--;
    displaySlides();
  }
});

// событие на правую кнопку
$("#arr-right").click(function (e) {
  e.preventDefault();
  if (displaySlidesArray[1] < totalSlides - 1) {
    displaySlidesArray[0]++;
    displaySlidesArray[1]++;
    displaySlides();
  }
});

function displaySlides() {
  console.log(displaySlidesArray);
  clearSliders();
  for (let i = displaySlidesArray[0]; i <= displaySlidesArray[1]; i++) {
    $(sliders[i]).css("display", "flex");
  }
}

function clearSliders() {
  sliders.css("display", "none");
}