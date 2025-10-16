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

       

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Importacion de Empleados";
            ofd.Filter = "Fichero csv|*csv";


            FileStream fl = null;
            StreamReader sr = null;


            try
            {
                string path = "";
                if (ofd.ShowDialog() == DialogResult.OK) { path = ofd.FileName; }

                fl = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fl);
                //como el archivo tiene dos cabeceras la descartamos
                sr.ReadLine();//cabecera 1
                sr.ReadLine();//cabecera 2

                while (sr.EndOfStream == false)
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
                if(fl != null) fl.Close();
                if (sr != null) sr.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                string path = null;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    path = sfd.FileName;
                    fs = new FileStream(path, FileMode.OpenOrCreate , FileAccess.Write);
                    sw = new StreamWriter(fs);
                    /* if (empleadosImportados != null)
                     {
                         foreach (Empleado em in empleadosImportados)
                         {
                             try
                             {
                                 if (em is Asalariado) { sw.WriteLine(((Asalariado)em).Exportar()); }

                             }catch(Exception ex) { MessageBox.Show(ex.Message,"Error en Asalariado"); }
                             try
                             {
                                 if (em is Jornalero) { sw.WriteLine(((Jornalero)em).Exportar()); }

                             }catch(Exception ex) { MessageBox.Show(ex.Message, "Error en Jornalero"); }

                         }

                     }*/

                    foreach (Empleado em in empleadosImportados)
                    {
                        if (em is IExportable exportable)
                        {
                            sw.WriteLine(exportable.Exportar());
                        }
                    }


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if (sw != null) sw.Close();
                if (fs != null) fs.Close();
            }
        }

        private void lbResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Empleado emSelect = lbResultados.SelectedItem as Empleado;
            FMostrar VMostrar = null;
            try
            {
                if (emSelect != null)
                {
                    VMostrar = new FMostrar();
                    foreach (string linea in emSelect.GenerarRecibo())
                    {
                        VMostrar.lbMostrar.Items.Add(linea);
                    }
                    VMostrar.ShowDialog();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if (VMostrar != null)
                {
                    VMostrar.Dispose();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            foreach (Empleado em in empleadosImportados)
            {
                if (em != null)
                {
                    foreach(string linea in em.GenerarRecibo())
                    lbResultados.Items.Add(linea);
                }
                lbResultados.Items.Add("");
            }
        }
    }
}
