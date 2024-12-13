document.addEventListener("DOMContentLoaded", () => {
  console.log("DOMContentLoaded");

  let filtersClass = new FiltersClass(true);
});

class FiltersClass {
  constructor(isDevMode) {
    this.carts = document.querySelectorAll(".cart"); //товары
    this.forms = document.forms; //формы
    this.costs = document.querySelectorAll(".cost"); //цены

    if (isDevMode) {
      console.log("----");
      console.log(this.carts);
      console.log(this.costs);
      console.log("----");
    }
    this.findMinMax();

    this.filterIvent1();
  }
  filterIvent1() {
    let filter = document.querySelector("#fiter-rand-1");

    filter.setAttribute("min", this.min + "");
    filter.setAttribute("max", this.max + "");

    filter.addEventListener("input", (event) => {
      filter.parentElement.children[2].textContent = event.target.value;
    });
  }
  findMinMax() {
    let array = [];

    Array.from(this.costs).forEach((elem) => {
      //   console.log(elem.innerHTML.split(" ")[0]);
      array.push(elem.innerHTML.split(" ")[0]);
    });
    array = array.sort();
    this.min = array[0];
    this.max = array[array.length - 1];

    console.log(this.min, this.max);
  }
}
