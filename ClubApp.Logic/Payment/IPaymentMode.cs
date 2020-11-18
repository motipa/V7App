using ClubApp.Models.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Payment
{
    public interface IPaymentMode
    {
        Task<PaymentViewModel> SavePayementDetails(PaymentModel payment);
    }
}
