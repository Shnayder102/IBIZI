
namespace IS_LAB3
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.InputText = new System.Windows.Forms.TextBox();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.KeyTextBox = new System.Windows.Forms.MaskedTextBox();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.EncryptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.InputText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OutputText);
            this.splitContainer1.Size = new System.Drawing.Size(703, 436);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 7;
            this.splitContainer1.TabStop = false;
            // 
            // InputText
            // 
            this.InputText.BackColor = System.Drawing.Color.White;
            this.InputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputText.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputText.ForeColor = System.Drawing.SystemColors.MenuText;
            this.InputText.Location = new System.Drawing.Point(0, 0);
            this.InputText.Margin = new System.Windows.Forms.Padding(2);
            this.InputText.Multiline = true;
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(703, 218);
            this.InputText.TabIndex = 0;
            this.InputText.TextChanged += new System.EventHandler(this.InputText_TextChanged);
            // 
            // OutputText
            // 
            this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputText.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputText.Location = new System.Drawing.Point(0, 0);
            this.OutputText.Margin = new System.Windows.Forms.Padding(2);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.Size = new System.Drawing.Size(703, 215);
            this.OutputText.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(703, 569);
            this.splitContainer2.SplitterDistance = 130;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.1254F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.8746F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DecryptButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.EncryptButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.90625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.09375F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 130);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Location = new System.Drawing.Point(2, 72);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.KeyTextBox);
            this.splitContainer3.Size = new System.Drawing.Size(355, 54);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ключ не более 32 ASCII символов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.AsciiOnly = true;
            this.KeyTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            this.KeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyTextBox.Location = new System.Drawing.Point(0, 0);
            this.KeyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(355, 20);
            this.KeyTextBox.TabIndex = 0;
            // 
            // DecryptButton
            // 
            this.DecryptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DecryptButton.Location = new System.Drawing.Point(361, 2);
            this.DecryptButton.Margin = new System.Windows.Forms.Padding(2);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(340, 66);
            this.DecryptButton.TabIndex = 4;
            this.DecryptButton.Text = "Расшифровать";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.ButtonDecrypt_Clicked);
            // 
            // EncryptButton
            // 
            this.EncryptButton.AutoSize = true;
            this.EncryptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EncryptButton.Location = new System.Drawing.Point(2, 2);
            this.EncryptButton.Margin = new System.Windows.Forms.Padding(2);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(355, 66);
            this.EncryptButton.TabIndex = 3;
            this.EncryptButton.Text = "Зашифровать";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.ButtonEncrypt_Clicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 569);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox KeyTextBox;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Button EncryptButton;
    }
}