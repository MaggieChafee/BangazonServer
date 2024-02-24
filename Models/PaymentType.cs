﻿using System.ComponentModel.DataAnnotations;

namespace BangazonServer.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}