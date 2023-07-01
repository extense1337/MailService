using Microsoft.EntityFrameworkCore;

namespace MailService.Database;

public sealed class MailDbContext : DbContext
{
    public MailDbContext(DbContextOptions<MailDbContext> options)
        : base(options)
    {
    }

    public DbSet<MailEntity> Mails { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MailEntity>().HasKey(entity => entity.Id);
    }

    #region Migration commands

    // How to do migrations after schema change
    //
    // Install ef tool if havent
    // cmd > dotnet tool install --global dotnet-ef --version 7.*
    //
    // Create migration
    // cmd> cd MailService.Database
    // cmd> dotnet ef --startup-project ../MailService.Api migrations add <migration-name>
    // cmd> dotnet ef --startup-project ../MailService.Api database update

    #endregion
}