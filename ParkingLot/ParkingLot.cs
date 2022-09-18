using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLot
    {
        private int _parking_lot = 0;
        private List<LotNumber> _lotNumbers;
        public ParkingLot()
        {
            this._lotNumbers = new List<LotNumber>();
        }

        public int ParkingLotNumber
        {
            get { return _parking_lot; }
            set
            {
                _parking_lot = value;
                createLotNumber();
            }
        }

        private bool isValidLotNumber(string regNo)
        {
            var lotExist = _lotNumbers.Where(x => !string.IsNullOrEmpty(x.RegistrationNo) && x.RegistrationNo.Equals(regNo)).FirstOrDefault();

            return lotExist != null;
        }

        public void Park(string regNo, string color, string vehicle)
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var availableLot = _lotNumbers.Where(x => x.IsAvailable == true).OrderBy(x => x.Lot).FirstOrDefault();

            if (availableLot != null)
            {
                if (!isValidLotNumber(regNo))
                {
                    var index = _lotNumbers.IndexOf(availableLot);

                    availableLot.RegistrationNo = regNo;
                    availableLot.Color = color;
                    availableLot.Vehicle = vehicle;
                    availableLot.IsAvailable = false;

                    _lotNumbers[index] = availableLot;

                    Console.WriteLine($"Allocated slot number:{availableLot.Lot}");
                }
                else
                {
                    Console.WriteLine($"{regNo} already park");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, parking lot is full");
            }

        }

        public void Leave(int lot)
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var existLot = _lotNumbers.Where(x => x.Lot.Equals(lot)).FirstOrDefault();

            if (existLot != null)
            {
                var index = _lotNumbers.IndexOf(existLot);

                existLot.RegistrationNo = string.Empty;
                existLot.Color = string.Empty;
                existLot.Vehicle = string.Empty;
                existLot.IsAvailable = true;

                _lotNumbers[index] = existLot;
                Console.WriteLine($"slot number {lot} is free");
            }
            else
            {
                Console.WriteLine($"slot number {lot} isn\'t valid");
            }

        }

        public void Status()
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var listCurrentParking = _lotNumbers.Where(x => x.IsAvailable == false).OrderBy(x => x.Lot).ToList();
            Console.WriteLine($"Slot No \t TypeRegistration No \t Colour");
            foreach (var currentPark in listCurrentParking)
            {
                Console.WriteLine($"{currentPark.Lot} \t {currentPark.RegistrationNo} {currentPark.Vehicle} \t {currentPark.Color}");
            }

        }

        public void TypeOfVehicle(string vehicle)
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var listCurrentParking = _lotNumbers.Where(x => x.IsAvailable == false && x.Vehicle.ToLower().Trim().Equals(vehicle.ToLower())).OrderBy(x => x.Lot).ToList();
            Console.WriteLine($"{listCurrentParking.Count}");

        }

        public void RegNumberForOddPlate()
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var listCurrentParking = _lotNumbers.Where(x => x.IsAvailable == false && Convert.ToInt32(x.RegistrationNo.Split('-')[1]) % 2 != 0).OrderBy(x => x.Lot).ToList();
            foreach (var item in listCurrentParking)
            {
                Console.Write($"{item.RegistrationNo},");
            }

        }

        public void RegNumberForEvenPlate()
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var listCurrentParking = _lotNumbers.Where(x => x.IsAvailable == false && Convert.ToInt32(x.RegistrationNo.Split('-')[1]) % 2 == 0).OrderBy(x => x.Lot).ToList();
            foreach (var item in listCurrentParking)
            {
                Console.Write($"{item.RegistrationNo},");
            }
        }

        public void RegNumberForColor(string colour)
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var listCurrentParking = _lotNumbers.Where(x => x.IsAvailable == false && x.Color.ToLower().Equals(colour.ToLower())).OrderBy(x => x.Lot).ToList();
            foreach (var item in listCurrentParking)
            {
                Console.Write($"{item.RegistrationNo},");
            }
        }

        public void SlotNumberForColor(string colour)
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var listCurrentParking = _lotNumbers.Where(x => x.IsAvailable == false && x.Color.ToLower().Equals(colour.ToLower())).OrderBy(x => x.Lot).ToList();
            foreach (var item in listCurrentParking)
            {
                Console.Write($"{item.Lot},");
            }
        }

        public void SlotNumberForRegNumber(string regNo)
        {
            if (_parking_lot < 1)
            {
                Console.WriteLine($"{_parking_lot} lot, create parking lot first");
                return;
            }

            var currentParking = _lotNumbers.Where(x => x.IsAvailable == false && x.RegistrationNo.ToLower().Equals(regNo.ToLower())).OrderBy(x => x.Lot).FirstOrDefault();

            if (currentParking != null)
                Console.Write($"{currentParking.Lot}");
            else
                Console.Write($"Not Found");
        }



        private void createLotNumber()
        {
            for (int i = 0; i < _parking_lot; i++)
            {
                _lotNumbers.Add(new LotNumber() { Lot = i + 1, IsAvailable = true });
            }
            Console.WriteLine($"Created a parking lot with {_parking_lot} slots");
        }
    }
}
