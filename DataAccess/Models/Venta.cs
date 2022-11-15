using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
        [Column("VALOR_TOTAL")]
        public decimal ValorTotal { get; set; }
        [Column("ID_PRODUCTO")]
        public int id_producto { get; set; }
        [Column("ID_CLIENTE")]
        public int id_cliente { get; set; }
    }
}
