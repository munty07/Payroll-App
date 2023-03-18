using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class AdaugareAngajati : System.Web.UI.Page
{
    OracleParameter p1, p2, p3, p4, p5, p6, p7, p8;
    OracleConnection conn;
    OracleCommand cmd;
    OracleDataReader dr;
    string str;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile != null)
            {
                conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
                conn.Open();

                p1 = new OracleParameter();
                p2 = new OracleParameter();
                p3 = new OracleParameter();
                p4 = new OracleParameter();
                p5 = new OracleParameter();
                p6 = new OracleParameter();
                p7 = new OracleParameter();
                p8 = new OracleParameter();

                //Creare PostedFile (upload)
                HttpPostedFile File1 = FileUpload1.PostedFile;
                //Creare sir byte Array de lungimea fisierului
                byte[] Data = new Byte[File1.ContentLength];
                //Scriere continut fisier in sirul de bytes
                File1.InputStream.Read(Data, 0, File1.ContentLength);


                p1.Value = txtNume.Text;
                p2.Value = txtPrenume.Text;
                p3.Value = txtFunctie.Text;
                p4.Value = txtSalarBaza.Text;
                p5.Value = txtSpor.Text;
                p6.Value = txtPremiiBrute.Text;
                p7.Value = txtRetineri.Text;
                p8.Value = Data;


                str = "INSERT INTO salariati (nume, prenume, functie, salar_baza, spor, premii_brute, retineri, poza) VALUES(:1, :2, :3, :4, :5, :6, :7, :8)";
                cmd = new OracleCommand(str, conn);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.ExecuteNonQuery();


                //preluare date din BD
                str = "SELECT total_brut, cas, cass, brut_impozabil, impozit, virat_card FROM salariati WHERE nume ='" + txtNume.Text + "'AND prenume = '" + txtPrenume.Text + "'";
                cmd = new OracleCommand(str, conn);
                dr = cmd.ExecuteReader();
                //citire o linie (prima linie returnata de Select)
                dr.Read();

                //popularea textbox-urilor
                txtTotalBrut.Text = dr["total_brut"].ToString();
                txtCAS.Text = dr["cas"].ToString();
                txtCASS.Text = dr["cass"].ToString();
                txtBrutImpozabil.Text = dr["brut_impozabil"].ToString();
                txtImpozit.Text = dr["impozit"].ToString();
                txtViratCard.Text = dr["virat_card"].ToString();

                dr.Close();
                conn.Close();

                lblError.Text = "Angajatul a fost adaugat cu succes!";
                lblError.ForeColor = System.Drawing.Color.Green;

                try
                {
                    conn.Open();

                    str = "SELECT poza FROM salariati WHERE nume = '" + txtNume.Text + "' AND prenume = '" + txtPrenume.Text + "'";
                    cmd = new OracleCommand(str, conn);
                    //DataReader
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    //daca a fost incarcata o poza..
                    if (FileUpload1.HasFile)
                    {
                        BinaryWriter Writer = null;
                        string Name = AppDomain.CurrentDomain.BaseDirectory.ToString() + "/imgAngajati/Poza-" + txtNume.Text + "-" + txtPrenume.Text + ".jpg";
                        Writer = new BinaryWriter(File.OpenWrite(Name));
                        Writer.Write((byte[])dr["poza"]);
                        Writer.Flush();
                        Writer.Close();
                        Image1.ImageUrl = "/imgAngajati/Poza-" + txtNume.Text + "-" + txtPrenume.Text + ".jpg";
                    }
                    else
                    {
                        Image1.ImageUrl = "~/img/profile.jpg";
                    }

                    dr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Image1.ImageUrl = "~/img/profile.jpg";
                }

            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Introduceti toate datele care sunt marcare cu steluta(*) !!";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtNume.Text = "";
        txtPrenume.Text = "";
        txtFunctie.Text = "";
        txtSalarBaza.Text = "";

        txtSpor.Text = "0";
        txtPremiiBrute.Text = "0";
        txtRetineri.Text = "0";

        txtTotalBrut.Text = "";
        txtCAS.Text = "";
        txtCASS.Text = "";
        txtBrutImpozabil.Text = "";
        txtImpozit.Text = "";
        txtViratCard.Text = "";

        lblError.Text = "";

        Image1.ImageUrl = "~/img/profile.jpg";
    }

}