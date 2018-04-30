﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDB.Models
{
    public class CheckingAccount
    {
        private decimal balance;

        [Key]
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public decimal Fee { get; set; }

        public void DepositMoney(decimal amount)
        {
            this.balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            this.balance -= amount;
            DeductFee();
        }

        public void DeductFee()
        {
            this.balance -= this.Fee;
        }
    }
}
