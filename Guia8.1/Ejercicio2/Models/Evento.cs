using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Evento
    {
        public DateTime Fecha { get; private set; }
        public string NombreEvento { get; private set;}

        public Evento(DateTime fecha, string nombreEvento)
        {
            Fecha = fecha;
            NombreEvento = nombreEvento;
        }
        public void  RegistrarExportable(IExportable exportable) { }
        public List<IExportable> VerExportables() {  return new List<IExportable>(); } //IMPLEMENTAR
    }
}
