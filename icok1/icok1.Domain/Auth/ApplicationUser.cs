//using icok1.Domain.Entities;
//using Microsoft.AspNetCore.Identity;
//using System.Collections.Generic;

//namespace icok1.Domain.Auth
//{
//    public class ApplicationUser : IdentityUser
//    {
//        public ApplicationUser()
//        {
//            //Orders = new List<Order>();
//        }

//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        //public List<Order> Orders { get; set; }

//        public List<RefreshToken> RefreshTokens { get; set; }
//        public bool OwnsToken(string token)
//        {
//            return this.RefreshTokens?.Find(x => x.Token == token) != null;
//        }
//    }
//}