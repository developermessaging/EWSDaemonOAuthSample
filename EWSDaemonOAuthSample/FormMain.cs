/*
 * By David Barrett, Microsoft Ltd. 2018. Use at your own risk.  No warranties are given.
 * 
 * DISCLAIMER:
 * THIS CODE IS SAMPLE CODE. THESE SAMPLES ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND.
 * MICROSOFT FURTHER DISCLAIMS ALL IMPLIED WARRANTIES INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OF MERCHANTABILITY OR OF FITNESS FOR
 * A PARTICULAR PURPOSE. THE ENTIRE RISK ARISING OUT OF THE USE OR PERFORMANCE OF THE SAMPLES REMAINS WITH YOU. IN NO EVENT SHALL
 * MICROSOFT OR ITS SUPPLIERS BE LIABLE FOR ANY DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION, DAMAGES FOR LOSS OF BUSINESS PROFITS,
 * BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR OTHER PECUNIARY LOSS) ARISING OUT OF THE USE OF OR INABILITY TO USE THE
 * SAMPLES, EVEN IF MICROSOFT HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. BECAUSE SOME STATES DO NOT ALLOW THE EXCLUSION OR LIMITATION
 * OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES, THE ABOVE LIMITATION MAY NOT APPLY TO YOU.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace EWSDaemonOAuthSample
{
    public partial class FormMain : Form
    {
        private ClassOAuthHelper _oAuthHelper;
        private ClassFormConfig _formConfig = null;

        public FormMain()
        {
            InitializeComponent();
            _formConfig = new ClassFormConfig(this);
            this.Text = Application.ProductName + " v" + Application.ProductVersion;
            _oAuthHelper = new ClassOAuthHelper();

            if (!String.IsNullOrEmpty(textBoxAuthCertificate.Text))
            {
                // We have a certificate specified, but we need to retrieve it to be able to use it
                textBoxAuthCertificate.Tag = FormChooseAuthCertificate.GetCertificateBySubject(textBoxAuthCertificate.Text);
                if (textBoxAuthCertificate.Tag == null)
                    textBoxAuthCertificate.Text = String.Empty;
            }

            UpdateAuthUI();
            UpdateEWSUI();
            textBoxTenantId_TextChanged(null, null);
        }

        private void UpdateAuthUI()
        {
            // Native application does not authenticate
            bool authEnabled = !nativeApiBtn.Checked;
            foreach (Control control in groupBoxAuth.Controls)
            {
                control.Enabled = authEnabled;
            }

            if (authEnabled)
            {
                bool bUsingClientSecret = radioButtonAuthWithClientSecret.Checked;
                textBoxAuthCertificate.Enabled = !bUsingClientSecret;
                buttonLoadCertificate.Enabled = !bUsingClientSecret;
                textBoxClientSecret.Enabled = bUsingClientSecret;
            }
        }

        private void ConfigureOAuthHelper()
        {
            // Read information from form and apply to OAuth Helper

            _oAuthHelper.IsNativeApplication = nativeApiBtn.Checked;
            _oAuthHelper.ApplicationId = textBoxApplicationId.Text;

            if (radioButtonAuthWithCertificate.Checked)
            {
                _oAuthHelper.AuthCertificate = (System.Security.Cryptography.X509Certificates.X509Certificate2)textBoxAuthCertificate.Tag;
                _oAuthHelper.AuthClientSecret = String.Empty;
            }
            else
            {
                _oAuthHelper.AuthClientSecret = textBoxClientSecret.Text;
                _oAuthHelper.AuthCertificate = null;
            }
            
            _oAuthHelper.AuthenticationUrl = comboBoxAuthenticationUrl.Text;
            _oAuthHelper.RedirectUrl = textBoxRedirectUrl.Text;
            _oAuthHelper.ResourceUrl = comboBoxResourceUrl.Text;
            _oAuthHelper.TenantId = textBoxTenantId.Text;
        }

        private void Log(string Log)
        {
            listBoxLog.Items.Add(Log);
        }

        private async Task<bool> GetAuthTokenAsync()
        {
            if (HaveAuthToken() && !_oAuthHelper.ObtainUserConsent)
            {
                Log(String.Format("Token acquisition ignored, valid token already obtained (expires {0}).", _oAuthHelper.AuthenticationResult.ExpiresOn));
                return true;
            }

            Log("Acquiring auth token");
            ConfigureOAuthHelper();
            await _oAuthHelper.AcquireDelegateTokenAsync(textBoxEWSMailbox.Text);
            UpdateEWSUI();
            if (!String.IsNullOrEmpty(_oAuthHelper.Token))
            {
                Log(String.Format("Token acquired, expires {0}", _oAuthHelper.AuthenticationResult.ExpiresOn));
                textBoxEWSMailbox.Text = _oAuthHelper.AuthenticationResult.UserInfo.UniqueId;
                toolTip1.SetToolTip(textBoxEWSMailbox, _oAuthHelper.AuthenticationResult.UserInfo.DisplayableId);
                return true;
            }

            if (_oAuthHelper.LastError != null)
            {
                if (_oAuthHelper.LastError.InnerException != null)
                {
                    // The error of interest from ADAL will be in the InnerException
                    Log(_oAuthHelper.LastError.InnerException.Message);
                }
                else
                    Log(_oAuthHelper.LastError.Message);
            }
            return false;
        }

        private bool HaveAuthToken()
        {
            if (!String.IsNullOrEmpty(_oAuthHelper.Token))
            {
                // We have a token, check that it hasn't expired
                if (!_oAuthHelper.TokenHasExpired)
                    return true;

                // Token has expired, we need to refresh it
                Log("Existing token has expired; refreshing.");
                return _oAuthHelper.RenewToken();
            }

            return false;
        }

        private ExchangeService GetExchangeService()
        {
            // Initialise an ExchangeService object so that it can be used to access a mailbox

            if (!HaveAuthToken())
            {
                Log("Must acquire an authentication token before making EWS calls.");
                return null;
            }

            if (checkBoxEWSImpersonate.Checked && String.IsNullOrEmpty(textBoxEWSMailbox.Text)) 
            {
                    MessageBox.Show("When impersonation is selected, you must specify the mailbox to impersonate");
                    return null;
            }

            try
            {
                ExchangeService exchangeService = new ExchangeService(ExchangeVersion.Exchange2013);
                exchangeService.Url = new Uri("https://outlook.office365.com/EWS/exchange.asmx");

                exchangeService.TraceListener = new EWSTracer(listBoxLog);
                exchangeService.TraceFlags = TraceFlags.All;
                exchangeService.TraceEnabled = checkBoxEWSTraceToOutput.Checked;

                if (checkBoxEWSImpersonate.Checked)
                    exchangeService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, textBoxEWSMailbox.Text);

                if (_oAuthHelper.TokenHasExpired)
                    _oAuthHelper.RenewToken();
                exchangeService.Credentials = new OAuthCredentials(_oAuthHelper.Token);

                exchangeService.HttpHeaders.Add("X-AnchorMailbox", MailboxSMTPAddress());
                return exchangeService;
            }
            catch (Exception ex)
            {
                Log(String.Format("Error: {0}", ex.Message));
            }

            return null;
        }

        private void buttonEWSGetInboxCount_Click(object sender, EventArgs e)
        {
            ExchangeService exchangeService = GetExchangeService();
            if (exchangeService == null) return;

            try
            {
                Folder inbox = Folder.Bind(exchangeService, WellKnownFolderName.Inbox);
                Log(String.Format("Inbox message count = {0}", inbox.TotalCount));
            }
            catch (Exception ex)
            {
                Log(String.Format("Error: {0}", ex.Message));
            }
        }

        private void buttonSubscribe_Click(object sender, EventArgs e)
        {
            ExchangeService exchangeService = GetExchangeService();
            if (exchangeService == null) return;
        }

        private void buttonAcquireToken_Click(object sender, EventArgs e)
        {
            // Note that we don't wait for the next async call to complete, as if we do we'll lock up the UI
            // We're not waiting on the result, so may as well return immediately
            _oAuthHelper.ObtainUserConsent = false;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            GetAuthTokenAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private void textBoxTenantId_TextChanged(object sender, EventArgs e)
        {
            comboBoxAuthenticationUrl.Items[1] = "https://login.microsoftonline.com/" + textBoxTenantId.Text;
        }

        private void radioButtonAuthWithClientSecret_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private void radioButtonAuthWithCertificate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private void buttonLoadCertificate_Click(object sender, EventArgs e)
        {
            FormChooseAuthCertificate oForm = new FormChooseAuthCertificate();
            DialogResult result = oForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            textBoxAuthCertificate.Tag = oForm.Certificate;
            textBoxAuthCertificate.Text = oForm.Certificate.Subject;
        }

        private void buttonSaveToken_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoadToken_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            oDialog.Filter = "Log files (*.log)|*.log|XML files (*.xml)|*.xml|Text files (*.txt)|*.txt|All Files|*.*";
            oDialog.DefaultExt = "log";
            oDialog.Title = "Select log/trace file to open";
            oDialog.CheckFileExists = true;
            if (oDialog.ShowDialog() != DialogResult.OK)
                return;
        }

        private void UpdateEWSUI()
        {
            bool bHaveAuthToken = HaveAuthToken();
            buttonEWSGetInboxCount.Enabled = bHaveAuthToken;
            buttonGetCalendarCount.Enabled = bHaveAuthToken;
        }

        private void buttonUserConsent_Click(object sender, EventArgs e)
        {
            _oAuthHelper.ObtainUserConsent = true;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            GetAuthTokenAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private void buttonManageTokens_Click(object sender, EventArgs e)
        {
            FormTokenViewer formTokenViewer = new FormTokenViewer(_oAuthHelper.TokenCache);
            formTokenViewer.Show(this);
        }

        private void nativeApiBtn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private void webAppApiBtn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private string MailboxSMTPAddress()
        {
            string mailboxSMTP = textBoxEWSMailbox.Text;
            if (!mailboxSMTP.Contains("@"))
            {
                mailboxSMTP = toolTip1.GetToolTip(textBoxEWSMailbox);
            }
            return mailboxSMTP;
        }

        private void buttonGetCalendarCount_Click(object sender, EventArgs e)
        {
            ExchangeService exchangeService = GetExchangeService();
            if (exchangeService == null) return;

            try
            {
                FolderId calendarFolderId = new FolderId(WellKnownFolderName.Calendar, MailboxSMTPAddress());
                Folder calendar = Folder.Bind(exchangeService, calendarFolderId);
                Log(String.Format("Appointment count = {0}", calendar.TotalCount));
            }
            catch (Exception ex)
            {
                Log(String.Format("Error: {0}", ex.Message));
            }
        }

        private OAuthContext InitOAuthContextFromFormValues()
        {
            // Create our OAuth information holder based on form values (we fill in what we can, some fields need to be filled in elsewhere)

            OAuthContext oAuthContext = new OAuthContext()
            {
                authUrl = comboBoxAuthenticationUrl.Text,
                clientId = textBoxApplicationId.Text,
                tenantName = textBoxTenantId.Text,
                resource = comboBoxResourceUrl.Text,
                redirectUrl = textBoxRedirectUrl.Text
            };

            if (radioButtonAuthWithCertificate.Checked)
            {
                oAuthContext.cert = (System.Security.Cryptography.X509Certificates.X509Certificate2)textBoxAuthCertificate.Tag;
                oAuthContext.secretKey = String.Empty;
            }
            else
                oAuthContext.secretKey = textBoxClientSecret.Text;

            return oAuthContext;
        }

        private async System.Threading.Tasks.Task buttonAppConsent_ClickAsync(object sender, EventArgs e)
        {
            // Obtain admin consent for application (which will return an id token that we use to get other tokens)
            OAuthContext oAuthContext = InitOAuthContextFromFormValues();
            oAuthContext.appConsent = true;
            oAuthContext.adminConsent = true; // This is implicit in app consent, but we'll set it anyway

            if (oAuthContext.cert == null)
            {
                // We MUST use certificate auth for application consent, so we fail here as we don't have one
                System.Windows.Forms.MessageBox.Show(this, "Certificate authentication is required for application authentication.", "Invalid Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormGetUserPermission formGetPermission = new FormGetUserPermission(oAuthContext);
            if (formGetPermission.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string code = formGetPermission.Token;
                // When we get our token, it will be cached in the TokenCache, so next time the silent calls will work

                ClientAssertionCertificate clientCert = new ClientAssertionCertificate(oAuthContext.clientId, oAuthContext.cert);
                AuthenticationResult authenticationResult = await _oAuthHelper.AuthenticationContext.AcquireTokenByAuthorizationCodeAsync(code, new Uri(oAuthContext.redirectUrl), clientCert);
            }
            return;
        }
    }
}
