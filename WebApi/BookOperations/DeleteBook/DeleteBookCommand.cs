using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOpreations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public readonly BookStoreDBContext _dbContext;

        public DeleteBookCommand(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == id);
            if(book is null)
            {
                throw new InvalidOperationException("Silinecek kitap bulunamadı.");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }
}