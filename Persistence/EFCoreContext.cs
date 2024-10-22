

using Microsoft.EntityFrameworkCore;
using Solucao.Models;

namespace Solucao.Persistence;

public class EFCoreContext : DbContext
{

    //    public EFCoreContext( )      public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)


     public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
    {
        
    }


    public DbSet<ReportModel> Reserves { get; set; }
    public DbSet<ReportModel> Reports { get; set; }
    public DbSet<RoomModel> Rooms { get; set; }
    public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=../SistemaHotel.db"); 

         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
        .Entity<UserModel>(
            eb =>
            {
                eb.HasKey(pk => pk.UserID);
            });

        base.OnModelCreating(modelBuilder);
        modelBuilder
        .Entity<RoomModel>(
            eb => {
                eb.HasKey(pk => pk.RoomID);
            });

        base.OnModelCreating(modelBuilder);
        modelBuilder
        .Entity<ReserveModel> (
            eb => {
                eb.HasKey(pk => pk.ReserveID);
            });

        base.OnModelCreating(modelBuilder);
        modelBuilder
        .Entity<ReportModel> (
            eb => {
                eb.HasKey(pk => pk.ReportID);
        });
    }

}
