using ACMDotNetCore.PizzaAPI.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using ACMDotNetCore.Shared;
using Dapper;
using Microsoft.AspNetCore.Components.Web;
using ACMDotNetCore.PizzaAPI.Queries;
using System.Collections.Generic;

namespace ACMDotNetCore.PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly DapperService _drapperService;

        public PizzaController()
        {
            _appDbContext = new AppDbContext();
            _drapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }
        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtraAsync()
        {
            var lst = await _appDbContext.ExtraPizzas.ToListAsync();
            return Ok(lst);
        }
        [HttpPost("Order")]
        public async Task<IActionResult> OrderAysnc(OrderRequest orderRequest)
        {
            var itemPizza=await _appDbContext.Pizzas.FirstOrDefaultAsync(x=>x.PizzaId==orderRequest.PizzaId);
            var total = itemPizza!.Price;

            if(orderRequest.ExtraPizzaId.Length>0)
            {
                var lstExtra=await _appDbContext.ExtraPizzas.Where(x=>orderRequest.ExtraPizzaId.Contains(x.ExtraPizzaId)).ToListAsync();
                total += lstExtra.Sum(x => x.ExtraPrice);
            }
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrdermodel = new PizzaOrderModel()
            { 
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo= invoiceNo,
                TotalAmount=total,
            };
            List<PizzaOrderDetailModel> pizzaExtraModel = orderRequest.ExtraPizzaId.Select(extralid => new PizzaOrderDetailModel
            {
                ExtraPizzaId = extralid,
                PizzaOrderInvoiceNo = invoiceNo,
            }).ToList();

            await _appDbContext.PizzaOrder.AddAsync(pizzaOrdermodel);
            await _appDbContext.PizzaOrderDetail.AddRangeAsync(pizzaExtraModel);
            await _appDbContext.SaveChangesAsync();

            OrderRespon respon = new OrderRespon()
            {
                InvoiceNo = invoiceNo,
                Message = "Thank you for your order! Enjoy your pizza",
                TotalAmount = total
            };
                 
            return Ok(respon);
        }
        [HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult> GetOrder(string invoiceNo)
        {
            var item = _drapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
                        (
                            PizzaQurey.PizzaOrderQuery,
                            new { PizzaOrderInvoiceNo = invoiceNo}
                        );
            var lst = _drapperService.Query<PizzaOrderInvoiceDetailModel>
                        (
                        PizzaQurey.PizzaOrderDetailQuery,new { PizzaOrderInvoiceNo = invoiceNo}
                        );
            var model = new PizzaOrderRespone
            {
                Order = item,
                OrderDetail = lst
            };    
             return Ok(model);
            //var item = await _appDbContext.PizzaOrder.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
            //var lst = await _appDbContext.PizzaOrderDetail.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
        }
    }
}
