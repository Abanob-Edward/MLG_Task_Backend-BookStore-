using AutoMapper;
using MLG_Task.Application.Contract;
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
    
    public class BookService : IBookService
    { 
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;  

        }
        public async Task<ICollection<BookDto>> GetAllCategories()
        {
            var BookList = (await _bookRepository.GetAllAsync());
            BookList.Where(c => c.IsDeleted == false);
            return _mapper.Map<List<BookDto>>(BookList);
        }
        public async Task<ResultDataList<BookDto>> GetAllPagination(int items, int pagenumber)
        {
            var AlldAta = (await _bookRepository.GetAllAsync());
            var books = AlldAta.Where(x => x.IsDeleted == false || x.IsDeleted == null);
            var pagingModel = books.Skip(items * (pagenumber - 1)).Take(items).ToList();
            var Model = _mapper.Map<List<Book>,List<BookDto>>(pagingModel);
            return new ResultDataList<BookDto>()
            {
                Count = Model.Count,
                Entities = Model
            };
        }
        public async Task<ResultView<BookDto>> GetBookByID(int Id)
        {
            var book = await _bookRepository.GetByIdAsync(Id);
            if (book == null)
            {
                return new ResultView<BookDto>()
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "not found"
                };
            }
            return new ResultView<BookDto>()
            {
                Entity = _mapper.Map<Book, BookDto>(book),
                IsSuccess = true,
                Message = "Get Book Successfully "
            };
        }
        public  async Task<ResultView<BookDto>> CreateBook(AddOrUpdateBookDto BookDto)
        {
            var Query = (await _bookRepository.GetAllAsync());
            var OldBook = Query.Where(c => c.Title == BookDto.Title ).FirstOrDefault();
            if (OldBook != null)
            {
                return new ResultView<BookDto> { Entity = null, IsSuccess = false, Message = "Already Exist" };
            }
            else
            {
                var book = _mapper.Map<Book>(BookDto);
                var Newbook = await _bookRepository.CreateAsync(book);
                await _bookRepository.SaveChangesAsync();
                var bookdto = _mapper.Map<BookDto>(Newbook);
                return new ResultView<BookDto> { Entity = bookdto, IsSuccess = true, Message = "Created Successfully" };
            }
        }
        public async Task<ResultView<BookDto>> UpdateBook(int Id ,AddOrUpdateBookDto BookDto)
        {
            try
            {
                var book = (await _bookRepository.GetByIdAsync(Id));
                
                if(book == null)
                {
                    return new ResultView<BookDto>
                    {
                        Entity = null,
                        IsSuccess = false,
                        Message = "the ID not found"
                    };
                }
                      
                book.IsDeleted = false;
                book.Title = BookDto.Title;
                book.Author = BookDto.Author;
                book.PublishedYear = BookDto.PublishedYear;
                book.Genre = BookDto.Genre;
                 await _bookRepository.SaveChangesAsync();
                var bokDto = _mapper.Map<AddOrUpdateBookDto, BookDto>(BookDto);
                return new ResultView<BookDto> { Entity = bokDto, IsSuccess = true, Message = "Updated Successfully" };
            }
            catch (Exception)
            {
                return new ResultView<BookDto> { Entity = null, IsSuccess = false, Message = "Can't updated" };
            }
        }
        public async Task<ResultView<BookDto>> HardDelete(int ID)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(ID);
                if (book == null)
                {
                    return new ResultView<BookDto>
                    {
                        Entity = null,
                        IsSuccess = false,
                        Message = "the ID not found"
                    };
                }
                await _bookRepository.DeleteAsync(book);
                await _bookRepository.SaveChangesAsync();
                var obj = _mapper.Map<BookDto>(book);
                return new ResultView<BookDto> { Entity = obj, IsSuccess = true, Message = "Updated Successfully" };
            }
            catch (Exception)
            {
                return new ResultView<BookDto> { Entity = null, IsSuccess = false, Message = "Can't updated" };
            }
        }
        public async Task<ResultView<BookDto>> SoftDelete(int ID)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(ID);
                if (book == null)
                {
                    return new ResultView<BookDto>()
                    {
                        Entity = null,
                        IsSuccess = false,
                        Message = "Not found Id"
                    };
                }
                book.IsDeleted = true;
                await _bookRepository.SaveChangesAsync();
                var cat = _mapper.Map<BookDto>(book);
                ResultView<BookDto> resultView = new ResultView<BookDto>()
                {
                    Entity = cat,
                    IsSuccess = true,
                    Message = "Deleted Successfully"
                };
                return resultView;
            }
            catch (Exception ex)
            {

                return new ResultView<BookDto> { Entity = null, IsSuccess = false, Message = ex.Message };
            }
        }

        
    }
}
