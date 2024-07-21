using Microsoft.EntityFrameworkCore;
using StockData.Application;
using StockData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure
{
	public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
	{

        public ICompanyRepository CompanyRepository { get; private set; }

        public IStockPricesRepository StockPriceRepository { get; private set;}

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IStockPricesRepository stockExchangeRepository,
			ICompanyRepository companyRepository) : base((DbContext)dbContext)
		{
			StockPriceRepository = stockExchangeRepository;
            CompanyRepository = companyRepository;
		}

    }
}
