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

        List<Tecnico> listaTecnicosEnEvento  = new List<Tecnico>();
        List<Persona> listaPersonasEnEvento = new List<Persona>(); 


        public Evento(DateTime fecha, string nombreEvento)
        {
            Fecha = fecha;
            NombreEvento = nombreEvento;
        }
        public void  RegistrarExportable(IExportable exportable) 
        {
            if (exportable == null) return;
            try
            {
                // comparar de que tipo es el argumento si persona o tecnico y guardarlo en la lista correspondiente
                if (exportable is Tecnico)
                {
                    Tecnico tecnico = exportable as Tecnico;
                    bool existeTecnico = listaTecnicosEnEvento.Any(tecnicosEnLista => tecnicosEnLista.CUIT == tecnico.CUIT); // compruebo si existe el tecnico en la lista
                    if (existeTecnico) return; // podria lanzar un error? throw new tecnicoExiteExceptio("TECNICO YA SE ENCUENTRA REGISTRADP"); ???

                    listaTecnicosEnEvento.Add(tecnico);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar Tecnico");
            }
                try
                {
                    if (exportable is Persona)
                    {
                        Persona person = exportable as Persona;
                        bool existePersona = listaPersonasEnEvento.Any(personaEnLista => personaEnLista.DNI == person.DNI);
                        if (existePersona) return; // lo mismo aca lanzar una validacion o msj de que ya existe la persona en la lista

                        listaPersonasEnEvento.Add(person);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error al registrar Persona"); }
            
        
        }


        public List<IExportable> VerExportables() // aca debo unir las dos listas en una y retornarla
        
        { 
            List<IExportable> listaExportable = new List<IExportable>();

            foreach(Tecnico tec in listaTecnicosEnEvento)
            {
                if(tec is IExportable) listaExportable.Add(tec as IExportable);
            }
            foreach (Persona per in listaPersonasEnEvento)
            {
                if (per is IExportable) { listaExportable.Add(per as IExportable); } 
            }


            return listaExportable;
        } 

        public override string ToString()
        {
            return $"{NombreEvento} - Fecha {Fecha:dd/MM/yyyy}";
        }
    }
}
