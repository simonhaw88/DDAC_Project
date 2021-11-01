using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class PaymentOption
    {
        public string CreditCard { get; set; }
        public string DebitCard { get; set; }
        public string Cash { get; set; }
        public int CreditCardNumber { get; set; }
        public int DebitCardNumber { get; set; }
        public string FullName { get; set; }
        public int CVV { get; set; }
        public int ExpiryDate { get; set; }

    }
}
