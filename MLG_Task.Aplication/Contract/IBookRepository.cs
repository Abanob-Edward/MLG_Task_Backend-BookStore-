using MLG_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace MLG_Task.Application.Contract
{
//    `GET /api/books` - Retrieve a list of all books.
//    - `GET /api/books/{ id}` - Retrieve a specific book by ID.
//    - `POST /api/books` - Add a new book.
//    - `PUT /api/books/{id
//}` -Update an existing book.
//    - `DELETE /api/books/{id}` -Delete a book by ID.

    public interface IBookRepository : IRepository<Book,int>
    {
        Task<Book> SearchByTitleAsync(string txt);

    }
}
