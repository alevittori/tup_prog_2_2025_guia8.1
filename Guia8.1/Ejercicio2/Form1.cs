using Ejercicio2.Models;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        List<Evento> eventosRegistrados;

        #region Metodos Auxiliares
        void ListarEventosRegistrados()
        {
            lbDetalles.Items.Clear();
            foreach (Evento evento in eventosRegistrados) { lbDetalles.Items.Add(evento); }

        }



        #endregion
        public Form1()
        {
            InitializeComponent();
            eventosRegistrados = new List<Evento>();
        }

        private void btnAltaEvento_Click(object sender, EventArgs e)
        {
            
            DateTime dia = dtpFecha.Value.Date;
            string nombre = tbNombreEvento.Text;
            
            if(string.IsNullOrEmpty(nombre) )
            {
                MessageBox.Show("Debe ingresar un nombre para el evento.", "Nombre vacío");
                return;
            }    
            //debemos validar que no exita el evento
            bool nombreExite = eventosRegistrados.Any(ev => ev.NombreEvento.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if(nombreExite ) { MessageBox.Show("Ya existe un evento con ese nombre", "Mismo Nombre"); return; }


            //despues podriamos validar que no se solapen con alguno con la misma fecha
            bool fechaOcupada = eventosRegistrados.Any(evento => evento.Fecha.Date == dia);
            if (fechaOcupada) { MessageBox.Show("Ya existe un evento registrado para esa fecha", "Fecha Ocupada"); return;}



            Evento nuevoEvento = new Evento(dia, nombre);
            eventosRegistrados.Add(nuevoEvento);
            MessageBox.Show($"El evento: {nuevoEvento.NombreEvento} se registro con exito.", "Bien Hecho!");
            ListarEventosRegistrados();

        }
    }
}
