using StockData.Application.DTOs;
using StockData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Application.Features
{
    public class ScrapDataManagementService : IScrapDataManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ScrapDataManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InsertCompanyAsync(CompanyDto companyDto)
        {
            var isInDb = await _unitOfWork.CompanyRepository.GetCountAsync(x => x.TradeCode == companyDto.TradeCode);
            if (isInDb > 0)
            {
                return;
            }

            await _unitOfWork.CompanyRepository.AddAsync(new Company
            {
                TradeCode = companyDto.TradeCode
            });
            await _unitOfWork.SaveAsync();
        }

        public async Task InsertStockPriceAsync(StockPriceDto stockPriceDto)
        {
            await _unitOfWork.StockPriceRepository.AddAsync(new StockPrice
            {
                CompanyId = await _unitOfWork.CompanyRepository.GetCompanyId(stockPriceDto.TradeCode),
                LastTradingPrice = stockPriceDto.LastTradingPrice,
                High = stockPriceDto.High,
                Low = stockPriceDto.Low,
                ClosePrice = stockPriceDto.ClosePrice,
                YesterdayClosePrice = stockPriceDto.YesterdayClosePrice,
                Change = stockPriceDto.Change,
                Trade = stockPriceDto.Trade,
                Value = stockPriceDto.Value,
                Volume = stockPriceDto.Volume
            });
            await _unitOfWork.SaveAsync();
        }
    }
}
