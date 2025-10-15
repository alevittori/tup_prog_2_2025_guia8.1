using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        List<Empleado> empleadosImportados = new List<Empleado>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            FileStream fl = null;
            StreamReader sr = null;
            try
            {
                string path = "";
                if (ofd.ShowDialog() == DialogResult.OK) { path = ofd.FileName; }

                fl = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fl);
                //como el archivo tiene dos cabeceras la descartamos
                sr.ReadLine();
                sr.ReadLine();

                while (sr.EndOfStream != true)
                {
                    string linea = sr.ReadLine();

                    string tipo = linea.Split(';')[0];
                    if (tipo.ToUpper() == "Asalariado".ToUpper())
                    {
                        Asalariado nuevoEmpleado = new Asalariado();
                        nuevoEmpleado.Importar(linea);
                        empleadosImportados.Add(nuevoEmpleado);
                    }
                    if (tipo.ToUpper() == "Jornalero".ToUpper())
                    {
                        Jornalero nuevoEmpleado = new Jornalero();
                        nuevoEmpleado.Importar(linea);
                        empleadosImportados.Add(nuevoEmpleado);
                    }

                }

                btnListar.PerformClick();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                sr.Close();
                fl.Close();
            }
        }


        private void btnListar_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            empleadosImportados.Sort();
            foreach (Empleado em in empleadosImportados)
            {
                lbResultados.Items.Add(em);
            }

        }
    }
}
