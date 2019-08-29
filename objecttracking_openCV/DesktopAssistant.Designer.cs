namespace objecttracking_openCV
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.iborignal = new Emgu.CV.UI.ImageBox();
            this.btmPauseOrResum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OrignalCopy = new Emgu.CV.UI.ImageBox();
            this.Brigtness_SLD = new System.Windows.Forms.TrackBar();
            this.Contrast_SLD = new System.Windows.Forms.TrackBar();
            this.Brigthness_LBL = new System.Windows.Forms.Label();
            this.Contrast_LBL = new System.Windows.Forms.Label();
            this.Sharpness_SLD = new System.Windows.Forms.TrackBar();
            this.Sharpness_LBL = new System.Windows.Forms.Label();
            this.Reset_Cam_Settings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iborignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrignalCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brigtness_SLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast_SLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sharpness_SLD)).BeginInit();
            this.SuspendLayout();
            // 
            // iborignal
            // 
            this.iborignal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iborignal.Cursor = System.Windows.Forms.Cursors.Default;
            this.iborignal.Location = new System.Drawing.Point(12, 12);
            this.iborignal.Name = "iborignal";
            this.iborignal.Size = new System.Drawing.Size(621, 446);
            this.iborignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iborignal.TabIndex = 2;
            this.iborignal.TabStop = false;
            // 
            // btmPauseOrResum
            // 
            this.btmPauseOrResum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmPauseOrResum.Location = new System.Drawing.Point(21, 484);
            this.btmPauseOrResum.Name = "btmPauseOrResum";
            this.btmPauseOrResum.Size = new System.Drawing.Size(261, 48);
            this.btmPauseOrResum.TabIndex = 3;
            this.btmPauseOrResum.Text = "Shift Mouse Control to Webcam";
            this.btmPauseOrResum.UseVisualStyleBackColor = true;
            this.btmPauseOrResum.Click += new System.EventHandler(this.btmPauseOrResum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Finger Count: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(495, 503);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 29);
            this.label2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            // 
            // OrignalCopy
            // 
            this.OrignalCopy.BackColor = System.Drawing.SystemColors.Window;
            this.OrignalCopy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OrignalCopy.Cursor = System.Windows.Forms.Cursors.Default;
            this.OrignalCopy.Location = new System.Drawing.Point(653, 12);
            this.OrignalCopy.Name = "OrignalCopy";
            this.OrignalCopy.Size = new System.Drawing.Size(190, 167);
            this.OrignalCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.OrignalCopy.TabIndex = 8;
            this.OrignalCopy.TabStop = false;
            // 
            // Brigtness_SLD
            // 
            this.Brigtness_SLD.Location = new System.Drawing.Point(639, 367);
            this.Brigtness_SLD.Name = "Brigtness_SLD";
            this.Brigtness_SLD.Size = new System.Drawing.Size(213, 45);
            this.Brigtness_SLD.TabIndex = 9;
            this.Brigtness_SLD.Scroll += new System.EventHandler(this.Brigtness_SLD_Scroll);
            // 
            // Contrast_SLD
            // 
            this.Contrast_SLD.Location = new System.Drawing.Point(639, 281);
            this.Contrast_SLD.Name = "Contrast_SLD";
            this.Contrast_SLD.Size = new System.Drawing.Size(213, 45);
            this.Contrast_SLD.TabIndex = 10;
            this.Contrast_SLD.Scroll += new System.EventHandler(this.Contrast_SLD_Scroll);
            // 
            // Brigthness_LBL
            // 
            this.Brigthness_LBL.AutoSize = true;
            this.Brigthness_LBL.Location = new System.Drawing.Point(840, 351);
            this.Brigthness_LBL.Name = "Brigthness_LBL";
            this.Brigthness_LBL.Size = new System.Drawing.Size(13, 13);
            this.Brigthness_LBL.TabIndex = 11;
            this.Brigthness_LBL.Text = "0";
            // 
            // Contrast_LBL
            // 
            this.Contrast_LBL.AutoSize = true;
            this.Contrast_LBL.Location = new System.Drawing.Point(840, 265);
            this.Contrast_LBL.Name = "Contrast_LBL";
            this.Contrast_LBL.Size = new System.Drawing.Size(13, 13);
            this.Contrast_LBL.TabIndex = 12;
            this.Contrast_LBL.Text = "0";
            // 
            // Sharpness_SLD
            // 
            this.Sharpness_SLD.Location = new System.Drawing.Point(639, 204);
            this.Sharpness_SLD.Name = "Sharpness_SLD";
            this.Sharpness_SLD.Size = new System.Drawing.Size(204, 45);
            this.Sharpness_SLD.TabIndex = 13;
            this.Sharpness_SLD.Scroll += new System.EventHandler(this.Sharpness_SLD_Scroll);
            // 
            // Sharpness_LBL
            // 
            this.Sharpness_LBL.AutoSize = true;
            this.Sharpness_LBL.Location = new System.Drawing.Point(840, 204);
            this.Sharpness_LBL.Name = "Sharpness_LBL";
            this.Sharpness_LBL.Size = new System.Drawing.Size(13, 13);
            this.Sharpness_LBL.TabIndex = 15;
            this.Sharpness_LBL.Text = "0";
            // 
            // Reset_Cam_Settings
            // 
            this.Reset_Cam_Settings.Location = new System.Drawing.Point(709, 503);
            this.Reset_Cam_Settings.Name = "Reset_Cam_Settings";
            this.Reset_Cam_Settings.Size = new System.Drawing.Size(115, 29);
            this.Reset_Cam_Settings.TabIndex = 16;
            this.Reset_Cam_Settings.Text = "Reset";
            this.Reset_Cam_Settings.UseVisualStyleBackColor = true;
            this.Reset_Cam_Settings.Click += new System.EventHandler(this.Reset_Cam_Settings_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(651, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Brigthness";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(651, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Contrast";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(651, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Sharpness";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::Mouse_Control_via_Webcam.Properties.Resources.Background_Image;
            this.ClientSize = new System.Drawing.Size(855, 554);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Reset_Cam_Settings);
            this.Controls.Add(this.Sharpness_LBL);
            this.Controls.Add(this.Sharpness_SLD);
            this.Controls.Add(this.Contrast_LBL);
            this.Controls.Add(this.Brigthness_LBL);
            this.Controls.Add(this.Contrast_SLD);
            this.Controls.Add(this.Brigtness_SLD);
            this.Controls.Add(this.OrignalCopy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btmPauseOrResum);
            this.Controls.Add(this.iborignal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cursor Hunter";
            this.TransparencyKey = System.Drawing.SystemColors.ControlDarkDark;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DesktopAssistant_Closed);
            this.Load += new System.EventHandler(this.DesktopAssistant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iborignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrignalCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brigtness_SLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast_SLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sharpness_SLD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox iborignal;
        private System.Windows.Forms.Button btmPauseOrResum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Emgu.CV.UI.ImageBox OrignalCopy;
        private System.Windows.Forms.TrackBar Brigtness_SLD;
        private System.Windows.Forms.TrackBar Contrast_SLD;
        private System.Windows.Forms.Label Brigthness_LBL;
        private System.Windows.Forms.Label Contrast_LBL;
        private System.Windows.Forms.TrackBar Sharpness_SLD;
        private System.Windows.Forms.Label Sharpness_LBL;
        private System.Windows.Forms.Button Reset_Cam_Settings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

