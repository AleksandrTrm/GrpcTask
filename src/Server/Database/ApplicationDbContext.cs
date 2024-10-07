using Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Server.Database;

public class ApplicationDbContext(ILogger<ApplicationDbContext> logger) : DbContext
{
     public DbSet<GrpcData> GrpcData => Set<GrpcData>();
     
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
          optionsBuilder.UseNpgsql(Constants.DATABASE);
          optionsBuilder.UseSnakeCaseNamingConvention();
          optionsBuilder.EnableSensitiveDataLogging();
          optionsBuilder.LogTo(message => logger.LogInformation(message));
     }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          modelBuilder.Entity<GrpcData>(builder =>
          {
               builder.ToTable("grpc_data");

               builder.HasKey(g => new { g.PacketSeqNum, g.RecordSeqNum });
               
               builder.Property(g => g.PacketSeqNum)
                    .IsRequired();

               builder.Property(g => g.RecordSeqNum)
                    .IsRequired();

               builder.Property(g => g.PacketTimestamp)
                    .IsRequired();

               builder.Property(g => g.Decimal1)
                   .IsRequired();
               
               builder.Property(g => g.Decimal2)
                   .IsRequired();
               
               builder.Property(g => g.Decimal3)
                   .IsRequired();
               
               builder.Property(g => g.Decimal4)
                   .IsRequired();

               builder.Property(g => g.RecordTimestamp);
          });
     }
}