class BookoramaClass {
  constructor() {
    this.forms = document.forms; //forms
    this.bookList = document.querySelector("#book-list"); //book-list
    this.defaultBookListElem =
      this.bookList.children[1].children[0].cloneNode(true); //don't delete element

    this.devMode = true; //dev mode

    if (this.devMode) {
      console.log("-----");
      console.log("dev mode enabled");
      console.log(this.forms);
      console.log(this.bookList);
      console.log(this.defaultBookListElem);
      console.log("-----");
    }

    this.deleteEvents();
    this.hideEvents();
    this.findEvents();
    this.addedEvents();
  }

  deleteEvents() {
    //delete event
    this.bookList.addEventListener("click", (event) => {
      let elem = event.target;
      console.log(elem.className);
      if (elem.className == "delete") {
        console.log(
          elem.parentElement.parentElement.removeChild(elem.parentElement)
        );
      }
    });
  }
  hideEvents() {
    //hide event
    this.forms[2].addEventListener("change", (event) => {
      let elem = event.target;
      console.log(elem);

      if (elem.checked) {
        this.bookList.style.display = "none";
      } else {
        this.bookList.style.display = "block";
      }
    });
  }
  findEvents() {
    //find event
    this.forms[0].addEventListener("keyup", (event) => {
      let elem = event.target;

      let value = elem.value;

      let names = document.querySelectorAll(".name");

      Array.from(names).forEach((name) => {
        name.parentElement.style.display = "none";
        if (name.innerHTML.toLowerCase().indexOf(value.toLowerCase()) != -1) {
          name.parentElement.style.display = "block";
        }
      });
    });
  }
  addedEvents() {
    // added event
    this.forms[1].addEventListener("submit", (event) => {
      event.preventDefault();

      let elem = event.target;

      let value = elem.children[0].value;

      console.log(value);

      let addBook = this.defaultBookListElem.cloneNode(true);
      console.log(addBook.children[0]);
      console.log(addBook);
      addBook.children[0].innerHTML = value;
      this.bookList.children[1].appendChild(addBook);
    });
  }
}

document.addEventListener("DOMContentLoaded", () => {
  let bookoramaClass = new BookoramaClass();
});
