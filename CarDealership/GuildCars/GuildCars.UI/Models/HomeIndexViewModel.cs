using GuildCars.Models.Query;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class HomeIndexViewModel
    {
        public List<FeaturedVehicleRequestItem> FeaturedVehicles { get; set; }
        public List<Special> Specials { get; set; }
        public string FileNameForPicture { get; set; }
    }
}