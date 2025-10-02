using AutoMapper;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming;
using The_Book_Circle._02.Business_Logic_Layer.Exceptions;
using The_Book_Circle.DTOs;
using The_Book_Circle.Errors;
using The_Book_Circle.Models;
using The_Book_Circle.Repositories.Interfaces;
using The_Book_Circle.Services.Interfaces;


namespace The_Book_Circle.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookManager = bookManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<BookDto>>> GetAllBooksAsync()
        {
            var books = await _bookManager.GetAllAsync();
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return ServiceResult<IEnumerable<BookDto>>
                .Success(bookDtos);
        }
        public async Task<ServiceResult<BookDto>> GetBookByIdAsync(int ID)
        {
            var book = await _bookManager.GetByIdAsync(ID)
                ?? throw new NotFoundException("Book not found.");

            var bookDto = _mapper.Map<BookDto>(book);

            return ServiceResult<BookDto>
                .Success(bookDto);
        }

        public async Task<ServiceResult<BookDto>> GetBookByISBN(string ISBN)
        {
            var book = await _bookManager.GetByISBNAsync(ISBN)
                ?? throw new NotFoundException("Book not found.");
            
            var bookDto = _mapper.Map<BookDto>(book);

            return ServiceResult<BookDto>
                .Success(bookDto);
        }

        public async Task<ServiceResult<BookDto>> CreateBookAsync(CreateBookDto createBookDto)
        {
            var existingBook = await _bookManager.GetByISBNAsync(createBookDto.ISBN);
            if (existingBook != null)
                throw new ConflictException("Book with same ISBN already exists.");

            var book = _mapper.Map<Book>(createBookDto);

            book.Author= await _unitOfWork.Authors.GetByIdAsync(createBookDto.AuthorID)
                ?? throw new NotFoundException("Incorrect Author ID.");

            book.Publisher = await _unitOfWork.Publishers.GetByIdAsync(createBookDto.PublisherID)
                ?? throw new NotFoundException("Incorrect Publisher ID.");

            foreach (var genreId in createBookDto.GenresIDs)
            {
                var genre = await _unitOfWork.Genres.GetByIdAsync(genreId)
                    ?? throw new NotFoundException($"Incorrect Genre ID: {genreId}.");
                book.Genres.Add(genre);
            }

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.Books.CreateAsync(book);
                await _unitOfWork.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            return ServiceResult<BookDto>
                .Success(
                    _mapper.Map<BookDto>(
                       _unitOfWork.Books.GetByISBNAsync(book.ISBN) 
                    )
                );
            


        }

        public async Task<ServiceResult<IEnumerable<BookDto>>> SearchBooksAsync(string query)
        {
            var books = await _bookManager.SearchAsync(query);

            if (!books.Any())
                throw new NotFoundException("No books found matching the search criteria.");
            
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return ServiceResult<IEnumerable<BookDto>>
                .Success(bookDtos);
        }

       
    }

}
