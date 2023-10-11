using Application.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[Controller]")]
    public class LibraryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetBooksByAuthor(string authorId)
        {
            return HandleResult(await Mediator.Send(new GetBooksByAuthor.Query { AuthorId = authorId }));
        }

        [HttpGet("GetAllCheckedOutBooks")]
        public async Task<IActionResult> GetAllCheckedOutBooks()
        {
            return HandleResult(await Mediator.Send(new GetAllCheckedOutBooks.Query { }));
        }

        [HttpPut("{isbn}")]
        public async Task<IActionResult> EditOrderPackage(string isbn)
        {
            return HandleResult(await Mediator.Send(new CheckOutBookAsync.Command { Isbn = isbn }));
        }
    }
}