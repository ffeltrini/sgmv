using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El nombre del proveedor es requerido")]
        public Proveedor Proveedor { get; set; }
        public bool Recibida { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int DiasDemora { get; set; }
        public IEnumerable<Repuesto> ListaRepuestos { get; set; } = new List<Repuesto>();
        public IEnumerable<CompraRepuesto> ListaCompraRepuesto { get; set; } = new List<CompraRepuesto>();

        public void ValidarDatos()
        {
            if (Fecha > DateTime.Now)
            {
                throw new CompraException("La fecha de compra debe ser menor o igual a la fecha actual");
            }
        }
    }
}
