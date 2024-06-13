using FinanceManagement.DATA.Data;
using FinanceManagement.DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialTransactionController : Controller
    {
        private readonly FinanceDbContext _context;
        public FinancialTransactionController(FinanceDbContext context)
        {
            _context = context;          
        }

        // GET: api/FinancialTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialTransaction>>> GetFinancialTransactions()
        {
            return await _context.FinancialTransactions.ToListAsync();
        }

        // GET: api/FinancialTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialTransaction>> GetFinancialTransaction(int id)
        {
            var transaction = await _context.FinancialTransactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // POST: api/FinancialTransactions
        [HttpPost]
        public async Task<ActionResult<FinancialTransaction>> PostFinancialTransaction(FinancialTransaction transaction)
        {
            _context.FinancialTransactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFinancialTransaction), new { id = transaction.FinancialTransactionId }, transaction);
        }

    }
}
