using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class PurchaseTypeRepositoryQA : IPurchaseTypeRepository
    {
        private static List<PurchaseType> _purchaseTypes = new List<PurchaseType>
        {
            new PurchaseType {PurchaseTypeId=1, PurchaseTypeName="Dealer Finance"},
            new PurchaseType {PurchaseTypeId=2, PurchaseTypeName="Bank Finance"},
            new PurchaseType {PurchaseTypeId=3, PurchaseTypeName="Cash"}
        };
        
        public List<PurchaseType> GetAll()
        {
            return _purchaseTypes;
        }
    }
}
