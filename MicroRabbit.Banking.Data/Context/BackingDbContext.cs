using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace MicroRabbit.Banking.Data.Context
{
    public class BackingDbContext : DbContext
    {
        public BackingDbContext( DbContextOptions<BackingDbContext> options ): base(options)
        {

        }

        public DbSet <Account> Accounts { get; set; }

    }
}
