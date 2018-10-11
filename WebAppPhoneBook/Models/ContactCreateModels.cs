using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppPhoneBook.Models
{
    public class ContactCreateModels
    {
        [Required]
        public string ContactNumber { get; set; }

        public string Type { get; set; }
    }
}