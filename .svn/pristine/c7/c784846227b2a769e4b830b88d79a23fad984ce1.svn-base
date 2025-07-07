using System.Windows.Forms;

namespace PIPT
{
    public partial class WaitForm : Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForm));
            this.pleaseWaitLabel = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.pleaseWaitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pleaseWaitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pleaseWaitLabel
            // 
            this.pleaseWaitLabel.AutoSize = true;
            this.pleaseWaitLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pleaseWaitLabel.Location = new System.Drawing.Point(61, 2);
            this.pleaseWaitLabel.Name = "pleaseWaitLabel";
            this.pleaseWaitLabel.Size = new System.Drawing.Size(142, 24);
            this.pleaseWaitLabel.TabIndex = 0;
            this.pleaseWaitLabel.Text = "PLEASE WAIT";
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.Location = new System.Drawing.Point(62, 31);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(58, 16);
            this.loadingLabel.TabIndex = 1;
            this.loadingLabel.Text = "Loading ...";
            // 
            // pleaseWaitPictureBox
            // 
            this.pleaseWaitPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pleaseWaitPictureBox.Image")));
            this.pleaseWaitPictureBox.Location = new System.Drawing.Point(3, 3);
            this.pleaseWaitPictureBox.Name = "pleaseWaitPictureBox";
            this.pleaseWaitPictureBox.Size = new System.Drawing.Size(54, 47);
            this.pleaseWaitPictureBox.TabIndex = 2;
            this.pleaseWaitPictureBox.TabStop = false;
            // 
            // WaitForm
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(208, 54);
            this.ControlBox = false;
            this.Controls.Add(this.pleaseWaitPictureBox);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.pleaseWaitLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WaitForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pleaseWaitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private Label pleaseWaitLabel;
        public Label loadingLabel;
        private PictureBox pleaseWaitPictureBox;
	}
	
}
