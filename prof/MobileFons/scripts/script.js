// TODO: redoned code for mobile fons
// find form, filters form

document.addEventListener("DOMContentLoaded", () => {
  console.log("DOM loaded!");

  const finderClass = new FinderClass(".cart-title", ".find-form");
  const costFilter = new FiltersClass(".cost", ".cost-input");
  const ramFilter = new FiltersClass(".ram", ".ram-input");
  const internalRamFilter = new FiltersClass(".internal", ".internal-input");
});

// TODO: for finder form
class FinderClass {
  constructor(classCartTitle, classFindForm) {
    this.cartTitle = document.querySelectorAll(classCartTitle);
    this.findForm = document.querySelector(classFindForm);

    // check to have a objects!
    if (this.cartTitle[0] == undefined || this.findForm == undefined) {
      console.log("Warning: objects don't init");
    }

    // simple js finder
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

// TODO: filters
class FiltersClass {
  constructor(classCosts, classForm) {
    console.log("----");
    console.log("New Filter Init!");

    this.costs = document.querySelectorAll(classCosts); // get costs
    this.costsForm = document.querySelectorAll(classForm); //forms of filters
    this.carts = document.querySelectorAll(".cart"); //carts

    this.classCosts = classCosts;

    this.min = 9999999;
    this.max = 0;

    this.userMin = 0;
    this.userMax = 0;

    // check to have a objects!
    if (this.costs[0] == undefined || this.costsForm[0] == undefined) {
      console.log("Warning: objects don't init");
    }

    this.setMinMax();
    this.clearFilterEvent();
    this.applyFilterEvent();

    console.log("Min: " + this.min + ". Max: " + this.max);
  }

  // set min max qualities to form
  setMinMax() {
    for (let i = 0; i < this.costs.length; i++) {
      // console.log(this.costs[i].textContent.split(" ")[0]);

      let trueCost = this.costs[i].textContent.split(" ")[0];

      trueCost = parseInt(trueCost);

      if (trueCost > this.max) {
        this.max = trueCost;
      }
      if (trueCost < this.min) {
        this.min = trueCost;
      }
    }

    // set
    this.costsForm[0].setAttribute(
      "placeholder",
      "От " + this.min + " " + this.costs[0].textContent.split(" ")[1]
    );
    this.costsForm[1].setAttribute(
      "placeholder",
      "До " + this.max + " " + this.costs[0].textContent.split(" ")[1]
    );
  }

  clearFilterEvent() {
    // clear filters
    this.clearButton = document.querySelector("#clear-button");
    this.clearButton.addEventListener("click", (ivent) => {
      console.log("Сброс фильтров");
      for (let i = 0; i < this.carts.length; i++) {
        this.carts[i].style.display = "grid";
      }

      // delete text on find form
      document.querySelector("#find-input").value = "";
    });
  }

  applyFilterEvent() {
    // apply filters
    this.filterButton = document.querySelector(".apply-button");
    this.filterButton.addEventListener("click", (ivent) => {
      this.userMin = this.costsForm[0].value;
      this.userMax = this.costsForm[1].value;

      // empty value
      if (this.userMin == "") {
        this.userMin = this.min;
      }
      if (this.userMax == "") {
        this.userMax = this.max;
      }

      // set right display
      for (let i = 0; i < this.costs.length; i++) {
        let cost = parseInt(this.costs[i].textContent.split(" ")[0]);

        console.log(cost);
        console.log(this.userMin);
        console.log(this.userMax);

        if (this.userMin > cost) {
          this.costs[i].parentElement.style.display = "none";
          console.log("Скрыт");
        } else if (this.userMax < cost) {
          this.costs[i].parentElement.style.display = "none";
          console.log("Скрыт");
        }
      }
    });
  }
}
