using MLG_Task.Dtos.Book;
using MLG_Task.Dtos.ViewResult;
using MLG_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG_Task.Application.Services
{
    public interface IBookService 
    {
        Task<ResultDataList<BookDto>> GetAllPagination(int items, int pagenumber);
        Task<ICollection<BookDto>> GetAllCategories();
        Task<ResultView<BookDto>> GetBookByID(int Id);
        Task<ResultView<BookDto>> CreateBook(AddOrUpdateBookDto BookDto);
        Task<ResultView<BookDto>> UpdateBook(int Id, AddOrUpdateBookDto BookDto);
        Task<ResultView<BookDto>> SoftDelete(int Id);
        Task<ResultView<BookDto>> HardDelete(int Id);

    }
}
