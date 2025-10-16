using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Jornalero : Empleado,IExportable
    {
        public int HorasTrabajadas { get; set; }
        public decimal ImportePorHora { get; set; }
        public decimal Retenciones { get; set; }

        public decimal ACobrar {  get { return CalcularImporteAPagar(); } }
        public string TipoEmpleado { get { return "Jornalero"; } }

        public Jornalero() { }

        public Jornalero(string dni, string nombre, int horas, decimal importeHora, decimal retenciones)
            : base(dni, nombre)
        {
            HorasTrabajadas = horas;
            ImportePorHora = importeHora;
            Retenciones = retenciones;
        }

        public override decimal CalcularImporteAPagar()
        {
            return (HorasTrabajadas * ImportePorHora) - Retenciones;
        }
        public override string[] GenerarRecibo()
        {
            string[] recibo = new string[5];

            recibo[0] = $"📄 RECIBO DE PAGO - {TipoEmpleado}";
            recibo[1] = $"Nombre: {Nombre}  - DNI: {DNI}";
            // usar Environment.NewLine al imprimir. para dejar un espacio en blanco

            recibo[2] = $"Importe en horas trabajadas:  ({HorasTrabajadas}/{ImportePorHora.ToString("F2", CultureInfo.InvariantCulture)})   {(HorasTrabajadas*ImportePorHora).ToString("F2",CultureInfo.InvariantCulture)} ";
            recibo[3] = $"Retenciones Impositivas:     - {Retenciones.ToString("F", CultureInfo.InvariantCulture)}";
            recibo[4] = $"Importe a Percibir:    {ACobrar.ToString("F2", CultureInfo.InvariantCulture)}";


            return recibo;
        }

        public override string ToString()
        {
            return $"{TipoEmpleado} - {Nombre} ({DNI}) - A cobrar: {ACobrar:C}";

        }

        public string Exportar()
        {
            //string infoExportar = $"{TipoEmpleado};{DNI};{Nombre};{HorasTrabajadas};{ImportePorHora};{Retenciones};{ACobrar}";
            //return infoExportar;

            return $"{TipoEmpleado};{DNI};{Nombre};{HorasTrabajadas};" +
           $"{ImportePorHora.ToString("F2", CultureInfo.InvariantCulture)};" +
           $"{Retenciones.ToString("F2", CultureInfo.InvariantCulture)};" +
           $"{ACobrar.ToString("F2", CultureInfo.InvariantCulture)}";



        }

        public void Importar(string datos)
        {
            //Tipo:Jornalero; DNI; Nombre; Horas Trabajadas; Importe Por Hora; Retenciones
            string linea = datos.Trim();
            string[] grupo = linea.Split(';');

            if(grupo.Length == 6 )
            {
                base.DNI = grupo[1];
                base.Nombre = grupo[2];
                HorasTrabajadas = Convert.ToInt32(grupo[3]);
                ImportePorHora = Convert.ToDecimal(grupo[4]);
                Retenciones = Convert.ToDecimal(grupo [5]);

            }

        }
    }
}
