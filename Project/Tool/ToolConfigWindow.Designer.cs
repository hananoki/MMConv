namespace MMConv {
	partial class ToolConfigWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof( ToolConfigWindow ) );
			this.label1 = new System.Windows.Forms.Label();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.m_editDlgFUZ = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.m_editDlgXWMA = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.m_editDlgWavGain = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.m_editDlg7Z = new System.Windows.Forms.TextBox();
			this.m_btnDlg7Z = new System.Windows.Forms.Button();
			this.m_editDlgSoX = new System.Windows.Forms.TextBox();
			this.m_btnDlgSoX = new System.Windows.Forms.Button();
			this.m_editDlgShn = new System.Windows.Forms.TextBox();
			this.m_btnDlgShn = new System.Windows.Forms.Button();
			this.m_editDlgTak = new System.Windows.Forms.TextBox();
			this.m_btnDlgTak = new System.Windows.Forms.Button();
			this.m_editDlgMP3Gain = new System.Windows.Forms.TextBox();
			this.m_btnDlgMP3Gain = new System.Windows.Forms.Button();
			this.m_editDlgNeroAAC = new System.Windows.Forms.TextBox();
			this.m_btnDlgNeroAAC = new System.Windows.Forms.Button();
			this.m_editDlgFlac = new System.Windows.Forms.TextBox();
			this.m_btnDlgFlac = new System.Windows.Forms.Button();
			this.m_editDlgFFMpeg = new System.Windows.Forms.TextBox();
			this.m_btnDlgFFMpeg = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(10, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "ffmpeg (ffmpeg.exe)";
			// 
			// m_btnOK
			// 
			this.m_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnOK.Location = new System.Drawing.Point(379, 516);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 6;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.button1_Click);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnCancel.Location = new System.Drawing.Point(298, 516);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 7;
			this.m_btnCancel.Text = "キャンセル";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnCancel.Visible = false;
			this.m_btnCancel.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(10, 53);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 12);
			this.label2.TabIndex = 9;
			this.label2.Text = "flac (flac.exe)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label3.Location = new System.Drawing.Point(10, 97);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "Nero AAC (neroAacEnc.exe)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(10, 141);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(124, 12);
			this.label4.TabIndex = 15;
			this.label4.Text = "MP3Gain (mp3gain.exe)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(10, 185);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 12);
			this.label5.TabIndex = 18;
			this.label5.Text = "TAK (takc.exe)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label6.Location = new System.Drawing.Point(10, 229);
			this.label6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(111, 12);
			this.label6.TabIndex = 21;
			this.label6.Text = "shntool (shntool.exe)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label7.Location = new System.Drawing.Point(10, 273);
			this.label7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(75, 12);
			this.label7.TabIndex = 24;
			this.label7.Text = "SoX (sox.exe)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label8.Location = new System.Drawing.Point(10, 317);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 12);
			this.label8.TabIndex = 27;
			this.label8.Text = "7-Zip (7z.exe)";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label9.Location = new System.Drawing.Point(10, 363);
			this.label9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(137, 12);
			this.label9.TabIndex = 30;
			this.label9.Text = "WaveGain (WaveGain.exe)";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label10.Location = new System.Drawing.Point(10, 409);
			this.label10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(150, 12);
			this.label10.TabIndex = 33;
			this.label10.Text = "fuz/xwm (xWMAEncode.exe)";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label11.Location = new System.Drawing.Point(10, 454);
			this.label11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(144, 12);
			this.label11.TabIndex = 36;
			this.label11.Text = "Unfuzer (Fuz_extractor.exe)";
			// 
			// m_editDlgFUZ
			// 
			this.m_editDlgFUZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgFUZ.Location = new System.Drawing.Point(12, 471);
			this.m_editDlgFUZ.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgFUZ.Name = "m_editDlgFUZ";
			this.m_editDlgFUZ.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgFUZ.TabIndex = 35;
			this.m_editDlgFUZ.Tag = MMConv.ToolType.FUZ;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button3.Location = new System.Drawing.Point(430, 471);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(24, 24);
			this.button3.TabIndex = 37;
			this.button3.Tag = MMConv.ToolType.FUZ;
			this.button3.UseVisualStyleBackColor = true;
			// 
			// m_editDlgXWMA
			// 
			this.m_editDlgXWMA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgXWMA.Location = new System.Drawing.Point(12, 426);
			this.m_editDlgXWMA.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgXWMA.Name = "m_editDlgXWMA";
			this.m_editDlgXWMA.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgXWMA.TabIndex = 32;
			this.m_editDlgXWMA.Tag = MMConv.ToolType.XWMA;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button2.Location = new System.Drawing.Point(430, 426);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(24, 24);
			this.button2.TabIndex = 34;
			this.button2.Tag = MMConv.ToolType.XWMA;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// m_editDlgWavGain
			// 
			this.m_editDlgWavGain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgWavGain.Location = new System.Drawing.Point(12, 380);
			this.m_editDlgWavGain.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgWavGain.Name = "m_editDlgWavGain";
			this.m_editDlgWavGain.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgWavGain.TabIndex = 29;
			this.m_editDlgWavGain.Tag = MMConv.ToolType.WAVEGAIN;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button1.Location = new System.Drawing.Point(430, 380);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 24);
			this.button1.TabIndex = 31;
			this.button1.Tag = MMConv.ToolType.WAVEGAIN;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// m_editDlg7Z
			// 
			this.m_editDlg7Z.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlg7Z.Location = new System.Drawing.Point(12, 334);
			this.m_editDlg7Z.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlg7Z.Name = "m_editDlg7Z";
			this.m_editDlg7Z.Size = new System.Drawing.Size(412, 19);
			this.m_editDlg7Z.TabIndex = 26;
			this.m_editDlg7Z.Tag = MMConv.ToolType.SEVENZ;
			// 
			// m_btnDlg7Z
			// 
			this.m_btnDlg7Z.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDlg7Z.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDlg7Z.Image")));
			this.m_btnDlg7Z.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnDlg7Z.Location = new System.Drawing.Point(430, 334);
			this.m_btnDlg7Z.Name = "m_btnDlg7Z";
			this.m_btnDlg7Z.Size = new System.Drawing.Size(24, 24);
			this.m_btnDlg7Z.TabIndex = 28;
			this.m_btnDlg7Z.Tag = MMConv.ToolType.SEVENZ;
			this.m_btnDlg7Z.UseVisualStyleBackColor = true;
			// 
			// m_editDlgSoX
			// 
			this.m_editDlgSoX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgSoX.Location = new System.Drawing.Point(12, 290);
			this.m_editDlgSoX.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgSoX.Name = "m_editDlgSoX";
			this.m_editDlgSoX.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgSoX.TabIndex = 23;
			this.m_editDlgSoX.Tag = MMConv.ToolType.SOX;
			// 
			// m_btnDlgSoX
			// 
			this.m_btnDlgSoX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDlgSoX.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDlgSoX.Image")));
			this.m_btnDlgSoX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnDlgSoX.Location = new System.Drawing.Point(430, 290);
			this.m_btnDlgSoX.Name = "m_btnDlgSoX";
			this.m_btnDlgSoX.Size = new System.Drawing.Size(24, 24);
			this.m_btnDlgSoX.TabIndex = 25;
			this.m_btnDlgSoX.Tag = MMConv.ToolType.SOX;
			this.m_btnDlgSoX.UseVisualStyleBackColor = true;
			// 
			// m_editDlgShn
			// 
			this.m_editDlgShn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgShn.Location = new System.Drawing.Point(12, 246);
			this.m_editDlgShn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgShn.Name = "m_editDlgShn";
			this.m_editDlgShn.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgShn.TabIndex = 20;
			this.m_editDlgShn.Tag = MMConv.ToolType.SHNTOOL;
			// 
			// m_btnDlgShn
			// 
			this.m_btnDlgShn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDlgShn.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDlgShn.Image")));
			this.m_btnDlgShn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnDlgShn.Location = new System.Drawing.Point(430, 246);
			this.m_btnDlgShn.Name = "m_btnDlgShn";
			this.m_btnDlgShn.Size = new System.Drawing.Size(24, 24);
			this.m_btnDlgShn.TabIndex = 22;
			this.m_btnDlgShn.Tag = MMConv.ToolType.SHNTOOL;
			this.m_btnDlgShn.UseVisualStyleBackColor = true;
			// 
			// m_editDlgTak
			// 
			this.m_editDlgTak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgTak.Location = new System.Drawing.Point(12, 202);
			this.m_editDlgTak.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgTak.Name = "m_editDlgTak";
			this.m_editDlgTak.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgTak.TabIndex = 17;
			this.m_editDlgTak.Tag = MMConv.ToolType.TAK;
			// 
			// m_btnDlgTak
			// 
			this.m_btnDlgTak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDlgTak.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDlgTak.Image")));
			this.m_btnDlgTak.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnDlgTak.Location = new System.Drawing.Point(430, 202);
			this.m_btnDlgTak.Name = "m_btnDlgTak";
			this.m_btnDlgTak.Size = new System.Drawing.Size(24, 24);
			this.m_btnDlgTak.TabIndex = 19;
			this.m_btnDlgTak.Tag = MMConv.ToolType.TAK;
			this.m_btnDlgTak.UseVisualStyleBackColor = true;
			// 
			// m_editDlgMP3Gain
			// 
			this.m_editDlgMP3Gain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgMP3Gain.Location = new System.Drawing.Point(12, 158);
			this.m_editDlgMP3Gain.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgMP3Gain.Name = "m_editDlgMP3Gain";
			this.m_editDlgMP3Gain.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgMP3Gain.TabIndex = 14;
			this.m_editDlgMP3Gain.Tag = MMConv.ToolType.MP3GAIN;
			// 
			// m_btnDlgMP3Gain
			// 
			this.m_btnDlgMP3Gain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDlgMP3Gain.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDlgMP3Gain.Image")));
			this.m_btnDlgMP3Gain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnDlgMP3Gain.Location = new System.Drawing.Point(430, 158);
			this.m_btnDlgMP3Gain.Name = "m_btnDlgMP3Gain";
			this.m_btnDlgMP3Gain.Size = new System.Drawing.Size(24, 24);
			this.m_btnDlgMP3Gain.TabIndex = 16;
			this.m_btnDlgMP3Gain.Tag = MMConv.ToolType.MP3GAIN;
			this.m_btnDlgMP3Gain.UseVisualStyleBackColor = true;
			// 
			// m_editDlgNeroAAC
			// 
			this.m_editDlgNeroAAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgNeroAAC.Location = new System.Drawing.Point(12, 114);
			this.m_editDlgNeroAAC.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgNeroAAC.Name = "m_editDlgNeroAAC";
			this.m_editDlgNeroAAC.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgNeroAAC.TabIndex = 11;
			this.m_editDlgNeroAAC.Tag = MMConv.ToolType.NEROAAC;
			// 
			// m_btnDlgNeroAAC
			// 
			this.m_btnDlgNeroAAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDlgNeroAAC.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDlgNeroAAC.Image")));
			this.m_btnDlgNeroAAC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnDlgNeroAAC.Location = new System.Drawing.Point(430, 114);
			this.m_btnDlgNeroAAC.Name = "m_btnDlgNeroAAC";
			this.m_btnDlgNeroAAC.Size = new System.Drawing.Size(24, 24);
			this.m_btnDlgNeroAAC.TabIndex = 13;
			this.m_btnDlgNeroAAC.Tag = MMConv.ToolType.NEROAAC;
			this.m_btnDlgNeroAAC.UseVisualStyleBackColor = true;
			// 
			// m_editDlgFlac
			// 
			this.m_editDlgFlac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgFlac.Location = new System.Drawing.Point(12, 70);
			this.m_editDlgFlac.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgFlac.Name = "m_editDlgFlac";
			this.m_editDlgFlac.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgFlac.TabIndex = 8;
			this.m_editDlgFlac.Tag = MMConv.ToolType.FLAC;
			// 
			// m_btnDlgFlac
			// 
			this.m_btnDlgFlac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDlgFlac.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDlgFlac.Image")));
			this.m_btnDlgFlac.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnDlgFlac.Location = new System.Drawing.Point(430, 70);
			this.m_btnDlgFlac.Name = "m_btnDlgFlac";
			this.m_btnDlgFlac.Size = new System.Drawing.Size(24, 24);
			this.m_btnDlgFlac.TabIndex = 10;
			this.m_btnDlgFlac.Tag = MMConv.ToolType.FLAC;
			this.m_btnDlgFlac.UseVisualStyleBackColor = true;
			// 
			// m_editDlgFFMpeg
			// 
			this.m_editDlgFFMpeg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editDlgFFMpeg.Location = new System.Drawing.Point(12, 26);
			this.m_editDlgFFMpeg.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			this.m_editDlgFFMpeg.Name = "m_editDlgFFMpeg";
			this.m_editDlgFFMpeg.Size = new System.Drawing.Size(412, 19);
			this.m_editDlgFFMpeg.TabIndex = 3;
			this.m_editDlgFFMpeg.Tag = MMConv.ToolType.FFMPEG;
			// 
			// m_btnDlgFFMpeg
			// 
			this.m_btnDlgFFMpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDlgFFMpeg.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDlgFFMpeg.Image")));
			this.m_btnDlgFFMpeg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnDlgFFMpeg.Location = new System.Drawing.Point(430, 26);
			this.m_btnDlgFFMpeg.Name = "m_btnDlgFFMpeg";
			this.m_btnDlgFFMpeg.Size = new System.Drawing.Size(24, 24);
			this.m_btnDlgFFMpeg.TabIndex = 5;
			this.m_btnDlgFFMpeg.Tag = MMConv.ToolType.FFMPEG;
			this.m_btnDlgFFMpeg.UseVisualStyleBackColor = true;
			// 
			// ToolDialog
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(466, 551);
			this.ControlBox = false;
			this.Controls.Add(this.m_editDlgFUZ);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.m_editDlgXWMA);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.m_editDlgWavGain);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.m_editDlg7Z);
			this.Controls.Add(this.m_btnDlg7Z);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.m_editDlgSoX);
			this.Controls.Add(this.m_btnDlgSoX);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.m_editDlgShn);
			this.Controls.Add(this.m_btnDlgShn);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.m_editDlgTak);
			this.Controls.Add(this.m_btnDlgTak);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_editDlgMP3Gain);
			this.Controls.Add(this.m_btnDlgMP3Gain);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_editDlgNeroAAC);
			this.Controls.Add(this.m_btnDlgNeroAAC);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_editDlgFlac);
			this.Controls.Add(this.m_btnDlgFlac);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.m_editDlgFFMpeg);
			this.Controls.Add(this.m_btnDlgFFMpeg);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ToolDialog";
			this.Text = "ツール設定";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox m_editDlgFFMpeg;
		private System.Windows.Forms.Button m_btnDlgFFMpeg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.TextBox m_editDlgFlac;
		private System.Windows.Forms.Button m_btnDlgFlac;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_editDlgNeroAAC;
		private System.Windows.Forms.Button m_btnDlgNeroAAC;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_editDlgMP3Gain;
		private System.Windows.Forms.Button m_btnDlgMP3Gain;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_editDlgTak;
		private System.Windows.Forms.Button m_btnDlgTak;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox m_editDlgShn;
		private System.Windows.Forms.Button m_btnDlgShn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox m_editDlgSoX;
		private System.Windows.Forms.Button m_btnDlgSoX;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox m_editDlg7Z;
		private System.Windows.Forms.Button m_btnDlg7Z;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox m_editDlgWavGain;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox m_editDlgXWMA;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox m_editDlgFUZ;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label11;
	}
}