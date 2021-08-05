﻿using System;
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
    public class InvoiceItemsController : ControllerBase
    {
        private readonly GeniiPosDbContext _context;

        public InvoiceItemsController(GeniiPosDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceItem>>> GetInvoiceItem()
        {
            return await _context.InvoiceItem.ToListAsync();
        }

        // GET: api/InvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceItem>> GetInvoiceItem(int id)
        {
            var invoiceItem = await _context.InvoiceItem.FindAsync(id);

            if (invoiceItem == null)
            {
                return NotFound();
            }

            return invoiceItem;
        }

        // PUT: api/InvoiceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceItem(int id, InvoiceItem invoiceItem)
        {
            if (id != invoiceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceItemExists(id))
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

        // POST: api/InvoiceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceItem>> PostInvoiceItem(InvoiceItem invoiceItem)
        {
            _context.InvoiceItem.Add(invoiceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceItem", new { id = invoiceItem.Id }, invoiceItem);
        }

        // DELETE: api/InvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceItem(int id)
        {
            var invoiceItem = await _context.InvoiceItem.FindAsync(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            _context.InvoiceItem.Remove(invoiceItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceItemExists(int id)
        {
            return _context.InvoiceItem.Any(e => e.Id == id);
        }
    }
}
