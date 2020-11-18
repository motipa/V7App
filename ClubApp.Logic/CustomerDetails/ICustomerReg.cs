using ClubApp.Models.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Customer
{
   public interface ICustomerReg
    {
        Task<CustomerViewModel> AddCustomer(CustomerModel model);
    }
}
