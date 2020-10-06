using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using DataAcces.Data;


using DataAccess.Models;

using Dto.ModelsDto;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppApi.Controllers.v1
{
    //[Route("api/[controller]")]
    //[ApiController]
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _applicatinDbContext;
        public BookController(ApplicationDbContext applicatinDbContext)
        {
            _applicatinDbContext = applicatinDbContext;
        }

        [HttpGet(template: ApiRoutes.Books.GetAll)]
        public async Task<IActionResult> GetAllListAsync()
        {
            var res = await _applicatinDbContext.Books.ToListAsync();
            return Ok(res);
        }

        [HttpPost(template: ApiRoutes.Books.Create)]
        public async Task<IActionResult> Create(Book book)
        {
            if (Guid.Empty.Equals(book.Id))
            {
                var res = _applicatinDbContext.Books.Add(book);
                if (res.State == EntityState.Added)
                {
                    await _applicatinDbContext.SaveChangesAsync();
                }
            }
            return CreatedAtAction(nameof(GetAllListAsync), new { id = book.Id }, book);
        }
        [HttpPut(template: ApiRoutes.Books.Update)]
        public async Task<IActionResult> PutBookAsync(Book book)
        {
            if (Guid.Empty.Equals(book.Id))
            {
                return BadRequest();
            }
            _applicatinDbContext.Entry(book).State = EntityState.Modified;
            try
            {

                _applicatinDbContext.Books.Update(book);
                await _applicatinDbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookItemExists(book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpGet(template: ApiRoutes.Books.Get)]
        public async Task<IActionResult> GetById(Guid id)
        {

            var res = await _applicatinDbContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }
        [HttpDelete(template: ApiRoutes.Books.Delete)]
        public async Task<ActionResult<Book>> DeleteAsync(Guid id)
        {
            var bookItem = await _applicatinDbContext.Books.FindAsync(id);
            if (bookItem == null)
            {
                return NotFound();
            }
            _applicatinDbContext.Books.Remove(bookItem);
            await _applicatinDbContext.SaveChangesAsync();
            return bookItem;
        }
        private bool BookItemExists(Guid id) =>
       _applicatinDbContext.Books.Any(e => e.Id == id);
    }
}
