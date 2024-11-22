using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntregaTrabajoSemana13
{
    public partial class Form1 : Form
    {
        private List<Ciudad> Ciudades;
        private Ciudad ciudadSel = new Ciudad();
        public Form1()
        {
            InitializeComponent();
            Ciudades = new List<Ciudad>();
        }
     

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ciudad ciudad = new Ciudad();
            ciudad.ID = int.Parse(txtCodigo.Text); //obtener el ID de ciudad
            ciudad.Nombre = txtNombre.Text; //Obtener el Nombre de ciudad 

            //buscar si ya existe una ciudad con el mismo ID en la lista
            int Index = Ciudades.FindIndex(item => item.ID == ciudad.ID);

            if (Index != -1)
            {
                Ciudades[Index] = ciudad;
            }
            else
            { 
             Ciudades.Add(ciudad);
            }

            MostrarDatos();
          
        }

        private void MostrarDatos()
        {
            dvgRegistros.DataSource = null; //actualizar datos o limpiar el data gried view
            dvgRegistros.DataSource = Ciudades; //alimentando el DataGriedView con la list ciudades
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ;
            try
            {
                Ciudades.Remove(ciudadSel);
                MessageBox.Show("Ciudad eliminada...", "ciudad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


                
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Archivos DAT (*.dat)| *.dat";
                saveFileDialog1.Title = "Guardar archivo";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Ciudad_Archivo archivo = new Ciudad_Archivo();
                    archivo.GUardarArchivo(Ciudades, saveFileDialog1.FileName);
                    MessageBox.Show("Se ha guardado el archivo", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
         
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Archivos DAT (*.dat)|*dat|Todos los archivos (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = openFileDialog1.FileName;

                Ciudad_Archivo archivo = new Ciudad_Archivo();
                Ciudades = archivo.CargarCiudades(ruta);
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("No se selecciono nigun archivo. ");
            
            }
        }

        private void dvgRegistros_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvgRegistros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dvgRegistros.CurrentRow;
            if (currentRow != null)
            {
                ciudadSel.ID = int.Parse(currentRow.Cells[0].Value.ToString());
                ciudadSel.Nombre = currentRow.Cells[1].Value.ToString();
                txtCodigo.Text = ciudadSel.ID.ToString();
                txtNombre.Text = ciudadSel.Nombre;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ciudad ciudad = new Ciudad();
            ciudad.ID = int.Parse(txtCodigo.Text); //obtener el ID de ciudad
            ciudad.Nombre = txtNombre.Text; //Obtener el Nombre de ciudad 

            //buscar si ya existe una ciudad con el mismo ID en la lista
            int Index = Ciudades.FindIndex(item => item.ID == ciudad.ID);

            if (Index != -1)
            {
                Ciudades[Index] = ciudad;
            }
            else
            {
                Ciudades.Add(ciudad);
            }

            MostrarDatos();

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Archivos DAT (*.dat)| *.dat";
                saveFileDialog1.Title = "Guardar archivo";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Ciudad_Archivo archivo = new Ciudad_Archivo();
                    archivo.GUardarArchivo(Ciudades, saveFileDialog1.FileName);
                    MessageBox.Show("Se ha guardado el archivo", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Archivos DAT (*.dat)|*dat|Todos los archivos (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = openFileDialog1.FileName;

                Ciudad_Archivo archivo = new Ciudad_Archivo();
                Ciudades = archivo.CargarCiudades(ruta);
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("No se selecciono nigun archivo. ");

            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ;
            try
            {
                Ciudades.Remove(ciudadSel);
                MessageBox.Show("Ciudad eliminada...", "ciudad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
