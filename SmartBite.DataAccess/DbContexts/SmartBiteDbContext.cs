using Microsoft.EntityFrameworkCore;

namespace SmartBite.DataAccess.DbContexts
{
    public class SmartBiteDbContext : DbContext
    {
        public SmartBiteDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }



        




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
