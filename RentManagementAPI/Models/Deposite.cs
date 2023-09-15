﻿using System;

namespace RentManagementAPI.Models
{
    public class Deposite
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public double DepositeAmount { get; set; }
        public double DueAmount { get; set; }
        public DateTime DepositeDatet { get; set; }
        public int RentId { get; set; }
        public Rent? Rent { get; set; }
    }
}