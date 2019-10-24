using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc; 

namespace HousingU
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String correo = tBNombre.Text;
            String contra = tBContra.Text;
            OdbcConnection con = new ConexionBD().con;
            String query = "select cUsuario from Usuario where correo  = ? and pwd = ?";
            OdbcCommand comando = new OdbcCommand(query, con);
            comando.Parameters.AddWithValue("correo", correo);
            comando.Parameters.AddWithValue("pwd", contra);
            OdbcDataReader lector = comando.ExecuteReader();
            
            if (lector.HasRows)
            {
                lector.Read();
                int cUsuario = lector.GetInt32(0);
                Session.Add("cUsuario", cUsuario);
                Response.Redirect("Inicio.aspx");
            }
            Label1.Text = "Credenciales incorrectas"; 
            tBNombre.Text = "";
            tBContra.Text = "";
            con.Close(); 

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx"); 
        }

      
    }
}