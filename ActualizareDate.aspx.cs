using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.Web;
using System.Data;
public partial class ActualizareDate : System.Web.UI.Page
{
    OracleConnection conn;
    OracleCommand cmd;
    OracleDataAdapter da;
    DataSet ds;
    string str, str1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                Panel1.Visible = false;
                conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
                str = "SELECT * FROM salariati";
                da = new OracleDataAdapter(str, conn);
                ds = new DataSet();
                da.Fill(ds, "salariati");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblError.Text = "Nu exista angajati in baza de date!";
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Tabela angajatilor nu exista in baza de date!";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btnCauta_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
            str = "SELECT * FROM salariati WHERE nume='" + txtNumeCautat.Text + "'";
            da = new OracleDataAdapter(str, conn);
            ds = new DataSet();
            da.Fill(ds, "salariati");
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblError.Text = "Nu exista niciun angajat cu numele '" + txtNumeCautat.Text + "'!";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // ** Afişează datele
                GridView1.DataSource = ds.Tables["salariati"].DefaultView;
                GridView1.DataBind();

                Panel1.Visible = true;
                txtId.Enabled = false;
                btnUpdate.Enabled = false;

                lblError.Text = "Selectati angajatul pentru a-i actualiza datele!";
                lblError.ForeColor = System.Drawing.Color.Blue;
            }

            txtId.Text = "";
            txtNume.Text = "";
            txtPrenume.Text = "";
            txtFunctie.Text = "";
            txtSalar.Text = "";
            txtSpor.Text = "";
            txtPremii.Text = "";
            txtRetineri.Text = "";

        }
        catch (Exception ex)
        {
            lblError.Text = " Introduceti numele angajatului pe care doriti sa-l cautati. ";
            lblError.ForeColor = System.Drawing.Color.Blue;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblError.Text = "";

        txtId.Text = GridView1.SelectedRow.Cells[1].Text;
        txtNume.Text = GridView1.SelectedRow.Cells[2].Text;
        txtPrenume.Text = GridView1.SelectedRow.Cells[3].Text;
        txtFunctie.Text = GridView1.SelectedRow.Cells[4].Text;
        txtSalar.Text = GridView1.SelectedRow.Cells[5].Text;
        txtSpor.Text = GridView1.SelectedRow.Cells[6].Text;
        txtPremii.Text = GridView1.SelectedRow.Cells[7].Text;
        txtRetineri.Text = GridView1.SelectedRow.Cells[13].Text;

        btnUpdate.Enabled = true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
            conn.Open();

            str = "UPDATE salariati SET nume = '" + txtNume.Text + "', prenume = '" + txtPrenume.Text + "', functie = '" + txtFunctie.Text + "', salar_baza = " + txtSalar.Text + ", spor = " + txtSpor.Text + ", premii_brute  = " + txtPremii.Text + ", retineri  = " + txtRetineri.Text + " WHERE id = " + txtId.Text;
            cmd = new OracleCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            //aici se poate evental reincarca (Refresh) DataGrid
            str1 = "SELECT * FROM salariati WHERE nume = '" + txtNume.Text + "' AND prenume = '" + txtPrenume.Text + "'";
            da = new OracleDataAdapter(str1, conn);
            ds = new DataSet();
            da.Fill(ds, "salariati");
            GridView1.DataSource = ds.Tables["salariati"].DefaultView;
            GridView1.DataBind();

            lblError.Text = "Datele au fost actualizate cu succes!";
            lblError.ForeColor = System.Drawing.Color.Green;

            txtId.Text = "";
            txtNume.Text = "";
            txtPrenume.Text = "";
            txtFunctie.Text = "";
            txtSalar.Text = "";
            txtSpor.Text = "";
            txtPremii.Text = "";
            txtRetineri.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = "Actualizarea datelor a esuat!";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtNumeCautat.Text = "";
        txtId.Text = "";
        txtNume.Text = "";
        txtPrenume.Text = "";
        txtFunctie.Text = "";
        txtSalar.Text = "";
        txtSpor.Text = "";
        txtPremii.Text = "";
        txtRetineri.Text = "";
        btnUpdate.Enabled = false;
    }
}