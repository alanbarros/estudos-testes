using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBlazor.Data.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string NomeCliente { get; set; }
        public double Valor { get; set; }
    }
}
