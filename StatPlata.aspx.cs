using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.Web;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class StatPlata : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            string cale = Server.MapPath("CrystalReport2.rpt");
            raport.Load(cale);
            raport.SetDataSource(ds.Tables["salariati"]);
            CrystalReportViewer1.ReportSource = raport;

            DiskFileDestinationOptions fisier = new DiskFileDestinationOptions();
            raport.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            raport.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            fisier.DiskFileName = Server.MapPath("stat_plata.pdf");
            raport.ExportOptions.ExportDestinationOptions = fisier;
            raport.Export();
            lblError.Text = " Fisierul stat_plata.pdf a fost generat cu succes!";
            lblError.ForeColor = System.Drawing.Color.Green;
        }
        catch (Exception ex)
        {
            lblError.Text = "Raportul nu a fost generat! ";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }

}