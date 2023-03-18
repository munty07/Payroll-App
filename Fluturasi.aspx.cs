using Oracle.ManagedDataAccess.Client;
using Oracle.Web;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;

public partial class Fluturasi : System.Web.UI.Page
{
    OracleConnection conn;
    OracleDataAdapter da;
    DataSet ds;
    String str;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtNume.Focus();
        lblID.Visible = false;
        txtID.Visible = false;
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
                    lblError.Text = "Selectati angajatul pentru care doriti sa generati un raport!";
                    lblError.ForeColor = System.Drawing.Color.Blue;

                    lblID.Visible = true;
                    txtID.Visible = true;

                    // ** Afişează datele
                    GridView1.DataSource = ds.Tables["salariati"].DefaultView;
                    GridView1.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Eroare: " + ex.ToString();
        }

    }

    protected void btnGenereaza_Click(object sender, EventArgs e)
    {
        try
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
            string str = "SELECT * FROM salariati ";
            OracleDataAdapter da = new OracleDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "salariati");

            ReportDocument raport = new ReportDocument();
            string cale = Server.MapPath("CrystalReport.rpt");
            raport.Load(cale);
            raport.SetDataSource(ds.Tables["salariati"]);
            CrystalReportViewer2.ReportSource = raport;

            DiskFileDestinationOptions fisier = new DiskFileDestinationOptions();
            raport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            raport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            fisier.DiskFileName = Server.MapPath("fluturasi.pdf");
            raport.ExportOptions.ExportDestinationOptions = fisier;
            raport.Export();
            lblError.Text = " Fisierul fluturasi.pdf a fost generat cu succes!";
            lblError.ForeColor = System.Drawing.Color.Blue;

        }
        catch (Exception ex)
        {
            lblError.Text = "Eroare ";
        }
    }

    protected void btnRaport_Click(object sender, EventArgs e)
    {
        try
        {
            lblID.Visible = true;
            txtID.Visible = true;

            if (txtID.Text.Length > 0)
            {
                lblError.Text = "";
                OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
                string str = "SELECT * FROM salariati WHERE id = " + txtID.Text + " AND nume = '" + txtNume.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter(str, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "salariati");

                ReportDocument raport = new ReportDocument();
                string cale = Server.MapPath("CrystalReport.rpt");
                raport.Load(cale);
                raport.SetDataSource(ds.Tables["salariati"]);
                CrystalReportViewer2.ReportSource = raport;

                DiskFileDestinationOptions fisier = new DiskFileDestinationOptions();
                raport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                raport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                fisier.DiskFileName = Server.MapPath("fluturas_" + txtID.Text + "_" + txtNume.Text + ".pdf");
                raport.ExportOptions.ExportDestinationOptions = fisier;
                raport.Export();
                lblError.Text = " Fisierul fluturas_" + txtID.Text + "_" + txtNume.Text + ".pdf a fost generat cu succes!";
                lblError.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblError.Text = "Selectati angajatul pentru care doriti sa generati un raport sau introduceti manual ID-ul sau!";
                lblError.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            lblError.Text = "Raportul nu a fost generat!";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblID.Visible = true;
        txtID.Visible = true;
        txtID.Text = GridView1.SelectedRow.Cells[1].Text;
    }
}