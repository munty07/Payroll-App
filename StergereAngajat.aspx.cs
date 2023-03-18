using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.Web;
using System.Data;

public partial class StergereAngajat : System.Web.UI.Page
{
    OracleConnection conn;
    OracleCommand cmd;
    OracleDataAdapter da;
    DataSet ds;
    string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnRenuntare.Visible = false;
            btnStergere.Visible = false;
            lblID.Visible = false;
            txtID.Visible = false;
        }
    }

    protected void btnCauta_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNume.Text == "")
            {
                lblError.Text = " Introduceti numele angajatului cautat. ";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblError.Text = "";

                conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
                str = "SELECT * FROM salariati WHERE nume = '" + txtNume.Text + "'";
                da = new OracleDataAdapter(str, conn);
                ds = new DataSet();
                da.Fill(ds, "salariati");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblError.Text = "Nu exista angajatul cu numele " + txtNume.Text;
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblID.Visible = true;
                    txtID.Visible = true;

                    lblError.Text = "Selectati angajatul pe care doriti sa-l stergeti!";
                    lblError.ForeColor = System.Drawing.Color.Blue;

                    // ** Afişează datele
                    GridView1.DataSource = ds.Tables["salariati"].DefaultView;
                    GridView1.DataBind();
                    txtNume.Enabled = false;
                    btnRenuntare.Visible = true;
                    btnCauta.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = " Introduceti numele angajatului cautat. ";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnStergere_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
            conn.Open();
            str = "DELETE FROM salariati WHERE id = " + txtID.Text + " AND nume = '" + txtNume.Text + "'";
            cmd = new OracleCommand(str, conn);
            cmd.ExecuteNonQuery();

            lblError.Text = "Stergerea angajatului '" + txtNume.Text + "' cu id-ul: " + txtID.Text + ", a fost realizata cu SUCCES!";
            lblError.ForeColor = System.Drawing.Color.Green;

            conn.Close();



            //Refresh DataGrid
            str = "SELECT * FROM salariati WHERE nume = '" + txtNume.Text + "'";
            da = new OracleDataAdapter(str, conn);
            ds = new DataSet();
            da.Fill(ds, "salariati");
            GridView1.DataSource = ds.Tables["salariati"].DefaultView;
            GridView1.DataBind();

            txtNume.Text = "";
            txtID.Text = "";

            btnCauta.Enabled = true;
            btnStergere.Visible = false;

            lblID.Visible = false;
            txtID.Visible = false;
            txtNume.Enabled = true;
        }
        catch (Exception ex)
        {
            lblError.Text = "Selectati angajatul pe care doriti sa-l stergeti!";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
        btnStergere.Visible = true;

        txtNume.Text = GridView1.SelectedRow.Cells[2].Text;
        txtID.Text = GridView1.SelectedRow.Cells[1].Text;
    }

    protected void btnRenuntare_Click(object sender, EventArgs e)
    {
        txtNume.Enabled = true;
        txtNume.Text = "";
        txtID.Text = "";
        lblError.Text = "";

        txtID.Visible = false;
        lblID.Visible = false;

        btnStergere.Visible = false;

        btnRenuntare.Visible = false;

        GridView1.DataSource = null;
        GridView1.DataBind();

        btnCauta.Enabled = true;
    }
}