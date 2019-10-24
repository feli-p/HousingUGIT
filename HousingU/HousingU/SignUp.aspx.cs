using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Drawing; 

namespace HousingU
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String nombre = tBNombre.Text;
            String correo = tBCorreo.Text;
            String psw = tBCon.Text;
            String verif = tBVerif.Text;
            Boolean aloja = CheckBox1.Checked;
            Boolean datosC = true;
            OdbcConnection con = new ConexionBD().con;
            String query = "select correo from usuario where correo = ?";
            OdbcCommand command = new OdbcCommand(query, con);
            command.Parameters.AddWithValue("Correo", correo);
            OdbcDataReader reader = command.ExecuteReader();

            foreach (TextBox tB in Form.Controls.OfType<TextBox>())
            {
                if(tB.Text == "")
                {
                    tB.BackColor = Color.FromArgb(233, 44, 44);
                    datosC = false; 
                }
                
            }
            if (reader.HasRows)
            {
                Label1.Text = "Ya existe una cuenta asociada a este correo";
                tBNombre.Text = "";
                tBCorreo.Text = "";
                tBCon.Text = "";
                tBVerif.Text = "";
                CheckBox1.Checked = false;
            }
            else if (!datosC)
            {
                Label1.Text = "Es necesario proporcionar todos los datos"; 
            }
            else if(psw != verif)
            {
                tBCon.Text = "";
                tBVerif.Text = "";
                Label1.Text = "Contraseñas no coinciden";
            }
            else
            {
                altaUsuario(nombre, correo, psw, aloja);
                con.Close();
                Response.Redirect("Inicio.aspx"); 
            }
            con.Close();

        }

        public void altaUsuario(String nombre, String correo, String psw, Boolean aloja)
        {
            OdbcConnection con = new ConexionBD().con;
            String query = "insert into Usuario values (?, ?, ?,?,?) ";
            Random r = new Random();
            int cU = 0, res, tipo = 1;
            Boolean exito = false;
            OdbcCommand comando = new OdbcCommand(query, con);
            if (aloja)
            {
                tipo = 2;
            }
            while (!exito)
            {
                cU = r.Next(1, 2147483647);
                comando.Parameters.AddWithValue("cUsuario", cU);
                comando.Parameters.AddWithValue("nombre", nombre);
                comando.Parameters.AddWithValue("correo", correo);
                comando.Parameters.AddWithValue("pwd", psw);
                comando.Parameters.AddWithValue("tipo", tipo);
                try
                {
                    res = comando.ExecuteNonQuery();
                    exito = true;
                } catch (Exception exc)
                {
                    Label1.Text = "Creando usuario...";
                }
            }
            con.Close();
        }
    }
}