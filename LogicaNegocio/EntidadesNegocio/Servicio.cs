﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Servicio
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int Km { get; set; }
        public DateTime FechaFin { get; set; }
        public IEnumerable<ServicioRepuesto> ListaRepuestos { get; set; } = new List<ServicioRepuesto>();
        public IEnumerable<ServicioMantenimiento> ListaMantenimientos { get; set; } = new List<ServicioMantenimiento>();
    }
}
