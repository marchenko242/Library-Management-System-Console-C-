using System;
using System.Collections.Generic;
using Models;
using Services;

class Program
{
    static void Main(string[] args)
    {

        StateService stateService = new StateService();

        List<Book> books = stateService.LoadBooks();
        List<Reader> listOfReaders = stateService.LoadReaders();
        List<Loan> loans = stateService.LoadLoans();

        BookService bookService = new BookService();

        ReaderService readerService = new ReaderService();

        LoanService loanService = new LoanService();

        



        Console.WriteLine("Welcome to the Library Management System!");

        while(true)
        {
            Console.WriteLine("Choose one option ( \n 1 - add book, \n 2 - Show all books, \n 3 - Add reader, \n 4 - Show all readers, \n 5 - Borrow book, \n 6 - Return book, \n 7 - Save & exit): ");

            string answerMenu = Console.ReadLine();

            switch (answerMenu)
            {
                case "1":
                    bookService.AddBook(books);
                    break;
                case "2":
                    bookService.ShowBooks(books);
                    break;
                case "3":
                    readerService.AddReader(listOfReaders);
                    break;
                case "4":
                    readerService.ShowAllReaders(listOfReaders);
                    break;
                case "5":
                    loanService.BorrowBook(listOfReaders, books, loans);
                    break;
                case "6":
                    loanService.ReturnBook(loans, books);
                    break;
                case "7":
                    stateService.Save(books, listOfReaders, loans);
                    Console.WriteLine("Date saved succesfully");
                    return;
            }
        }
    }

}