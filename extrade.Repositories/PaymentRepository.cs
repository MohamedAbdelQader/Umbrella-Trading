using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmbrellaTrading.Models;

namespace UmbrellaTrading.Repositories
{
    public class PaymentRepository : GeneralRepositories<AllPayment>
    {
        public PaymentRepository(UmbrellaTradingContext _DBContext) : base(_DBContext)
        {
        }
    }
}
