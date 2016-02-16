using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HouseholdBudget.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string HouseholdName { get; set; }
        public string MemberId { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }

    //public class CategoryHousehold
    //{
    //    public int Id { get; set; }
    //    [Required]
    //    public Household HouseHold { get; set; }
    //    [Required]
    //    public Category Category { get; set; }

    //}

    public class Budget
    {
        public int Id { get; set; }
        public string BudgetName { get; set; }
        public int HouseholdId { get; set; }
    }

    public class BudgetItems
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
        public int BudgetId { get; set; }
    }

    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountDescription { get; set; }
        public decimal Balance { get; set; }
        public bool Reconciled { get; set; }
        public Nullable<decimal> ReconciledAmount { get; set; }
        public Nullable<decimal> ReconciledBalance { get; set; }
        public int HouseholdId { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public decimal TransactionAmount { get; set; }
        public string CategoryName { get; set; }
        public int TransactionEnteredBy { get; set; }
        public bool Reconciled { get; set; }
        public Nullable<decimal> ReconciledAmount { get; set; }
        public int ReconciledById { get; set; }
        public int AccountId { get; set; }

    }

    public class Invitation
    {
        public int Id { get; set; }
        public string ToEmail { get; set; }
        public int UserId { get; set; }
        public int HouseholdId { get; set; }
    }
}