using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Asalariado : Empleado
    {
        public decimal Basico { get; set; }
        public decimal AportesPrevisionales { get; set; }

        public Asalariado(string dni, string nombre, decimal basico, decimal aportes)
            : base(dni, nombre)
        {
            Basico = basico;
            AportesPrevisionales = aportes;
        }

        public override decimal CalcularSueldo()
        {
            return Basico - AportesPrevisionales;
        }
    }
}
