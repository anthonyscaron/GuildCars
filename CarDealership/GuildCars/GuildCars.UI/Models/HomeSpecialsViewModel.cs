using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class HomeSpecialsViewModel
    {
        public List<Special> Specials { get; set; }
        public string FileNameForPicture { get; set; }
        public string FileNameForIcon { get; set; }
    }
}