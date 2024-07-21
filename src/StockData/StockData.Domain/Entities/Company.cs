using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Domain.Entities
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string TradeCode { get; set; }
    }
}
