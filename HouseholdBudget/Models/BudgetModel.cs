﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HouseholdBudget.Models
{
    public class Household
    {
        public Household()
        {
            //Account = new HashSet<Account>();
            //BudgetItems = new HashSet<BudgetItems>();
            //Transaction = new HashSet<Transaction>();
            //Invitation = new HashSet<Invitation>();
        }
        [Display(Name = "Household Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Household Name")]
        public string HouseholdName { get; set; }
        public virtual ICollection<ApplicationUser> Members { get; set; }
        public virtual ICollection<Budget> BudgetItems { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
        public virtual ICollection<Invitation> Invitation { get; set; }

    }

    public class Category
    {
        [Display(Name = "Category Id")]
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }

    //public class CategoryHousehold
    //{
    //    public int Id { get; set; }
    //    public Household HouseHold { get; set; }
    //    public Category Category { get; set; }
    //}

    public class Budget
    {
        [Display(Name = "Budget Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Budget Name")]
        public string BudgetName { get; set; }
        [Display(Name = "Household Id")]
        public int HouseholdId { get; set; }
    }

    public class BudgetItems
    {
        [Display(Name = "Budget Item Id")]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Budget Id")]
        public int BudgetId { get; set; }
    }

    public class Account
    {
        [Display(Name = "Account Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }
        [Display(Name = "Account Description")]
        public string AccountDescription { get; set; }
        public decimal Balance { get; set; }
        public bool Reconciled { get; set; }
        [Display(Name = "Reconciled Amount")]
        public Nullable<decimal> ReconciledAmount { get; set; }
        [Display(Name = "Reconciled Balance")]
        public Nullable<decimal> ReconciledBalance { get; set; }
        [Display(Name = "Household Id")]
        public int HouseholdId { get; set; }
    }

    public class Transaction
    {
        [Display(Name = "Transaction Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Required]
        [Display(Name = "Transaction Description")]
        public string TransactionDescription { get; set; }
        [Required]
        [Display(Name = "Transaction Amount")]
        public decimal TransactionAmount { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Transaction Entered By")]
        public int TransactionEnteredBy { get; set; }
        public bool Reconciled { get; set; }
        [Display(Name = "Reconciled Amount")]
        public Nullable<decimal> ReconciledAmount { get; set; }
        [Display(Name = "Reconciled By")]
        public Nullable<int> ReconciledById { get; set; }
        [Display(Name = "Account Id")]
        public int AccountId { get; set; }
    }
        public class Invitation
    {
        [Display(Name = "Invitation Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Invitee's Email Address")]
        public string ToEmail { get; set; }
        public Guid JoinCode { get; set; }
        [Display(Name = "Household Id")]
        public int HouseholdId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Household Household { get; set; }
    }

}