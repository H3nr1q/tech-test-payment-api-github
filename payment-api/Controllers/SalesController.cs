using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using payment_api.Context;
using payment_api.Models;

namespace payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly PaymentApiContext _context;

        public SalesController(PaymentApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateSale(Sale sale)
        {
            if(sale.Products == null)
            {
                return NotFound();
            }
            _context.Add(sale);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult SearchSaleId(int id)
        {
            var result = _context.Sales.Where(v => v.Id == id).Include(p => p.Products).Include(s => s.Salesman);
            if(result == null)
                return BadRequest($"Não existe um pedido de venda com esse número {id}.");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStatusSalesId(int id, EnumStatusSales statusPedido)
        {
            var result = _context.Sales.Find(id);

            if (result == null)
                return BadRequest($"Não existe um pedido de venda com esse número {id} ");  

            var status = Convert.ToString(result.StatusPedido);
            var statusNovo = Convert.ToString(statusPedido);                          

            if((status == "Aguardando_Pagamento" && statusNovo == "Pagamento_Aprovado") || (status == "Aguardando_Pagamento" && statusNovo == "Cancelada"))
            {
                result.StatusPedido = statusPedido;

                _context.Sales.Update(result);
                _context.SaveChanges();    
                
                return Ok(result);
            } 
            else if((status == "Pagamento_Aprovado" && statusNovo == "Enviado_A_Transportadora") || (status == "Pagamento_Aprovado" && statusNovo == "Cancelada"))
            {
                result.StatusPedido = statusPedido;

                _context.Sales.Update(result);
                _context.SaveChanges();    
                
                return Ok(result);
            } 
            else if(status == "Enviado_A_Transportadora" && statusNovo == "Entregue")
            {
                result.StatusPedido = statusPedido;

                _context.Sales.Update(result);
                _context.SaveChanges();    
                
                return Ok(result);
            } 
            else
            {
                return BadRequest($"Não é permitido transitar um pedido {status} para o {statusNovo}");  
            }
        }
    }
}