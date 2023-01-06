using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using payment_api.Models;

namespace payment_api.Context
{
    public class PaymentApiContext : DbContext
    {
        public PaymentApiContext(DbContextOptions<PaymentApiContext> options) : base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Salesman> Salesman { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("payment_api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("payment_api.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SalesmanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalesmanId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("payment_api.Models.Salesman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Salesman");
                });

            modelBuilder.Entity("payment_api.Models.Product", b =>
                {
                    b.HasOne("payment_api.Models.Sale", null)
                        .WithMany("Products")
                        .HasForeignKey("SaleId");
                });

            modelBuilder.Entity("payment_api.Models.Sale", b =>
                {
                    b.HasOne("payment_api.Models.Salesman", "Salesman")
                        .WithMany()
                        .HasForeignKey("SalesmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salesman");
                });

            modelBuilder.Entity("payment_api.Models.Sale", b =>
                {
                    b.Navigation("Products");
                });
        }

    }
}