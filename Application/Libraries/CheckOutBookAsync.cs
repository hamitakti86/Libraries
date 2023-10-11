using Application.Core;
using MediatR;
using Application.Library.Interfaces;

namespace Application.Library
{
    public class CheckOutBookAsync
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Isbn { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly ILibraryService _libraryService;
            public Handler(ILibraryService libraryService)
            {
                _libraryService = libraryService;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _libraryService.CheckOutBookAsync(request.Isbn);
            }
        }
    }
}