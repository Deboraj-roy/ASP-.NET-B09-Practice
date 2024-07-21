using StockData.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Application.Features
{
    public interface IScrapDataManagementService
    {
        Task InsertCompanyAsync(CompanyDto stockPriceDto);
        Task InsertStockPriceAsync(StockPriceDto stockPriceDto);
    }
}
