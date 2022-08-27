using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.SupportData
{
    public class YearsRepositorySupport
    {
        public List<int> GetAll()
        {
            var years = new List<int>();
            var startingYear = 2000;
            var endingYear = Int32.Parse(DateTime.Now.Year.ToString()) + 1;
            var yearToAdd = startingYear;

            while (yearToAdd <= endingYear)
            {
                years.Add(yearToAdd);
                yearToAdd++;
            }
            return years;
        }

        public List<int> GetAllSales()
        {
            var years = new List<int>();
            var startingYear = 2021;
            var currentYear = Int32.Parse(DateTime.Now.Year.ToString());
            var yearToAdd = startingYear;

            while (yearToAdd <= currentYear)
            {
                years.Add(yearToAdd);
                yearToAdd++;
            }
            return years;
        }
    }
}
