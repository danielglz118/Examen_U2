using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_U2
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

            private void ActualizaGrid()
         {
            Datos obj = new Datos();
            DataSet ds = obj.Consulta("SELECT ID, NOMBRE AS Nombre, AP_PATERNO AS [Apellido Paterno], " +
                                      "AP_MATERNO AS [Apellido Materno], " +
                                      "TELEFONO AS Teléfono, CORREO AS Correo " +
                                      "FROM Usuarios");
            if (ds != null)
            {
                dgvUsuarios.DataSource = ds.Tables[0];
            }
        }


        private void Usuarios_Activated(object sender, EventArgs e)
        {
            ActualizaGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmActualizaUsuario actualiza = new frmActualizaUsuario(
    dgvUsuarios[0, e.RowIndex].Value.ToString(), 
    dgvUsuarios[1, e.RowIndex].Value.ToString(), 
    dgvUsuarios[2, e.RowIndex].Value.ToString(), 
    dgvUsuarios[3, e.RowIndex].Value.ToString(), 
    dgvUsuarios[4, e.RowIndex].Value.ToString(), 
    dgvUsuarios[5, e.RowIndex].Value.ToString()); 
            actualiza.Show();

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            ActualizaGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInsertarUsuario inserta = new frmInsertarUsuario();
            inserta.Show();
        }
    }
}
