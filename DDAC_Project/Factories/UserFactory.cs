using DDAC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Factories
{
    public class UserFactory
    {
        public static User Create(int role, User usr = null)
        {
            User user = usr == null ? new User() : usr;

            if(role == (int)UserEnum.Admin)
            {
                usr.Role = (int)UserEnum.Admin;
                user.Admin = new Admin();
                user.Admin.Address = new Address();
            } else if(role == (int)UserEnum.Staff)
            {
                usr.Role = (int)UserEnum.Staff;
                user.Staff = new Staff();
                user.Staff.Address = new Address();

            }
            else if(role == (int)UserEnum.Customer)
            {
                usr.Role = (int)UserEnum.Customer;
                user.Customer = new Customer();
                user.Customer.Address = new Address();

            }


            return user;
        }
        
      
    }
}
