﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppPhoneBook.Models
{
    public class ContactCreateModels
    {
        public int PersonId { get; set; }
        public int ContactId { get; set; }
        [Required]
        public string ContactNumber { get; set; }

        public string Type { get; set; }
    }
}