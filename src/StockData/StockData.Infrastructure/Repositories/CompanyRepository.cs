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
    public class CompanyRepository : Repository<Company, Guid>, ICompanyRepository
    {
        public CompanyRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public async Task<Guid> GetCompanyId(string tradeCode)
        {
            var result = await GetAsync(x => x.TradeCode == tradeCode, null);
            return result.FirstOrDefault()!.Id;
        }
    }
}
