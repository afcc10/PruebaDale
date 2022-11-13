using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Column("Cedula")]
        public string Cedula { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Apellido")]
        public string Apellido { get; set; }
        [Column("Telefono")]
        public string Telefono { get; set; }
    }
}
