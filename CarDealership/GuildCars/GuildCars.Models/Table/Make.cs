using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Table
{
    public class Make
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedByUser { get; set; }
    }
}
