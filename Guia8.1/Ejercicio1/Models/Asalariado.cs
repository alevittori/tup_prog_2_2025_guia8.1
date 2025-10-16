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

        public decimal ACobrar 
        {
            get
            {
                return CalcularImporteAPagar();
            }
        }
        public string TipoEmpleado { get { return "Asalariado"; } }

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
            

            //Tipo:Asalariado;DNI;Nombre;Básico,Aportes provisionales, e agrega el monto a cobrar al final de la línea.
            //Asalariado; 45654355; Agustín; 900456,00; 6000,5

            string infoExportar = $"{TipoEmpleado};{DNI};{Nombre};{Basico};{AportesPrevisionales};{ACobrar}";
            return infoExportar;

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
