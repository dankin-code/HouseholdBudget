using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseholdBudget.Models;

namespace HouseholdBudget.Models
{
    public class DashboardModel
    {
        public int Id { get; set; }
        public IEnumerable<Household> households { get; set; }
        public IEnumerable<Account> accounts { get; set; }
        public IEnumerable<BudgetItems> budgetItems { get; set; }
        public IEnumerable<Budget> budgets { get; set; }
        public IEnumerable<Invitation> invitations { get; set; }
        public IEnumerable<Transaction> transactions { get; set; }
  
    }
}