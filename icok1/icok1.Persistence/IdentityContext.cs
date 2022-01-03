//using icok1.Domain.Auth;
//using icok1.Persistence.Seeds;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace icok1.Persistence
//{
//    public class IdentityContext : IdentityDbContext<ApplicationUser>
//    {
//        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
//        {
//        }
//        //public IdentityContext()
//        //{

//        //}
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            modelBuilder.HasDefaultSchema("Identity");
//            modelBuilder.Entity<ApplicationUser>(entity =>
//            {
//                entity.ToTable(name: "User");
//            });

//            modelBuilder.Entity<IdentityRole>(entity =>
//            {
//                entity.ToTable(name: "Role");
//            });
//            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
//            {
//                entity.ToTable("UserRoles");
//            });

//            //modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
//            //{
//            //    entity.ToTable("UserClaims");
//            //});

//            //modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
//            //{
//            //    entity.ToTable("UserLogins");
//            //});

//            //modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
//            //{
//            //    entity.ToTable("RoleClaims");
//            //});

//            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
//            {
//                entity.ToTable("UserTokens");
//            });
//            //modelBuilder.Entity<Domain.Entities.Order>() //todo: why should we do it here also ?
//            //.HasOne(a => a.PaymentTransaction)
//            //.WithOne(a => a.Order)
//            //.HasForeignKey<Domain.Entities.PaymentTransaction>(c => c.OrderId);
//            //modelBuilder.Entity<Domain.Entities.OrderDetail>().HasKey(o => new { o.OrderId, o.ProductId });

//            modelBuilder.IdentitySeed();
//        }
//    }
//}
