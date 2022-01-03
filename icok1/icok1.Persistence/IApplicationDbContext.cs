using icok1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace icok1.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<PaymentTransaction> PaymentTransactions { get; set; }

        Task<int> SaveChangesAsync();
    }
}
