using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class IdGenerator
    {

        public static int GenerateBookId(List<Book> books)
        {
            int maxId = 0;

            foreach (Book book in books)
            {
                if (book.Id > maxId)
                {
                    maxId = book.Id;
                }
            }


            return maxId + 1;
        }
        public static int GenerateReaderId(List<Reader> readers)
        {
            int maxId = 0;

            foreach (Reader reader in readers)
            {
                if (reader.Id > maxId)
                {
                    maxId = reader.Id;
                }
            }

            return maxId + 1;

        }

    }
}
