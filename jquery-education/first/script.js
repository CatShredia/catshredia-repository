console.log("Hi");

// ? nature JavaScript
// let elems = document.querySelectorAll("p");

// for (let i = 0; i < elems.length; i++) {
//   elems[i].innerHTML = "!!!";
//   elems[i].style.color = "red";
// }

// ? JQuery
// * selectors
let elem = $(".www");
elem.css("color", "red").html("!!!");

let text = $(".text").html();

console.log(text);

$(".www").css({ color: "black", font: "20px Arial" });

elem = $("h3 ~ textarea");
console.log(elem);
elem = $("h3 + textarea");
console.log(elem);

let inputsTexts = $("input[type='text']");
console.log(inputsTexts);

let newElem = $("h6").parent();
console.log(newElem);
