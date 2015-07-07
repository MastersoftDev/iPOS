using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.BUS.System;
using iPOS.Core.Helper;
using iPOS.DTO.System;
using iPOS.Management.Common;
using iPOS.Core.Security;

namespace iPOS.Management
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region [Declare Variables]
        SYS_tblUserBUS busUser;
        #endregion

        #region [Personal Method]
        private bool CheckLogin()
        {
            if (txtUsername.Text.Equals(""))
            {
                Common.Common.ShowMessage(Lang.GetMessageByLanguage("000011", Common.Common.Culture, Common.Common.ResourceMessage), 0);
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text.Equals(""))
            {
                Common.Common.ShowMessage(Lang.GetMessageByLanguage("000011", Common.Common.Culture, Common.Common.ResourceMessage), 0);
                txtPassword.Focus();
                return false;
            }
            try
            {
                SYS_tblUserDTO user = busUser.CheckLogin(txtUsername.Text, Encryption.Encrypt(txtPassword.Text));
                if (user != null)
                {
                    User.UserInfo = user;
                    if (user.Locked)
                    {
                        Common.Common.ShowMessage(Lang.GetMessageByLanguage("000010", Common.Common.Culture, Common.Common.ResourceMessage).Replace("$UserName$", user.Username), 0);
                        txtUsername.Focus();
                        return false;
                    }
                }
                else
                {
                    Common.Common.ShowMessage(Lang.GetMessageByLanguage("000009", Common.Common.Culture, Common.Common.ResourceMessage), 0);
                    txtUsername.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Common.Common.ShowExceptionMessage(ex);
                txtUsername.Focus();
                return false;
            }

            return true;
        }

        private void Initialize()
        {
            string _username = new IO().Read("Initialize", "Username");
            string _password = new IO().Read("Initialize", "Password");
            string _language = new IO().Read("Initialize", "Language");
            icbLanguage.SelectedIndex = (_language.Equals("en-US")) ? 0 : 1;
            if (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password))
            {
                txtUsername.Text = Encryption.Decrypt(_username);
                txtPassword.Text = Encryption.Decrypt(_password);
                txtPassword.Focus();
                chkRemember.Checked = true;
            }
            else chkRemember.Checked = false;
        }

        private void ChangeLanguage(int type)
        {
            if (type == 0)
            {
                icbLanguage.Properties.Items[0].Description = "English";
                icbLanguage.Properties.Items[1].Description = "Vietnamese";
                this.Text = "Sign In System - iPOS Management 1.0";
                lblTitle.Text = "SIGN IN";                
                hplForgotPassword.Text = "Forgot password?";
                lblLanguage.Text = "Language:";
                lblUsername.Text = "Username:";
                lblPassword.Text = "Password:";
                chkRemember.Text = "Remember username and password?";
                btnLogin.Text = "Sign In";
                btnExit.Text = "Exit";

            }
            else
            {
                icbLanguage.Properties.Items[0].Description = "Tiếng Anh";
                icbLanguage.Properties.Items[1].Description = "Tiếng Việt";
                this.Text = "Đăng Nhập Hệ Thống - iPOS Management 1.0";
                lblTitle.Text = "ĐĂNG NHẬP";
                hplForgotPassword.Text = "Quên mật khẩu?";
                lblLanguage.Text = "Ngôn ngữ:";
                lblUsername.Text = "Tên tài khoản:";
                lblPassword.Text = "Mật khẩu:";
                chkRemember.Text = "Nhớ tài khoản và mật khẩu?";
                btnLogin.Text = "Đăng Nhập";
                btnExit.Text = "Thoát";
            }
        }
        #endregion

        #region [Form Event]
        public frmLogin()
        {
            InitializeComponent();
            busUser = new SYS_tblUserBUS();
            Initialize();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
                User.UserInfo.LanguageID = icbLanguage.Properties.Items[icbLanguage.SelectedIndex].Value + "";
                string _username = (chkRemember.Checked) ? Encryption.Encrypt(txtUsername.Text) : "";
                string _password = (chkRemember.Checked) ? Encryption.Encrypt(txtPassword.Text) : "";
                new IO().Write("Initialize", "Username", _username);
                new IO().Write("Initialize", "Password", _password);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
                log.Activity = "Insert";
                log.Username = txtUsername.Text;
                log.ActionVN = "Đăng Nhập";
                log.ActionEN = "Login";
                log.FunctionID = null;
                log.FunctionNameEN = log.ActionEN;
                log.FunctionNameVN = log.ActionVN;
                log.DescriptionEN = string.Format("Account '{0}' has logined to system at {1}.", txtUsername.Text, DateTime.Now); 
                log.DescriptionVN = string.Format("Tài khoản '{0}' vừa đăng nhập vào hệ thống vào lúc {1}.", txtUsername.Text, DateTime.Now);
                busUser.InsertActionLog(log);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void icbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            new IO().Write("Initialize", "Language", icbLanguage.Properties.Items[icbLanguage.SelectedIndex].Value.ToString());
            ChangeLanguage(icbLanguage.SelectedIndex);
        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Contains(" "))
                dxeError.SetError(txtUsername, Lang.GetMessageByLanguage("000004", Common.Common.Culture, Common.Common.ResourceMessage));
            else dxeError.SetError(txtUsername, (string.IsNullOrEmpty(txtUsername.Text)) ? Lang.GetMessageByLanguage("000003", Common.Common.Culture, Common.Common.ResourceMessage) : null);
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            dxeError.SetError(txtPassword, (string.IsNullOrEmpty(txtPassword.Text)) ? Lang.GetMessageByLanguage("000003", Common.Common.Culture, Common.Common.ResourceMessage) : null);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnLogin_Click(null, null);
        }
        #endregion
    }
}