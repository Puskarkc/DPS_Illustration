using System;
using System.Collections.Generic;
using System.ComponentModel;
//*****************************************************************************
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//*****************************************************************************
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//*****************************************************************************
using System.IO;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Manage_Data
{
    public partial class DPS : Form
    {
        public static double rateInPercent = 0;
        public DPS()
        {
            InitializeComponent();
            cmbben.SelectedIndex = 0;
        }
        private double FA;
        private double BP;
        private double CI;
        private double WP;
        private double aDDciwp;
        private int age;
        private int term;
        private int pr_mode;
        private int ci_ben;
        private double BAP;
        private double TAP;
        private string tblci;
        private string tblwp;
        private double bapMode;
        private double TMP;
        private double matV9;
        private double matan7 = 0.0;
        private double matan9 = 0.0;
        private double TAPM = 0.0;
        BusinessStrategy bm = new BusinessStrategy();
        delegate void LoadDataDelegate(string key);

        private string plan;
        private double basic;
        private int Prmode;
        private int Pterm;
        private int CCi = 0;
        private int Page;
        private double maturityV = 0.0;
        private double cici = 0.0;
       
        private void initializeteam()
        {
            plan = cmbPlan.SelectedItem.ToString();
            basic = Convert.ToDouble(txtBasic.Text);
            Prmode = Convert.ToInt32(cmbPrMode.SelectedValue);
            Pterm = Convert.ToInt32(cmbterm.SelectedItem.ToString());
            //cmbCi.SelectedIndex = 1;
            //if (plan == "GOLD" || plan == "SILVER")
            //{
            //    CCi = Convert.ToInt32(cmbCi.SelectedItem.ToString());  
            //}
            //else
            //{
            //    CCi= Convert.ToInt32(cmbCi.SelectedItem.ToString());  

            //}
            Page = Convert.ToInt32(txtAge.Text);
            if (Page < 45 && Pterm <= 12)
            {
                CCi = 100;
            }
            else
            {
                CCi = 50;
            }

        }
        private void MainCall()
        {
            if (Page < 45 && Pterm <= 12)
            {
                CCi = 100;
            }
            else
            {
                CCi = 50;
            }

            if (plan == "GOLD" || plan == "SILVER")
            {
                double CCII = 0.0;
                //groupBox2.Visible = true;
                FA = faceamount(basic,
                              Prmode,
                              Pterm);

                BAP = BasicAP(basic, Prmode);

                BAP = Math.Round(BAP, 2);
                CI = ci(FA, CCi,
                Prmode,
                Pterm,
                Page);

                // this is for CI 
                if (Math.Round(CI, 2) > 2000000)
                {

                    CCII = 2000000;
                    CI = ci(CCII, CCi,
                Prmode,
                Pterm,
                Page);
                    CCII = Math.Round(CI, 2);
                    //CCi = CCII;
                }
                else
                {
                    CCII = Math.Round(CI, 2);
                    //CCi = CCII;
                }
                if (cmbben.SelectedItem.ToString() == "CI")
                {

                    WP = 0.0;

                    int age1;
                    int term1;
                    term1 = Convert.ToInt32(cmbterm.SelectedItem.ToString());


                    age1 = Convert.ToInt32(txtAge.Text);
                    if (age1 + term1 > 60)
                    {
                        MessageBox.Show("CI Rider can be taken within the Term for 60 years (Age+Term)");
                        cmbben.SelectedIndex = 1;
                    }

                }

                if (cmbben.SelectedItem.ToString() == "NONE")
                {
                    CI = 0.0;
                    WP = 0.0;

                }
                if (cmbben.SelectedItem.ToString() == "FPR")
                {
                    CI = 0.0;


                }
                if (cmbben.SelectedItem.ToString() == "CI & FPR")
                {
                    int age1;
                    int term1;
                    term1 = Convert.ToInt32(cmbterm.SelectedItem.ToString());


                    age1 = Convert.ToInt32(txtAge.Text);
                    if (age1 + term1 > 60)
                    {
                        CI = 0.0;
                    }

                }


                bapMode = (BAP) + Math.Round(CI, 2);
                bapMode = Math.Round(bapMode, 0);


                WP = wp(bapMode,
                    CCi,
                    Prmode,
                    Pterm, Page
                    );

                if (cmbben.SelectedItem.ToString() == "CI")
                {

                    WP = 0.0;

                    int age1;
                    int term1;
                    term1 = Convert.ToInt32(cmbterm.SelectedItem.ToString());


                    age1 = Convert.ToInt32(txtAge.Text);
                    if (age1 + term1 > 60)
                    {
                        MessageBox.Show("CI Rider can be taken within the Term for 60 years (Age+Term)");
                        cmbben.SelectedIndex = 1;
                    }
                }

                if (cmbben.SelectedItem.ToString() == "NONE")
                {
                    CI = 0.0;
                    WP = 0.0;

                }

                if (cmbben.SelectedItem.ToString() == "FPR")
                {
                    CI = 0.0;


                }
                if (cmbben.SelectedItem.ToString() == "CI & FPR")
                {
                    int age1;
                    int term1;
                    term1 = Convert.ToInt32(cmbterm.SelectedItem.ToString());


                    age1 = Convert.ToInt32(txtAge.Text);
                    if (age1 + term1 > 60)
                    {
                        CI = 0.0;
                    }

                }


                aDDciwp = Math.Round(CI, 2) + Math.Round(WP, 2);
                aDDciwp = Math.Round(aDDciwp, 0);
                cici = aDDciwp / Prmode;

                TAP = Math.Round(((BAP) / Prmode), 2) + Math.Round(Math.Ceiling(cici), 2);
                cici = Math.Round(Math.Ceiling(cici), 0);
                TMP = Math.Round(TAP, 2);
                TMP = Math.Round(TMP, 0);
                TAP = Math.Round(TAP, 2);
                TAPM = (TAP * Prmode);



            }
            else if (plan == " FOR HOUSEWIFE")
            {
                //groupBox2.Visible = true;
                double CCII = 0.0;
                FA = faceamount(basic,
                              Prmode,
                              Pterm);

                BAP = BasicAP(basic, Prmode);
                BAP = Math.Round(BAP, 2);
                if (Math.Round(FA, 2) > 1500000.0)
                {
                    CCII = 1500000.0;
                    // CCi = CCII;
                }
                else
                {
                    CCII = Math.Round(FA, 2);
                    // CCi = CCII;
                }
                CI = ci(Math.Round(FA, 2), CCi,
                    Prmode,
                    Pterm,
                    Page);

                bapMode = (BAP) + Math.Round(CI, 2);
                bapMode = Math.Round(bapMode, 0);


                WP = wp(bapMode,
                    CCi,
                    Prmode,
                    Pterm, Page
                    );

                aDDciwp = Math.Round(CI, 2);//+ Math.Round(WP, 2);
                aDDciwp = Math.Round(aDDciwp, 0);
                cici = aDDciwp / Prmode;

                TAP = Math.Round(((BAP) / Prmode), 2) + Math.Round(Math.Ceiling(cici), 2);
                cici = Math.Round(Math.Ceiling(cici), 0);
                TMP = Math.Round(TAP, 2);
                TMP = Math.Round(TMP, 0);
                TAP = Math.Round(TAP, 2);
                TAPM = (TAP * Prmode);



            }
            else if (plan == "GOLD")
            {
                //label3.Visible = false;
                //cmbCi.Visible = false;
                //groupBox2.Visible = true;
                FA = faceamount(basic,
                             Prmode,
                             Pterm);

                BAP = BasicAP(basic, Prmode);
                BAP = Math.Round(BAP, 2);
                //CI = ci(Math.Round(FA, 2),
                //    Convert.ToInt32(cmbCi.SelectedItem.ToString()),
                //    Convert.ToInt32(cmbPrMode.SelectedValue),
                //    Convert.ToInt32(cmbterm.SelectedItem.ToString()),
                //    Convert.ToInt32(txtAge.Text));
                bapMode = (BAP);//+ Math.Round(CI, 2);

                //WP = wp(bapMode,
                //    Convert.ToInt32(cmbCi.SelectedItem.ToString()),
                //    Convert.ToInt32(cmbPrMode.SelectedValue),
                //    Convert.ToInt32(cmbterm.SelectedItem.ToString()),
                //    Convert.ToInt32(txtAge.Text));

                // aDDciwp = Math.Round(CI, 2) + Math.Round(WP, 2);
                //aDDciwp = Math.Round(aDDciwp, 2);

                TAP = Math.Round(BAP, 2);//+ Math.Round(aDDciwp, 2);

                TMP = Math.Round(TAP, 2) / Prmode;

                TMP = Math.Round(TMP, 2);
                TAP = Math.Round(TAP, 2);
                //label12.Text = FA.ToString();
                //label13.Text = BAP.ToString();
                ////label14.Text = aDDciwp.ToString();
                //label14.Visible = false;
                //label15.Text = TAP.ToString();
                //label18.Text = TMP.ToString();
                TAPM = (TAP * Prmode);

            }
            else
            {
                //label3.Visible = false;
                //cmbCi.Visible = false;
                //groupBox2.Visible = true;
                FA = faceamount(basic,
                              Prmode,
                              Pterm);

                BAP = BasicAP(basic, Prmode);
                BAP = Math.Round(BAP, 0);
                //CI = ci(Math.Round(FA, 2),
                //    Convert.ToInt32(cmbCi.SelectedItem.ToString()),
                //    Convert.ToInt32(cmbPrMode.SelectedValue),
                //    Convert.ToInt32(cmbterm.SelectedItem.ToString()),
                //    Convert.ToInt32(txtAge.Text));
                bapMode = (BAP);//+ Math.Round(CI, 2);

                //WP = wp(bapMode,
                //    Convert.ToInt32(cmbCi.SelectedItem.ToString()),
                //    Convert.ToInt32(cmbPrMode.SelectedValue),
                //    Convert.ToInt32(cmbterm.SelectedItem.ToString()),
                //    Convert.ToInt32(txtAge.Text));

                // aDDciwp = Math.Round(CI, 2) + Math.Round(WP, 2);
                //aDDciwp = Math.Round(aDDciwp, 2);

                TAP = Math.Round(BAP, 2);//+ Math.Round(aDDciwp, 2);

                TMP = Math.Round(TAP, 2) / Prmode;

                TMP = Math.Round(TMP, 0);
                TAP = Math.Round(TAP, 2);
                //label12.Text = FA.ToString();
                //label13.Text = BAP.ToString();
                ////label14.Text = aDDciwp.ToString();
                //label14.Visible = false;
                //label15.Text = TAP.ToString();
                //label18.Text = TMP.ToString();
                TAPM = (TAP * Prmode);
            }




        }
        private void CALL(string key)
        {

            if (plan == "")
            {
                maturityV = bm.maturity(Pterm,
                               Page, basic, FA, Prmode);
                //label21.Text = maturityV.ToString();

                matV9 = bm.maturity9(Pterm,
                                Page, basic, FA, Prmode);

                matan7 = bm.maturity7ANN(Pterm,
                                Page, basic, FA, Prmode);
                matan9 = bm.maturity9ANN(Pterm,
                                Page, basic, FA, Prmode);
                // label23.Text = matV9.ToString();
            }

            else if (plan == "SILVER")
            {
                maturityV = bm.maturityBronge(Pterm,
                               Page, basic, FA, Prmode);
                // label21.Text = maturityV.ToString();

                matV9 = bm.maturityBronge9(Pterm,
                                Page, basic, FA, Prmode);

                matan7 = bm.maturityANN7(Pterm,
                                Page, basic, FA, Prmode);
                matan9 = bm.maturityANN9(Pterm,
                                Page, basic, FA, Prmode);
                // label23.Text = matV9.ToString();

            }
            else
            {
                maturityV = bm.maturity(Pterm,
                               Page, basic, FA, Prmode);
                // label21.Text = maturityV.ToString();

                matV9 = bm.maturity9(Pterm,
                                Page, basic, FA, Prmode);

                matan7 = bm.maturity7ANN(Pterm,
                                Page, basic, FA, Prmode);
                matan9 = bm.maturity9ANN(Pterm,
                                Page, basic, FA, Prmode);

                //label23.Text = matV9.ToString();
            }

        }
        //declare a delegate to call the Display Wait method
        delegate void DisplayWaitDelegate(bool boolDisplay);
        string strConn = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            
            rateInPercent = Convert.ToDouble(txtBoxRateInPercent.Text);
            lblMaturityRate.Text = "Maturity Value @ " + rateInPercent.ToString() +"%";
            rateInPercent = rateInPercent / 100;
            if (this.validate() && this.housewife())
            {
                this.initializeteam();
                this.MainCall();
                if (!this.valid())
                {
                    EmptyTextBoxes(groupBox1);
                    Emptycom(groupBox1);
                    txtName.Focus();
                    button3.Visible = false;
                    button4.Visible = false;
                    txtName.Text = "";
                    txtName.Focus();

                }
                else
                {
                    this.DisplayWait(true);

                    //this.Displayshow(false);
                    LoadDataDelegate delLoadData = new LoadDataDelegate(CALL);


                    string key = "Process is running";
                    //Since we want to call the Load function asynchronously on another thread, use BeginInvoke. The next
                    //argument is the function name being called once this thread is completed
                    delLoadData.BeginInvoke(key, this.LoadComplete, delLoadData);


                }

                //this.show();

            }
            else
            {
                //MessageBox.Show("Please Provide valid Information");
            }



        }


        public void LoadData(string key)
        {





        }

        #region ALL FORMULA
        private double faceamount(double basicP, int pMode, int term)
        {
            double fAmount = (basicP * pMode * term);
            return fAmount;

        }
        private double Basik(double FA, int pMode, int term)
        {
            double basic = ((FA) / (pMode * term));
            return basic;
        }
        private void calcage()
        {
            int age = Convert.ToInt32((DateTime.Now.Subtract(Convert.ToDateTime(dateTimePicker1.Text)).Days));
            double age1 = Math.Round(Convert.ToDouble(age) / 365);
            age = Convert.ToInt32(age1);

            Page = age;
            this.txtAge.Text = age.ToString();



        } ///age calculation



        private double BasicAP(double basicP, int pMode)
        {
            double bap = (basicP * pMode);
            return bap;

        }

        private double ci(double fa, int ci, int pMode, int term, int age)
        {
            double ciMain;
            double cip = ((Convert.ToDouble(ci) / Convert.ToDouble(100))) * fa;
            double rate = 0;
            string strSQL = "SELECT a" + term.ToString() + " FROM " + tblci + " where age=" + age + "";
            OleDbDataAdapter DA = new OleDbDataAdapter(strSQL, DBConn.GetConn());
            DataSet DS = new DataSet();
            DA.Fill(DS, "ci");
            DataTable DT = DS.Tables["ci"];
            //cmbID.Items.Clear();
            foreach (DataRow dr in DT.Rows)
            {
                foreach (DataColumn dc in DT.Columns)
                {
                    rate = Convert.ToDouble(dr[dc]);
                }
            }
            ciMain = (((cip / 1000) * rate)); ///commented

            return ciMain;


        }

        private double wp(double fa, int ci, int pMode, int term, int age)
        {
            double ciMain;
            //double cip = (ci / 100)*fa;
            double rate = 0;
            string strSQL = "SELECT a" + term.ToString() + " FROM " + tblwp + " where age=" + age + "";
            OleDbDataAdapter DA = new OleDbDataAdapter(strSQL, DBConn.GetConn());
            DataSet DS = new DataSet();
            DA.Fill(DS, "ci");
            DataTable DT = DS.Tables["ci"];
            //cmbID.Items.Clear();
            foreach (DataRow dr in DT.Rows)
            {
                foreach (DataColumn dc in DT.Columns)
                {
                    rate = Convert.ToDouble(dr[dc]);
                }
            }
            ciMain = ((fa * (rate / 100)));
            return ciMain;


        }


        #endregion


        private void DPS_Load(object sender, EventArgs e)
        {
            //groupBox2.Visible = false;

            // TODO: This line of code loads data into the 'illustration1DataSet4.pr_mode' table. You can move, or remove it, as needed.
            this.pr_modeTableAdapter2.Fill(this.illustration1DataSet4.pr_mode);
            txtName.Focus();
            // TODO: This line of code loads data into the 'illustration1DataSet2.pr_mode' table. You can move, or remove it, as needed.
            this.pr_modeTableAdapter1.Fill(this.illustration1DataSet2.pr_mode);
            // TODO: This line of code loads data into the 'illustration1DataSet1.pr_mode' table. You can move, or remove it, as needed.
            this.pr_modeTableAdapter.Fill(this.illustration1DataSet1.pr_mode);
            groupBox2.Visible = false;
        }

        private void cmbS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbS.SelectedItem.ToString() == "Male")
            {
                tblci = "ci_male";
                tblwp = "wp_male";
                // txtName.Text = "Mr."+" " + txtName.Text;
            }
            else if (cmbS.SelectedItem.ToString() == "Female")
            {
                tblci = "ci_female";
                tblwp = "wp_female";
                //txtName.Text = "Mrs." + " " + txtName.Text;
            }
            else
            {
                //tblci = "ci_male";
                //tblwp = "wp_male";
                txtName.Text = txtName.Text + "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            EmptyTextBoxes(groupBox2);
            EmptyTextBoxes(groupBox1);
            EmptyTextBoxes(groupBox3);
            Emptycom(groupBox1);
            txtName.Focus();
            button3.Visible = false;
            button4.Visible = false;
            txtName.Text = "";
            txtName.Focus();
            dateTimePicker1.Text = "";
            cmbben.SelectedIndex = 0;

        }
        public static void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
        }
        public static void Emptycom(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)(c)).SelectedIndex = 0;
                }
            }
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlan.SelectedItem.ToString() == "")
            {
                //groupBox3.Visible = false;
                //label3.Visible = true;
                //label2.Visible = true;
                //label9.Visible = true;
                //label10.Visible = true;
                //label13.Visible = true;
                //label14.Visible = true;
                //label8.Visible = true;
                //label12.Visible = true;
                //cmbCi.Visible = true;

                groupBox3.Visible = false;
                // label3.Visible = false;
                label2.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label8.Visible = true;
                label12.Visible = true;
                //cmbCi.Visible = false;
            }
            else if (cmbPlan.SelectedItem.ToString() == "GOLD")
            {
                groupBox3.Visible = false;
                // label3.Visible = false;
                label2.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label8.Visible = false;
                label12.Visible = false;
                //cmbCi.Visible = false;
            }
            else if (cmbPlan.SelectedItem.ToString() == " FOR HOUSEWIFE")
            {
                //groupBox3.Visible = true;
                //label3.Visible = true;
                //label2.Visible = true;
                //label9.Visible = true;
                //label10.Visible = true;
                //label13.Visible = true;
                //label14.Visible = true;
                //label8.Visible = true;
                //label12.Visible = true;
                //cmbCi.Visible = true;
                //cmbS.SelectedIndex = 1;
            }
            else
            {
                groupBox3.Visible = false;
                // label3.Visible = false;
                label2.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label8.Visible = false;
                label12.Visible = false;
                //cmbCi.Visible = false;
            }
        }


        private void LoadComplete(IAsyncResult ar)
        {
            LoadDataDelegate d = (LoadDataDelegate)ar.AsyncState;

            //end the Load method call
            d.EndInvoke(ar);

            //now when the Load is complete..remove the wait image
            DisplayWait(false);
            Displayshow(true);
            // MessageBox.Show("Compilation Of Illustration Completed.");

        }
        private void show()
        {
            groupBox2.Visible = true;
            label12.Text = FA.ToString();
            label13.Text = BAP.ToString();
            label14.Text = aDDciwp.ToString();
            label15.Text = TAPM.ToString();
            label18.Text = TMP.ToString();

            label21.Text = maturityV.ToString();
            label23.Text = matV9.ToString();

        }

        private void DisplayWait(bool boolDisplay)
        {
            //this check is required to carry out the cross thread oprtation on a control which is pictureBox1 in this case.
            if (pictureBox1.InvokeRequired)
            {
                // this is worker thread
                DisplayWaitDelegate del = new DisplayWaitDelegate(DisplayWait);
                pictureBox1.Invoke(del, new object[] { boolDisplay });
                //UseWaitCursor = boolDisplay;
            }
            else
            {
                // this is UI thread     
                pictureBox1.Visible = boolDisplay;
                //UseWaitCursor = boolDisplay;
            }
        }


        private void Displayshow(bool boolDisplay)
        {
            //this check is required to carry out the cross thread oprtation on a control which is pictureBox1 in this case.
            if (pictureBox1.InvokeRequired)
            {
                // this is worker thread
                DisplayWaitDelegate del = new DisplayWaitDelegate(Displayshow);
                groupBox1.Invoke(del, new object[] { boolDisplay });

                DisplayWaitDelegate del1 = new DisplayWaitDelegate(Displayshow);
                label12.Invoke(del1, new object[] { boolDisplay });

                DisplayWaitDelegate del3 = new DisplayWaitDelegate(Displayshow);
                label13.Invoke(del3, new object[] { boolDisplay });

                DisplayWaitDelegate del4 = new DisplayWaitDelegate(Displayshow);
                label14.Invoke(del4, new object[] { boolDisplay });

                DisplayWaitDelegate del5 = new DisplayWaitDelegate(Displayshow);
                label15.Invoke(del5, new object[] { boolDisplay });

                DisplayWaitDelegate del6 = new DisplayWaitDelegate(Displayshow);
                label18.Invoke(del6, new object[] { boolDisplay });

                DisplayWaitDelegate del7 = new DisplayWaitDelegate(Displayshow);
                label21.Invoke(del7, new object[] { boolDisplay });

                DisplayWaitDelegate del8 = new DisplayWaitDelegate(Displayshow);
                label23.Invoke(del8, new object[] { boolDisplay });

                //UseWaitCursor = boolDisplay;
            }
            else
            {
                // this is UI thread     
                if (plan == "GOLD")
                {
                    button3.Visible = boolDisplay;
                    button4.Visible = boolDisplay;
                    groupBox2.Visible = boolDisplay;
                    label12.Text = FA.ToString();
                    label13.Text = BAP.ToString();
                    label14.Text = aDDciwp.ToString();
                    label15.Text = TAPM.ToString();
                    label18.Text = TMP.ToString();

                    label21.Text = maturityV.ToString();
                    label23.Text = matV9.ToString();
                    label10.Visible = false;
                    label14.Visible = false;
                }
                else if (plan == "")
                {
                    button3.Visible = boolDisplay;
                    button4.Visible = boolDisplay;
                    groupBox2.Visible = boolDisplay;
                    label12.Text = FA.ToString();
                    label13.Text = BAP.ToString();
                    label14.Text = aDDciwp.ToString();
                    label15.Text = TAPM.ToString();
                    label18.Text = TMP.ToString();

                    label21.Text = maturityV.ToString();
                    label23.Text = matV9.ToString();
                }
                else
                {
                    button3.Visible = boolDisplay;
                    button4.Visible = boolDisplay;
                    groupBox2.Visible = boolDisplay;
                    label12.Text = FA.ToString();
                    label13.Text = BAP.ToString();
                    label14.Text = aDDciwp.ToString();
                    label15.Text = TAPM.ToString();
                    label18.Text = TMP.ToString();

                    label21.Text = maturityV.ToString();
                    label23.Text = matV9.ToString();

                }

                //UseWaitCursor = boolDisplay;
            }
        } // waiting animation
        private static string strConns = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        private void insertData()
        {
            string strSQL = @"INSERT INTO ALL_DATA(Name, age, Plan, term, BasicPrem, Mode, CI, FA, BasicAP, AnpCIWP, TAP,Maturity7, Maturity9, Agent_code, Agent_name, Entry_date) 
                               VALUES(@Name, @age, @Plan, @term, @BasicPrem, @Mode, @CI, @FA, @BasicAP, @AnpCIWP, @TAP,@Maturity7, @Maturity9, @Agent_code, @Agent_name, @Entry_date)";
            OleDbConnection objConn = new OleDbConnection(strConns);
            OleDbCommand objComm = new OleDbCommand(strSQL, objConn);
            objComm.CommandType = CommandType.Text;

            //objComm.Parameters.Add("@std_id", OleDbType.Numeric, 4);
            //objComm.Parameters.Add("@std_name", OleDbType.VarChar, 255);
            //objComm.Parameters.Add("@address", OleDbType.VarChar, 255);
            //objComm.Parameters.Add("@phone", OleDbType.VarChar, 255);
            //objComm.Parameters.Add("@ad_date", OleDbType.Date, 8);
            //objComm.Parameters.Add("@fat_name", OleDbType.VarChar, 255);
            //objComm.Parameters.Add("@inst", OleDbType.VarChar, 255);

            ////objComm.Parameters.AddWithValue("@std_id", cmbID.Text);
            ////objComm.Parameters.AddWithValue("@std_name", cmbName.Text);
            ////objComm.Parameters.AddWithValue("@address", txtAddress.Text);
            ////objComm.Parameters.AddWithValue("@phone", txtPhone.Text);
            ////objComm.Parameters.AddWithValue("@ad_date", dtpDate.Text);


            //objComm.Parameters["@std_id"].Value = cmbID.Text;
            //objComm.Parameters["@std_name"].Value = cmbName.Text;
            //objComm.Parameters["@address"].Value = txtAddress.Text;
            //objComm.Parameters["@phone"].Value = txtPhone.Text;
            //objComm.Parameters["@ad_date"].Value = Convert.ToDateTime(dtpDate.Text);
            //objComm.Parameters["@fat_name"].Value = txtfat.Text;
            //objComm.Parameters["@inst"].Value = txtinst.Text;
            //@Name, @age, @Plan, @term, @BasicPrem,
            //@Mode, @CI, @FA, @BasicAP, @AnpCIWP,
            //@TAP,@Maturity7, @Maturity9, @Agent_code, 
            //@Agent_name, @Entry_date
            objComm.Parameters.AddWithValue("@Name", Convert.ToString(txtName.Text));
            objComm.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));
            objComm.Parameters.AddWithValue("@Plan", Convert.ToString(plan));
            objComm.Parameters.AddWithValue("@term", Convert.ToInt32(Pterm));
            objComm.Parameters.AddWithValue("@BasicPrem", Convert.ToInt32(basic));
            objComm.Parameters.AddWithValue("@Mode", cmbPrMode.Text);
            objComm.Parameters.AddWithValue("@CI", Convert.ToInt32(CCi));
            objComm.Parameters.AddWithValue("@FA", Convert.ToInt32(FA));
            objComm.Parameters.AddWithValue("@BasicAP", Convert.ToInt32(BAP));
            objComm.Parameters.AddWithValue("@AnpCIWP", Convert.ToInt32(cici));
            objComm.Parameters.AddWithValue("@TAP", Convert.ToInt32(TAP));
            objComm.Parameters.AddWithValue("@Maturity7", Convert.ToInt32(maturityV));
            objComm.Parameters.AddWithValue("@Maturity9", Convert.ToInt32(matV9));
            objComm.Parameters.AddWithValue("@Agent_code", Convert.ToString(txtagnt.Text));
            objComm.Parameters.AddWithValue("@Agent_name", Convert.ToString(txtAname.Text));
            objComm.Parameters.AddWithValue("@Entry_date", DateTime.Now.ToString("dd/MM/yyyy"));

            try
            {
                objConn.Open();
                objComm.ExecuteNonQuery();
                objConn.Close();
                objComm.Dispose();

                MessageBox.Show("Data Saved Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        } // for reporting

        private void button3_Click(object sender, EventArgs e)
        {
            //this.show();
            if (plan == "")
            {
                //_Bangla_id4 PR = new _Bangla_id4();
                //PR.SetParameterValue("name", Convert.ToString(txtName.Text));
                //PR.SetParameterValue("age", Convert.ToInt32(txtAge.Text));
                //PR.SetParameterValue("plan", Convert.ToString(plan));
                //PR.SetParameterValue("term", Convert.ToInt32(Pterm));
                //PR.SetParameterValue("basic", Convert.ToInt32(basic));
                //PR.SetParameterValue("mode", cmbPrMode.Text);
                //PR.SetParameterValue("ci", Convert.ToInt32(CCi));
                //PR.SetParameterValue("face", Convert.ToInt32(FA));
                //PR.SetParameterValue("bap", Convert.ToInt32(BAP));
                //PR.SetParameterValue("anpciwp", Convert.ToInt32(cici));
                //PR.SetParameterValue("tap", Convert.ToInt32(TAP));
                //PR.SetParameterValue("mat7", Convert.ToInt32(maturityV));
                //PR.SetParameterValue("mat9", Convert.ToInt32(matV9));
                //PR.SetParameterValue("matan7", Convert.ToInt32(matan7));
                //PR.SetParameterValue("matan9", Convert.ToInt32(matan9));
                //PR.SetParameterValue("agent", Convert.ToString(txtagnt.Text));
                //PR.SetParameterValue("aName", Convert.ToString(txtAname.Text));
                //PR.SetParameterValue("@mob", Convert.ToString(txtMob.Text));
                ////PR.SetParameterValue("@conDate1", Convert.ToDateTime(dtpedate.Text));
                ////PR.SetParameterValue("@month", Convert.ToDecimal(txtmonth.Text));
                ////PR.SetParameterValue("@year", Convert.ToDecimal(txtYear.Text));
                ////PR.SetDatabaseLogon("sa", "sa");

                //ReportContainer RC = new ReportContainer(PR);
                //RC.Show();
                //this.insertData();

            }
            else if (plan == "GOLD")
            {
                SILVER_Bangla_id3 PR = new SILVER_Bangla_id3();
                PR.SetParameterValue("name", Convert.ToString(txtName.Text));
                PR.SetParameterValue("age", Convert.ToInt32(txtAge.Text));
                PR.SetParameterValue("plan", Convert.ToString(plan));
                PR.SetParameterValue("term", Convert.ToInt32(Pterm));
                PR.SetParameterValue("basic", Convert.ToInt32(basic));
                PR.SetParameterValue("mode", cmbPrMode.Text);
                PR.SetParameterValue("ci", Convert.ToInt32(CI));
                PR.SetParameterValue("face", Convert.ToInt32(FA));
                PR.SetParameterValue("bap", Convert.ToInt32(BAP));
                PR.SetParameterValue("anpciwp", Convert.ToInt32(WP));
                PR.SetParameterValue("tap", Convert.ToInt32(TAP));
                PR.SetParameterValue("mat7", Convert.ToInt32(maturityV));
                PR.SetParameterValue("mat9", Convert.ToInt32(matV9));
                PR.SetParameterValue("matan7", Convert.ToInt32(matan7));
                PR.SetParameterValue("matan9", Convert.ToInt32(matan9));
                PR.SetParameterValue("agent", Convert.ToString(txtagnt.Text));
                PR.SetParameterValue("aName", Convert.ToString(txtAname.Text));
                PR.SetParameterValue("@mob", Convert.ToString(txtMob.Text));
                PR.SetParameterValue("cifa", Convert.ToInt32(CCi));
                //PR.SetParameterValue("@conDate1", Convert.ToDateTime(dtpedate.Text));
                //PR.SetParameterValue("@month", Convert.ToDecimal(txtmonth.Text));
                //PR.SetParameterValue("@year", Convert.ToDecimal(txtYear.Text));
                //PR.SetDatabaseLogon("sa", "sa");

                ReportContainer RC = new ReportContainer(PR);
                RC.Show();
                this.insertData();


            }
            else if (plan == "SILVER")
            {
                SILVER_Bangla_id3 PR = new SILVER_Bangla_id3();
                PR.SetParameterValue("name", Convert.ToString(txtName.Text));
                PR.SetParameterValue("age", Convert.ToInt32(txtAge.Text));
                PR.SetParameterValue("plan", Convert.ToString(plan));
                PR.SetParameterValue("term", Convert.ToInt32(Pterm));
                PR.SetParameterValue("basic", Convert.ToInt32(basic));
                PR.SetParameterValue("mode", cmbPrMode.Text);
                PR.SetParameterValue("ci", Convert.ToInt32(CI));
                PR.SetParameterValue("face", Convert.ToInt32(FA));
                PR.SetParameterValue("bap", Convert.ToInt32(BAP));
                PR.SetParameterValue("anpciwp", Convert.ToInt32(WP));
                PR.SetParameterValue("tap", Convert.ToInt32(TAP));
                PR.SetParameterValue("mat7", Convert.ToInt32(maturityV));
                PR.SetParameterValue("mat9", Convert.ToInt32(matV9));
                PR.SetParameterValue("matan7", Convert.ToInt32(matan7));
                PR.SetParameterValue("matan9", Convert.ToInt32(matan9));
                PR.SetParameterValue("agent", Convert.ToString(txtagnt.Text));
                PR.SetParameterValue("aName", Convert.ToString(txtAname.Text));
                PR.SetParameterValue("@mob", Convert.ToString(txtMob.Text));
                PR.SetParameterValue("cifa", Convert.ToInt32(CCi));
                //PR.SetParameterValue("@conDate1", Convert.ToDateTime(dtpedate.Text));
                //PR.SetParameterValue("@month", Convert.ToDecimal(txtmonth.Text));
                //PR.SetParameterValue("@year", Convert.ToDecimal(txtYear.Text));
                //PR.SetDatabaseLogon("sa", "sa");

                ReportContainer RC = new ReportContainer(PR);
                RC.Show();
                this.insertData();


            }
            else
            {
                //_Bangla_id5 PR = new _Bangla_id5();
                //PR.SetParameterValue("name", Convert.ToString(txtName.Text));
                //PR.SetParameterValue("age", Convert.ToInt32(txtAge.Text));
                //PR.SetParameterValue("plan", Convert.ToString(plan));
                //PR.SetParameterValue("term", Convert.ToInt32(Pterm));
                //PR.SetParameterValue("basic", Convert.ToInt32(basic));
                //PR.SetParameterValue("mode", cmbPrMode.Text);
                //PR.SetParameterValue("ci", Convert.ToInt32(CCi));
                //PR.SetParameterValue("face", Convert.ToInt32(FA));
                //PR.SetParameterValue("bap", Convert.ToInt32(BAP));
                //PR.SetParameterValue("anpciwp", Convert.ToInt32(cici));
                //PR.SetParameterValue("tap", Convert.ToInt32(TAP));
                //PR.SetParameterValue("mat7", Convert.ToInt32(maturityV));
                //PR.SetParameterValue("mat9", Convert.ToInt32(matV9));
                //PR.SetParameterValue("matan7", Convert.ToInt32(matan7));
                //PR.SetParameterValue("matan9", Convert.ToInt32(matan9));
                //PR.SetParameterValue("agent", Convert.ToString(txtagnt.Text));
                //PR.SetParameterValue("aName", Convert.ToString(txtAname.Text));
                //PR.SetParameterValue("@mob", Convert.ToString(txtMob.Text));
                ////PR.SetParameterValue("@conDate1", Convert.ToDateTime(dtpedate.Text));
                ////PR.SetParameterValue("@month", Convert.ToDecimal(txtmonth.Text));
                ////PR.SetParameterValue("@year", Convert.ToDecimal(txtYear.Text));
                ////PR.SetDatabaseLogon("sa", "sa");

                //ReportContainer RC = new ReportContainer(PR);
                //RC.Show();
                //this.insertData();

            }



        }


        private void button4_Click(object sender, EventArgs e)
        {
            //this.show();
            if (plan == "")
            {
               

            }
            else if (plan == "GOLD")
            {
                SILVER_Nepali_id3 PR = new SILVER_Nepali_id3();
                PR.SetParameterValue("name", Convert.ToString(txtName.Text));
                PR.SetParameterValue("age", Convert.ToInt32(txtAge.Text));
                PR.SetParameterValue("plan", Convert.ToString(plan));
                PR.SetParameterValue("term", Convert.ToInt32(Pterm));
                PR.SetParameterValue("basic", Convert.ToInt32(basic));
                PR.SetParameterValue("mode", cmbPrMode.Text);
                PR.SetParameterValue("ci", Convert.ToInt32(CI));
                PR.SetParameterValue("face", Convert.ToInt32(FA));
                PR.SetParameterValue("bap", Convert.ToInt32(BAP));
                PR.SetParameterValue("anpciwp", Convert.ToInt32(WP));
                PR.SetParameterValue("tap", Convert.ToInt32(TAP));
                PR.SetParameterValue("mat7", Convert.ToInt32(maturityV));
                PR.SetParameterValue("mat9", Convert.ToInt32(matV9));
                PR.SetParameterValue("matan7", Convert.ToInt32(matan7));
                PR.SetParameterValue("matan9", Convert.ToInt32(matan9));
                PR.SetParameterValue("agent", Convert.ToString(txtagnt.Text));
                PR.SetParameterValue("aName", Convert.ToString(txtAname.Text));
                PR.SetParameterValue("@mob", Convert.ToString(txtMob.Text));
                PR.SetParameterValue("cifa", Convert.ToInt32(CCi));
                

                ReportContainer RC = new ReportContainer(PR);
                RC.Show();
                this.insertData();


            }
            else if (plan == "SILVER")
            {
                SILVER_Nepali_id3 PR = new SILVER_Nepali_id3();
                PR.SetParameterValue("name", Convert.ToString(txtName.Text));
                PR.SetParameterValue("age", Convert.ToInt32(txtAge.Text));
                PR.SetParameterValue("plan", Convert.ToString(plan));
                PR.SetParameterValue("term", Convert.ToInt32(Pterm));
                PR.SetParameterValue("basic", Convert.ToInt32(basic));
                PR.SetParameterValue("mode", cmbPrMode.Text);
                PR.SetParameterValue("ci", Convert.ToInt32(CI));
                PR.SetParameterValue("face", Convert.ToInt32(FA));
                PR.SetParameterValue("bap", Convert.ToInt32(BAP));
                PR.SetParameterValue("anpciwp", Convert.ToInt32(WP));
                PR.SetParameterValue("tap", Convert.ToInt32(TAP));
                PR.SetParameterValue("mat7", Convert.ToInt32(maturityV));
                PR.SetParameterValue("mat9", Convert.ToInt32(matV9));
                PR.SetParameterValue("matan7", Convert.ToInt32(matan7));
                PR.SetParameterValue("matan9", Convert.ToInt32(matan9));
                PR.SetParameterValue("agent", Convert.ToString(txtagnt.Text));
                PR.SetParameterValue("aName", Convert.ToString(txtAname.Text));
                PR.SetParameterValue("@mob", Convert.ToString(txtMob.Text));
                PR.SetParameterValue("cifa", Convert.ToInt32(CCi));
               

                ReportContainer RC = new ReportContainer(PR);
                RC.Show();
                this.insertData();


            }
            else
            {
               

            }
        }
        
        // button condition

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pr_modeTableAdapter1.FillBy(this.illustration1DataSet2.pr_mode);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.pr_modeTableAdapter1.FillBy(this.illustration1DataSet2.pr_mode);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private bool va()
        {
            if (cmbPlan.Text == string.Empty)
            {
                MessageBox.Show("Please Select DPS Super Plan ");
                return false;
            }
            if (cmbPrMode.Text == "Select One")
            {
                MessageBox.Show("Please Select Premium Mode");
                return false;
            }
            if (cmbterm.Text == string.Empty)
            {
                MessageBox.Show("Please Select DPS Super Policy Term");
                return false;
            }
            return true;

        } // bool to validate general condt
        private bool validate()
        {
            //NAME

            if (txtName.Text == string.Empty)
            {

                MessageBox.Show("Please Provide Proposed Insured Name");
                return false;
            }

            if (txtBasic.Text == string.Empty)
            {

                MessageBox.Show("Please Provide Basic Premium");
                return false;
            }
            //SEX
            if (cmbS.Text == "Select One")
            {
                MessageBox.Show("Please Provide Gender");
                cmbS.Focus();
                return false;

            }
            if (cmbben.SelectedItem.ToString() == "(Select)")
            {
                MessageBox.Show("Please Provide CI & FPR Benefit Type");
                return false;

            }
            if (cmbS.Text == string.Empty)
            {
                MessageBox.Show("Please Provide Gender");
                cmbS.Focus();
                return false;

            }

            //AGE
            if (txtAge.Text == string.Empty)
            {
                MessageBox.Show("Please Provide Insured Age");
                txtAge.Focus();
                return false;

            }
            if (Convert.ToInt32(txtAge.Text) > 54 || Convert.ToInt32(txtAge.Text) < 18)
            {
                MessageBox.Show("Please Provide Valid Insured age Limit");
                return false;

            }

            //Agent Code
            //if (txtagnt.Text==string.Empty)
            //{

            //    MessageBox.Show("Please Provide Financial Associate's Code");
            //    return false;

            //}
            //if (txtagnt.Text.ToCharArray().Length!=9)
            //{

            //    MessageBox.Show("Please Provide Financial Associate's Code");
            //    return false;

            //}

            if (txtAge.Text != string.Empty || txtBasic.Text != string.Empty || txtagnt.Text != string.Empty || cmbS.Text != string.Empty)
            {
                if (cmbPlan.Text == string.Empty)
                {
                    MessageBox.Show("Please Select DPS Super Plan");
                    return false;
                }
                if (cmbPrMode.Text == string.Empty)
                {
                    MessageBox.Show("Please Select Premium Mode");
                    return false;
                }
                if (cmbterm.Text == string.Empty)
                {
                    MessageBox.Show("Please Select DPS Super Policy Term");
                    return false;
                }
                if (cmbPlan.Text == "Select One")
                {
                    MessageBox.Show("Please Select DPS Super Plan");
                    return false;
                }
                if (cmbPrMode.Text == "Select One")
                {
                    MessageBox.Show("Please Select Premium Mode");
                    return false;
                }
                if (cmbterm.Text == "Select One")
                {
                    MessageBox.Show("Please Select DPS Super Policy Term");
                    return false;
                }




                else
                {
                    int age;
                    bool num;
                    int age1;
                    bool num1;
                    num = Int32.TryParse(txtAge.Text, out age);
                    num1 = Int32.TryParse(txtBasic.Text, out age1);
                    if (num)
                    {
                        if (cmbPlan.Text == "GOLD" || cmbPlan.Text == "SILVER")
                        {

                            if (cmbCi.Text == string.Empty || cmbCi.Text == "Select One")
                            {
                                return true;
                            }

                        }
                        else if (cmbPlan.Text == "")
                        {

                            if (cmbCi.Text == string.Empty || cmbCi.Text == "Select One")
                            {
                                MessageBox.Show("Please select CI Benefit % of Face Amount");
                                return false;

                            }

                        }
                        else
                            return true;
                        //MessageBox.Show("Please Provide Valid data selection");

                    }

                    else
                    {
                        // MessageBox.Show("Please Provide Valid data selection");
                        return false;
                    }

                }
                return true;
            }




            else
            {
                return true;
            }


        } // bool to validate general condition

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private bool valid()
        {
            if (FA > 15000000) // 1.5 crore
            {
                MessageBox.Show("Face Amount Must not be greater than 1.5 crore ");
                return false;
            }
            if (Convert.ToDecimal(txtBasic.Text) < 700)
            {
                MessageBox.Show("Basic Amount Must not be Less than RS 700 ");
                return false;
            }
            else
            {
                return true;
            }

        } // Bool to check 1.5 crore

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //   Page = calcage();

        }

        private void dateTimePicker1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            this.calcage();
            txtAge.Text = Page.ToString();
            txtAge.Focus();
        }

        private void txtFa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFa_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFa_Leave(object sender, EventArgs e)
        {
            double a;
            if (double.TryParse(txtFa.Text, out a) && txtBasic.Text == string.Empty && txtFa.Text != string.Empty)
            {
                FA = Convert.ToDouble(txtFa.Text);
                // if ((FA < 45000.0) || (FA > 10000000.0)) //orig by dip
                if ((FA < 60000.0) || (FA >= 15000001.0))
                {
                    MessageBox.Show("Please Enter Valid Face Amount");
                    txtBasic.Text = "";
                    txtFa.Text = "";
                    txtBasic.Focus();


                }
                else
                {
                    txtFa.Text = FA.ToString();
                    basic = Basik(FA, Convert.ToInt32(cmbPrMode.SelectedValue), Convert.ToInt32(cmbterm.Text));
                    basic = Math.Round(basic, 2);
                    txtBasic.Text = basic.ToString();

                }


            }



            cmbCi.Focus();
        } // check valid face amount

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txtBasic_Leave(object sender, EventArgs e)
        {
            if (txtBasic.Text != string.Empty && this.va())
            {


                FA = faceamount(Convert.ToDouble(txtBasic.Text),
                                  Convert.ToInt32(cmbPrMode.SelectedValue), Convert.ToInt32(cmbterm.Text));




                if ((FA < 60000.0) || (FA > 15000001.0))
                {
                    MessageBox.Show("Please Enter Valid Basic Premuim");
                    txtBasic.Text = "";
                    txtFa.Text = "";
                    txtBasic.Focus();


                }
                else
                {
                    txtFa.Text = FA.ToString();

                }
            }

        } // check valid basic premium

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void txtAname_Leave(object sender, EventArgs e)
        {

        }

        private void txtAname_KeyPress(object sender, KeyPressEventArgs e)
        {

            string allowedCharacterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ.\b\n\t\r' '";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {
                if (e.KeyChar.ToString() == "."
                    && txtAname.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }



        }

        private void txtAname_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void txtBasic_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedCharacterSet = "0123456789.\b";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {
                if (e.KeyChar.ToString() == "."
                    && txtBasic.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtagnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedCharacterSet = "0123456789\b";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMob_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedCharacterSet = "0123456789\b";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {

            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedCharacterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ.\b\n\t\r' '";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {
                if (e.KeyChar.ToString() == "."
                    && txtName.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtFa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedCharacterSet = "0123456789.\b";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedCharacterSet = "0123456789\b";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool housewife()
        {
            if (cmbPlan.SelectedItem.ToString() == " FOR HOUSEWIFE")
            {
                if (txtwpa.Text == string.Empty)
                {
                    txtwpa.Text = "0.0";
                }
                if (txthpfa.Text == string.Empty)
                {
                    txthpfa.Text = "0.0";
                }
                double exists = 0.0;
                double exists1 = 0.0;
                exists = Convert.ToDouble(txtwpa.Text);
                exists1 = Convert.ToDouble(txthpfa.Text);

                if (chkha.Checked == true && chkhp.Checked == false && (Convert.ToDouble(txtFa.Text) + exists) <= 1000000.0)
                {
                    return true;
                }


                else if (chkha.Checked == false && chkhp.Checked == true)
                {
                    if (Convert.ToDouble(txtFa.Text) + exists <= exists1)
                    {
                        if ((Convert.ToDouble(txtFa.Text) + exists) <= 1500000.0)
                        {
                            return true;

                        }
                        else
                        {
                            MessageBox.Show("Maximum Face Amount is Rs 1,500,000");
                            txtBasic.Text = "";
                            txtFa.Text = "";
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Maximum Face Amount Must be Equal To Husbands Policy Face Amount");
                        txtBasic.Text = "";
                        txtFa.Text = "";
                        return false;
                    }



                }

                else
                {
                    MessageBox.Show("Maximum Face Amount is Rs 1,000,000");
                    txtBasic.Text = "";
                    txtFa.Text = "";
                    return false;
                }
            }
            return true;

        } // for housewives

        private void txthpfa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedCharacterSet = "0123456789.\b";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtwpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowedCharacterSet = "0123456789.\b";

            if (allowedCharacterSet.Contains(e.KeyChar.ToString()))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void chkhp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhp.Checked)
            {
                chkha.Checked = false;
                label34.Visible = true;
                txthpfa.Visible = true;
            }
            else
            {
                label34.Visible = false;
                txthpfa.Visible = false;
            }

        }

        private void chkwp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkwp.Checked == true)
            {
                label36.Visible = true;
                txtwpa.Visible = true;
            }
            else
            {
                label36.Visible = false;
                txtwpa.Visible = false;
            }

        }

        private void chkha_CheckedChanged(object sender, EventArgs e)
        {
            chkhp.Checked = false;
            //if (chkhp.Checked)
            //{
            //    label34.Visible = true;
            //    txthpfa.Visible = true;
            //}
            //else
            //{
            //    label34.Visible = false;
            //    txthpfa.Visible = false;
            //}
        }

        private void cmbben_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbterm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (age + term > 60 && cmbben.SelectedIndex == 2)
            //{
            //    MessageBox.Show("Customer Can Select CI Rider Within 60 Years (Policy Term + Customer Age)");
            //    cmbben.SelectedIndex = 1;
            //}
        }

        private void cmbben_TabIndexChanged(object sender, EventArgs e)
        {
            int age1;
            int term1;
            term1 = Convert.ToInt32(cmbterm.SelectedItem.ToString());


            age1 = Convert.ToInt32(txtAge.Text);
            if (age1 + term1 > 60 && cmbben.SelectedIndex == 2)
            {
                MessageBox.Show("Customer Can Select CI Rider Within 60 Years (Policy Term + Customer Age)");
                cmbben.SelectedIndex = 1;
            }
        } // Function to check Age and Term more than 60, NO CI


        private void cmbben_Leave(object sender, EventArgs e)
        {
            int age1;
            int term1;
            term1 = Convert.ToInt32(cmbterm.SelectedItem.ToString());


            age1 = Convert.ToInt32(txtAge.Text);
            if (age1 + term1 > 60 && cmbben.SelectedIndex == 2)
            {
                MessageBox.Show("Customer Can Select CI Rider Within 60 Years (Policy Term + Customer Age)");
                cmbben.SelectedIndex = 1;
            }
        }

        // Function to check Age and Term more than 60, NO CI




    }
}
