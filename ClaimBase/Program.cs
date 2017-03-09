using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using System.Security.Principal;

namespace ClaimBase
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Claim> claimCollection = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Phi"),
                new Claim(ClaimTypes.Country,"VietNam"),
                new Claim(ClaimTypes.Gender,"Nam"),
                new Claim(ClaimTypes.Surname,"Dinh"),
                new Claim(ClaimTypes.Email,"dinhhongphi@gmail.com"),
                new Claim(ClaimTypes.Role,"IT")
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection,"my app");
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            Thread.CurrentPrincipal = principal;
            //CheckCompatibility();
            GetAllClaim();
        }

        public static void CheckCompatibility()
        {
            IPrincipal currentPrincipal = Thread.CurrentPrincipal;
            Console.WriteLine(currentPrincipal.Identity.Name);
            Console.WriteLine(currentPrincipal.IsInRole("IT"));
        }

        public static void GetAllClaim()
        {
            ClaimsPrincipal current = Thread.CurrentPrincipal as ClaimsPrincipal;
            foreach(ClaimsIdentity identity in current.Identities)
            {
                Console.WriteLine(identity.AuthenticationType);
                foreach(Claim claim in identity.Claims)
                {
                    Console.WriteLine("\t{0} : {1} : {2}", claim.Subject, claim.Value, claim.ValueType);
                }
            }
        }
    }
}
