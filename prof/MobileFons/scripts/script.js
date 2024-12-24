// TODO: redoned code for mobile fons
// find form, filters form

document.addEventListener("DOMContentLoaded", () => {
  console.log("DOM loaded!");

  const finderClass = new FinderClass(".cart-title", ".find-form");
  const costFilter = new FiltersClass(".cost", ".cost-input");
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
  constructor(classCosts, classForms) {
    this.costs = document.querySelectorAll(classCosts); // берем цены

    console.log(this.costs);

    for (let i = 0; i < this.costs.length; i++) {
      console.log(this.costs[i]);
      this.costs[i] = this.costs[i];
    }

    this.devMode = true;

    if (this.devMode) {
      console.log("Dev Mode: ");
      console.log(this.costs);
    }

    this.setCostsToFilters(classForms);
  }
  setCostsToFilters(classForms) {
    this.filterMin = document.querySelectorAll(classForms)[0];
    this.filterMax = document.querySelectorAll(classForms)[1];
    // this.filterMax = document.querySelector("#cost-min");

    if (this.devMode) {
      console.log(this.filterMin);
      console.log(this.filterMax);
    }
  }
}
