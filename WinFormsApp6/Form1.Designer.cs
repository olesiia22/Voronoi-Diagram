namespace WinFormsApp6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonToggleMode;
        private System.Windows.Forms.Button buttonToggleSplitRegions;
        private System.Windows.Forms.Button buttonShowMemory;
        private System.Windows.Forms.Button buttonShowElapsedTime;
        private System.Windows.Forms.Button buttonShowCpuTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonToggleMode = new System.Windows.Forms.Button();
            this.buttonToggleSplitRegions = new System.Windows.Forms.Button();
            this.buttonShowMemory = new System.Windows.Forms.Button();
            this.buttonShowElapsedTime = new System.Windows.Forms.Button();
            this.buttonShowCpuTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;

            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(12, 606);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);

            // 
            // buttonToggleMode
            // 
            this.buttonToggleMode.Location = new System.Drawing.Point(93, 606);
            this.buttonToggleMode.Name = "buttonToggleMode";
            this.buttonToggleMode.Size = new System.Drawing.Size(75, 23);
            this.buttonToggleMode.TabIndex = 2;
            this.buttonToggleMode.Text = "Toggle Mode";
            this.buttonToggleMode.UseVisualStyleBackColor = true;
            this.buttonToggleMode.Click += new System.EventHandler(this.buttonToggleMode_Click);

            // 
            // buttonToggleSplitRegions
            // 
            this.buttonToggleSplitRegions.Location = new System.Drawing.Point(174, 606);
            this.buttonToggleSplitRegions.Name = "buttonToggleSplitRegions";
            this.buttonToggleSplitRegions.Size = new System.Drawing.Size(140, 23);
            this.buttonToggleSplitRegions.TabIndex = 3;
            this.buttonToggleSplitRegions.Text = "Toggle Split Regions";
            this.buttonToggleSplitRegions.UseVisualStyleBackColor = true;
            this.buttonToggleSplitRegions.Click += new System.EventHandler(this.buttonToggleSplitRegions_Click);

            // 
            // buttonShowMemory
            // 
            this.buttonShowMemory.Location = new System.Drawing.Point(320, 606);
            this.buttonShowMemory.Name = "buttonShowMemory";
            this.buttonShowMemory.Size = new System.Drawing.Size(100, 23);
            this.buttonShowMemory.TabIndex = 4;
            this.buttonShowMemory.Text = "Show Memory";
            this.buttonShowMemory.UseVisualStyleBackColor = true;
            this.buttonShowMemory.Click += new System.EventHandler(this.buttonShowMemory_Click);

            // 
            // buttonShowElapsedTime
            // 
            this.buttonShowElapsedTime.Location = new System.Drawing.Point(426, 606);
            this.buttonShowElapsedTime.Name = "buttonShowElapsedTime";
            this.buttonShowElapsedTime.Size = new System.Drawing.Size(100, 23);
            this.buttonShowElapsedTime.TabIndex = 5;
            this.buttonShowElapsedTime.Text = "Show Elapsed Time";
            this.buttonShowElapsedTime.UseVisualStyleBackColor = true;
            this.buttonShowElapsedTime.Click += new System.EventHandler(this.buttonShowElapsedTime_Click);

            // 
            // buttonShowCpuTime
            // 
            this.buttonShowCpuTime.Location = new System.Drawing.Point(532, 606);
            this.buttonShowCpuTime.Name = "buttonShowCpuTime";
            this.buttonShowCpuTime.Size = new System.Drawing.Size(100, 23);
            this.buttonShowCpuTime.TabIndex = 6;
            this.buttonShowCpuTime.Text = "Show CPU Time";
            this.buttonShowCpuTime.UseVisualStyleBackColor = true;
            this.buttonShowCpuTime.Click += new System.EventHandler(this.buttonShowCpuTime_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 641);
            this.Controls.Add(this.buttonShowCpuTime);
            this.Controls.Add(this.buttonShowElapsedTime);
            this.Controls.Add(this.buttonShowMemory);
            this.Controls.Add(this.buttonToggleSplitRegions);
            this.Controls.Add(this.buttonToggleMode);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Voronoi Diagram";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
