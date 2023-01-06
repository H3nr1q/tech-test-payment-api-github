using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.Models
{
    public class Sale
    {
        public Sale()
        {
            this.Date = DateTime.Now;
            this.StatusPedido = EnumStatusSales.Aguardando_Pagamento;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public EnumStatusSales StatusPedido {get; set;}
        public Salesman Salesman { get; set; }
        public List<Product> Products  { get; set; }    
        public int SalesmanId {get; set;}           
    }
}