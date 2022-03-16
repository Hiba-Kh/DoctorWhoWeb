﻿using DoctorWho.Db.Mappings;
using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<ViewEpisodes> ViewEpisodes { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) =>   
            category == DbLoggerCategory.Database.Command.Name
            && level == LogLevel.Information)
            .AddConsole();
        });
        public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options) :base(options)
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging();
            //   optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DoctorWhoCore");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpisodeCompanion>().HasKey(ec => new { ec.CompanionId, ec.EpisodeId }); 
            modelBuilder.Entity<EpisodeEnemy>().HasKey(ee => new { ee.EpisodeId, ee.EnemyId });

            modelBuilder.Entity<ViewEpisodes>().HasNoKey().ToView("viewEpisodes");
            modelBuilder.Entity<ViewEpisodes>().Property(p => p.Title).HasColumnName("Episode Title");
            modelBuilder.Entity<ViewEpisodes>().Property(p => p.AuthorName).HasColumnName("Author Name");
            modelBuilder.Entity<ViewEpisodes>().Property(p => p.DoctorName).HasColumnName("Doctor Name");

            modelBuilder.Entity<FnCompanionsResult>().HasNoKey();
            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(fnCompanion), new[] { typeof(int) }));
            modelBuilder.Entity<FnEnemiesResult>().HasNoKey();
            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(fnEnemies), new[] { typeof(int) }));

            //SET IDENTITY_INSERT Doctors ON 
           // modelBuilder.Entity<Doctor>().Property(d => d.DoctorId).ValueGeneratedOnAddOrUpdate();//.ValueGeneratedOnAdd();
        }
        public IQueryable<FnCompanionsResult> fnCompanion(int episodeId) => FromExpression(() => fnCompanion(episodeId));
        public IQueryable<FnEnemiesResult> fnEnemies(int episodeId) => FromExpression(() => fnEnemies(episodeId));


    }
}
