using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPhoneBook
{
    public class Meduim
    {
        private static int mediumData;

        public static int MediumData
        {
            get
            {
                return mediumData;
            }

            set
            {
                mediumData = value;
            }
        }
    }
}