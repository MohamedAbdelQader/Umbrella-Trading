using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmbrellaTrading.Models;

namespace UmbrellaTrading.Repositories
{
    public class UnitOfWork
    {
        private readonly UmbrellaTradingContext dbContext;
        public UnitOfWork(UmbrellaTradingContext context)
        {
            dbContext = context;
        }
        public void Submit()
        {
            dbContext.SaveChanges();
        }

    }
}
