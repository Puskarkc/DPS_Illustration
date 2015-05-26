using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
//using AgencyClassLibrary;
using System.Reflection;
using System.Runtime.Remoting;
using System.Configuration;


namespace Manage_Data
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public static string formTag = "";
        public static float rateInPercent;
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuManageData_Click(object sender, EventArgs e)
        {
           // frmManageData manData = new frmManageData();
           // manData.ShowDialog();
        }

        private void mnuTest_Click(object sender, EventArgs e)
        {
            frmTest tst = new frmTest();
            tst.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssDate.Text = DateTime.Now.ToLongDateString();
            tssTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void dPSGOLDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmMain fmMain = new frmMain();
            //DPS fm = new DPS();
            ////fm.Parent = fmMain;
            //fm.MdiParent = this;
            //fm.Parent = panel1;
            //fm.WindowState = FormWindowState.Maximized;
            //fm.Show();

           
            OpenOrActivateForm("DPS ILLUSTRATION", "Manage_Data.DPS", "DPS");
            // tsMain.Items.Add("DPS");
            
        }
        private bool IsFormOpen(string formid)
        {
            label1.Parent=null;
            label1.Visible = false;
            label2.Parent = null;
            label2.Visible = false;
            foreach (Form f in panel1.Controls)
                if (f.Tag.ToString() == formid) return true;

            return false;
        }
        private void OpenOrActivateForm(string formid, string formtypename, string formtitle)
        {
            //Constants.FormAccessTypesEnum _faccess = Constants.FormAccessTypesEnum.FormNoAccess;

            if (!IsFormOpen(formid))
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Type formtype = asm.GetType(formtypename);
                Form _form = (Form)Activator.CreateInstance(formtype);
                PropertyInfo pinfo = formtype.GetProperty("FormEditMode");
                
                //PropertyInfo pinfo2 = formtype.GetProperty("selectedStockType");
                //pinfo2.SetValue(_form, stocktypeid, null);
                if (formtitle != string.Empty)
                    _form.Text = formtitle;
                _form.Tag = formid;
                _form.MdiParent = this;
                _form.Parent = panel1;
                _form.WindowState = FormWindowState.Maximized;
                _form.Show();
            }
            else
                FormActivate(formid);
        }

        private void FormActivate(string formid)
        {
            foreach (Form f in panel1.Controls)
            {
                if (f.Tag.ToString() == formid)
                {
                    f.BringToFront();
                    tsMain.Activate(f.Tag.ToString());
                    return;
                }
            }
        }

        private void tsMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is myToolStripLabel)
            {
                formTag = e.ClickedItem.Name;
                tsMain.CurrentActive = e.ClickedItem.Name;
                ActivateFormByTitle(tsMain.CurrentActive);
            }
        }

        private void ActivateFormByTitle(string formtitle)
        {
            // loop through the MDI child forms, which are open under panelMain control...
            foreach (Form f in panel1.Controls)
            {
                if (f.Tag.ToString() == formtitle)
                {
                    f.BringToFront();
                    f.Activate();
                    tsMain.Activate(f.Tag.ToString());
                    return;
                }
            }
        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.Text != "Terms of Use: This Illustration System is the property of MetLife . The use of this MetLife  Illustration System is restricted to authorized users only. Unauthorized access, use, alteration, copying and/or reverse engineering of this Illustration System or any attempt thereat may result in disciplinary action by the Company and/or any civil/criminal judicial proceeding.")
            {
                if (e.Control.Text != ".:: DPS SUPER ILLUSTRATION SYSTEM ::.")
                {
                    tsMain.AddForm(e.Control.Tag.ToString(), e.Control.Text);
                    formTag = e.Control.Tag.ToString();
                }
            }
        }

        private void panel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            tsMain.RemoveForm();
        }

        private void tsFormList_Click(object sender, EventArgs e)
        {

        }

        private void tsFormList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string frmText = e.ClickedItem.Text;

            foreach (Form f in panel1.Controls)
            {
                if (f.Text == frmText)
                {
                    tsMain.Items.RemoveByKey(e.ClickedItem.Name);
                    tsFormList.DropDownItems.RemoveByKey(e.ClickedItem.Name);
                    tsMain.AddForm(e.ClickedItem.Name.ToString(), e.ClickedItem.Text);

                    ////////int ItemsSelected = tsFormList.DropDownItems.IndexOfKey(e.ClickedItem.Name);
                    ////////int ItemsSelected = tsMain.Items.IndexOfKey(e.ClickedItem);
                    ////////tsMain.Items.Add(e.ClickedItem);
                    //////////tsMain.Items[tsMain.Items.Count].Text = e.ClickedItem.Name;
                    ////////for (int i = ItemsSelected; i >= 2; i--)
                    ////////{
                    ////////    tsMain.Items[i] = tsMain.Items[i - 1];
                    ////////}
                    ////////tsMain.Items[2] = e.ClickedItem;

                    ////////tsMain.Items.RemoveAt(tsMain.Items.Count - 1);
                    tsMain.CurrentActive = e.ClickedItem.Name;
                    ActivateFormByTitle(tsMain.CurrentActive);
                    formTag = e.ClickedItem.Text;
                    f.BringToFront();
                    break;
                }
            }            
        }

        private void tsFormClose_Click(object sender, EventArgs e)
        {
            FormCollection formLists = Application.OpenForms;
            foreach (Form f in panel1.Controls)
            {
                if (f.Tag.ToString() == formTag)
                {
                    f.Close();
                    if (formLists.Count > 1)
                        formTag = formLists[formLists.Count - 1].Tag.ToString();
                    break;
                }
            }
        }

        private void tsFormList_Click_1(object sender, EventArgs e)
        {
            
        }

        private void tsFormList_DropDownItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            string frmText = e.ClickedItem.Text;

            foreach (Form f in panel1.Controls)
            {
                if (f.Text == frmText)
                {
                    tsMain.Items.RemoveByKey(e.ClickedItem.Name);
                    tsFormList.DropDownItems.RemoveByKey(e.ClickedItem.Name);
                    tsMain.AddForm(e.ClickedItem.Name.ToString(), e.ClickedItem.Text);

                    ////////int ItemsSelected = tsFormList.DropDownItems.IndexOfKey(e.ClickedItem.Name);
                    ////////int ItemsSelected = tsMain.Items.IndexOfKey(e.ClickedItem);
                    ////////tsMain.Items.Add(e.ClickedItem);
                    //////////tsMain.Items[tsMain.Items.Count].Text = e.ClickedItem.Name;
                    ////////for (int i = ItemsSelected; i >= 2; i--)
                    ////////{
                    ////////    tsMain.Items[i] = tsMain.Items[i - 1];
                    ////////}
                    ////////tsMain.Items[2] = e.ClickedItem;

                    ////////tsMain.Items.RemoveAt(tsMain.Items.Count - 1);
                    tsMain.CurrentActive = e.ClickedItem.Name;
                    ActivateFormByTitle(tsMain.CurrentActive);
                    formTag = e.ClickedItem.Text;
                    f.BringToFront();
                    break;
                }
            }            
        }

        private void tsFormClose_Click_1(object sender, EventArgs e)
        {
            FormCollection formLists = Application.OpenForms;
            if (formLists.Count == 1)
            {
                label1.Parent = panel1;
                label1.Visible = true;
                label2.Parent = panel1;
                label2.Visible = true;
            
            }
            if (formLists.Count > 1)
            {
                label1.Parent = panel1;
                label1.Visible = true;
                label2.Parent = panel1;
                label2.Visible = true;
                foreach (Form f in panel1.Controls)
                {
                    if (f.Tag.ToString() == formTag)
                    {
                        f.Close();
                        if (formLists.Count > 1)
                            formTag = formLists[formLists.Count - 1].Tag.ToString();
                        break;
                    }
                }
            }
        }

        private void tsMain_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is myToolStripLabel)
            {
                formTag = e.ClickedItem.Name;
                tsMain.CurrentActive = e.ClickedItem.Name;
                ActivateFormByTitle(tsMain.CurrentActive);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //OpenOrActivateForm("DPS ILLUSTRATION", "Manage_Data.DPS", "DPS");
        }

        private void analysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivateForm("DPS ILLUSTRATION ANALYSIS", "Manage_Data.Analysis", "Analysis");
        }

        
    }
}