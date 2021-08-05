using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeniiPosAPI.Data;
using GeniiPosAPI.Models;

namespace GeniiPosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceStatusController : ControllerBase
    {
        private readonly GeniiPosDbContext _context;

        public InvoiceStatusController(GeniiPosDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceStatus>>> GetInvoiceStatus()
        {
            return await _context.InvoiceStatus.ToListAsync();
        }

        // GET: api/InvoiceStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceStatus>> GetInvoiceStatus(int id)
        {
            var invoiceStatus = await _context.InvoiceStatus.FindAsync(id);

            if (invoiceStatus == null)
            {
                return NotFound();
            }

            return invoiceStatus;
        }

        // PUT: api/InvoiceStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceStatus(int id, InvoiceStatus invoiceStatus)
        {
            if (id != invoiceStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceStatusExists(id))
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

        // POST: api/InvoiceStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceStatus>> PostInvoiceStatus(InvoiceStatus invoiceStatus)
        {
            _context.InvoiceStatus.Add(invoiceStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceStatus", new { id = invoiceStatus.Id }, invoiceStatus);
        }

        // DELETE: api/InvoiceStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceStatus(int id)
        {
            var invoiceStatus = await _context.InvoiceStatus.FindAsync(id);
            if (invoiceStatus == null)
            {
                return NotFound();
            }

            _context.InvoiceStatus.Remove(invoiceStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceStatusExists(int id)
        {
            return _context.InvoiceStatus.Any(e => e.Id == id);
        }
    }
}
