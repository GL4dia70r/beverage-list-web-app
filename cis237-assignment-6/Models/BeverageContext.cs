//// David Allen
//// 12/15/22
//// Assignment 6
//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//#nullable disable

//namespace cis237_assignment_6.Models
//{
//    public partial class BeverageContext : DbContext
//    {
//        public BeverageContext()
//        {
//        }

//        public BeverageContext(DbContextOptions<BeverageContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Beverage> Beverages { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=barnesbrothers.ddns.net;User Id=dallen;Password=password;Database=BeverageDAllen;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<Beverage>(entity =>
//            {
//                entity.Property(e => e.Name).IsFixedLength(true);

//                entity.Property(e => e.Pack).IsFixedLength(true);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
