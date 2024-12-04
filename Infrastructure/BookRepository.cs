using MLG_Task.Application.Contract;
using MLG_Task.Context;
using MLG_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG_Task.Infrastructure
{
    public class BookRepository : Repository<Book, int> , IBookRepository
    {


        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }
        public async Task<Book> SearchByTitleAsync(string txt)
        {
            var book =  _context.Book.FirstOrDefault(t => t.Title.ToLower() == txt.ToLower() );
            return book;
        }

       
    }
}
