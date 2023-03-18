using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.Web;
using System.Data;

public partial class ModificareProcente : System.Web.UI.Page
{
    OracleConnection conn;
    OracleCommand cmd;
    OracleDataReader dr;
    OracleDataAdapter da;
    DataSet ds;
    string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnCancel.Visible = false;
            btnActualizare.Visible = false;
            txtImpozit.Visible = false;
            txtCASS.Visible = false;
            txtCAS.Visible = false;
            lblCAS.Visible = false;
            lblCASS.Visible = false;
            lblImp.Visible = false;

            txtParola.Visible = true;
            btnPass.Visible = true;
            lblPass.Visible = true;
        }
    }

    protected void btnPass_Click(object sender, EventArgs e)
    {
        try
        {
            conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
            conn.Open();
            str = "SELECT parola FROM procente WHERE parola = '" + txtParola.Text + "'";
            cmd = new OracleCommand(str, conn);

            dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                lblEroare.Text = "Parola este gresita!";
                lblEroare.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                btnActualizare.Enabled = true;
                lblEroare.Text = "Parola este corecta! Acum puteti modifica procentele!";
                lblEroare.ForeColor = System.Drawing.Color.Green;


                //conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=munty;PERSIST SECURITY INFO=True;USER ID=MUNTY");
                str = "SELECT cas, cass, impozit FROM procente WHERE parola = '" + txtParola.Text + "'";
                cmd = new OracleCommand(str, conn);
                dr = cmd.ExecuteReader();
                //citire o linie (prima linie returnata de Select)
                dr.Read();

                float cas, cass, imp;
                cas = float.Parse(dr["cas"].ToString()) * 100;
                cass = float.Parse(dr["cass"].ToString()) * 100;
                imp = float.Parse(dr["impozit"].ToString()) * 100;

                //popularea textbox-urilor
                txtCAS.Text = cas.ToString();
                txtCASS.Text = cass.ToString();
                txtImpozit.Text = imp.ToString();

                dr.Close();

                btnCancel.Visible = true;
                btnActualizare.Visible = true;
                txtImpozit.Visible = true;
                txtCASS.Visible = true;
                txtCAS.Visible = true;
                lblCAS.Visible = true;
                lblCASS.Visible = true;
                lblImp.Visible = true;

                txtParola.Visible = false;
                btnPass.Visible = false;
                lblPass.Visible = false;

            }

            dr.Close();
            conn.Close();

        }
        catch (Exception ex)
        {
            lblEroare.Text = "Parola este gresita!";
            lblEroare.ForeColor = System.Drawing.Color.Red;
        }

    }

    protected void btnActualizare_Click(object sender, EventArgs e)
    {
        try
        {
            conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
            conn.Open();
            float cas, cass, imp;
            cas = float.Parse(txtCAS.Text) / 100;
            cass = float.Parse(txtCASS.Text) / 100;
            imp = float.Parse(txtImpozit.Text) / 100;

            str = "UPDATE procente SET cas = " + cas + ", cass = " + cass + ", impozit = " + imp;
            cmd = new OracleCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            lblEroare.Text = "Procentele au fost actualizate cu succes!";
            lblEroare.ForeColor = System.Drawing.Color.Green;

        }
        catch (Exception ex)
        {
            lblEroare.Text = "Eroare " + ex.ToString();
            lblEroare.ForeColor = System.Drawing.Color.Red;
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel.Visible = false;
        btnActualizare.Visible = false;
        txtImpozit.Visible = false;
        txtCASS.Visible = false;
        txtCAS.Visible = false;
        lblCAS.Visible = false;
        lblCASS.Visible = false;
        lblImp.Visible = false;

        txtParola.Visible = true;
        btnPass.Visible = true;
        lblPass.Visible = true;

        lblEroare.Text = "";
    }
}