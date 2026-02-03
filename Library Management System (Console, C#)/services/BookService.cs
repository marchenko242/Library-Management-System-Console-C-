using System;
using System.Collections.Generic;
using System.Text;
using Models;


namespace Services
{
    public class BookService
    {
        public void AddBook(List<Book> books)
        {
            while (true)
            {
                Console.WriteLine("Enter the title of book (or 'exit' to stop): ");
                string title = Console.ReadLine();


                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("title cannot be empty.");
                    continue;
                }

                title = title.ToLower();

                if (title == "exit" || title == "stop")
                {
                    return;
                }

                Console.WriteLine("Enter the author of book: ");
                string enterAuthorOfBook = Console.ReadLine();

                foreach(Book book in books)
                {
                    if(book.Title == title && book.Author == enterAuthorOfBook)
                    {
                        Console.WriteLine("This book already exists.");
                        return;
                    }
                }

                int newId = IdGenerator.GenerateBookId(books);

                Book newBook = new Book();
                newBook.Id = newId;
                newBook.Title = title;
                newBook.Author = enterAuthorOfBook;
                newBook.IsAvailable = true;

                books.Add(newBook);

                Console.WriteLine("Book added.");
            }
        }

        public void ShowBooks(List<Book> books)
        {
            if(books.Count == 0)
            {
                Console.WriteLine("No books.");
                return;
            }

            foreach(var book in books)
            {
                Console.WriteLine($"[{book.Id}] {book.Title} - {book.Author} (Available: {book.IsAvailable}).");
            }
        }
    }
}
