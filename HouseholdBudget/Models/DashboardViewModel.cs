using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseholdBudget.Models
{
    public class DashboardViewModel
    {
        public int HouseholdId { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public Budget CurrentBudget { get; set; }
        public ICollection<BudgetItems> BudgetItemsList { get; set; }
        public List<Transaction> Transactions { get; set; }
    }

}