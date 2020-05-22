using System;
using _02_KomodoClaimsDepartment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_claimstests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ClaimsRepository _claimsRepository = new ClaimsRepository();

        [TestInitialize]
        public void SeedMethod()
        {
            Claim newClaimOne = new Claim(1, ClaimType.Theft, "Car was stolen.", 4000.00, new DateTime(2020, 4, 27), DateTime.Now);
            Claim newClaimTwo = new Claim(2, ClaimType.Car, "Car Accident on 464.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));

            _claimsRepository.CreateNewClaim(newClaimOne);
            _claimsRepository.CreateNewClaim(newClaimTwo);
        }

        [TestMethod]
        public void TestAddClaimShouldAddClaim()
        {
            Claim newClaimOne = new Claim(4, ClaimType.Theft, "Car was stolen.", 4000.00, new DateTime(2020, 4, 27), DateTime.Now);
            Assert.IsTrue(_claimsRepository.CreateNewClaim(newClaimOne));
            Assert.IsTrue(newClaimOne.isValid);
            Console.WriteLine(newClaimOne.isValid);
        }

        [TestMethod]
        public void TestGetClaim()
        {
            Claim getClaim = _claimsRepository.GetClaim();
            _claimsRepository.WriteClaimToConsole(getClaim);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            _claimsRepository.SeeAllClaims();
        }
    }
}
