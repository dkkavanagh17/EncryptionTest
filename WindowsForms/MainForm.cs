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
            tableEncrypted = new TableLayoutPanel();
            tableDecrypted = new TableLayoutPanel();
            tableRow1 = new TableLayoutPanel();
            buttonGenerateKey = new Button();
            label1 = new Label();
            tableMain.SuspendLayout();
            tableRow3.SuspendLayout();
            tableEncrypted.SuspendLayout();
            tableDecrypted.SuspendLayout();
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
            dropdownMode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dropdownMode.FormattingEnabled = true;
            dropdownMode.Items.AddRange(new object[] { "Encrypt", "Decrypt" });
            dropdownMode.Location = new Point(80, 3);
            dropdownMode.Margin = new Padding(0);
            dropdownMode.Name = "dropdownMode";
            dropdownMode.Size = new Size(120, 33);
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
            textboxKey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textboxKey.Font = new Font("Courier New", 9F);
            textboxKey.Location = new Point(350, 6);
            textboxKey.Margin = new Padding(0);
            textboxKey.Name = "textboxKey";
            textboxKey.Size = new Size(261, 28);
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
            textboxDecryptedText.Font = new Font("Courier New", 9F);
            textboxDecryptedText.Location = new Point(0, 40);
            textboxDecryptedText.Margin = new Padding(0);
            textboxDecryptedText.Multiline = true;
            textboxDecryptedText.Name = "textboxDecryptedText";
            textboxDecryptedText.Size = new Size(805, 132);
            textboxDecryptedText.TabIndex = 5;
            // 
            // textboxEncryptedText
            // 
            textboxEncryptedText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textboxEncryptedText.Font = new Font("Courier New", 9F);
            textboxEncryptedText.Location = new Point(3, 43);
            textboxEncryptedText.Multiline = true;
            textboxEncryptedText.Name = "textboxEncryptedText";
            textboxEncryptedText.Size = new Size(805, 133);
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
            tableMain.Controls.Add(tableRow3, 0, 3);
            tableMain.Controls.Add(tableEncrypted, 0, 4);
            tableMain.Controls.Add(tableDecrypted, 0, 2);
            tableMain.Controls.Add(tableRow1, 0, 1);
            tableMain.Controls.Add(label1, 0, 0);
            tableMain.Location = new Point(12, 12);
            tableMain.Margin = new Padding(0);
            tableMain.Name = "tableMain";
            tableMain.RowCount = 5;
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableMain.Size = new Size(811, 477);
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
            tableRow3.Location = new Point(0, 258);
            tableRow3.Margin = new Padding(0);
            tableRow3.Name = "tableRow3";
            tableRow3.RowCount = 1;
            tableRow3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableRow3.Size = new Size(811, 40);
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
            labelError.Size = new Size(671, 40);
            labelError.TabIndex = 10;
            labelError.Text = "ERROR";
            labelError.TextAlign = ContentAlignment.MiddleLeft;
            labelError.Visible = false;
            // 
            // tableEncrypted
            // 
            tableEncrypted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableEncrypted.AutoSize = true;
            tableEncrypted.ColumnCount = 1;
            tableEncrypted.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableEncrypted.Controls.Add(textboxEncryptedText, 0, 1);
            tableEncrypted.Controls.Add(labelTextEncrypted, 0, 0);
            tableEncrypted.Location = new Point(0, 298);
            tableEncrypted.Margin = new Padding(0);
            tableEncrypted.Name = "tableEncrypted";
            tableEncrypted.RowCount = 2;
            tableEncrypted.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableEncrypted.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableEncrypted.Size = new Size(811, 179);
            tableEncrypted.TabIndex = 9;
            // 
            // tableDecrypted
            // 
            tableDecrypted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableDecrypted.AutoSize = true;
            tableDecrypted.ColumnCount = 1;
            tableDecrypted.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableDecrypted.Controls.Add(textboxDecryptedText, 0, 1);
            tableDecrypted.Controls.Add(labelTextDecrypted, 0, 0);
            tableDecrypted.Location = new Point(3, 83);
            tableDecrypted.Name = "tableDecrypted";
            tableDecrypted.RowCount = 2;
            tableDecrypted.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableDecrypted.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableDecrypted.Size = new Size(805, 172);
            tableDecrypted.TabIndex = 10;
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
            tableRow1.Controls.Add(dropdownMode, 1, 0);
            tableRow1.Controls.Add(buttonGenerateKey, 5, 0);
            tableRow1.Controls.Add(textboxKey, 4, 0);
            tableRow1.Location = new Point(0, 40);
            tableRow1.Margin = new Padding(0);
            tableRow1.Name = "tableRow1";
            tableRow1.RowCount = 1;
            tableRow1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableRow1.Size = new Size(811, 40);
            tableRow1.TabIndex = 11;
            // 
            // buttonGenerateKey
            // 
            buttonGenerateKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonGenerateKey.Font = new Font("Segoe UI", 9F);
            buttonGenerateKey.Location = new Point(611, 0);
            buttonGenerateKey.Margin = new Padding(0);
            buttonGenerateKey.Name = "buttonGenerateKey";
            buttonGenerateKey.Size = new Size(200, 40);
            buttonGenerateKey.TabIndex = 9;
            buttonGenerateKey.Text = "Generate Random Key";
            buttonGenerateKey.UseVisualStyleBackColor = true;
            buttonGenerateKey.Click += buttonGenerateKey_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(109, 40);
            label1.TabIndex = 10;
            label1.Text = "v2024.05.26";
            label1.TextAlign = ContentAlignment.MiddleLeft;
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
            tableEncrypted.ResumeLayout(false);
            tableEncrypted.PerformLayout();
            tableDecrypted.ResumeLayout(false);
            tableDecrypted.PerformLayout();
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
        private TableLayoutPanel tableEncrypted;
        private TableLayoutPanel tableDecrypted;
        private TableLayoutPanel tableRow1;
        private Button buttonGenerateKey;
        private Label label1;
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