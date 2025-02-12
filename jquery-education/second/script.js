let texts = $(".main-text li");
let count = 1;

texts.each(function () {
  $(this).text(`number-${count}`);
  count++;
});
