﻿namespace lab3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30D, 7D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30D, 2D);
            this.pctSource = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.listBoxChannels = new System.Windows.Forms.ListBox();
            this.chartChannels = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxAverage = new System.Windows.Forms.TextBox();
            this.lblAverage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartChannels)).BeginInit();
            this.SuspendLayout();
            // 
            // pctSource
            // 
            this.pctSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctSource.Location = new System.Drawing.Point(12, 12);
            this.pctSource.Name = "pctSource";
            this.pctSource.Size = new System.Drawing.Size(361, 341);
            this.pctSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctSource.TabIndex = 0;
            this.pctSource.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 368);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // listBoxChannels
            // 
            this.listBoxChannels.FormattingEnabled = true;
            this.listBoxChannels.Items.AddRange(new object[] {
            "RGB",
            "Red",
            "Green",
            "Blue"});
            this.listBoxChannels.Location = new System.Drawing.Point(256, 368);
            this.listBoxChannels.Name = "listBoxChannels";
            this.listBoxChannels.Size = new System.Drawing.Size(117, 56);
            this.listBoxChannels.TabIndex = 3;
            // 
            // chartChannels
            // 
            chartArea1.Name = "ChannelArea";
            this.chartChannels.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartChannels.Legends.Add(legend1);
            this.chartChannels.Location = new System.Drawing.Point(409, 12);
            this.chartChannels.Name = "chartChannels";
            series1.ChartArea = "ChannelArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Legend = "Legend1";
            series1.Name = "ChannelValues";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            this.chartChannels.Series.Add(series1);
            this.chartChannels.Size = new System.Drawing.Size(859, 553);
            this.chartChannels.TabIndex = 4;
            this.chartChannels.Text = "Channels diagram";
            // 
            // textBoxAverage
            // 
            this.textBoxAverage.Location = new System.Drawing.Point(256, 479);
            this.textBoxAverage.Name = "textBoxAverage";
            this.textBoxAverage.Size = new System.Drawing.Size(100, 20);
            this.textBoxAverage.TabIndex = 5;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(253, 463);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(47, 13);
            this.lblAverage.TabIndex = 6;
            this.lblAverage.Text = "Average";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 590);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.textBoxAverage);
            this.Controls.Add(this.chartChannels);
            this.Controls.Add(this.listBoxChannels);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.pctSource);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pctSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartChannels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctSource;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ListBox listBoxChannels;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartChannels;
        private System.Windows.Forms.TextBox textBoxAverage;
        private System.Windows.Forms.Label lblAverage;
    }
}

