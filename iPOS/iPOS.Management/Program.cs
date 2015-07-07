using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.IO;

namespace iPOS.Management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Blue");

            if (!File.Exists(Application.StartupPath + @"\Config.ini"))
            {
                MessageBox.Show("Thieu file Config");
                return;
            }
            else
            {
                frmLogin frm = new frmLogin();
                if (frm.ShowDialog() == DialogResult.OK)
                    Application.Run(new frmMain());
                else Application.Exit();
            }

            //Common.Common.OpenInputForm(new iPOS.Management.Common.uc_ImportExcel("PRO_Province_FileSelect.xlsx", "PRO_spfrmProvinceImport", "PRO", "8"), "đá", "đá", new System.Drawing.Size(900, 600));
            //Common.Common.OpenInputForm(new iPOS.Management.Common.uc_ImportExcel("PRO_District_FileSelect.xlsx", "PRO_spfrmDistrictImport", "PRO", "12"), "đá", "đá", new System.Drawing.Size(900, 600));
        }
    }
}