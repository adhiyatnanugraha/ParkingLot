using System;

namespace ParkingLot
{
    public class Program
    {
        const string CREATE_PARKING_LOT = "create_parking_lot";
        const string PARK_PARKING_LOT = "park";
        const string LEAVE_PARKING_LOT = "leave";
        const string STATUS_PARKING_LOT = "status";
        const string REPORT_TYPE_OF_VEHICLE = "type_of_vehicle";
        const string REPORT_REGISTRATION_NUMBERS_VEHICLE_ODD = "registration_numbers_for_vehicles_with_ood_plate";
        const string REPORT_REGISTRATION_NUMBERS_VEHICLE_EVEN = "registration_numbers_for_vehicles_with_event_plate";
        const string REPORT_REGISTRATION_NUMBERS_VEHICLE_COLOR = "registration_numbers_for_vehicles_with_colour";
        const string REPORT_SLOT_NUMBERS_VEHICLE_WITH_COLOR = "slot_numbers_for_vehicles_with_colour";
        const string REPORT_SLOT_NUMBERS_VEHICLE_WITH_REGNO = "slot_number_for_registration_number";
        static void Main(string[] args)
        {
            var parkingLot = new ParkingLot();

            var isRunning = true;
            while (isRunning)
            {
                var inp = Console.ReadLine();
                if (string.IsNullOrEmpty(inp))
                    return;

                var firstInp = inp.Split(' ');

                if (firstInp.Length < 1)
                    return;

                string txtCommand = string.Empty;

                for (int i = 0; i < firstInp.Length; i++)
                {
                    if (i == 0)
                        txtCommand = firstInp[i];
                }

                if (string.IsNullOrEmpty(txtCommand))
                    return;

                if (txtCommand.ToLower().Equals(CREATE_PARKING_LOT)) // create parking lot
                {
                    string lotValue = string.Empty;

                    for (int i = 0; i < firstInp.Length; i++)
                    {
                        if (i == 1)
                            lotValue = firstInp[i];
                    }

                    if (!string.IsNullOrEmpty(lotValue))
                    {
                        parkingLot.ParkingLotNumber = Convert.ToInt16(lotValue);

                    }

                }
                else if (txtCommand.ToLower().Equals(PARK_PARKING_LOT)) // parking lot
                {
                    string regNo = string.Empty;
                    string color = string.Empty;
                    string vehicle = string.Empty;

                    for (int i = 0; i < firstInp.Length; i++)
                    {
                        if (i == 1)
                            regNo = firstInp[i];

                        if (i == 2)
                            color = firstInp[i];

                        if (i == 3)
                            vehicle = firstInp[i];
                    }


                    parkingLot.Park(regNo, color, vehicle);
                }
                else if (txtCommand.ToLower().Equals(LEAVE_PARKING_LOT)) // leave parking lot
                {
                    string lot = string.Empty;

                    for (int i = 0; i < firstInp.Length; i++)
                    {
                        if (i == 1)
                            lot = firstInp[i];
                    }

                    parkingLot.Leave(Convert.ToInt16(lot));
                }
                else if (txtCommand.ToLower().Equals(STATUS_PARKING_LOT)) // status parking lot
                {
                    parkingLot.Status();
                }
                else if (txtCommand.ToLower().Equals(REPORT_TYPE_OF_VEHICLE)) // type of vehicle
                {
                    string vehicle = string.Empty;

                    for (int i = 0; i < firstInp.Length; i++)
                    {
                        if (i == 1)
                            vehicle = firstInp[i];
                    }
                    parkingLot.TypeOfVehicle(vehicle);
                }
                else if (txtCommand.ToLower().Equals(REPORT_REGISTRATION_NUMBERS_VEHICLE_ODD)) // registration number for vehicle with odd plate
                {
                    parkingLot.RegNumberForOddPlate();
                }
                else if (txtCommand.ToLower().Equals(REPORT_REGISTRATION_NUMBERS_VEHICLE_EVEN)) // registration number for vehicle with even plate
                {
                    parkingLot.RegNumberForEvenPlate();
                }
                else if (txtCommand.ToLower().Equals(REPORT_REGISTRATION_NUMBERS_VEHICLE_COLOR)) // registration number for vehicle with colour
                {
                    string color = string.Empty;

                    for (int i = 0; i < firstInp.Length; i++)
                    {
                        if (i == 1)
                            color = firstInp[i];
                    }
                    parkingLot.RegNumberForColor(color);
                }
                else if (txtCommand.ToLower().Equals(REPORT_SLOT_NUMBERS_VEHICLE_WITH_COLOR)) // slot number for vehicle with colour
                {
                    string color = string.Empty;

                    for (int i = 0; i < firstInp.Length; i++)
                    {
                        if (i == 1)
                            color = firstInp[i];
                    }
                    parkingLot.SlotNumberForColor(color);
                }
                else if (txtCommand.ToLower().Equals(REPORT_SLOT_NUMBERS_VEHICLE_WITH_REGNO)) // slot number for vehicle with colour
                {
                    string regNo = string.Empty;

                    for (int i = 0; i < firstInp.Length; i++)
                    {
                        if (i == 1)
                            regNo = firstInp[i];
                    }
                    parkingLot.SlotNumberForRegNumber(regNo);
                }
                else if (inp.ToLower().Equals("exit"))
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine($"command isn\'t valid");
                }

            }
        }
    }
}
