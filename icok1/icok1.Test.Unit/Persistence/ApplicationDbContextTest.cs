//using icok1.Domain.Entities;
//using icok1.Persistence;
//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;

//namespace icok1.Test.Unit.Persistence
//{
//    public class ApplicationDbContextTest
//    {
//        [Test]
//        public void CanInsertProductIntoDatabase()
//        {
//            ProductCosmosDbService context = new ProductCosmosDbService();
//            try
//            {
//                var product = new Product();
//                context.AddAsync(product);
//                Assert.AreEqual(EntityState.Added, context.Entry(product).State);
//            }
//            finally
//            {
//                context.Dispose();
//            }
//        }
//    }
//}
