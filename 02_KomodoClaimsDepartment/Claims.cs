using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsDepartment
{
    public enum ClaimType { Car, Home, Theft,
        Undefined
    }

    public class Claim
    {
        public int ClaimID { get; set; } = 0;
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool isValid
        {
            get
            { return TimeSpan.FromDays(30) >= (DateOfClaim - DateOfAccident); }
        }

        public Claim(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
        }

        public Claim() 
        {
            ClaimType = ClaimType.Undefined;
            Description = "Undefined";
        }

    }
}
