$("img").each(function () {
  var srcValue = $(this).attr("src");
  var altValue = $(this).attr("alt");

  console.log("Source: " + srcValue + ", Alt: " + altValue);
});

$("img").attr({ src: "rec/2.png", alt: "Бен Бен" });

$("img").removeAttr("alt");

let inputs = $("input");

console.log(inputs);

$("#input1").prop("disabled", true);
$("#input3").prop("disabled", true);

let input = $("#number1");
input.text("New Text");

input.addClass("newClass");
input.removeClass("newClass");
