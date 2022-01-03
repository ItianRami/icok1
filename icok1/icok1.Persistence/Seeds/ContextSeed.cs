//using icok1.Domain.Auth;
//using icok1.Domain.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;

//namespace icok1.Persistence.Seeds
//{
//    public static class ContextSeed
//    {
//        public static void IdentitySeed(this ModelBuilder modelBuilder)
//        {
//            CreateRoles(modelBuilder);

//            CreateBasicUsers(modelBuilder);

//            MapUserRole(modelBuilder);

//        }

//        public static void ApplicationSeed(this ModelBuilder modelBuilder)
//        {
//            CreateProducts(modelBuilder);

//            CreateOrderForUser(modelBuilder);
//        }
//        private static void CreateRoles(ModelBuilder modelBuilder)
//        {
//            List<IdentityRole> roles = DefaultRoles.IdentityRoleList();
//            modelBuilder.Entity<IdentityRole>().HasData(roles);
//        }

//        private static void CreateBasicUsers(ModelBuilder modelBuilder)
//        {
//            List<ApplicationUser> users = DefaultUser.IdentityBasicUserList();
//            modelBuilder.Entity<ApplicationUser>().HasData(users);
//        }

//        private static void MapUserRole(ModelBuilder modelBuilder)
//        {
//            var identityUserRoles = MappingUserRole.IdentityUserRoleList();
//            modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityUserRoles);
//        }

//        private static void CreateProducts(ModelBuilder modelBuilder)
//        {
//            List<Product> products = DefaultProducts.ProductList();
//            modelBuilder.Entity<Product>().HasData(products);
//        }
//        private static void CreateOrderForUser(ModelBuilder modelBuilder)
//        {
//            var orders = DefaultOrders.OrderList();
//            modelBuilder.Entity<Order>().HasData(orders);
//        }

//    }
//}
