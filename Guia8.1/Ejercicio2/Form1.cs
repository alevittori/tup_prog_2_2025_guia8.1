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

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe ingresar un nombre para el evento.", "Nombre vacío");
                return;
            }
            //debemos validar que no exita el evento
            bool nombreExite = eventosRegistrados.Any(ev => ev.NombreEvento.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (nombreExite) { MessageBox.Show("Ya existe un evento con ese nombre", "Mismo Nombre"); return; }


            //despues podriamos validar que no se solapen con alguno con la misma fecha
            bool fechaOcupada = eventosRegistrados.Any(evento => evento.Fecha.Date == dia);
            if (fechaOcupada) { MessageBox.Show("Ya existe un evento registrado para esa fecha", "Fecha Ocupada"); return; }



            Evento nuevoEvento = new Evento(dia, nombre);
            eventosRegistrados.Add(nuevoEvento);
            MessageBox.Show($"El evento: {nuevoEvento.NombreEvento} se registro con exito.", "Bien Hecho!");
            ListarEventosRegistrados();

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            //Importar el listado de técnicos y expositores, según el evento seleccionado desde el listbox de eventos

            //1 debo seleccionar el evento en el listBox
            //2 buscarlo en la lista de eventosRegistrados
            //3 debo abrir un opendDialog para obtener el archivo con los datos a importar
            //4 abrir un flujo de lectura
            //5 validar los datos de cada linea, para ver si es Tecnico, o Expositor
            //6 instanciar un objeto segun el tipo que corresponda y luego llamar al metodo registrarExportable de la clase evento

            // 1. Validar selección de evento
            if (lbDetalles.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un evento.", "Evento no seleccionado");
                return;
            }

            Evento eventoSeleccionado = lbDetalles.SelectedItem as Evento;
            Evento eventoReal = eventosRegistrados.FirstOrDefault(eve => eve.Fecha == eventoSeleccionado.Fecha && eve.NombreEvento.Equals(eventoSeleccionado.NombreEvento, StringComparison.OrdinalIgnoreCase)); // esto me asegura que estoy usando la referencia al objeto en mi List que luego puedo llegar a serializar o exportar, para tener una persistencia en los datos.

            // 2. Abrir OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            openFileDialog.Title = "Seleccionar archivo de técnicos y expositores";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            // 3. Leer archivo línea por línea
            try
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string linea;
                    int lineaActual = 0;

                    while ((linea = reader.ReadLine()) != null)
                    {
                        lineaActual++;
                        if (lineaActual <= 2) continue; // Saltar encabezados

                        string[] partes = linea.Split(';');
                        if (partes.Length < 4)
                        {
                            MessageBox.Show($"Línea inválida en el archivo: {linea}", "Error de formato");
                            continue;
                        }

                        string tipo = partes[0].Trim().ToUpper();

                        if (tipo == "TECNICO")
                        {
                            // ACA DEBERIAMOS USAR LOS METODOS LEER O ESCRIBIR ???

                            Tecnico tecnico = new Tecnico();
                            tecnico.Leer(partes);
                            eventoReal.RegistrarExportable(tecnico);
                        }
                        else if (tipo == "EXPOSITOR")
                        {
                            // ACA DEBERIAMOS USAR LOS METODOS LEER O ESCRIBIR ???
                            Expositor expositor = new Expositor();
                            expositor.Leer(partes);


                            eventoReal.RegistrarExportable(expositor);
                        }
                        else
                        {
                            MessageBox.Show($"Tipo desconocido en línea {lineaActual}: {tipo}", "Error de tipo");
                        }
                    }

                    MessageBox.Show("Importación completada correctamente.", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar: {ex.Message}", "Error");
            }


        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarEventosRegistrados();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //ahora debemos ahcer algo parecido al btnImportar
            // pero con el metodo Escribir para hacer la exportacion por el evento seleccionado
            // 1. Validar selección de evento
            if (lbDetalles.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un evento.", "Evento no seleccionado");
                return;
            }

            Evento eventoSeleccionado = lbDetalles.SelectedItem as Evento;
            Evento eventoReal = eventosRegistrados.FirstOrDefault(eve =>
                eve.Fecha == eventoSeleccionado.Fecha &&
                eve.NombreEvento.Equals(eventoSeleccionado.NombreEvento, StringComparison.OrdinalIgnoreCase));

            if (eventoReal == null)
            {
                MessageBox.Show("No se encontró el evento en la lista principal.", "Error");
                return;
            }

            List<IExportable> aExportar = eventoReal.VerExportables();
            if (aExportar.Count == 0)
            {
                MessageBox.Show("No hay personas registrados para exportar.", "Sin datos");
                return;
            }

            // 2. Abrir SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo CSV (*.csv)|*.csv";
            saveFileDialog.Title = $"Exportar asistentes del evento {eventoReal.NombreEvento}";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            // 3. Escribir archivo
            try
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    // Encabezados
                    writer.WriteLine("Tipo:TECNICO;CUIT;Nombre;Cargo");
                    writer.WriteLine("Tipo:EXPOSITOR;DNI;Nombre;PapelProtagonico");

                    foreach (IExportable exportable in aExportar)
                    {
                        writer.WriteLine(exportable.Escribir()); // polimorfismo
                    }

                    MessageBox.Show("Exportación completada correctamente.", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error");
            }
        }
    }
}
