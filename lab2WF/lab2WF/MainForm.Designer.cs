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
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxSelectedColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDestColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderSensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxSource
            // 
            this.pctBoxSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxSource.Location = new System.Drawing.Point(12, 12);
            this.pctBoxSource.Name = "pctBoxSource";
            this.pctBoxSource.Size = new System.Drawing.Size(509, 400);
            this.pctBoxSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxSource.TabIndex = 0;
            this.pctBoxSource.TabStop = false;
            // 
            // pctBoxDestination
            // 
            this.pctBoxDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxDestination.Location = new System.Drawing.Point(710, 12);
            this.pctBoxDestination.Name = "pctBoxDestination";
            this.pctBoxDestination.Size = new System.Drawing.Size(509, 400);
            this.pctBoxDestination.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 562);
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
    }
}

