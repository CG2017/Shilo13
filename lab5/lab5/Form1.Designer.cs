namespace lab5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.x1TB = new System.Windows.Forms.TextBox();
            this.y1TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btn1BLine = new System.Windows.Forms.Button();
            this.btn2BCircle = new System.Windows.Forms.Button();
            this.btn3DDA = new System.Windows.Forms.Button();
            this.btn4SimpleIter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // x1TB
            // 
            this.x1TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.x1TB.Location = new System.Drawing.Point(580, 174);
            this.x1TB.Name = "x1TB";
            this.x1TB.Size = new System.Drawing.Size(121, 20);
            this.x1TB.TabIndex = 1;
            this.x1TB.Text = "100";
            this.x1TB.TextChanged += new System.EventHandler(this.x1TB_TextChanged);
            // 
            // y1TB
            // 
            this.y1TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.y1TB.Location = new System.Drawing.Point(580, 200);
            this.y1TB.Name = "y1TB";
            this.y1TB.Size = new System.Drawing.Size(121, 20);
            this.y1TB.TabIndex = 2;
            this.y1TB.Text = "100";
            this.y1TB.TextChanged += new System.EventHandler(this.y1TB_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "max x";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "max y";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(580, 226);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(121, 28);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBarScroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.AutoSize = false;
            this.trackBar2.Location = new System.Drawing.Point(580, 260);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(121, 28);
            this.trackBar2.TabIndex = 14;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBarScroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar3.AutoSize = false;
            this.trackBar3.Location = new System.Drawing.Point(580, 294);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(121, 28);
            this.trackBar3.TabIndex = 15;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBarScroll);
            // 
            // trackBar4
            // 
            this.trackBar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar4.AutoSize = false;
            this.trackBar4.Location = new System.Drawing.Point(580, 328);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(121, 28);
            this.trackBar4.TabIndex = 16;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBarScroll);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "y0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "x0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(518, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "y1";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(518, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "x1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zedGraphControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Coordinates field";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(427, 456);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 494);
            this.tabControl1.TabIndex = 21;
            // 
            // btn1BLine
            // 
            this.btn1BLine.Location = new System.Drawing.Point(520, 40);
            this.btn1BLine.Name = "btn1BLine";
            this.btn1BLine.Size = new System.Drawing.Size(82, 31);
            this.btn1BLine.TabIndex = 22;
            this.btn1BLine.Text = "BLine";
            this.btn1BLine.UseVisualStyleBackColor = true;
            this.btn1BLine.Click += new System.EventHandler(this.btn1BLine_Click);
            // 
            // btn2BCircle
            // 
            this.btn2BCircle.Location = new System.Drawing.Point(521, 77);
            this.btn2BCircle.Name = "btn2BCircle";
            this.btn2BCircle.Size = new System.Drawing.Size(81, 30);
            this.btn2BCircle.TabIndex = 23;
            this.btn2BCircle.Text = "BCircle";
            this.btn2BCircle.UseVisualStyleBackColor = true;
            this.btn2BCircle.Click += new System.EventHandler(this.btn2BCircle_Click);
            // 
            // btn3DDA
            // 
            this.btn3DDA.Location = new System.Drawing.Point(608, 40);
            this.btn3DDA.Name = "btn3DDA";
            this.btn3DDA.Size = new System.Drawing.Size(83, 31);
            this.btn3DDA.TabIndex = 24;
            this.btn3DDA.Text = "DDA";
            this.btn3DDA.UseVisualStyleBackColor = true;
            this.btn3DDA.Click += new System.EventHandler(this.btn3DDA_Click);
            // 
            // btn4SimpleIter
            // 
            this.btn4SimpleIter.Location = new System.Drawing.Point(521, 113);
            this.btn4SimpleIter.Name = "btn4SimpleIter";
            this.btn4SimpleIter.Size = new System.Drawing.Size(170, 36);
            this.btn4SimpleIter.TabIndex = 25;
            this.btn4SimpleIter.Text = "Simple Iteration";
            this.btn4SimpleIter.UseVisualStyleBackColor = true;
            this.btn4SimpleIter.Click += new System.EventHandler(this.btn4SimpleIter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 518);
            this.Controls.Add(this.btn4SimpleIter);
            this.Controls.Add(this.btn3DDA);
            this.Controls.Add(this.btn2BCircle);
            this.Controls.Add(this.btn1BLine);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.y1TB);
            this.Controls.Add(this.x1TB);
            this.Name = "Form1";
            this.Text = "Rasterization";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox x1TB;
        private System.Windows.Forms.TextBox y1TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn1BLine;
        private System.Windows.Forms.Button btn2BCircle;
        private System.Windows.Forms.Button btn3DDA;
        private System.Windows.Forms.Button btn4SimpleIter;
    }
}

