// TODO: redoned code for mobile fons
// find form, filters form

document.addEventListener("DOMContentLoaded", () => {
  console.log("DOM loaded!");

  const finderClass = new FinderClass(".cart-title", ".find-form");
  const filterClass = new FiltersClass(".cost");
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
  constructor(classCosts) {
    this.cost = document.querySelectorAll(classCosts);

    this.devMode = true;

    if (this.devMode) {
      console.log(this.cost);
    }
  }
}
