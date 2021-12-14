using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        public string Sector_Type { get; set; }

        public Sector()
        {
        }

        public Sector(int id, string sector_Type)
        {
            Id = id;
            Sector_Type = sector_Type;
        }
    }
}
