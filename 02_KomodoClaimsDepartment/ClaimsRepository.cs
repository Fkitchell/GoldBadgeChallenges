using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsDepartment
{
    public class ClaimsRepository
    {
        private readonly Queue<Claim> _claims = new Queue<Claim>();

        //enter a new claim
        public bool CreateNewClaim(Claim newClaim)
        {
            int startingCount = _claims.Count();

            _claims.Enqueue(newClaim);

            return _claims.Count == startingCount + 1;
        }

        //get next claim
        public Claim GetClaim()
        {
            if (_claims.Count > 0)
            { return _claims.Dequeue(); }
            else
            {
                return null;
            }
        }

        //see all claims
        public void SeeAllClaims()
        {
            DataTable dataTable = new DataTable();

            Console.WriteLine("Claim ID  Type     Description           Amount    Date of Accident Date of Claim  IsValid");
            foreach (Claim claims in _claims)
            {
                Console.WriteLine($"{claims.ClaimID,-10}{claims.ClaimType,-9}{claims.Description,-22}{claims.ClaimAmount,-13}{claims.DateOfAccident.ToShortDateString(),-16}{claims.DateOfClaim.ToShortDateString(),-15}{claims.isValid}");
            }
        }

        public void WriteClaimToConsole(Claim claim)
        {
            if (claim!= null)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n\n" +
                $"Claim Type: {claim.ClaimType}\n\n" +
                $"Description: {claim.Description}\n\n" +
                $"Amount: ${claim.ClaimAmount}\n\n" +
                $"Date of Accident: {claim.DateOfAccident.ToShortDateString()}\n\n" +
                $"Date of Claim: {claim.DateOfClaim.Date.ToShortDateString()}\n\n" +
                $"Claim is valid: {claim.isValid}");
            }
            else
            {
                Console.WriteLine("There are no claims left in the queue. Congrats!!");
            }
        }
    }
}
