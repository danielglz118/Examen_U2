using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Examen_U2
{
    internal class Datos
    {

        private readonly string cadenaConexion = "Data Source=localhost;" +
        "integrated security=true;initial catalog=AGENDA;encrypt=false";

            private SqlConnection abrirConexion()
            {
                try
                {
                    SqlConnection conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    return conexion;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                    return null;
                }
            }

            public bool prueba()
            {
                using (SqlConnection con = abrirConexion())
                {
                    return con != null;
                }
            }

            public DataSet Consulta(string consulta)
            {
                try
                {
                    using (SqlConnection con = abrirConexion())
                    {
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(consulta, con);
                        da.Fill(ds);
                        return ds;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }

            public bool comando(string consulta)
            {
                try
                {
                    using (SqlConnection con = abrirConexion())
                    {
                        using (SqlCommand cmd = new SqlCommand(consulta, con))
                        {
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
    }
