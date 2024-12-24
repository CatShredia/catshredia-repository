// dom loaded
document.addEventListener("DOMContentLoaded", () => {
  console.log("DOMContentLoaded");

  let finderClass = new FinderClass();
  let filtersClass = new FiltersClass();
  let ramClass = new RamClass();
});

class FiltersClass {
  constructor() {
    this.costs = document.querySelectorAll(".cost"); //all costs of phones
    this.forms = document.forms; //all forms

    console.log("filters:");
    console.log("----");
    console.log(this.costs);
    console.log(this.forms);
    console.log("----");

    this.findMinMax(); //find default costs from html document
    this.setMinMax(); //set costs to inputs placeholders

    this.applyIvent(); //add apply ivent to button
  }
  findMinMax() {
    let array = [];

    let index = 0;
    Array.from(this.costs).forEach((cost) => {
      array[index] = cost.textContent;
      index += 1;
    });

    array.sort();

    console.log(array);

    this.min = "От " + array[0];
    this.max = "До " + array[array.length - 1];
  }
  setMinMax() {
    let minInput = this.forms[1].querySelector("#cost-min");
    let maxInput = this.forms[1].querySelector("#cost-max");

    minInput.setAttribute("placeholder", this.min);
    maxInput.setAttribute("placeholder", this.max);
  }
  applyIvent() {
    this.forms[1]
      .querySelector(".apply-button")
      .addEventListener("click", (ivent) => {
        //timer to apply
        setTimeout(
          this.updateProduct,
          500,
          this.forms[1],
          this.costs,
          this.min,
          this.max
        );
      });
  }
  updateProduct(form, costs, min, max) {
    // console.log(form);
    let userMin = form.querySelector("#cost-min").value;
    let userMax = form.querySelector("#cost-max").value;

    if (userMin == "") {
      userMin = min.split(" ")[1];
    }
    if (userMax == "") {
      userMax = max.split(" ")[1];
    }

    Array.from(costs).forEach((elem) => {
      // console.log(parseInt(elem.textContent.split(" ")[0]));
      // console.log(parseInt(userMin));
      if (
        parseInt(elem.textContent.split(" ")[0]) >= parseInt(userMin) &&
        parseInt(elem.textContent.split(" ")[0]) <= parseInt(userMax)
      ) {
        elem.parentElement.style.display = "grid";
      } else {
        elem.parentElement.style.display = "none";
      }
    });
  }
}
class FinderClass {
  constructor() {
    this.cartTitle = document.querySelectorAll(".cart-title");
    this.findForm = document.querySelector(".find-form");

    console.log("find:");
    console.log("----");
    console.log(this.cartTitle);
    console.log(this.findForm);
    console.log("----");

    this.findForm.addEventListener("keyup", (ivent) => {
      let value = ivent.target.value.toLowerCase();

      Array.from(this.cartTitle).forEach((title) => {
        title.parentElement.style.display = "none";
        if (title.innerHTML.toLowerCase().indexOf(value) != -1) {
          title.parentElement.style.display = "grid";
        }
      });
    });
  }
}
class RamClass {
  constructor() {
    this.costs = document.querySelectorAll(".ram"); //all costs of phones
    this.forms = document.forms; //all forms

    console.log("filters:");
    console.log("----");
    console.log(this.costs);
    console.log(this.forms);
    console.log("----");

    this.findMinMax(); //find default costs from html document
    this.setMinMax(); //set costs to inputs placeholders

    this.applyIvent(); //add apply ivent to button
  }
  findMinMax() {
    let array = [];

    let index = 0;
    Array.from(this.costs).forEach((cost) => {
      array[index] = parseInt(cost.textContent.split(" ")[0]);
      index += 1;
    });

    array.sort();

    this.min = 50000000;
    this.max = 0;
    array.forEach((elem) => {
      console.log(elem + " s");
      if (this.min > elem) {
        this.min = elem;
      }
      if (this.max < elem) {
        this.max = elem;
      }
    });

    console.log(array);
    console.log(this.min + " " + this.max);
  }
  setMinMax() {
    let minInput = this.forms[1].querySelector("#ram-min");
    let maxInput = this.forms[1].querySelector("#ram-max");

    minInput.setAttribute("placeholder", this.min);
    maxInput.setAttribute("placeholder", this.max);
  }
  applyIvent() {
    this.forms[1]
      .querySelector(".apply-button")
      .addEventListener("click", (ivent) => {
        //timer to apply
        setTimeout(
          this.updateProduct,
          500,
          this.forms[1],
          this.costs,
          this.min,
          this.max
        );
      });
  }
  updateProduct(form, costs, min, max) {
    // console.log(form);
    let userMin = form.querySelector("#ram-min").value;
    let userMax = form.querySelector("#ram-max").value;

    if (userMin == "") {
      userMin = min;
    }
    if (userMax == "") {
      userMax = max;
    }

    Array.from(costs).forEach((elem) => {
      // console.log(parseInt(elem.textContent.split(" ")[0]));
      // console.log(parseInt(userMin));
      if (
        parseInt(elem.textContent.split(" ")[0]) >= parseInt(userMin) &&
        parseInt(elem.textContent.split(" ")[0]) <= parseInt(userMax)
      ) {
        elem.parentElement.style.display = "grid";
      } else {
        elem.parentElement.style.display = "none";
      }
    });
  }
}
