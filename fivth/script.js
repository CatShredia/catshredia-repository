// let button = $(".button");

// let count = 0;
// button.click(function (e) {
//   e.preventDefault();

//   if (count == 0) {
//     button.css("background-color", "red");

//     count++;
//   } else if (count == 1) {
//     button.css("background-color", "gray");

//     count--;
//   }
// });

let button = $(".button");

let count = 0;
button.click(function (e) {
  e.preventDefault();

  button.toggleClass("red");

  if (button.hasClass("red")) {
    console.log("Red!!!");
  }
});

button.wrap("<div></div>");
button.parent().addClass("newDiv");

button.unwrap("div");

let p = $("p");

p.wrapInner("<b></b>");

button.prepend("<b>THE</b>");
