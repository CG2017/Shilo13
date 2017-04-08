namespace lab2WF
{
    partial class MainForm
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
            this.pctBoxSource = new System.Windows.Forms.PictureBox();
            this.pctBoxDestination = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.pctBoxSelectedColor = new System.Windows.Forms.PictureBox();
            this.lblSelectedColor = new System.Windows.Forms.Label();
            this.pctBoxDestColor = new System.Windows.Forms.PictureBox();
            this.lblDestColor = new System.Windows.Forms.Label();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.sliderSensitivity = new System.Windows.Forms.TrackBar();
            this.lblSensitivity = new System.Windows.Forms.Label();
            this.btnSetAsSource = new System.Windows.Forms.Button();
            this.sliderKL = new System.Windows.Forms.TrackBar();
            this.sliderKA = new System.Windows.Forms.TrackBar();
            this.sliderKB = new System.Windows.Forms.TrackBar();
            this.lblKL = new System.Windows.Forms.Label();
            this.lblKA = new System.Windows.Forms.Label();
            this.lblKB = new System.Windows.Forms.Label();
            this.lblKLvalue = new System.Windows.Forms.Label();
            this.lblKAvalue = new System.Windows.Forms.Label();
            this.lblKBvalue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxSelectedColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDestColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderKL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderKB)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxSource
            // 
            this.pctBoxSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxSource.Location = new System.Drawing.Point(12, 12);
            this.pctBoxSource.Name = "pctBoxSource";
            this.pctBoxSource.Size = new System.Drawing.Size(509, 400);
            this.pctBoxSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxSource.TabIndex = 0;
            this.pctBoxSource.TabStop = false;
            // 
            // pctBoxDestination
            // 
            this.pctBoxDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxDestination.Location = new System.Drawing.Point(710, 12);
            this.pctBoxDestination.Name = "pctBoxDestination";
            this.pctBoxDestination.Size = new System.Drawing.Size(509, 400);
            this.pctBoxDestination.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxDestination.TabIndex = 1;
            this.pctBoxDestination.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 418);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(91, 36);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(540, 275);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(150, 43);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = ">>>>>>>>>>>>>>";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // pctBoxSelectedColor
            // 
            this.pctBoxSelectedColor.BackColor = System.Drawing.Color.White;
            this.pctBoxSelectedColor.Location = new System.Drawing.Point(540, 114);
            this.pctBoxSelectedColor.Name = "pctBoxSelectedColor";
            this.pctBoxSelectedColor.Size = new System.Drawing.Size(150, 33);
            this.pctBoxSelectedColor.TabIndex = 4;
            this.pctBoxSelectedColor.TabStop = false;
            // 
            // lblSelectedColor
            // 
            this.lblSelectedColor.AutoSize = true;
            this.lblSelectedColor.Location = new System.Drawing.Point(540, 95);
            this.lblSelectedColor.Name = "lblSelectedColor";
            this.lblSelectedColor.Size = new System.Drawing.Size(75, 13);
            this.lblSelectedColor.TabIndex = 5;
            this.lblSelectedColor.Text = "Selected color";
            // 
            // pctBoxDestColor
            // 
            this.pctBoxDestColor.BackColor = System.Drawing.Color.White;
            this.pctBoxDestColor.Location = new System.Drawing.Point(543, 236);
            this.pctBoxDestColor.Name = "pctBoxDestColor";
            this.pctBoxDestColor.Size = new System.Drawing.Size(147, 33);
            this.pctBoxDestColor.TabIndex = 6;
            this.pctBoxDestColor.TabStop = false;
            // 
            // lblDestColor
            // 
            this.lblDestColor.AutoSize = true;
            this.lblDestColor.Location = new System.Drawing.Point(543, 216);
            this.lblDestColor.Name = "lblDestColor";
            this.lblDestColor.Size = new System.Drawing.Size(63, 13);
            this.lblDestColor.TabIndex = 7;
            this.lblDestColor.Text = "Result color";
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(540, 168);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(150, 32);
            this.btnSelectColor.TabIndex = 8;
            this.btnSelectColor.Text = "Select color";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // sliderSensitivity
            // 
            this.sliderSensitivity.Location = new System.Drawing.Point(476, 446);
            this.sliderSensitivity.Maximum = 200;
            this.sliderSensitivity.Minimum = 1;
            this.sliderSensitivity.Name = "sliderSensitivity";
            this.sliderSensitivity.Size = new System.Drawing.Size(276, 45);
            this.sliderSensitivity.TabIndex = 9;
            this.sliderSensitivity.Value = 1;
            // 
            // lblSensitivity
            // 
            this.lblSensitivity.AutoSize = true;
            this.lblSensitivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSensitivity.Location = new System.Drawing.Point(574, 423);
            this.lblSensitivity.Name = "lblSensitivity";
            this.lblSensitivity.Size = new System.Drawing.Size(79, 20);
            this.lblSensitivity.TabIndex = 10;
            this.lblSensitivity.Text = "Sensitivity";
            // 
            // btnSetAsSource
            // 
            this.btnSetAsSource.Location = new System.Drawing.Point(1076, 423);
            this.btnSetAsSource.Name = "btnSetAsSource";
            this.btnSetAsSource.Size = new System.Drawing.Size(143, 42);
            this.btnSetAsSource.TabIndex = 11;
            this.btnSetAsSource.Text = "Set as source";
            this.btnSetAsSource.UseVisualStyleBackColor = true;
            this.btnSetAsSource.Click += new System.EventHandler(this.btnSetAsSource_Click);
            // 
            // sliderKL
            // 
            this.sliderKL.Location = new System.Drawing.Point(134, 446);
            this.sliderKL.Maximum = 500;
            this.sliderKL.Name = "sliderKL";
            this.sliderKL.Size = new System.Drawing.Size(177, 45);
            this.sliderKL.TabIndex = 12;
            this.sliderKL.Value = 100;
            // 
            // sliderKA
            // 
            this.sliderKA.Location = new System.Drawing.Point(134, 516);
            this.sliderKA.Maximum = 500;
            this.sliderKA.Name = "sliderKA";
            this.sliderKA.Size = new System.Drawing.Size(177, 45);
            this.sliderKA.TabIndex = 13;
            this.sliderKA.Value = 100;
            // 
            // sliderKB
            // 
            this.sliderKB.Location = new System.Drawing.Point(134, 591);
            this.sliderKB.Maximum = 500;
            this.sliderKB.Name = "sliderKB";
            this.sliderKB.Size = new System.Drawing.Size(177, 45);
            this.sliderKB.TabIndex = 14;
            this.sliderKB.Value = 100;
            // 
            // lblKL
            // 
            this.lblKL.AutoSize = true;
            this.lblKL.Location = new System.Drawing.Point(131, 430);
            this.lblKL.Name = "lblKL";
            this.lblKL.Size = new System.Drawing.Size(56, 13);
            this.lblKL.TabIndex = 15;
            this.lblKL.Text = "L multiplier";
            // 
            // lblKA
            // 
            this.lblKA.AutoSize = true;
            this.lblKA.Location = new System.Drawing.Point(131, 500);
            this.lblKA.Name = "lblKA";
            this.lblKA.Size = new System.Drawing.Size(56, 13);
            this.lblKA.TabIndex = 16;
            this.lblKA.Text = "a multiplier";
            // 
            // lblKB
            // 
            this.lblKB.AutoSize = true;
            this.lblKB.Location = new System.Drawing.Point(131, 575);
            this.lblKB.Name = "lblKB";
            this.lblKB.Size = new System.Drawing.Size(56, 13);
            this.lblKB.TabIndex = 17;
            this.lblKB.Text = "b multiplier";
            // 
            // lblKLvalue
            // 
            this.lblKLvalue.AutoSize = true;
            this.lblKLvalue.Location = new System.Drawing.Point(317, 452);
            this.lblKLvalue.Name = "lblKLvalue";
            this.lblKLvalue.Size = new System.Drawing.Size(28, 13);
            this.lblKLvalue.TabIndex = 18;
            this.lblKLvalue.Text = "1.00";
            // 
            // lblKAvalue
            // 
            this.lblKAvalue.AutoSize = true;
            this.lblKAvalue.Location = new System.Drawing.Point(317, 516);
            this.lblKAvalue.Name = "lblKAvalue";
            this.lblKAvalue.Size = new System.Drawing.Size(28, 13);
            this.lblKAvalue.TabIndex = 19;
            this.lblKAvalue.Text = "1.00";
            // 
            // lblKBvalue
            // 
            this.lblKBvalue.AutoSize = true;
            this.lblKBvalue.Location = new System.Drawing.Point(317, 591);
            this.lblKBvalue.Name = "lblKBvalue";
            this.lblKBvalue.Size = new System.Drawing.Size(28, 13);
            this.lblKBvalue.TabIndex = 20;
            this.lblKBvalue.Text = "1.00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 648);
            this.Controls.Add(this.lblKBvalue);
            this.Controls.Add(this.lblKAvalue);
            this.Controls.Add(this.lblKLvalue);
            this.Controls.Add(this.lblKB);
            this.Controls.Add(this.lblKA);
            this.Controls.Add(this.lblKL);
            this.Controls.Add(this.sliderKB);
            this.Controls.Add(this.sliderKA);
            this.Controls.Add(this.sliderKL);
            this.Controls.Add(this.btnSetAsSource);
            this.Controls.Add(this.lblSensitivity);
            this.Controls.Add(this.sliderSensitivity);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.lblDestColor);
            this.Controls.Add(this.pctBoxDestColor);
            this.Controls.Add(this.lblSelectedColor);
            this.Controls.Add(this.pctBoxSelectedColor);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.pctBoxDestination);
            this.Controls.Add(this.pctBoxSource);
            this.Name = "MainForm";
            this.Text = "Color changer";
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxSelectedColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDestColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderKL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderKB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoxSource;
        private System.Windows.Forms.PictureBox pctBoxDestination;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.PictureBox pctBoxSelectedColor;
        private System.Windows.Forms.Label lblSelectedColor;
        private System.Windows.Forms.PictureBox pctBoxDestColor;
        private System.Windows.Forms.Label lblDestColor;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.TrackBar sliderSensitivity;
        private System.Windows.Forms.Label lblSensitivity;
        private System.Windows.Forms.Button btnSetAsSource;
        private System.Windows.Forms.TrackBar sliderKL;
        private System.Windows.Forms.TrackBar sliderKA;
        private System.Windows.Forms.TrackBar sliderKB;
        private System.Windows.Forms.Label lblKL;
        private System.Windows.Forms.Label lblKA;
        private System.Windows.Forms.Label lblKB;
        private System.Windows.Forms.Label lblKLvalue;
        private System.Windows.Forms.Label lblKAvalue;
        private System.Windows.Forms.Label lblKBvalue;
    }
}

