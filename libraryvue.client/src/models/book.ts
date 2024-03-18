class Book {
  Id: number;
  Author: string;
  Title: string;
  NumberOfPages: number;
  IsBorrowed: boolean;

  constructor(
    id: number,
    autor: string,
    title: string,
    numberOfPages: number,
    isborrowed: boolean,
  ) {
    this.Author = autor;
    this.Id = id;
    this.Title = title;
    this.IsBorrowed = isborrowed;
    this.NumberOfPages = numberOfPages;
  }
}

export async function GetBooks() {
  const response = await fetch("/books/GetAll");
  const names = await response.json();
  console.log(names);
}
