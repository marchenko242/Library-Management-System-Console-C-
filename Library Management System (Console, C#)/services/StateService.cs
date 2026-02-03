using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using Models;

namespace Services
{
    public class StateService
    {
        private const string DataFolder = "Data";
        private const string BooksFile = "Data/books.json";
        private const string LoansFile = "Data/loans.json";
        private const string ReadersFile = "Data/readers.json";


        public void Save(List<Book> books, List<Reader> readers, List<Loan> loans)
        {
            if(!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }

            File.WriteAllText(BooksFile, JsonSerializer.Serialize(books));
            File.WriteAllText(ReadersFile, JsonSerializer.Serialize(readers));
            File.WriteAllText(LoansFile, JsonSerializer.Serialize(loans));

        }
        public List<Book> LoadBooks()
        {
            if (!File.Exists(BooksFile))
            {
                return new List<Book>();
            }

            return JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(BooksFile));
        }

        public List<Reader> LoadReaders()
        {
            if (!File.Exists(ReadersFile))
            {
                return new List<Reader>();
            }

            return JsonSerializer.Deserialize<List<Reader>>(File.ReadAllText(ReadersFile));
        }
        public List<Loan> LoadLoans()
        {
            if (!File.Exists(LoansFile))
            {
                return new List<Loan>();
            }

            return JsonSerializer.Deserialize<List<Loan>>(File.ReadAllText(LoansFile));
        }

    }
}
