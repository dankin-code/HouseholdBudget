using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseholdBudget.Models
{
    public class DashboardViewModel
    {
        public Household household { get; set; }
        public List<Account> accounts { get; set; }
        public List<Category> categories { get; set; }
        public List<Transaction> transactions { get; set; }
        public List<Invitation> invitations { get; set; }
        public List<Budget> budgets { get; set; }
        public List<BudgetItems> budgetItems { get; set; }

    }
}