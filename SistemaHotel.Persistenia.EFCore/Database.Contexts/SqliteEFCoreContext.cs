using System;
using Microsoft.EntityFrameworkCore;
using SistemaHotel.Modelo.Basicas;

namespace SistemaHotel.Persistencia.EFCore.Database.Contexts;

public class SqliteEFCoreContext : DbContext
{

    // public SqliteEFCoreContext(DbContextOptions<SqliteEFCoreContext> options) : base(options)
    // {}

    public DbSet<UsuarioModelo> Usuarios {get;set;}
    public DbSet<QuartoModelo> Quartos {get;set;}
    public DbSet<ReservaModelo> Reservas {get;set;}
    public DbSet<RelatorioModelo> Relatorios {get;set;}

    // public string DbPath { get; }$"Data Source=C:\\Área de Trabalho\\Projeto_Tds\\SistemaHotel.Persistencia.EFCore\\SistemaHotel.db"

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=../SistemaHotel.Persistenia.EFCore/SistemaHotel.db"); 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
        .Entity<UsuarioModelo>(
            eb =>
            {
                eb.HasKey(pk => pk.UsuarioID);
            });

        base.OnModelCreating(modelBuilder);
        modelBuilder
        .Entity<QuartoModelo>(
            eb => {
                eb.HasKey(pk => pk.QuartoID);
            });

        base.OnModelCreating(modelBuilder);
        modelBuilder
        .Entity<ReservaModelo> (
            eb => {
                eb.HasKey(pk => pk.ReservaID);
            });

        base.OnModelCreating(modelBuilder);
        modelBuilder
        .Entity<RelatorioModelo> (
            eb => {
                eb.HasKey(pk => pk.RelatorioID);
        });
    }
}
