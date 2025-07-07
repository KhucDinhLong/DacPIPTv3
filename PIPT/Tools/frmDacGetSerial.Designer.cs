namespace PIPT
{
    partial class frmDacGetSerial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacGetSerial));
            this.dacws = new PIPT.Track.dacws.WSACShowResult();
            this.btnGetSerial = new System.Windows.Forms.Button();
            this.labelDacCode = new System.Windows.Forms.Label();
            this.groupBoxGetSerial = new System.Windows.Forms.GroupBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDacCode = new System.Windows.Forms.TextBox();
            this.groupBoxGetSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // dacws
            // 
            this.dacws.AuthHeaderValue = null;
            this.dacws.Credentials = null;
            this.dacws.Url = "http://dacws.temchonggia.com.vn/WSACShowresult.asmx";
            this.dacws.UseDefaultCredentials = false;
            // 
            // btnGetSerial
            // 
            this.btnGetSerial.Location = new System.Drawing.Point(93, 45);
            this.btnGetSerial.Name = "btnGetSerial";
            this.btnGetSerial.Size = new System.Drawing.Size(105, 23);
            this.btnGetSerial.TabIndex = 1;
            this.btnGetSerial.Text = "Nhận số serial";
            this.btnGetSerial.UseVisualStyleBackColor = true;
            this.btnGetSerial.Click += new System.EventHandler(this.buttonGetSerial_Click);
            // 
            // labelDacCode
            // 
            this.labelDacCode.AutoSize = true;
            this.labelDacCode.Location = new System.Drawing.Point(27, 22);
            this.labelDacCode.Name = "labelDacCode";
            this.labelDacCode.Size = new System.Drawing.Size(60, 13);
            this.labelDacCode.TabIndex = 1;
            this.labelDacCode.Text = "Mã an ninh";
            // 
            // groupBoxGetSerial
            // 
            this.groupBoxGetSerial.Controls.Add(this.txtSerial);
            this.groupBoxGetSerial.Controls.Add(this.label1);
            this.groupBoxGetSerial.Controls.Add(this.txtDacCode);
            this.groupBoxGetSerial.Controls.Add(this.labelDacCode);
            this.groupBoxGetSerial.Controls.Add(this.btnGetSerial);
            this.groupBoxGetSerial.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGetSerial.Name = "groupBoxGetSerial";
            this.groupBoxGetSerial.Size = new System.Drawing.Size(306, 110);
            this.groupBoxGetSerial.TabIndex = 2;
            this.groupBoxGetSerial.TabStop = false;
            this.groupBoxGetSerial.Text = "Nhận số serial";
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(93, 74);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(153, 20);
            this.txtSerial.TabIndex = 2;
            this.txtSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSerial_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Serial";
            // 
            // txtDacCode
            // 
            this.txtDacCode.Location = new System.Drawing.Point(93, 19);
            this.txtDacCode.Name = "txtDacCode";
            this.txtDacCode.Size = new System.Drawing.Size(153, 20);
            this.txtDacCode.TabIndex = 0;
            // 
            // frmDacGetSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 131);
            this.Controls.Add(this.groupBoxGetSerial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacGetSerial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lấy số serial của mã an ninh";
            this.groupBoxGetSerial.ResumeLayout(false);
            this.groupBoxGetSerial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PIPT.Track.dacws.WSACShowResult dacws;
        private System.Windows.Forms.Button btnGetSerial;
        private System.Windows.Forms.Label labelDacCode;
        private System.Windows.Forms.GroupBox groupBoxGetSerial;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDacCode;
    }
}