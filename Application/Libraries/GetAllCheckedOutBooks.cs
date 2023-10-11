using Application.Core;
using Application.Library.Interfaces;
using Domain;
using MediatR;

namespace Application.Library
{
    public class GetAllCheckedOutBooks
    {
        public class Query : IRequest<Result<List<Book>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<Book>>>
        {
            private readonly ILibraryService _libraryService;
            public Handler(ILibraryService libraryService)
            {
                _libraryService = libraryService;
            }

            public async Task<Result<List<Book>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var books = await _libraryService.GetAllCheckedOutBooks();

                return Result<List<Book>>.Success(books);
            }
        }
    }
}