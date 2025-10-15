using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal interface IExportable
    {
        string Exportar(); // Para exportar al archivo .txt
        void Importar(string datos); // Para mostrar en pantalla o imprimir
    }
}
