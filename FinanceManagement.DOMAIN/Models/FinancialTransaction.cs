using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.DOMAIN.Models
{
    public class FinancialTransaction
    {
        public int FinancialTransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
