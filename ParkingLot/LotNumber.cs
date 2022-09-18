using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class LotNumber
    {
        public int Lot { get; set; }
        public string RegistrationNo { get; set; }
        public string Vehicle { get; set; }
        public string Color { get; set; }
        public bool IsAvailable { get; set; }
    }
}
