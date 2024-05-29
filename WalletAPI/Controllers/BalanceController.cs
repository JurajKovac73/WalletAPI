using Microsoft.AspNetCore.Mvc;
using WalletAPI.Models;
using WalletAPI.Services.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        // GET: api/<BalanceController>
        [HttpGet("getTransactionHistory")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("getBalance")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("sendTransaction")]
        public async Task<IActionResult> SendTransaction([FromBody] BalanceTransaction balanceTransaction)
        {
            if (balanceTransaction == null)
            {
                return BadRequest();
            }

            BalanceTransactionResult result = await _transactionService.ExecuteTransaction(balanceTransaction);
            
            if (result.Accepted)
            {
                return Ok(result.ResultMessage);
            }

            return BadRequest(result.ResultMessage);
        }

    }
}
