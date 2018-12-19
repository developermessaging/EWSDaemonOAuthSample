namespace EWSDaemonOAuthSample
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxAuthenticationUrl = new System.Windows.Forms.ComboBox();
            this.comboBoxResourceUrl = new System.Windows.Forms.ComboBox();
            this.textBoxTenantId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxApplicationId = new System.Windows.Forms.TextBox();
            this.textBoxRedirectUrl = new System.Windows.Forms.TextBox();
            this.groupBoxAuth = new System.Windows.Forms.GroupBox();
            this.textBoxAuthCertificate = new System.Windows.Forms.TextBox();
            this.buttonLoadCertificate = new System.Windows.Forms.Button();
            this.radioButtonAuthWithCertificate = new System.Windows.Forms.RadioButton();
            this.radioButtonAuthWithClientSecret = new System.Windows.Forms.RadioButton();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.nativeApiBtn = new System.Windows.Forms.RadioButton();
            this.webAppApiBtn = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.v2EndpointBtn = new System.Windows.Forms.RadioButton();
            this.v1EndpointBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGetCalendarCount = new System.Windows.Forms.Button();
            this.buttonSubscribe = new System.Windows.Forms.Button();
            this.checkBoxEWSTraceToOutput = new System.Windows.Forms.CheckBox();
            this.checkBoxEWSImpersonate = new System.Windows.Forms.CheckBox();
            this.buttonEWSGetInboxCount = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEWSMailbox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonAppConsent = new System.Windows.Forms.Button();
            this.buttonUserConsent = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonManageTokens = new System.Windows.Forms.Button();
            this.buttonAcquireToken = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBoxAuth.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxAuthenticationUrl);
            this.groupBox2.Controls.Add(this.comboBoxResourceUrl);
            this.groupBox2.Controls.Add(this.textBoxTenantId);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxApplicationId);
            this.groupBox2.Controls.Add(this.textBoxRedirectUrl);
            this.groupBox2.Location = new System.Drawing.Point(21, 121);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(574, 214);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Information";
            // 
            // comboBoxAuthenticationUrl
            // 
            this.comboBoxAuthenticationUrl.FormattingEnabled = true;
            this.comboBoxAuthenticationUrl.Items.AddRange(new object[] {
            "https://login.microsoftonline.com/common",
            "https://login.microsoftonline.com/<tenant>",
            "https://login.windows.net/common"});
            this.comboBoxAuthenticationUrl.Location = new System.Drawing.Point(161, 139);
            this.comboBoxAuthenticationUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAuthenticationUrl.Name = "comboBoxAuthenticationUrl";
            this.comboBoxAuthenticationUrl.Size = new System.Drawing.Size(403, 28);
            this.comboBoxAuthenticationUrl.TabIndex = 26;
            // 
            // comboBoxResourceUrl
            // 
            this.comboBoxResourceUrl.FormattingEnabled = true;
            this.comboBoxResourceUrl.Items.AddRange(new object[] {
            "https://outlook.office365.com",
            "https://graph.microsoft.com",
            "https://manage.office.com",
            "https://graph.windowsazure.net"});
            this.comboBoxResourceUrl.Location = new System.Drawing.Point(161, 66);
            this.comboBoxResourceUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxResourceUrl.Name = "comboBoxResourceUrl";
            this.comboBoxResourceUrl.Size = new System.Drawing.Size(403, 28);
            this.comboBoxResourceUrl.TabIndex = 25;
            this.comboBoxResourceUrl.Text = "https://outlook.office365.com";
            // 
            // textBoxTenantId
            // 
            this.textBoxTenantId.Location = new System.Drawing.Point(161, 32);
            this.textBoxTenantId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTenantId.Name = "textBoxTenantId";
            this.textBoxTenantId.Size = new System.Drawing.Size(403, 26);
            this.textBoxTenantId.TabIndex = 20;
            this.textBoxTenantId.TextChanged += new System.EventHandler(this.textBoxTenantId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Application ID*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tenant ID*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Resource Url*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Redirect Url:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Authentication Url*:";
            // 
            // textBoxApplicationId
            // 
            this.textBoxApplicationId.Location = new System.Drawing.Point(161, 176);
            this.textBoxApplicationId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxApplicationId.Name = "textBoxApplicationId";
            this.textBoxApplicationId.Size = new System.Drawing.Size(403, 26);
            this.textBoxApplicationId.TabIndex = 21;
            // 
            // textBoxRedirectUrl
            // 
            this.textBoxRedirectUrl.Location = new System.Drawing.Point(161, 102);
            this.textBoxRedirectUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRedirectUrl.Name = "textBoxRedirectUrl";
            this.textBoxRedirectUrl.Size = new System.Drawing.Size(403, 26);
            this.textBoxRedirectUrl.TabIndex = 23;
            // 
            // groupBoxAuth
            // 
            this.groupBoxAuth.Controls.Add(this.textBoxAuthCertificate);
            this.groupBoxAuth.Controls.Add(this.buttonLoadCertificate);
            this.groupBoxAuth.Controls.Add(this.radioButtonAuthWithCertificate);
            this.groupBoxAuth.Controls.Add(this.radioButtonAuthWithClientSecret);
            this.groupBoxAuth.Controls.Add(this.textBoxClientSecret);
            this.groupBoxAuth.Location = new System.Drawing.Point(601, 11);
            this.groupBoxAuth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAuth.Name = "groupBoxAuth";
            this.groupBoxAuth.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAuth.Size = new System.Drawing.Size(574, 101);
            this.groupBoxAuth.TabIndex = 39;
            this.groupBoxAuth.TabStop = false;
            this.groupBoxAuth.Text = "Authentication";
            // 
            // textBoxAuthCertificate
            // 
            this.textBoxAuthCertificate.Location = new System.Drawing.Point(144, 58);
            this.textBoxAuthCertificate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAuthCertificate.Name = "textBoxAuthCertificate";
            this.textBoxAuthCertificate.Size = new System.Drawing.Size(339, 26);
            this.textBoxAuthCertificate.TabIndex = 31;
            // 
            // buttonLoadCertificate
            // 
            this.buttonLoadCertificate.Location = new System.Drawing.Point(489, 58);
            this.buttonLoadCertificate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLoadCertificate.Name = "buttonLoadCertificate";
            this.buttonLoadCertificate.Size = new System.Drawing.Size(75, 32);
            this.buttonLoadCertificate.TabIndex = 30;
            this.buttonLoadCertificate.Text = "Select...";
            this.buttonLoadCertificate.UseVisualStyleBackColor = true;
            this.buttonLoadCertificate.Click += new System.EventHandler(this.buttonLoadCertificate_Click);
            // 
            // radioButtonAuthWithCertificate
            // 
            this.radioButtonAuthWithCertificate.AutoSize = true;
            this.radioButtonAuthWithCertificate.Location = new System.Drawing.Point(11, 59);
            this.radioButtonAuthWithCertificate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonAuthWithCertificate.Name = "radioButtonAuthWithCertificate";
            this.radioButtonAuthWithCertificate.Size = new System.Drawing.Size(110, 24);
            this.radioButtonAuthWithCertificate.TabIndex = 28;
            this.radioButtonAuthWithCertificate.Text = "Certificate:";
            this.radioButtonAuthWithCertificate.UseVisualStyleBackColor = true;
            this.radioButtonAuthWithCertificate.CheckedChanged += new System.EventHandler(this.radioButtonAuthWithCertificate_CheckedChanged);
            // 
            // radioButtonAuthWithClientSecret
            // 
            this.radioButtonAuthWithClientSecret.AutoSize = true;
            this.radioButtonAuthWithClientSecret.Checked = true;
            this.radioButtonAuthWithClientSecret.Location = new System.Drawing.Point(11, 25);
            this.radioButtonAuthWithClientSecret.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonAuthWithClientSecret.Name = "radioButtonAuthWithClientSecret";
            this.radioButtonAuthWithClientSecret.Size = new System.Drawing.Size(126, 24);
            this.radioButtonAuthWithClientSecret.TabIndex = 0;
            this.radioButtonAuthWithClientSecret.TabStop = true;
            this.radioButtonAuthWithClientSecret.Text = "Client secret:";
            this.radioButtonAuthWithClientSecret.UseVisualStyleBackColor = true;
            this.radioButtonAuthWithClientSecret.CheckedChanged += new System.EventHandler(this.radioButtonAuthWithClientSecret_CheckedChanged);
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.Location = new System.Drawing.Point(144, 24);
            this.textBoxClientSecret.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.Size = new System.Drawing.Size(420, 26);
            this.textBoxClientSecret.TabIndex = 27;
            this.textBoxClientSecret.UseSystemPasswordChar = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.nativeApiBtn);
            this.groupBox8.Controls.Add(this.webAppApiBtn);
            this.groupBox8.Location = new System.Drawing.Point(316, 11);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Size = new System.Drawing.Size(279, 101);
            this.groupBox8.TabIndex = 42;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Registration Type";
            // 
            // nativeApiBtn
            // 
            this.nativeApiBtn.AutoSize = true;
            this.nativeApiBtn.Location = new System.Drawing.Point(18, 64);
            this.nativeApiBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nativeApiBtn.Name = "nativeApiBtn";
            this.nativeApiBtn.Size = new System.Drawing.Size(160, 24);
            this.nativeApiBtn.TabIndex = 32;
            this.nativeApiBtn.Text = "Native Application";
            this.nativeApiBtn.UseVisualStyleBackColor = true;
            this.nativeApiBtn.CheckedChanged += new System.EventHandler(this.nativeApiBtn_CheckedChanged);
            // 
            // webAppApiBtn
            // 
            this.webAppApiBtn.AutoSize = true;
            this.webAppApiBtn.Checked = true;
            this.webAppApiBtn.Location = new System.Drawing.Point(18, 34);
            this.webAppApiBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.webAppApiBtn.Name = "webAppApiBtn";
            this.webAppApiBtn.Size = new System.Drawing.Size(187, 24);
            this.webAppApiBtn.TabIndex = 31;
            this.webAppApiBtn.TabStop = true;
            this.webAppApiBtn.Text = "Web Application / API";
            this.webAppApiBtn.UseVisualStyleBackColor = true;
            this.webAppApiBtn.CheckedChanged += new System.EventHandler(this.webAppApiBtn_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.v2EndpointBtn);
            this.groupBox7.Controls.Add(this.v1EndpointBtn);
            this.groupBox7.Location = new System.Drawing.Point(21, 11);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Size = new System.Drawing.Size(279, 101);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Endpoint Type";
            // 
            // v2EndpointBtn
            // 
            this.v2EndpointBtn.AutoSize = true;
            this.v2EndpointBtn.Location = new System.Drawing.Point(18, 64);
            this.v2EndpointBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.v2EndpointBtn.Name = "v2EndpointBtn";
            this.v2EndpointBtn.Size = new System.Drawing.Size(248, 24);
            this.v2EndpointBtn.TabIndex = 32;
            this.v2EndpointBtn.Text = "v2.0 (apps.dev.microsoft..com)";
            this.v2EndpointBtn.UseVisualStyleBackColor = true;
            // 
            // v1EndpointBtn
            // 
            this.v1EndpointBtn.AutoSize = true;
            this.v1EndpointBtn.Checked = true;
            this.v1EndpointBtn.Location = new System.Drawing.Point(18, 34);
            this.v1EndpointBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.v1EndpointBtn.Name = "v1EndpointBtn";
            this.v1EndpointBtn.Size = new System.Drawing.Size(195, 24);
            this.v1EndpointBtn.TabIndex = 31;
            this.v1EndpointBtn.TabStop = true;
            this.v1EndpointBtn.Text = "v1.0 (portal.azure.com)";
            this.v1EndpointBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGetCalendarCount);
            this.groupBox1.Controls.Add(this.buttonSubscribe);
            this.groupBox1.Controls.Add(this.checkBoxEWSTraceToOutput);
            this.groupBox1.Controls.Add(this.checkBoxEWSImpersonate);
            this.groupBox1.Controls.Add(this.buttonEWSGetInboxCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxEWSMailbox);
            this.groupBox1.Location = new System.Drawing.Point(601, 287);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(574, 135);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EWS Tests";
            // 
            // buttonGetCalendarCount
            // 
            this.buttonGetCalendarCount.Location = new System.Drawing.Point(156, 91);
            this.buttonGetCalendarCount.Name = "buttonGetCalendarCount";
            this.buttonGetCalendarCount.Size = new System.Drawing.Size(172, 34);
            this.buttonGetCalendarCount.TabIndex = 35;
            this.buttonGetCalendarCount.Text = "Get Calendar Count";
            this.buttonGetCalendarCount.UseVisualStyleBackColor = true;
            this.buttonGetCalendarCount.Click += new System.EventHandler(this.buttonGetCalendarCount_Click);
            // 
            // buttonSubscribe
            // 
            this.buttonSubscribe.Enabled = false;
            this.buttonSubscribe.Location = new System.Drawing.Point(334, 91);
            this.buttonSubscribe.Name = "buttonSubscribe";
            this.buttonSubscribe.Size = new System.Drawing.Size(123, 34);
            this.buttonSubscribe.TabIndex = 34;
            this.buttonSubscribe.Text = "Subscribe";
            this.buttonSubscribe.UseVisualStyleBackColor = true;
            this.buttonSubscribe.Click += new System.EventHandler(this.buttonSubscribe_Click);
            // 
            // checkBoxEWSTraceToOutput
            // 
            this.checkBoxEWSTraceToOutput.AutoSize = true;
            this.checkBoxEWSTraceToOutput.Location = new System.Drawing.Point(276, 58);
            this.checkBoxEWSTraceToOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxEWSTraceToOutput.Name = "checkBoxEWSTraceToOutput";
            this.checkBoxEWSTraceToOutput.Size = new System.Drawing.Size(143, 24);
            this.checkBoxEWSTraceToOutput.TabIndex = 33;
            this.checkBoxEWSTraceToOutput.Text = "Trace to output";
            this.checkBoxEWSTraceToOutput.UseVisualStyleBackColor = true;
            // 
            // checkBoxEWSImpersonate
            // 
            this.checkBoxEWSImpersonate.AutoSize = true;
            this.checkBoxEWSImpersonate.Enabled = false;
            this.checkBoxEWSImpersonate.Location = new System.Drawing.Point(425, 58);
            this.checkBoxEWSImpersonate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxEWSImpersonate.Name = "checkBoxEWSImpersonate";
            this.checkBoxEWSImpersonate.Size = new System.Drawing.Size(125, 24);
            this.checkBoxEWSImpersonate.TabIndex = 2;
            this.checkBoxEWSImpersonate.Text = "Impersonate";
            this.checkBoxEWSImpersonate.UseVisualStyleBackColor = true;
            // 
            // buttonEWSGetInboxCount
            // 
            this.buttonEWSGetInboxCount.Location = new System.Drawing.Point(10, 91);
            this.buttonEWSGetInboxCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEWSGetInboxCount.Name = "buttonEWSGetInboxCount";
            this.buttonEWSGetInboxCount.Size = new System.Drawing.Size(139, 34);
            this.buttonEWSGetInboxCount.TabIndex = 32;
            this.buttonEWSGetInboxCount.Text = "Get Inbox Count";
            this.buttonEWSGetInboxCount.UseVisualStyleBackColor = true;
            this.buttonEWSGetInboxCount.Click += new System.EventHandler(this.buttonEWSGetInboxCount_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mailbox to access:";
            // 
            // textBoxEWSMailbox
            // 
            this.textBoxEWSMailbox.Location = new System.Drawing.Point(150, 22);
            this.textBoxEWSMailbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEWSMailbox.Name = "textBoxEWSMailbox";
            this.textBoxEWSMailbox.Size = new System.Drawing.Size(414, 26);
            this.textBoxEWSMailbox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxEWSMailbox, "Must be specified as GUID");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxLog);
            this.groupBox3.Location = new System.Drawing.Point(21, 427);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1154, 505);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 20;
            this.listBoxLog.Location = new System.Drawing.Point(3, 22);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(1148, 480);
            this.listBoxLog.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonAppConsent);
            this.groupBox4.Controls.Add(this.buttonUserConsent);
            this.groupBox4.Location = new System.Drawing.Point(601, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(574, 78);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Consent";
            // 
            // buttonAppConsent
            // 
            this.buttonAppConsent.Location = new System.Drawing.Point(11, 32);
            this.buttonAppConsent.Name = "buttonAppConsent";
            this.buttonAppConsent.Size = new System.Drawing.Size(186, 34);
            this.buttonAppConsent.TabIndex = 36;
            this.buttonAppConsent.Text = "Application Consent...";
            this.buttonAppConsent.UseVisualStyleBackColor = true;
            // 
            // buttonUserConsent
            // 
            this.buttonUserConsent.Location = new System.Drawing.Point(203, 32);
            this.buttonUserConsent.Name = "buttonUserConsent";
            this.buttonUserConsent.Size = new System.Drawing.Size(138, 34);
            this.buttonUserConsent.TabIndex = 35;
            this.buttonUserConsent.Text = "User Consent...";
            this.buttonUserConsent.UseVisualStyleBackColor = true;
            this.buttonUserConsent.Click += new System.EventHandler(this.buttonUserConsent_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonManageTokens);
            this.groupBox5.Controls.Add(this.buttonAcquireToken);
            this.groupBox5.Location = new System.Drawing.Point(601, 201);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(574, 65);
            this.groupBox5.TabIndex = 46;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tokens";
            // 
            // buttonManageTokens
            // 
            this.buttonManageTokens.Location = new System.Drawing.Point(156, 25);
            this.buttonManageTokens.Name = "buttonManageTokens";
            this.buttonManageTokens.Size = new System.Drawing.Size(178, 34);
            this.buttonManageTokens.TabIndex = 38;
            this.buttonManageTokens.Text = "Manage tokens...";
            this.buttonManageTokens.UseVisualStyleBackColor = true;
            this.buttonManageTokens.Click += new System.EventHandler(this.buttonManageTokens_Click);
            // 
            // buttonAcquireToken
            // 
            this.buttonAcquireToken.Location = new System.Drawing.Point(11, 25);
            this.buttonAcquireToken.Name = "buttonAcquireToken";
            this.buttonAcquireToken.Size = new System.Drawing.Size(138, 34);
            this.buttonAcquireToken.TabIndex = 37;
            this.buttonAcquireToken.Text = "Acquire token";
            this.buttonAcquireToken.UseVisualStyleBackColor = true;
            this.buttonAcquireToken.Click += new System.EventHandler(this.buttonAcquireToken_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 1032);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBoxAuth);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxAuth.ResumeLayout(false);
            this.groupBoxAuth.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxAuthenticationUrl;
        private System.Windows.Forms.ComboBox comboBoxResourceUrl;
        private System.Windows.Forms.TextBox textBoxTenantId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxApplicationId;
        private System.Windows.Forms.TextBox textBoxRedirectUrl;
        private System.Windows.Forms.GroupBox groupBoxAuth;
        private System.Windows.Forms.TextBox textBoxAuthCertificate;
        private System.Windows.Forms.Button buttonLoadCertificate;
        private System.Windows.Forms.RadioButton radioButtonAuthWithCertificate;
        private System.Windows.Forms.RadioButton radioButtonAuthWithClientSecret;
        private System.Windows.Forms.TextBox textBoxClientSecret;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton nativeApiBtn;
        private System.Windows.Forms.RadioButton webAppApiBtn;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton v2EndpointBtn;
        private System.Windows.Forms.RadioButton v1EndpointBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxEWSTraceToOutput;
        private System.Windows.Forms.CheckBox checkBoxEWSImpersonate;
        private System.Windows.Forms.Button buttonEWSGetInboxCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEWSMailbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSubscribe;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonUserConsent;
        private System.Windows.Forms.Button buttonGetCalendarCount;
        private System.Windows.Forms.Button buttonAppConsent;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonManageTokens;
        private System.Windows.Forms.Button buttonAcquireToken;
    }
}

