using Microsoft.AspNetCore.Mvc;
using HackerBankAPI.Data;
using HackerBankAPI.Models;

namespace HackerBankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET ALL TRANSACTIONS
        [HttpGet]
        public IActionResult GetTransactions()
        {
            var data = _context.Transactions.ToList();
            return Ok(data);
        }

        // ✅ GET BY DATE (optional backend filtering)
        [HttpGet("by-date")]
        public IActionResult GetByDate([FromQuery] DateTime date)
        {
            var data = _context.Transactions
                .Where(t => t.Date.Date == date.Date)
                .ToList();

            return Ok(data);
        }

        // ✅ ADD TRANSACTION (optional)
        [HttpPost]
        public IActionResult AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return Ok(transaction);
        }
    }
}