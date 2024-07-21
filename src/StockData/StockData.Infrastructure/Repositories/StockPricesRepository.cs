using Microsoft.EntityFrameworkCore;
using StockData.Domain.Entities;
using StockData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.Repositories
{
    public class StockPricesRepository : Repository<StockPrice, Guid>, IStockPricesRepository
    {
        public StockPricesRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}
