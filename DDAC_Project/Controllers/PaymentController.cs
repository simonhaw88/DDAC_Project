using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Controllers
{
    public class PaymentController : Controller

    {

        public IActionResult PaymentOption()
        {           
                return View();
        }
    }
}
