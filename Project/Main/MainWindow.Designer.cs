namespace MMConv {
	partial class MainWindow {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.m_listView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.m_editOutDir = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btnOpenFileDlg = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_rbtnWavSplitGain = new System.Windows.Forms.RadioButton();
			this.m_rbtnWavSplit = new System.Windows.Forms.RadioButton();
			this.m_rbtnWavGain = new System.Windows.Forms.RadioButton();
			this.m_rbtnReplayGain = new System.Windows.Forms.RadioButton();
			this.m_rbtnCnvXWM = new System.Windows.Forms.RadioButton();
			this.m_rbtnWavJoin = new System.Windows.Forms.RadioButton();
			this.m_rbtnSoundSplit = new System.Windows.Forms.RadioButton();
			this.m_rbtnTagRename = new System.Windows.Forms.RadioButton();
			this.m_rbtnCnvFLAC = new System.Windows.Forms.RadioButton();
			this.m_rbtnCDBatch2 = new System.Windows.Forms.RadioButton();
			this.m_rbtnCopyMKV = new System.Windows.Forms.RadioButton();
			this.m_rbtnCnvM4A = new System.Windows.Forms.RadioButton();
			this.m_rbtnCDBatch = new System.Windows.Forms.RadioButton();
			this.m_rbtnCopyM4V = new System.Windows.Forms.RadioButton();
			this.m_rbtnCnvWav = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.m_uiStart = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.m_txtNotify = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.m_picNotify = new System.Windows.Forms.PictureBox();
			this.m_pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_picNotify)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// m_listView
			// 
			this.m_listView.AllowDrop = true;
			this.m_listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.m_listView.FullRowSelect = true;
			this.m_listView.GridLines = true;
			this.m_listView.Location = new System.Drawing.Point(4, 28);
			this.m_listView.Margin = new System.Windows.Forms.Padding(0);
			this.m_listView.Name = "m_listView";
			this.m_listView.Size = new System.Drawing.Size(689, 282);
			this.m_listView.TabIndex = 0;
			this.m_listView.UseCompatibleStateImageBehavior = false;
			this.m_listView.View = System.Windows.Forms.View.Details;
			this.m_listView.VirtualMode = true;
			this.m_listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDropProcess);
			this.m_listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_listView_DragEnter);
			this.m_listView.DragOver += new System.Windows.Forms.DragEventHandler(this.Window_PreviewDragOver);
			this.m_listView.DoubleClick += new System.EventHandler(this.m_listView_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "入力ファイル名";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "形式";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "再生時間";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "ビットレート";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "再生時間";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Location = new System.Drawing.Point(3, 220);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(689, 32);
			this.panel1.TabIndex = 1;
			this.panel1.Visible = false;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(422, 201);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(179, 16);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "動作後に出力設定フォルダを開く";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.Visible = false;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(422, 179);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(149, 16);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "出力ファイルリストで上書き";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Visible = false;
			// 
			// m_editOutDir
			// 
			this.m_editOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_editOutDir.Location = new System.Drawing.Point(136, 18);
			this.m_editOutDir.Name = "m_editOutDir";
			this.m_editOutDir.Size = new System.Drawing.Size(518, 19);
			this.m_editOutDir.TabIndex = 3;
			this.m_editOutDir.TextChanged += new System.EventHandler(this.m_editOutDir_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_btnOpenFileDlg);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.m_editOutDir);
			this.groupBox1.Location = new System.Drawing.Point(4, 313);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(689, 52);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "出力設定";
			// 
			// m_btnOpenFileDlg
			// 
			this.m_btnOpenFileDlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnOpenFileDlg.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOpenFileDlg.Image")));
			this.m_btnOpenFileDlg.Location = new System.Drawing.Point(657, 18);
			this.m_btnOpenFileDlg.Margin = new System.Windows.Forms.Padding(0);
			this.m_btnOpenFileDlg.Name = "m_btnOpenFileDlg";
			this.m_btnOpenFileDlg.Size = new System.Drawing.Size(24, 24);
			this.m_btnOpenFileDlg.TabIndex = 2;
			this.m_btnOpenFileDlg.UseVisualStyleBackColor = true;
			this.m_btnOpenFileDlg.Click += new System.EventHandler(this.m_btnOpenFileDlg_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.DropDownWidth = 124;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "入力と同じ場所",
            "場所を指定"});
			this.comboBox1.Location = new System.Drawing.Point(6, 18);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(124, 20);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.m_rbtnWavSplitGain);
			this.groupBox2.Controls.Add(this.m_rbtnWavSplit);
			this.groupBox2.Controls.Add(this.m_rbtnWavGain);
			this.groupBox2.Controls.Add(this.m_rbtnReplayGain);
			this.groupBox2.Controls.Add(this.m_rbtnCnvXWM);
			this.groupBox2.Controls.Add(this.m_rbtnWavJoin);
			this.groupBox2.Controls.Add(this.m_rbtnSoundSplit);
			this.groupBox2.Controls.Add(this.m_rbtnTagRename);
			this.groupBox2.Controls.Add(this.m_rbtnCnvFLAC);
			this.groupBox2.Controls.Add(this.m_rbtnCDBatch2);
			this.groupBox2.Controls.Add(this.m_rbtnCopyMKV);
			this.groupBox2.Controls.Add(this.m_rbtnCnvM4A);
			this.groupBox2.Controls.Add(this.m_rbtnCDBatch);
			this.groupBox2.Controls.Add(this.m_rbtnCopyM4V);
			this.groupBox2.Controls.Add(this.m_rbtnCnvWav);
			this.groupBox2.Location = new System.Drawing.Point(4, 381);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(689, 91);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "目的の動作";
			// 
			// m_rbtnWavSplitGain
			// 
			this.m_rbtnWavSplitGain.AutoSize = true;
			this.m_rbtnWavSplitGain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnWavSplitGain.Location = new System.Drawing.Point(585, 42);
			this.m_rbtnWavSplitGain.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnWavSplitGain.Name = "m_rbtnWavSplitGain";
			this.m_rbtnWavSplitGain.Size = new System.Drawing.Size(90, 16);
			this.m_rbtnWavSplitGain.TabIndex = 21;
			this.m_rbtnWavSplitGain.TabStop = true;
			this.m_rbtnWavSplitGain.Tag = MMConv.CommandType.WavSplitGain;
			this.m_rbtnWavSplitGain.Text = "WavSplitGain";
			this.m_rbtnWavSplitGain.UseVisualStyleBackColor = true;
			this.m_rbtnWavSplitGain.Click += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnWavSplit
			// 
			this.m_rbtnWavSplit.AutoSize = true;
			this.m_rbtnWavSplit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnWavSplit.Location = new System.Drawing.Point(449, 43);
			this.m_rbtnWavSplit.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnWavSplit.Name = "m_rbtnWavSplit";
			this.m_rbtnWavSplit.Size = new System.Drawing.Size(67, 16);
			this.m_rbtnWavSplit.TabIndex = 20;
			this.m_rbtnWavSplit.TabStop = true;
			this.m_rbtnWavSplit.Tag = MMConv.CommandType.WavSplit;
			this.m_rbtnWavSplit.Text = "WavSplit";
			this.m_rbtnWavSplit.UseVisualStyleBackColor = true;
			this.m_rbtnWavSplit.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnWavGain
			// 
			this.m_rbtnWavGain.AutoSize = true;
			this.m_rbtnWavGain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnWavGain.Location = new System.Drawing.Point(585, 66);
			this.m_rbtnWavGain.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnWavGain.Name = "m_rbtnWavGain";
			this.m_rbtnWavGain.Size = new System.Drawing.Size(95, 16);
			this.m_rbtnWavGain.TabIndex = 19;
			this.m_rbtnWavGain.TabStop = true;
			this.m_rbtnWavGain.Tag = MMConv.CommandType.DiscPack;
			this.m_rbtnWavGain.Text = "複数DiscPack";
			this.m_rbtnWavGain.UseVisualStyleBackColor = true;
			this.m_rbtnWavGain.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnReplayGain
			// 
			this.m_rbtnReplayGain.AutoSize = true;
			this.m_rbtnReplayGain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnReplayGain.Location = new System.Drawing.Point(449, 66);
			this.m_rbtnReplayGain.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnReplayGain.Name = "m_rbtnReplayGain";
			this.m_rbtnReplayGain.Size = new System.Drawing.Size(81, 16);
			this.m_rbtnReplayGain.TabIndex = 16;
			this.m_rbtnReplayGain.TabStop = true;
			this.m_rbtnReplayGain.Tag = MMConv.CommandType.ReplayGain;
			this.m_rbtnReplayGain.Text = "ReplayGain";
			this.toolTip1.SetToolTip(this.m_rbtnReplayGain, "MP3Gainを適用します");
			this.m_rbtnReplayGain.UseVisualStyleBackColor = true;
			this.m_rbtnReplayGain.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnCnvXWM
			// 
			this.m_rbtnCnvXWM.AutoSize = true;
			this.m_rbtnCnvXWM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnCnvXWM.Location = new System.Drawing.Point(585, 19);
			this.m_rbtnCnvXWM.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnCnvXWM.Name = "m_rbtnCnvXWM";
			this.m_rbtnCnvXWM.Size = new System.Drawing.Size(81, 16);
			this.m_rbtnCnvXWM.TabIndex = 17;
			this.m_rbtnCnvXWM.TabStop = true;
			this.m_rbtnCnvXWM.Tag = MMConv.CommandType.CnvXWM;
			this.m_rbtnCnvXWM.Text = "XWMに変換";
			this.toolTip1.SetToolTip(this.m_rbtnCnvXWM, "XWMに変換します");
			this.m_rbtnCnvXWM.UseVisualStyleBackColor = true;
			this.m_rbtnCnvXWM.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnWavJoin
			// 
			this.m_rbtnWavJoin.AutoSize = true;
			this.m_rbtnWavJoin.Checked = true;
			this.m_rbtnWavJoin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnWavJoin.Location = new System.Drawing.Point(449, 19);
			this.m_rbtnWavJoin.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnWavJoin.Name = "m_rbtnWavJoin";
			this.m_rbtnWavJoin.Size = new System.Drawing.Size(72, 16);
			this.m_rbtnWavJoin.TabIndex = 18;
			this.m_rbtnWavJoin.TabStop = true;
			this.m_rbtnWavJoin.Tag = MMConv.CommandType.WavJoin;
			this.m_rbtnWavJoin.Text = "WAV結合";
			this.m_rbtnWavJoin.UseVisualStyleBackColor = true;
			this.m_rbtnWavJoin.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnSoundSplit
			// 
			this.m_rbtnSoundSplit.AutoSize = true;
			this.m_rbtnSoundSplit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnSoundSplit.Location = new System.Drawing.Point(300, 66);
			this.m_rbtnSoundSplit.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnSoundSplit.Name = "m_rbtnSoundSplit";
			this.m_rbtnSoundSplit.Size = new System.Drawing.Size(113, 16);
			this.m_rbtnSoundSplit.TabIndex = 13;
			this.m_rbtnSoundSplit.TabStop = true;
			this.m_rbtnSoundSplit.Tag = MMConv.CommandType.SoundParge;
			this.m_rbtnSoundSplit.Text = "動画から音声分離";
			this.m_rbtnSoundSplit.UseVisualStyleBackColor = true;
			this.m_rbtnSoundSplit.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnTagRename
			// 
			this.m_rbtnTagRename.AutoSize = true;
			this.m_rbtnTagRename.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnTagRename.Location = new System.Drawing.Point(300, 43);
			this.m_rbtnTagRename.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnTagRename.Name = "m_rbtnTagRename";
			this.m_rbtnTagRename.Size = new System.Drawing.Size(87, 16);
			this.m_rbtnTagRename.TabIndex = 14;
			this.m_rbtnTagRename.TabStop = true;
			this.m_rbtnTagRename.Tag = MMConv.CommandType.TagRename;
			this.m_rbtnTagRename.Text = "タグでリネーム";
			this.toolTip1.SetToolTip(this.m_rbtnTagRename, "再圧縮なしでMKVに変換します");
			this.m_rbtnTagRename.UseVisualStyleBackColor = true;
			this.m_rbtnTagRename.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnCnvFLAC
			// 
			this.m_rbtnCnvFLAC.AutoSize = true;
			this.m_rbtnCnvFLAC.Checked = true;
			this.m_rbtnCnvFLAC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnCnvFLAC.Location = new System.Drawing.Point(300, 19);
			this.m_rbtnCnvFLAC.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnCnvFLAC.Name = "m_rbtnCnvFLAC";
			this.m_rbtnCnvFLAC.Size = new System.Drawing.Size(85, 16);
			this.m_rbtnCnvFLAC.TabIndex = 15;
			this.m_rbtnCnvFLAC.TabStop = true;
			this.m_rbtnCnvFLAC.Tag = MMConv.CommandType.CnvFLAC;
			this.m_rbtnCnvFLAC.Text = "FLACに変換";
			this.m_rbtnCnvFLAC.UseVisualStyleBackColor = true;
			this.m_rbtnCnvFLAC.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnCDBatch2
			// 
			this.m_rbtnCDBatch2.AutoSize = true;
			this.m_rbtnCDBatch2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnCDBatch2.Location = new System.Drawing.Point(156, 66);
			this.m_rbtnCDBatch2.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnCDBatch2.Name = "m_rbtnCDBatch2";
			this.m_rbtnCDBatch2.Size = new System.Drawing.Size(105, 16);
			this.m_rbtnCDBatch2.TabIndex = 10;
			this.m_rbtnCDBatch2.TabStop = true;
			this.m_rbtnCDBatch2.Tag = MMConv.CommandType.CDSplitM4A;
			this.m_rbtnCDBatch2.Text = "CD -> SplitM4A";
			this.m_rbtnCDBatch2.UseVisualStyleBackColor = true;
			this.m_rbtnCDBatch2.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnCopyMKV
			// 
			this.m_rbtnCopyMKV.AutoSize = true;
			this.m_rbtnCopyMKV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnCopyMKV.Location = new System.Drawing.Point(156, 43);
			this.m_rbtnCopyMKV.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnCopyMKV.Name = "m_rbtnCopyMKV";
			this.m_rbtnCopyMKV.Size = new System.Drawing.Size(107, 16);
			this.m_rbtnCopyMKV.TabIndex = 11;
			this.m_rbtnCopyMKV.TabStop = true;
			this.m_rbtnCopyMKV.Tag = MMConv.CommandType.CopyMKV;
			this.m_rbtnCopyMKV.Text = "コンテナ変換MKV";
			this.toolTip1.SetToolTip(this.m_rbtnCopyMKV, "再圧縮なしでMKVに変換します");
			this.m_rbtnCopyMKV.UseVisualStyleBackColor = true;
			this.m_rbtnCopyMKV.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnCnvM4A
			// 
			this.m_rbtnCnvM4A.AutoSize = true;
			this.m_rbtnCnvM4A.Checked = true;
			this.m_rbtnCnvM4A.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnCnvM4A.Location = new System.Drawing.Point(156, 19);
			this.m_rbtnCnvM4A.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnCnvM4A.Name = "m_rbtnCnvM4A";
			this.m_rbtnCnvM4A.Size = new System.Drawing.Size(79, 16);
			this.m_rbtnCnvM4A.TabIndex = 12;
			this.m_rbtnCnvM4A.TabStop = true;
			this.m_rbtnCnvM4A.Tag = MMConv.CommandType.CnvM4A;
			this.m_rbtnCnvM4A.Text = "M4Aに変換";
			this.m_rbtnCnvM4A.UseVisualStyleBackColor = true;
			this.m_rbtnCnvM4A.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnCDBatch
			// 
			this.m_rbtnCDBatch.AutoSize = true;
			this.m_rbtnCDBatch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnCDBatch.Location = new System.Drawing.Point(9, 66);
			this.m_rbtnCDBatch.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnCDBatch.Name = "m_rbtnCDBatch";
			this.m_rbtnCDBatch.Size = new System.Drawing.Size(88, 16);
			this.m_rbtnCDBatch.TabIndex = 9;
			this.m_rbtnCDBatch.TabStop = true;
			this.m_rbtnCDBatch.Tag = MMConv.CommandType.CDFlac;
			this.m_rbtnCDBatch.Text = "CD -> FLAC";
			this.m_rbtnCDBatch.UseVisualStyleBackColor = true;
			this.m_rbtnCDBatch.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnCopyM4V
			// 
			this.m_rbtnCopyM4V.AutoSize = true;
			this.m_rbtnCopyM4V.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnCopyM4V.Location = new System.Drawing.Point(9, 43);
			this.m_rbtnCopyM4V.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnCopyM4V.Name = "m_rbtnCopyM4V";
			this.m_rbtnCopyM4V.Size = new System.Drawing.Size(106, 16);
			this.m_rbtnCopyM4V.TabIndex = 9;
			this.m_rbtnCopyM4V.TabStop = true;
			this.m_rbtnCopyM4V.Tag = MMConv.CommandType.CopyM4V;
			this.m_rbtnCopyM4V.Text = "コンテナ変換M4V";
			this.m_rbtnCopyM4V.UseVisualStyleBackColor = true;
			this.m_rbtnCopyM4V.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// m_rbtnCnvWav
			// 
			this.m_rbtnCnvWav.AutoSize = true;
			this.m_rbtnCnvWav.Checked = true;
			this.m_rbtnCnvWav.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbtnCnvWav.Location = new System.Drawing.Point(9, 19);
			this.m_rbtnCnvWav.Margin = new System.Windows.Forms.Padding(4);
			this.m_rbtnCnvWav.Name = "m_rbtnCnvWav";
			this.m_rbtnCnvWav.Size = new System.Drawing.Size(81, 16);
			this.m_rbtnCnvWav.TabIndex = 9;
			this.m_rbtnCnvWav.TabStop = true;
			this.m_rbtnCnvWav.Tag = MMConv.CommandType.CnvWAV;
			this.m_rbtnCnvWav.Text = "WAVに変換";
			this.m_rbtnCnvWav.UseVisualStyleBackColor = true;
			this.m_rbtnCnvWav.CheckedChanged += new System.EventHandler(this.OnRadioBtn_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button2);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Controls.Add(this.m_uiStart);
			this.panel3.Controls.Add(this.button4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(699, 26);
			this.panel3.TabIndex = 7;
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(183, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(48, 20);
			this.button2.TabIndex = 10;
			this.button2.Text = "ログ";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(89, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 20);
			this.button1.TabIndex = 1;
			this.button1.Text = "リストをクリア";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnClick_ListClear);
			// 
			// m_uiStart
			// 
			this.m_uiStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_uiStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.m_uiStart.FlatAppearance.BorderSize = 0;
			this.m_uiStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_uiStart.Image = ((System.Drawing.Image)(resources.GetObject("m_uiStart.Image")));
			this.m_uiStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_uiStart.Location = new System.Drawing.Point(635, 3);
			this.m_uiStart.Name = "m_uiStart";
			this.m_uiStart.Size = new System.Drawing.Size(61, 20);
			this.m_uiStart.TabIndex = 9;
			this.m_uiStart.Text = "実行";
			this.m_uiStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_uiStart.UseVisualStyleBackColor = true;
			this.m_uiStart.Click += new System.EventHandler(this.m_uiStart_Click);
			// 
			// button4
			// 
			this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.button4.FlatAppearance.BorderSize = 0;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.Location = new System.Drawing.Point(3, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 20);
			this.button4.TabIndex = 8;
			this.button4.Text = "ツール設定";
			this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.OnClick_ToolPanel);
			// 
			// m_txtNotify
			// 
			this.m_txtNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_txtNotify.AutoSize = true;
			this.m_txtNotify.Location = new System.Drawing.Point(29, 479);
			this.m_txtNotify.Name = "m_txtNotify";
			this.m_txtNotify.Size = new System.Drawing.Size(99, 12);
			this.m_txtNotify.TabIndex = 4;
			this.m_txtNotify.Text = "例外が発生しました";
			// 
			// m_picNotify
			// 
			this.m_picNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_picNotify.Location = new System.Drawing.Point(3, 478);
			this.m_picNotify.Name = "m_picNotify";
			this.m_picNotify.Size = new System.Drawing.Size(20, 20);
			this.m_picNotify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picNotify.TabIndex = 8;
			this.m_picNotify.TabStop = false;
			// 
			// m_pictureBox1
			// 
			this.m_pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_pictureBox1.Location = new System.Drawing.Point(669, 474);
			this.m_pictureBox1.Name = "m_pictureBox1";
			this.m_pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.m_pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pictureBox1.TabIndex = 5;
			this.m_pictureBox1.TabStop = false;
			// 
			// MainWindow
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(699, 500);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.m_txtNotify);
			this.Controls.Add(this.m_picNotify);
			this.Controls.Add(this.m_pictureBox1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.m_listView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainWindow";
			this.Text = "MMConv v20191125";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_picNotify)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView m_listView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox m_editOutDir;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button m_btnOpenFileDlg;
		private System.Windows.Forms.PictureBox m_pictureBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button m_uiStart;
		private System.Windows.Forms.PictureBox m_picNotify;
		private System.Windows.Forms.Label m_txtNotify;
		private System.Windows.Forms.RadioButton m_rbtnCopyM4V;
		private System.Windows.Forms.RadioButton m_rbtnCnvWav;
		private System.Windows.Forms.RadioButton m_rbtnCDBatch;
		private System.Windows.Forms.RadioButton m_rbtnCDBatch2;
		private System.Windows.Forms.RadioButton m_rbtnCopyMKV;
		private System.Windows.Forms.RadioButton m_rbtnCnvM4A;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.RadioButton m_rbtnReplayGain;
		private System.Windows.Forms.RadioButton m_rbtnCnvXWM;
		private System.Windows.Forms.RadioButton m_rbtnWavJoin;
		private System.Windows.Forms.RadioButton m_rbtnSoundSplit;
		private System.Windows.Forms.RadioButton m_rbtnTagRename;
		private System.Windows.Forms.RadioButton m_rbtnCnvFLAC;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.RadioButton m_rbtnWavGain;
		private System.Windows.Forms.RadioButton m_rbtnWavSplit;
		private System.Windows.Forms.RadioButton m_rbtnWavSplitGain;
		private System.Windows.Forms.Button button2;
	}
}

