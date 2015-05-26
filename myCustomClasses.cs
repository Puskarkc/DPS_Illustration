#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

#endregion

namespace Manage_Data
{
    public class myToolStripLabel : ToolStripLabel
    {
        bool _activelabel = true;

        public bool ActiveLabel
        {
            get { return _activelabel; }
            set { _activelabel = value; }
        }

        public myToolStripLabel() { }

        public myToolStripLabel(string labelname, string labeltext)
        {
            this.Name = labelname;
            this.Text = labeltext;

            this.AutoSize = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.IsLink = true;
            this.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.Margin = new System.Windows.Forms.Padding(20, 4, 5, -3);
            this.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;

        }

        public void DrawActive()
        {
            this.IsLink = false;
            this.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;

            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Manage_Data.Properties.Resources.Download;
            this.ForeColor = System.Drawing.Color.SlateGray;
            this.LinkColor = System.Drawing.Color.SlateGray;

        }
        
        public void DrawInactive()
        {

            this.IsLink = true;

            this.BackColor = System.Drawing.Color.SlateGray;
            this.BackgroundImage = null;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ForeColor = System.Drawing.Color.White;
            this.LinkColor = System.Drawing.Color.White;
        }


    }


    /////////////////////////////////////////////////////////////////////////

    public class MyFormBar : ToolStrip
    {
        private MyFormBarRenderer _renderer = new MyFormBarRenderer();

        private int _count = 1;
        private string _currentactive = String.Empty;
        private const int _FIRST_BUTTON_INDEX = 2;

        public MyFormBar()
            : base()
        {
            // Set renderer
            _renderer.RoundedEdges = false;
            this.Renderer = _renderer;
            this.GripStyle = ToolStripGripStyle.Hidden;
        }

        protected override void OnRendererChanged(EventArgs e)
        {
            if (this.Renderer != _renderer)
            {
                // Force to our renderer
                this.Renderer = _renderer;
            }
            else
            {
                base.OnRendererChanged(e);
            }
        }

        public void AddForm(string labelid, string labeltext)
        {
            _count++;
            //myToolStripLabel tslabel = new myToolStripLabel("lbl" + _count.ToString(), labeltext);
            myToolStripLabel tslabel = new myToolStripLabel(labelid, labeltext);
            this.Items.Insert(_FIRST_BUTTON_INDEX, tslabel);
            CurrentActive = tslabel.Name;

            ToolStripMenuItem tsmi = new ToolStripMenuItem(labeltext);
            tsmi.Name = labelid;
            ((ToolStripDropDownButton)this.Items["tsformlist"]).DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi });
        }

        public void RemoveForm()
        {
            if (_currentactive != String.Empty)
            {
                this.Items.RemoveByKey(_currentactive);

                //string dropdownlabel = _currentactive.Replace("lbl", "lst");
                ((ToolStripDropDownButton)this.Items["tsformlist"]).DropDownItems.RemoveByKey(_currentactive);

                if (this.Items.Count > 2)
                    CurrentActive = this.Items[_FIRST_BUTTON_INDEX].Name;
                else
                    CurrentActive = String.Empty;
            }
        }

        public void Activate(string formid)
        {
            for (int index = _FIRST_BUTTON_INDEX; index < this.Items.Count; index++)
            {
                myToolStripLabel tslabel = ((myToolStripLabel)this.Items[index]);
                if (tslabel.Name == formid)
                {
                    if (tslabel.Placement == ToolStripItemPlacement.None)
                    {
                        this.Items.Remove(tslabel);
                        AddForm(tslabel.Name, tslabel.Name);
                    }
                    else
                        CurrentActive = tslabel.Name;
                    break;
                }
            }
        }

        public string CurrentActive
        {
            get { return _currentactive; }
            set
            {
                _currentactive = value;
                if (_currentactive != String.Empty)
                {
                    for (int index = _FIRST_BUTTON_INDEX; index < this.Items.Count; index++)
                    {
                        myToolStripLabel tslabel = ((myToolStripLabel)this.Items[index]);
                        if (tslabel.Name == _currentactive)
                            tslabel.DrawActive();
                        else
                            tslabel.DrawInactive();
                    }
                }
            }
        }

    }

    public class MyFormBarRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            // Call base
            base.OnRenderToolStripBackground(e);

            // Do green
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            Rectangle bounds = new Rectangle(Point.Empty, toolStrip.Size);

            if (bounds.Width > 0 && bounds.Height > 0)
            {
                //using (Brush b = new LinearGradientBrush(bounds, Color.FromArgb(90, 122, 90), Color.FromArgb(172, 208, 172), LinearGradientMode.Horizontal))
                using (Brush b = new SolidBrush(Color.SlateGray))
                {
                    g.FillRectangle(b, bounds);
                }
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }
    }

}
