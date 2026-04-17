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

        [HttpGet]
        public IActionResult GetTransactions()
        {
            return Ok(_context.Transactions.ToList());
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            if (transaction == null)
                return BadRequest();

            var lastTransaction = _context.Transactions
                .OrderByDescending(t => t.Id)
                .FirstOrDefault();

            double lastBalance = 0;

            if (lastTransaction != null)
            {
                lastBalance = Convert.ToDouble(
                    lastTransaction.Balance.Replace("$", "").Replace(",", "")
                );
            }

            double newBalance = transaction.Type == 0
                ? lastBalance + transaction.Amount
                : lastBalance - transaction.Amount;

            transaction.Balance = "$" + newBalance.ToString("N2");

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return Ok(transaction);
        }
    }
}