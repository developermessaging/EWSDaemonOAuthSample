﻿/*
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;

namespace EWSDaemonOAuthSample
{
    class ClassFormConfig
    {
        private Form _form = null;
        private string _configFile = @".\Config.dat";
        private bool _encryptData = true;
        static Dictionary<string, string> _formsConfig = null;

        public ClassFormConfig(System.Windows.Forms.Form form)
        {
            Initialise(form);
        }

        public ClassFormConfig(Form form, bool Encrypt)
        {
            _encryptData = Encrypt;
            Initialise(form);
        }

        public ClassFormConfig(System.Windows.Forms.Form form, string configFile) 
        {
            _configFile = configFile;
            Initialise(form);
        }

        public ClassFormConfig(System.Windows.Forms.Form form, string configFile, bool Encrypt)
        {
            _configFile = configFile;
            _encryptData = Encrypt;
            Initialise(form);
        }

        private void _form_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormValues(_configFile);
        }

        private void Initialise(Form form)
        {
            if (_formsConfig == null)
                _formsConfig = new Dictionary<string, string>();
            _form = form;
            ReadFormValues(_configFile);
            _form.FormClosing += _form_FormClosing;
        }

        private void SaveControlProperties(Control control, ref StringBuilder appSettings)
        {
            // Write the control's properties to our config file

            appSettings.AppendLine(control.Name + ":Text:" + control.Text);

            PropertyInfo prop = control.GetType().GetProperty("SelectedIndex", BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                appSettings.AppendLine(control.Name + ":SelectedIndex:" + prop.GetValue(control));

            prop = control.GetType().GetProperty("Checked", BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                appSettings.AppendLine(control.Name + ":Checked:" + prop.GetValue(control));
        }

        private void RecurseControls(Control ParentControl, ref StringBuilder appSettings)
        {
            // Recursive routine to write control properties to our config file

            SaveControlProperties(ParentControl, ref appSettings);
            if (!ParentControl.HasChildren)
                return;

            foreach (Control control in ParentControl.Controls)
            {
                RecurseControls(control, ref appSettings);
            }
        }

        private void SaveFormValues(string Filename)
        {
            // Read and save all our control's values

            StringBuilder appSettings = new StringBuilder("FormConfig:");
            appSettings.AppendLine();

            foreach (Control control in _form.Controls)
                RecurseControls(control, ref appSettings);

            if (_encryptData)
            {
                File.WriteAllBytes(Filename, ProtectedData.Protect(Encoding.Unicode.GetBytes(appSettings.ToString()), null, DataProtectionScope.CurrentUser));
            }
            else
                File.WriteAllBytes(Filename, Encoding.Unicode.GetBytes(appSettings.ToString()));
        }

        private void ReadFormValues(string Filename)
        {
            // Read our saved control values from the file, and restore

            if (!File.Exists(Filename)) return;

            String appSettings = String.Empty;
            try
            {
                appSettings = Encoding.Unicode.GetString(ProtectedData.Unprotect(File.ReadAllBytes(Filename), null,
                                                             DataProtectionScope.CurrentUser));
            }
            catch { }
            if (!appSettings.StartsWith("FormConfig:"))
            {
                // Try reading unencrypted
                try
                {
                    appSettings = Encoding.Unicode.GetString(File.ReadAllBytes(Filename));
                }
                catch { }
            }
            if (!appSettings.StartsWith("FormConfig:"))
                return;


            using (StringReader reader = new StringReader(appSettings))
            {
                string sLine = "";
                while (sLine != null)
                {
                    sLine = reader.ReadLine();

                    if (!String.IsNullOrEmpty(sLine))
                    {
                        string[] controlSetting = sLine.Split(':');
                        if (controlSetting.Length > 3)
                        {
                            for (int i = 3; i < controlSetting.Length; i++)
                            {
                                controlSetting[2] = controlSetting[2] + ":" + controlSetting[i];
                            }
                        }

                        Control control = null;
                        try
                        {
                            control = _form.Controls.Find(controlSetting[0].Trim(), true)[0];
                        }
                        catch { }
                        if (control != null)
                        {
                            PropertyInfo prop = control.GetType().GetProperty(controlSetting[1].Trim(), BindingFlags.Public | BindingFlags.Instance);
                            if (prop != null && prop.CanWrite)
                            {
                                try
                                {
                                    switch (prop.PropertyType.Name.ToString())
                                    {
                                        case "Int32":
                                            prop.SetValue(control, Convert.ToInt32(controlSetting[2]));
                                            break;

                                        case "Boolean":
                                            prop.SetValue(control, Convert.ToBoolean(controlSetting[2]));
                                            break;

                                        default:
                                            prop.SetValue(control, controlSetting[2]);
                                            break;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
        }
    }


}
