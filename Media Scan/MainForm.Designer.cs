namespace Media_Scan
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
            this.label1 = new System.Windows.Forms.Label();
            this.movieListCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.seasonsCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.episodesCb = new System.Windows.Forms.ComboBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.minuteUd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.pathTi = new System.Windows.Forms.TextBox();
            this.scanBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.minuteUd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movies:";
            // 
            // movieListCb
            // 
            this.movieListCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.movieListCb.FormattingEnabled = true;
            this.movieListCb.Location = new System.Drawing.Point(71, 73);
            this.movieListCb.Name = "movieListCb";
            this.movieListCb.Size = new System.Drawing.Size(205, 21);
            this.movieListCb.TabIndex = 1;
            this.movieListCb.SelectedIndexChanged += new System.EventHandler(this.movieListCb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seasons:";
            // 
            // seasonsCb
            // 
            this.seasonsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seasonsCb.FormattingEnabled = true;
            this.seasonsCb.Location = new System.Drawing.Point(71, 100);
            this.seasonsCb.Name = "seasonsCb";
            this.seasonsCb.Size = new System.Drawing.Size(42, 21);
            this.seasonsCb.TabIndex = 1;
            this.seasonsCb.SelectedIndexChanged += new System.EventHandler(this.seasonsCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Episodes:";
            // 
            // episodesCb
            // 
            this.episodesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.episodesCb.FormattingEnabled = true;
            this.episodesCb.Location = new System.Drawing.Point(71, 127);
            this.episodesCb.Name = "episodesCb";
            this.episodesCb.Size = new System.Drawing.Size(42, 21);
            this.episodesCb.TabIndex = 3;
            this.episodesCb.SelectedIndexChanged += new System.EventHandler(this.episodesCb_SelectedIndexChanged);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(68, 183);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(101, 23);
            this.playBtn.TabIndex = 4;
            this.playBtn.Text = "Play && Save";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Minute:";
            // 
            // minuteUd
            // 
            this.minuteUd.Location = new System.Drawing.Point(71, 153);
            this.minuteUd.Name = "minuteUd";
            this.minuteUd.Size = new System.Drawing.Size(42, 20);
            this.minuteUd.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Directory:";
            // 
            // pathTi
            // 
            this.pathTi.Location = new System.Drawing.Point(71, 6);
            this.pathTi.Name = "pathTi";
            this.pathTi.Size = new System.Drawing.Size(205, 20);
            this.pathTi.TabIndex = 8;
            this.pathTi.Text = "c:\\Projects\\net\\MediaScan\\demo\\";
            this.pathTi.TextChanged += new System.EventHandler(this.pathTi_TextChanged);
            // 
            // scanBtn
            // 
            this.scanBtn.Location = new System.Drawing.Point(71, 32);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(75, 23);
            this.scanBtn.TabIndex = 9;
            this.scanBtn.Text = "Scan";
            this.scanBtn.UseVisualStyleBackColor = true;
            this.scanBtn.Click += new System.EventHandler(this.scanBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(175, 183);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(101, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 219);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.scanBtn);
            this.Controls.Add(this.pathTi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.minuteUd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.episodesCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seasonsCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.movieListCb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Movie Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minuteUd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox movieListCb;
        private System.Windows.Forms.ComboBox seasonsCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox episodesCb;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown minuteUd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pathTi;
        private System.Windows.Forms.Button scanBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}

