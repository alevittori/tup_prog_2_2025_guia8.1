using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal interface IExportable
    {
        string ExportarLinea(); // Para exportar al archivo .txt
        string GenerarRecibo(); // Para mostrar en pantalla o imprimir
    }
}
