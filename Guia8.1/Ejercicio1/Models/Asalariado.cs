using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Asalariado : Empleado,IExportable
    {
        public decimal Basico { get; private set; }
        public decimal AportesPrevisionales { get; private set; }

        public Asalariado():base() { }

        public Asalariado(string dni, string nombre, decimal basico, decimal aportes)
            : base(dni, nombre)
        {
            Basico = basico;
            AportesPrevisionales = aportes;
        }

        public override decimal CalcularImporteAPagar()
        {
            return Basico - AportesPrevisionales;
        }
        public override string[] GenerarRecibo()
        {
            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public string Exportar()
        {
            throw new NotImplementedException();
        }

        public void Importar(string datos)
        {
            //Tipo:Asalariado;DNI;Nombre;Básico,Aportes provisionales

            string linea = datos.Trim();
            string[] grupo = linea.Split(';');

            if (grupo.Length == 5)
            {
                base.DNI = grupo[1];
                base.Nombre = grupo[2];
                Basico = Convert.ToDecimal(grupo[3]);
                AportesPrevisionales = Convert.ToDecimal(grupo[4]);
            }
        }
    }
}
