using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class License
    {
        public int Id {get; set;}
        public string License_Type {get; set;}

        public License()
        {
        }

        public License(int id, string license_Type)
        {
            Id = id;
            License_Type = license_Type;
        }
    }
}