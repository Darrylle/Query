using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query
{
    public partial class frmTestData : Form
    {
        public frmTestData()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            
            //Initialise variables...
            //
            string strDataPath =
                        "\\\\Server_pc\\M\\1 NTFS\\Data\\Dev\\Access" +
                        "\\BAE\\TIM\\Query\\dev\\dat\\query_be.mdb";

            string strConn =
                        "Provider=Microsoft.ACE.OLEDB.12.0;" +
                        "Data Source='" + strDataPath + "';" +
                        "Persist Security Info=False;";

            string strQuery =
                        "SELECT pk " +
                        "FROM   tblEmp " +
                        "WHERE  nw_login = '" + txtEmpLogin.Text + "' " +
                        "AND    full_name = '" + txtFullName.Text + "';";
            
            //Intialise the connection criteria...
            //
            DataConnection.DataConnector dtc = 
                new DataConnection.DataConnector (strConn);

            //Connect and retrieve the query data...
            //
            DataTable dtb = dtc.DataSelect (strQuery);

            //Check and display results...
            //
            if( dtb.Rows.Count > 0)
            {
                //Show 'pk' value in first record returned [0]...
                //MessageBox.Show("User pk value = " + dtb.Rows[0]["pk"].ToString()); 
                txtResult.Text  = "User pk value = " + dtb.Rows[0]["pk"].ToString();
            }
            else
            {
                txtResult.Text  = "This user does NOT exist!";
            }
        }

    }
}
