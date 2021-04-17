using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
     public interface ICheckout
        {
            bool SaveChanges();
            TCheckout GetPaymentById(int id);
            void CreatePayment(TCheckout checkout);
            void DeletePayment(TCheckout checkout);
        }
   
}
