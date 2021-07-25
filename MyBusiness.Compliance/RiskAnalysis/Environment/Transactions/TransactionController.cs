using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MyBusiness.Compliance.RiskAnalysis.Environment.Transactions
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController: ControllerBase
    {

        private readonly TransactionBroker _broker;

        public TransactionController(TransactionHolder holder)
        {
            _broker = holder.Broker;
        }

        [HttpGet("approved")]
        [ProducesResponseType(200)]
        [ProducesDefaultResponseType(typeof(Transaction[]))]
        public IActionResult GetApproved()
        {
            return Ok(_broker.ApprovedTransactions.ToList());
        }
        
        [HttpGet("forbidden")]
        [ProducesResponseType(200)]
        [ProducesDefaultResponseType(typeof(Transaction[]))]
        public IActionResult GetForbidden()
        {
            return Ok(_broker.ForbiddenTransactions.ToList());
        }      
        
        [HttpGet("report")]
        [ProducesResponseType(200)]
        public IActionResult GetReport()
        {
            return Ok(new
            {
                Approved = _broker.ApprovedTransactions.Count,
                Forbidden = _broker.ForbiddenTransactions.Count
            });
        }          
    }
}