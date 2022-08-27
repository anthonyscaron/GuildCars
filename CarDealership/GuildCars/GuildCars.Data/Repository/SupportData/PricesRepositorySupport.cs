using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.SupportData
{
    public class PricesRepositorySupport
    {
        public List<decimal> GetAll() 
        {
            var prices = new List<decimal>();
            var startingPrice = 5000.00M;
            var endingPrice = 95000.00M;
            var priceIncrease = 5000.00M;
            var priceToAdd = startingPrice;

            while (priceToAdd <= endingPrice)
            {
                prices.Add(priceToAdd);
                priceToAdd += priceIncrease;
            }
            
            return prices;
        }
    }
}
