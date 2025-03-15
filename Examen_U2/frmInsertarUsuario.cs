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
    public partial class frmInsertarUsuario : Form
    {
        public frmInsertarUsuario()
        {
            InitializeComponent();
        }

        private void frmInsertarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            bool f = datos.comando("INSERT INTO Usuarios (NOMBRE, AP_PATERNO, AP_MATERNO, TELEFONO, CORREO) VALUES ('" +
                txtApPaterno.Text + "', '" + txtApMaterno.Text + "', '" + txtNombre.Text + "', '" +
                txtTelefono.Text + "', '" + txtCorreo.Text + "')");

            if (f == true)
            {
                MessageBox.Show("Datos insertados", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al insertar", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string[] nombres = { "Juan", "María", "Carlos", "Ana", "Luis", "Elena", "Pedro", "Laura", "David", "Sofía", "Antonio", "Carmen" };
            string[] apellidos = { "Gómez", "Fernández", "Martínez", "Rodríguez", "Pérez", "Sánchez", "García", "López", "Vázquez", "Moreno", "Jiménez", "Hernández" };


            txtApPaterno.Text = apellidos[rnd.Next(apellidos.Length)];
            txtApMaterno.Text = apellidos[rnd.Next(apellidos.Length)];
            txtNombre.Text = nombres[rnd.Next(nombres.Length)];
            txtTelefono.Text = rnd.Next(600000000, 699999999).ToString();
            txtCorreo.Text = txtNombre.Text.ToLower() + "@correo.com";
        }
    }
}
