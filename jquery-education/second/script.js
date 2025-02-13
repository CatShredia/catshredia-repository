//
let texts = $(".main-text li");
let count = 1;

texts.each(function () {
  $(this).text(`number-${count}`);
  count++;
});

console.log(texts);

texts = $(".main-text li")
  .map(function () {
    return this.id;
  })
  .get()
  .join();

console.log(texts);

console.log($("p"));
console.log(
  $("p")
    .map(function () {
      return this;
    })
    .get()
    .join(", ")
);

console.log(
  $("p")
    .map(function () {
      return this.id;
    })
    .get()
    .join()
);
