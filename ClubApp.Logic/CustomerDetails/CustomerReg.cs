using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Logic.Customer;
using ClubApp.Models.Customer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.CustomerDetails
{
    public class CustomerReg : LogicBase,ICustomerReg
    {
        public CustomerReg(DatabaseContext db, IMapper mapper, IConfiguration config) : base(db, mapper, config)
        {

        }
        public async Task<CustomerViewModel> AddCustomer(CustomerModel model)
        {
            if (model.Name != null & model.Phone!=null)
            {
                ClubApp.Data.Entities.Customer customer = _mapper.Map<ClubApp.Data.Entities.Customer>(model);               
                await _db.Customers.AddAsync(customer);
                await _db.SaveChangesAsync();
                return new CustomerViewModel { Name = customer.Name };
            }
            else
            {
                throw new ConsoleCommonException("Registration Failed");
            }
        }
    }
}
