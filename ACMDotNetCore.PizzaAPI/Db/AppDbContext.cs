using ACMDotNetCore.PizzaAPI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.PizzaAPI.Db
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<PizzaModel> Pizzas { get; set; }
        public DbSet<ExtraPizzaModel> ExtraPizzas { get; set; }
        public DbSet<PizzaOrderModel> PizzaOrder { get; set; }  
        public DbSet<PizzaOrderDetailModel> PizzaOrderDetail { get; set; }
    }

    [Table("Tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        [Column("PizzaId")]
        public int PizzaId { get; set; }
        [Column("PizzaName")]
        public string PizzaName { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
    }
    [Table("Tbl_ExtraPizza")]
    public class ExtraPizzaModel
    {
        [Key]
        [Column("ExtraPizzaId")]
        public int ExtraPizzaId { get; set;}
        [Column("ExtraPizzaName")]
        public string ExtraPizzaName { get; set;}
        [Column("ExtraPrice")]
        public decimal ExtraPrice { get; set; }
        public string PirceStr { get { return "$ " + ExtraPrice; } }
    }
    public class OrderRequest
    {
        public int PizzaId { get; set; }
        public int[] ExtraPizzaId { get; set; }
    }
    public class OrderRespon
    {
        public string Message { get; set; }
        public string InvoiceNo { get;set; }
        public decimal TotalAmount { get;set; }
    }
   
    [Table("Tbl_PizzaOrder")]
    public class PizzaOrderModel
    {
        [Key]
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalAmount { get; set; }
    }

    [Table("Tbl_PizzaOrderDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int ExtraPizzaId { get;set;}
    }
    public class PizzaOrderInvoiceHeadModel
    {
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalAmount { get; set; }
         public string PizzaName { get; set; }
         public decimal Price { get; set; }
    }
    public class PizzaOrderInvoiceDetailModel
    {
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int ExtraPizzaId { get; set; }
        public string ExtraPizzaName { get; set; }
        public decimal ExtraPrice { get; set; }
    }
    public class PizzaOrderRespone
    {
        public PizzaOrderInvoiceHeadModel Order { get; set; }
        public List<PizzaOrderInvoiceDetailModel> OrderDetail { get; set; }
    }

}
