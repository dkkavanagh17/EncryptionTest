using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public MainForm()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            labelMode = new Label();
            dropdownMode = new ComboBox();
            labelKey = new Label();
            textboxKey = new TextBox();
            labelTextDecrypted = new Label();
            textboxDecryptedText = new TextBox();
            textboxEncryptedText = new TextBox();
            labelTextEncrypted = new Label();
            buttonEncryptDecrypt = new Button();
            tableMain = new TableLayoutPanel();
            tableRow3 = new TableLayoutPanel();
            labelError = new Label();
            tableRow4 = new TableLayoutPanel();
            tableRow2 = new TableLayoutPanel();
            tableRow1 = new TableLayoutPanel();
            buttonGenerateKey = new Button();
            tableMain.SuspendLayout();
            tableRow3.SuspendLayout();
            tableRow4.SuspendLayout();
            tableRow2.SuspendLayout();
            tableRow1.SuspendLayout();
            SuspendLayout();
            // 
            // labelMode
            // 
            labelMode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelMode.AutoSize = true;
            labelMode.Location = new Point(3, 0);
            labelMode.Name = "labelMode";
            labelMode.Size = new Size(59, 40);
            labelMode.TabIndex = 0;
            labelMode.Text = "Mode";
            labelMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dropdownMode
            // 
            dropdownMode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dropdownMode.FormattingEnabled = true;
            dropdownMode.Items.AddRange(new object[] { "Encrypt", "Decrypt" });
            dropdownMode.Location = new Point(83, 3);
            dropdownMode.Name = "dropdownMode";
            dropdownMode.Size = new Size(114, 33);
            dropdownMode.TabIndex = 1;
            dropdownMode.Text = "Encrypt";
            dropdownMode.SelectedIndexChanged += dropdownMode_SelectedIndexChanged;
            // 
            // labelKey
            // 
            labelKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelKey.AutoSize = true;
            labelKey.Location = new Point(303, 0);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(44, 40);
            labelKey.TabIndex = 2;
            labelKey.Text = "Key";
            labelKey.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textboxKey
            // 
            textboxKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textboxKey.Location = new Point(353, 3);
            textboxKey.Name = "textboxKey";
            textboxKey.Size = new Size(252, 31);
            textboxKey.TabIndex = 3;
            // 
            // labelTextDecrypted
            // 
            labelTextDecrypted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelTextDecrypted.AutoSize = true;
            labelTextDecrypted.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTextDecrypted.Location = new Point(3, 0);
            labelTextDecrypted.Name = "labelTextDecrypted";
            labelTextDecrypted.Size = new Size(145, 40);
            labelTextDecrypted.TabIndex = 4;
            labelTextDecrypted.Text = "Enter Plain Text";
            labelTextDecrypted.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textboxDecryptedText
            // 
            textboxDecryptedText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textboxDecryptedText.Location = new Point(0, 40);
            textboxDecryptedText.Margin = new Padding(0);
            textboxDecryptedText.Multiline = true;
            textboxDecryptedText.Name = "textboxDecryptedText";
            textboxDecryptedText.Size = new Size(802, 152);
            textboxDecryptedText.TabIndex = 5;
            // 
            // textboxEncryptedText
            // 
            textboxEncryptedText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textboxEncryptedText.Location = new Point(3, 43);
            textboxEncryptedText.Multiline = true;
            textboxEncryptedText.Name = "textboxEncryptedText";
            textboxEncryptedText.Size = new Size(802, 153);
            textboxEncryptedText.TabIndex = 7;
            // 
            // labelTextEncrypted
            // 
            labelTextEncrypted.Anchor = AnchorStyles.Left;
            labelTextEncrypted.AutoSize = true;
            labelTextEncrypted.Location = new Point(0, 7);
            labelTextEncrypted.Margin = new Padding(0);
            labelTextEncrypted.Name = "labelTextEncrypted";
            labelTextEncrypted.Size = new Size(126, 25);
            labelTextEncrypted.TabIndex = 6;
            labelTextEncrypted.Text = "Encrypted Text";
            labelTextEncrypted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonEncryptDecrypt
            // 
            buttonEncryptDecrypt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEncryptDecrypt.Font = new Font("Segoe UI", 9F);
            buttonEncryptDecrypt.Location = new Point(0, 0);
            buttonEncryptDecrypt.Margin = new Padding(0);
            buttonEncryptDecrypt.Name = "buttonEncryptDecrypt";
            buttonEncryptDecrypt.Size = new Size(120, 40);
            buttonEncryptDecrypt.TabIndex = 8;
            buttonEncryptDecrypt.Text = "Encrypt";
            buttonEncryptDecrypt.UseVisualStyleBackColor = true;
            buttonEncryptDecrypt.Click += buttonEncryptDecrypt_Click;
            // 
            // tableMain
            // 
            tableMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableMain.AutoSize = true;
            tableMain.ColumnCount = 1;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableMain.Controls.Add(tableRow3, 0, 2);
            tableMain.Controls.Add(tableRow4, 0, 3);
            tableMain.Controls.Add(tableRow2, 0, 1);
            tableMain.Controls.Add(tableRow1, 0, 0);
            tableMain.Location = new Point(12, 12);
            tableMain.Name = "tableMain";
            tableMain.RowCount = 4;
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableMain.Size = new Size(808, 477);
            tableMain.TabIndex = 10;
            // 
            // tableRow3
            // 
            tableRow3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableRow3.AutoSize = true;
            tableRow3.ColumnCount = 3;
            tableRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableRow3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableRow3.Controls.Add(buttonEncryptDecrypt, 0, 0);
            tableRow3.Controls.Add(labelError, 2, 0);
            tableRow3.Location = new Point(0, 238);
            tableRow3.Margin = new Padding(0);
            tableRow3.Name = "tableRow3";
            tableRow3.RowCount = 1;
            tableRow3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableRow3.Size = new Size(808, 40);
            tableRow3.TabIndex = 8;
            // 
            // labelError
            // 
            labelError.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelError.BackColor = SystemColors.Control;
            labelError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(140, 0);
            labelError.Margin = new Padding(0);
            labelError.Name = "labelError";
            labelError.Size = new Size(668, 40);
            labelError.TabIndex = 10;
            labelError.Text = "ERROR";
            labelError.TextAlign = ContentAlignment.MiddleLeft;
            labelError.Visible = false;
            // 
            // tableRow4
            // 
            tableRow4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableRow4.AutoSize = true;
            tableRow4.ColumnCount = 1;
            tableRow4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableRow4.Controls.Add(textboxEncryptedText, 0, 1);
            tableRow4.Controls.Add(labelTextEncrypted, 0, 0);
            tableRow4.Location = new Point(0, 278);
            tableRow4.Margin = new Padding(0);
            tableRow4.Name = "tableRow4";
            tableRow4.RowCount = 2;
            tableRow4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableRow4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableRow4.Size = new Size(808, 199);
            tableRow4.TabIndex = 9;
            // 
            // tableRow2
            // 
            tableRow2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableRow2.AutoSize = true;
            tableRow2.ColumnCount = 1;
            tableRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableRow2.Controls.Add(textboxDecryptedText, 0, 1);
            tableRow2.Controls.Add(labelTextDecrypted, 0, 0);
            tableRow2.Location = new Point(3, 43);
            tableRow2.Name = "tableRow2";
            tableRow2.RowCount = 2;
            tableRow2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableRow2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableRow2.Size = new Size(802, 192);
            tableRow2.TabIndex = 10;
            // 
            // tableRow1
            // 
            tableRow1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableRow1.ColumnCount = 6;
            tableRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableRow1.Controls.Add(labelMode, 0, 0);
            tableRow1.Controls.Add(labelKey, 3, 0);
            tableRow1.Controls.Add(textboxKey, 4, 0);
            tableRow1.Controls.Add(dropdownMode, 1, 0);
            tableRow1.Controls.Add(buttonGenerateKey, 5, 0);
            tableRow1.Location = new Point(0, 0);
            tableRow1.Margin = new Padding(0);
            tableRow1.Name = "tableRow1";
            tableRow1.RowCount = 1;
            tableRow1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableRow1.Size = new Size(808, 40);
            tableRow1.TabIndex = 11;
            // 
            // buttonGenerateKey
            // 
            buttonGenerateKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonGenerateKey.Font = new Font("Segoe UI", 9F);
            buttonGenerateKey.Location = new Point(608, 0);
            buttonGenerateKey.Margin = new Padding(0);
            buttonGenerateKey.Name = "buttonGenerateKey";
            buttonGenerateKey.Size = new Size(200, 40);
            buttonGenerateKey.TabIndex = 9;
            buttonGenerateKey.Text = "Generate Random Key";
            buttonGenerateKey.UseVisualStyleBackColor = true;
            buttonGenerateKey.Click += buttonGenerateKey_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(832, 501);
            Controls.Add(tableMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(492, 0);
            Name = "MainForm";
            Text = "XR4 Encryption";
            tableMain.ResumeLayout(false);
            tableMain.PerformLayout();
            tableRow3.ResumeLayout(false);
            tableRow4.ResumeLayout(false);
            tableRow4.PerformLayout();
            tableRow2.ResumeLayout(false);
            tableRow2.PerformLayout();
            tableRow1.ResumeLayout(false);
            tableRow1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox dropdownMode;
        private Label labelKey;
        private TextBox textboxKey;
        private Label labelTextDecrypted;
        private TextBox textboxDecryptedText;
        private TextBox textboxEncryptedText;
        private Label labelTextEncrypted;
        private Button buttonEncryptDecrypt;
        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableRow3;
        private Label labelError;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableRow4;
        private TableLayoutPanel tableRow2;
        private TableLayoutPanel tableRow1;
        private Button buttonGenerateKey;
        private Label labelMode;

        private void dropdownMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFromMode();
        }

        private void buttonEncryptDecrypt_Click(object sender, EventArgs e)
        {
            EncryptDecrypt();
        }

        private void UpdateFromMode()
        {
            UpdateError(false);

            if (dropdownMode.SelectedIndex == 0) //Encrypt Mode
            {
                labelTextDecrypted.Text = "Enter Plain Text";
                labelTextDecrypted.Font = new Font(labelTextDecrypted.Font, FontStyle.Bold);
                labelTextEncrypted.Text = "Encrypted Text";
                labelTextEncrypted.Font = new Font(labelTextEncrypted.Font, FontStyle.Regular);
                buttonEncryptDecrypt.Text = "Encrypt";
            }
            else //Decrypt Mode
            {
                labelTextDecrypted.Text = "Decrypted Text";
                labelTextDecrypted.Font = new Font(labelTextDecrypted.Font, FontStyle.Regular);
                labelTextEncrypted.Text = "Enter Encrypted Text";
                labelTextEncrypted.Font = new Font(labelTextEncrypted.Font, FontStyle.Bold);
                buttonEncryptDecrypt.Text = "Decrypt";
            }
        }

        private void EncryptDecrypt()
        {
            UpdateError(false);

            string input_data;

            if (dropdownMode.SelectedIndex == 0) //Encrypt Mode
            {
                input_data = textboxDecryptedText.Text;
            }
            else //Decrypt Mode
            {
                input_data = textboxEncryptedText.Text;
            }


            XR4.KeyData keyData = XR4.KeyDataFromText(textboxKey.Text);

            if (keyData == null)
            {
                UpdateError(true, "INVALID KEY");
                return;
            }


            XR4v2024_05_26 xr4 = new XR4v2024_05_26(keyData);
            int[] batch;

            if (dropdownMode.SelectedIndex == 0) //Encrypt Mode
            {
                batch = XR4.BatchFromText(textboxDecryptedText.Text);
            }
            else //Decrypt Mode
            {
                batch = XR4.BatchFrom8BitHex(textboxEncryptedText.Text);
            }

            if (batch == null)
            {
                if (dropdownMode.SelectedIndex == 0) //Encrypt Mode
                {
                    UpdateError(true, "INVALID TEXT NOT ASCII");
                }
                else //Decrypt Mode
                {
                    UpdateError(true, "INVALID HEX NOT 8BIT (MULTIPLE OF 2 DIGITS)");
                }
                return;
            }




            string output_data;

            if (dropdownMode.SelectedIndex == 0) //Encrypt Mode
            {
                batch = xr4.Encrypt(batch);

                output_data = XR4.BatchTo8BitHex(batch);

                textboxEncryptedText.Text = output_data;
            }
            else //Decrypt Mode
            {
                batch = xr4.Decrypt(batch);

                output_data = XR4.BatchToText(batch);

                textboxDecryptedText.Text = output_data;
            }
        }

        private void UpdateError(bool enabled)
        {
            UpdateError(enabled, "");
        }

        private void UpdateError(bool enabled, string text)
        {
            labelError.Visible = enabled;
            labelError.Text = text;
        }

        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            XR4.KeyData keyData = XR4.GenerateRandomKeyData();
            textboxKey.Text = XR4.KeyDataToText(keyData);
        }
    }
}