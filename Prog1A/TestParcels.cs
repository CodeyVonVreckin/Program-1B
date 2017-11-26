/*
Grading ID: C4811
CIS 200-01
Due Date: 10/17/16
This test program takes objects created from previously created concrete classes, 
adds them to a list, and then uses LINQ to produce simple reports from them
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Stan Marsh", "ShTapa Town", "4321 Your Street", 
                "Pittsburgh", "Pennsylvania", 15201); // Test Address 5
            Address a6 = new Address("Eric Cartman", "South Park Elementary", "Detention Room 102", 
                "New York City", "New York", 10001); // Test Address 6
            Address a7 = new Address("Kenny McCormick", "SoDoSoapa", "1111 Gheto Avenue", 
                "South Park", "Colorado", 80019); // Test Address 7
            Address a8 = new Address("Kyle Broflovski", "The Church of God", "5676 Jewish Lane",
                "Jersey City", "New Jersey", 07208); // Test Address 8

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter 1 test object
            Letter letter2 = new Letter(a2, a3, 4.50M);                            // Letter 2 test object
            Letter letter3 = new Letter(a3, a4, 1.50M);                            // Letter 3 test object
            Letter letter4 = new Letter(a4, a8, .75M);                             // Letter 4 test object

            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground 1 test object
            GroundPackage gp2 = new GroundPackage(a5, a7, 10, 5, 2, 50);           // Ground 2 test object
            GroundPackage gp3 = new GroundPackage(a7, a1, 15, 20, 25, 35.8);       // Ground 3 test object
            GroundPackage gp4 = new GroundPackage(a2, a6, 60, 50, 23, 150);        // Ground 4 test object

            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day 1 test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a5, a6, 20, 10, 5,     // Next Day 2 test object
                80, 10.50M);
            NextDayAirPackage ndap3 = new NextDayAirPackage(a1, a8, 15, 40, 32,    // Next Day 3 test object
                95, 4.55M);
            NextDayAirPackage ndap4 = new NextDayAirPackage(a2, a7, 100, 50, 75,   // Next Day 4 test object
                70, 20.95M);


            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day 1 test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a2, a4, 30.2, 19.4, 20.5, // Two Day 2 test object
                90, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a3, a5, 6.5, 9.54, 30.04, // Two Day 3 test object
                60.25, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage tdap4 = new TwoDayAirPackage(a6, a8, 40.0, 50.5, 33.33, // Two Day 4 test object
                50.75, TwoDayAirPackage.Delivery.Early);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populates list with 4 letter objects
            parcels.Add(letter2);
            parcels.Add(letter3);
            parcels.Add(letter4);
            parcels.Add(gp1); // Populates list with 4 ground package objects
            parcels.Add(gp2);
            parcels.Add(gp3);
            parcels.Add(gp4);
            parcels.Add(ndap1); // Populates list with 4 next day air packages objects
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(ndap4);
            parcels.Add(tdap1); // Populates list with 4 two day air packages objects
            parcels.Add(tdap2);
            parcels.Add(tdap3);
            parcels.Add(tdap4);       
                                                                

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }

            // selects all Parcels and orders them by destination zip in a descending order
            var destinationZip =
                from destZip in parcels
                orderby destZip.DestinationAddress.Zip descending
                select destZip;

            Console.WriteLine("\nParcels Ordered by Destination Zip"); // displays a header for the query
            Console.WriteLine("----------------------------------");

            // displays all parcels ordered by their destination zip
            foreach (var destZip in destinationZip)
                Console.WriteLine(destZip);

            // selects all Parcels and orders them by their Cost in a ascending order
            var cost =
               from c in parcels
               orderby c.CalcCost()
               select c;

            Console.WriteLine("\nParcels Ordered by Cost"); // displays a header for the query
            Console.WriteLine("-----------------------");

            // displays all parcels ordered by their cost 
            foreach (var c in cost)
                Console.WriteLine(c);

            // selects all Parcels and orders them by their type (ascending) and their cost (descending)
            var parcelTypeandCost =
                from pTC in parcels
                orderby pTC.GetType().ToString() ascending, pTC.CalcCost() descending 
                select pTC;

            Console.WriteLine("\nParcels Ordered by Type and Cost"); // displays a header for the query
            Console.WriteLine("-----------------------");

            // displays all parcels ordered by their type and cost
            foreach (var pTC in parcelTypeandCost)
                Console.WriteLine(pTC);

            Console.WriteLine("\nHeavy AirPackages Ordered by Weight"); // displays a header for the query
            Console.WriteLine("-----------------------------------");

            // selects all AirPackages in parcels that are heavy and orders them by their weight in a descending order
            var heavyAirPackage =
                from hAP in parcels
                where hAP is AirPackage
                let airPackage = (AirPackage)hAP
                where airPackage.IsHeavy() == true
                orderby airPackage.Weight descending
                select airPackage;

            // displays all Air Package parcels that are heavy and ordered by their weight
            foreach (var airPackage in heavyAirPackage)
                Console.WriteLine(airPackage);            
                     

        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
