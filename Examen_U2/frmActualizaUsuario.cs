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
    public partial class frmActualizaUsuario : Form
    {
        public frmActualizaUsuario(string id, string apPaterno, string apMaterno, string nombre,
    string telefono, string correo)
        {
            InitializeComponent();
            txtId.Text = id;
            txtApPaterno.Text = apPaterno;
            txtApMaterno.Text = apMaterno;
            txtNombre.Text = nombre;
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;
        }


        private void frmActualizaUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            bool f = datos.comando("UPDATE Usuarios SET " +
                "AP_PATERNO='" + txtApPaterno.Text +
                "', AP_MATERNO='" + txtApMaterno.Text +
                "', NOMBRE='" + txtNombre.Text +
                "', TELEFONO='" + txtTelefono.Text +
                "', CORREO='" + txtCorreo.Text +
                "' WHERE ID=" + txtId.Text);

            if (f == true)
            {
                MessageBox.Show("Datos Actualizados", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Error al actualizar", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro de eliminar el registro?",
        "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Datos datos = new Datos();
                bool f = datos.comando("DELETE FROM Usuarios WHERE ID=" + txtId.Text);
                if (f == true)
                {
                    MessageBox.Show("Datos Eliminados", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar", "Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
