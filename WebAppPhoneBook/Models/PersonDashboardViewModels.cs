using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPhoneBook.Models
{
    public class PersonDashboardViewModels
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public System.DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
        public string HomeAddress { get; set; }
        public string HomeCity { get; set; }
        public string FaceBookAccountId { get; set; }
        public string LinkedInId { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public string ImagePath { get; set; }
        public string TwitterId { get; set; }
        public string EmailId { get; set; }
    }
}