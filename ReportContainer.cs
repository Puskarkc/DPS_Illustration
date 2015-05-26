using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Manage_Data
{
    public partial class ReportContainer : Form
    {
        public ReportContainer(ReportClass report)
        {
            InitializeComponent();
            





             //crystalReportViewer1.AllowedExportFormats = formats;
             crystalReportViewer1.ReportSource = report;


             int formats;
             formats = Convert.ToInt32(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);


             ExportOptions exportOpts = new ExportOptions();
             PdfRtfWordFormatOptions excelFormatOpts = new PdfRtfWordFormatOptions();
             DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
             exportOpts = report.ExportOptions;

             // Set the excel format options.
             //excelFormatOpts.ExcelUseConstantColumnWidth = true;
             exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
             exportOpts.FormatOptions = excelFormatOpts;

             // Set the disk file options and export.
             //exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
             //diskOpts. = "C:/GM/";
             //exportOpts.ExportDestinationOptions = diskOpts;
             //report.Export(exportOpts);
             //crystalReportViewer1.PrintReport();
                  
            
        }
      
    }
}
