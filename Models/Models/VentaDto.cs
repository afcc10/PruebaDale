using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class VentaDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorTotal { get; set; }
        public int id_producto { get; set; }
        public int id_cliente { get; set; }
    }
}
