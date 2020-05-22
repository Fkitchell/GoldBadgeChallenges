using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_KomodoClaimsDepartment
{
    class ProgramUI
    {
        private readonly ClaimsRepository _claimsRepository = new ClaimsRepository();

        public void Run()
        {
            SeedQueue();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Choose a menu item:\n" +
                    "1.See all claims\n" +
                    "2.Take care of next claim\n" +
                    "3.Enter a new claim\n"
                    );
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        GetNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        Thread.Sleep(1000);
                        break;


                }
            }
        }

        public void SeeAllClaims()
        {
            Console.Clear();
            _claimsRepository.SeeAllClaims();
            Console.WriteLine("\n\nPress any key to continue.");
            Console.ReadKey();
        }

        public void GetNextClaim()
        {
            Console.Clear();
            _claimsRepository.WriteClaimToConsole(_claimsRepository.GetClaim());
            Console.WriteLine("\n\nPress any key to continue.");
            Console.ReadKey();
        }

        public void AddNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("Enter the Claim ID:");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Select a type: \n" +
                "1. Car\n" +
                "2. Theft\n" +
                "3. Home \n\n");
            string typeInput = Console.ReadLine();

            switch (typeInput.ToLower())
            {
                case "1":
                case "car":
                case "c":
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                case "theft":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
                case "3":
                case "home":
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                default:
                    newClaim.ClaimType = ClaimType.Undefined;
                    break;
            }

            Console.Clear();
            Console.WriteLine("How much was the claim:");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            bool accidentDateIsNotValid = true;

            while (accidentDateIsNotValid)
            {
                Console.Clear();

                Console.WriteLine("When was the incident (in the following format)\n" +
                    "Year (YYYY):");
                string inputYear = Console.ReadLine();
                bool yearBool = int.TryParse(inputYear, out int year);


                Console.WriteLine("Month(MM):");
                string inputMonth = Console.ReadLine();
                bool monthBool = int.TryParse(inputMonth, out int month);


                Console.WriteLine("Day(DD):");
                string inputDay = Console.ReadLine();
                bool dayBool = int.TryParse(inputDay, out int day);

                if ((dayBool && day > 0 && day <= 31) && (monthBool && month > 1 && month <= 12) && (yearBool && year >= 1980 && year <= DateTime.Now.Year))
                {
                    newClaim.DateOfAccident = new DateTime(year, month, day);
                    accidentDateIsNotValid = false;
                }
                else
                {
                    Console.WriteLine("You did not enter the date correctly. Please enter all components in the YYYY, MM, DD format. \n\n" +
                        "Press any key to continue.");
                    Console.ReadKey();
                }
            }

            bool claimDateIsNotValid = true;

            while (claimDateIsNotValid)
            {

                Console.Clear();
                Console.WriteLine("When was the claim submitted (in the following format)\n" +
                    "Year (YYYY):");

                string inputYear = Console.ReadLine();
                bool yearBool = int.TryParse(inputYear, out int year);


                Console.WriteLine("Month(MM):");
                string inputMonth = Console.ReadLine();
                bool monthBool = int.TryParse(inputMonth, out int month);


                Console.WriteLine("Day(DD):");
                string inputDay = Console.ReadLine();
                bool dayBool = int.TryParse(inputDay, out int day);

                if ((dayBool && day > 0 && day <= 31) && (monthBool && month > 1 && month <= 12) && (yearBool && year >= 1980 && year <= DateTime.Now.Year))
                {
                    DateTime dateOfClaim = new DateTime(year, month, day);
                    if (dateOfClaim > DateTime.Now)
                    {
                        Console.WriteLine("The date you entered is in the future.");
                    }
                    else
                    {
                        newClaim.DateOfClaim = dateOfClaim;
                        claimDateIsNotValid = false;
                    }
                }
                else
                {
                    Console.WriteLine("You did not enter the date correctly. Please enter all components in the YYYY, MM, DD format. \n\n" +
                        "Press any key to continue.");
                    Console.ReadKey();
                }


                bool wasAdded = _claimsRepository.CreateNewClaim(newClaim);

                if (wasAdded)
                {
                    Console.WriteLine("Added Successfully.");
                }
                else
                {
                    Console.WriteLine("Not added succesfully.");
                }
            }

            _claimsRepository.WriteClaimToConsole(newClaim);
            Console.WriteLine("\n\nPress any key to continue.");
            Console.ReadKey();
        }

        public void SeedQueue()
        {
            Claim newClaimOne = new Claim(1, ClaimType.Theft, "Car was stolen.", 4000.00, new DateTime(2020, 4, 27), DateTime.Now);
            Claim newClaimTwo = new Claim(2, ClaimType.Car, "Car Accident on 464.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim newClaimThree = new Claim(3, ClaimType.Theft, "Car was stolen.", 12000.00, new DateTime(2020, 2, 27), new DateTime(2020, 4, 1));

            _claimsRepository.CreateNewClaim(newClaimOne);
            _claimsRepository.CreateNewClaim(newClaimTwo);
            _claimsRepository.CreateNewClaim(newClaimThree);
        }
    }
}
