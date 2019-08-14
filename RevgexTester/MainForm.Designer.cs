namespace RevgexTester {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.codeEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ignoreWhitespace = new System.Windows.Forms.CheckBox();
            this.ignoreLineEndings = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.repetitionLimit = new System.Windows.Forms.NumericUpDown();
            this.generateButton = new System.Windows.Forms.Button();
            this.generationCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.output = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filter = new FastColoredTextBoxNS.FastColoredTextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.insertMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maleNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.femaleNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surnameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSPhoneNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailAddressSuffixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.integerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.strongPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupTimer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.outputSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeEditor)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repetitionLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filter)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.codeEditor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 284);
            this.panel1.TabIndex = 0;
            // 
            // codeEditor
            // 
            this.codeEditor.AutoCompleteBrackets = true;
            this.codeEditor.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.codeEditor.AutoIndentChars = false;
            this.codeEditor.AutoIndentExistingLines = false;
            this.codeEditor.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.codeEditor.BackBrush = null;
            this.codeEditor.CharHeight = 14;
            this.codeEditor.CharWidth = 8;
            this.codeEditor.CommentPrefix = "";
            this.codeEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.codeEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.codeEditor.IsReplaceMode = false;
            this.codeEditor.LeftBracket = '(';
            this.codeEditor.LeftBracket2 = '[';
            this.codeEditor.Location = new System.Drawing.Point(0, 24);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Paddings = new System.Windows.Forms.Padding(0);
            this.codeEditor.RightBracket = ')';
            this.codeEditor.RightBracket2 = ']';
            this.codeEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.codeEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("codeEditor.ServiceColors")));
            this.codeEditor.Size = new System.Drawing.Size(448, 260);
            this.codeEditor.TabIndex = 1;
            this.codeEditor.Zoom = 100;
            this.codeEditor.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.codeEditor_TextChangedDelayed);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ignoreWhitespace);
            this.panel2.Controls.Add(this.ignoreLineEndings);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.repetitionLimit);
            this.panel2.Controls.Add(this.generateButton);
            this.panel2.Controls.Add(this.generationCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 111);
            this.panel2.TabIndex = 0;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // ignoreWhitespace
            // 
            this.ignoreWhitespace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ignoreWhitespace.AutoSize = true;
            this.ignoreWhitespace.Checked = true;
            this.ignoreWhitespace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreWhitespace.Location = new System.Drawing.Point(227, 54);
            this.ignoreWhitespace.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ignoreWhitespace.Name = "ignoreWhitespace";
            this.ignoreWhitespace.Size = new System.Drawing.Size(163, 22);
            this.ignoreWhitespace.TabIndex = 7;
            this.ignoreWhitespace.Text = "Ignore whitespace";
            this.ignoreWhitespace.UseVisualStyleBackColor = true;
            this.ignoreWhitespace.CheckedChanged += new System.EventHandler(this.ignoreWs_CheckedChanged);
            // 
            // ignoreLineEndings
            // 
            this.ignoreLineEndings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ignoreLineEndings.AutoSize = true;
            this.ignoreLineEndings.Checked = true;
            this.ignoreLineEndings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreLineEndings.Location = new System.Drawing.Point(3, 54);
            this.ignoreLineEndings.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ignoreLineEndings.Name = "ignoreLineEndings";
            this.ignoreLineEndings.Size = new System.Drawing.Size(179, 22);
            this.ignoreLineEndings.TabIndex = 6;
            this.ignoreLineEndings.Text = "Ignore line endings";
            this.ignoreLineEndings.UseVisualStyleBackColor = true;
            this.ignoreLineEndings.CheckedChanged += new System.EventHandler(this.ignoreLineEndings_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Generation count:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Repetition limit:";
            // 
            // repetitionLimit
            // 
            this.repetitionLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.repetitionLimit.Location = new System.Drawing.Point(227, 26);
            this.repetitionLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.repetitionLimit.Name = "repetitionLimit";
            this.repetitionLimit.Size = new System.Drawing.Size(218, 25);
            this.repetitionLimit.TabIndex = 5;
            this.repetitionLimit.ValueChanged += new System.EventHandler(this.repetitionLimit_ValueChanged);
            // 
            // generateButton
            // 
            this.generateButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.generateButton.Location = new System.Drawing.Point(0, 79);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(448, 32);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // generationCount
            // 
            this.generationCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.generationCount.Location = new System.Drawing.Point(3, 26);
            this.generationCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.generationCount.Name = "generationCount";
            this.generationCount.Size = new System.Drawing.Size(218, 25);
            this.generationCount.TabIndex = 2;
            this.generationCount.ValueChanged += new System.EventHandler(this.generationCount_ValueChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Output:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.output);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.filter);
            this.splitContainer1.Panel2.Controls.Add(this.copyButton);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2MinSize = 192;
            this.splitContainer1.Size = new System.Drawing.Size(704, 395);
            this.splitContainer1.SplitterDistance = 448;
            this.splitContainer1.TabIndex = 1;
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.Color.White;
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Location = new System.Drawing.Point(0, 24);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(252, 278);
            this.output.TabIndex = 3;
            this.output.Text = "";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filter:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filter
            // 
            this.filter.AllowMacroRecording = false;
            this.filter.AutoCompleteBrackets = true;
            this.filter.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.filter.AutoIndent = false;
            this.filter.AutoIndentChars = false;
            this.filter.AutoIndentExistingLines = false;
            this.filter.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.filter.BackBrush = null;
            this.filter.CharHeight = 14;
            this.filter.CharWidth = 8;
            this.filter.CommentPrefix = "";
            this.filter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.filter.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.filter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filter.Hotkeys = resources.GetString("filter.Hotkeys");
            this.filter.IsReplaceMode = false;
            this.filter.LeftBracket = '(';
            this.filter.LeftBracket2 = '[';
            this.filter.Location = new System.Drawing.Point(0, 326);
            this.filter.Multiline = false;
            this.filter.Name = "filter";
            this.filter.Paddings = new System.Windows.Forms.Padding(0);
            this.filter.RightBracket = ')';
            this.filter.RightBracket2 = ']';
            this.filter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.filter.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("filter.ServiceColors")));
            this.filter.ShowLineNumbers = false;
            this.filter.ShowScrollBars = false;
            this.filter.Size = new System.Drawing.Size(252, 37);
            this.filter.TabIndex = 5;
            this.filter.Zoom = 100;
            this.filter.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.filter_TextChangedDelayed);
            // 
            // copyButton
            // 
            this.copyButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.copyButton.Location = new System.Drawing.Point(0, 363);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(252, 32);
            this.copyButton.TabIndex = 4;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "revgex";
            this.openFileDialog.Filter = "Revgex files|*.revgex";
            this.openFileDialog.Title = "Open File";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.outputToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator1,
            this.insertMacroToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // insertMacroToolStripMenuItem
            // 
            this.insertMacroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maleNameToolStripMenuItem,
            this.femaleNameToolStripMenuItem,
            this.surnameToolStripMenuItem,
            this.uSPhoneNumberToolStripMenuItem,
            this.emailAddressSuffixToolStripMenuItem,
            this.toolStripSeparator2,
            this.integerToolStripMenuItem,
            this.byteToolStripMenuItem,
            this.toolStripSeparator3,
            this.strongPasswordToolStripMenuItem});
            this.insertMacroToolStripMenuItem.Name = "insertMacroToolStripMenuItem";
            this.insertMacroToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.insertMacroToolStripMenuItem.Text = "Insert macro";
            // 
            // maleNameToolStripMenuItem
            // 
            this.maleNameToolStripMenuItem.Name = "maleNameToolStripMenuItem";
            this.maleNameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.maleNameToolStripMenuItem.Text = "Male name";
            this.maleNameToolStripMenuItem.Click += new System.EventHandler(this.maleNameToolStripMenuItem_Click);
            // 
            // femaleNameToolStripMenuItem
            // 
            this.femaleNameToolStripMenuItem.Name = "femaleNameToolStripMenuItem";
            this.femaleNameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.femaleNameToolStripMenuItem.Text = "Female name";
            this.femaleNameToolStripMenuItem.Click += new System.EventHandler(this.femaleNameToolStripMenuItem_Click);
            // 
            // surnameToolStripMenuItem
            // 
            this.surnameToolStripMenuItem.Name = "surnameToolStripMenuItem";
            this.surnameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.surnameToolStripMenuItem.Text = "Surname";
            this.surnameToolStripMenuItem.Click += new System.EventHandler(this.surnameToolStripMenuItem_Click);
            // 
            // uSPhoneNumberToolStripMenuItem
            // 
            this.uSPhoneNumberToolStripMenuItem.Name = "uSPhoneNumberToolStripMenuItem";
            this.uSPhoneNumberToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.uSPhoneNumberToolStripMenuItem.Text = "US phone number";
            this.uSPhoneNumberToolStripMenuItem.Click += new System.EventHandler(this.uSPhoneNumberToolStripMenuItem_Click);
            // 
            // emailAddressSuffixToolStripMenuItem
            // 
            this.emailAddressSuffixToolStripMenuItem.Name = "emailAddressSuffixToolStripMenuItem";
            this.emailAddressSuffixToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.emailAddressSuffixToolStripMenuItem.Text = "E-mail address suffix";
            this.emailAddressSuffixToolStripMenuItem.Click += new System.EventHandler(this.emailAddressSuffixToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // integerToolStripMenuItem
            // 
            this.integerToolStripMenuItem.Name = "integerToolStripMenuItem";
            this.integerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.integerToolStripMenuItem.Text = "Integer";
            this.integerToolStripMenuItem.Click += new System.EventHandler(this.integerToolStripMenuItem_Click);
            // 
            // byteToolStripMenuItem
            // 
            this.byteToolStripMenuItem.Name = "byteToolStripMenuItem";
            this.byteToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.byteToolStripMenuItem.Text = "Byte";
            this.byteToolStripMenuItem.Click += new System.EventHandler(this.byteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // strongPasswordToolStripMenuItem
            // 
            this.strongPasswordToolStripMenuItem.Name = "strongPasswordToolStripMenuItem";
            this.strongPasswordToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.strongPasswordToolStripMenuItem.Text = "Strong password";
            this.strongPasswordToolStripMenuItem.Click += new System.EventHandler(this.strongPasswordToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotkeysToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // hotkeysToolStripMenuItem
            // 
            this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
            this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.hotkeysToolStripMenuItem.Text = "Hotkeys";
            this.hotkeysToolStripMenuItem.Click += new System.EventHandler(this.shortcutsToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.saveOutputToolStripMenuItem,
            this.separatorStyleToolStripMenuItem});
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.outputToolStripMenuItem.Text = "Output";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // saveOutputToolStripMenuItem
            // 
            this.saveOutputToolStripMenuItem.Name = "saveOutputToolStripMenuItem";
            this.saveOutputToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveOutputToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveOutputToolStripMenuItem.Text = "Save";
            this.saveOutputToolStripMenuItem.Click += new System.EventHandler(this.saveOutputToolStripMenuItem_Click);
            // 
            // separatorStyleToolStripMenuItem
            // 
            this.separatorStyleToolStripMenuItem.Name = "separatorStyleToolStripMenuItem";
            this.separatorStyleToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.separatorStyleToolStripMenuItem.Text = "Separator style";
            this.separatorStyleToolStripMenuItem.Click += new System.EventHandler(this.separatorStyleToolStripMenuItem_Click);
            // 
            // backupTimer
            // 
            this.backupTimer.Enabled = true;
            this.backupTimer.Interval = 3000;
            this.backupTimer.Tick += new System.EventHandler(this.backupTimer_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "revgex";
            this.saveFileDialog.Filter = "Revgex file|*.revgex";
            this.saveFileDialog.Title = "Save File";
            // 
            // outputSaveFileDialog
            // 
            this.outputSaveFileDialog.Filter = "Data file|*.dat|Text file|*.txt|Any file|*.*";
            this.outputSaveFileDialog.Title = "Save Output";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel1.Text = "Soutěžní verze pro";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(134, 17);
            this.toolStripStatusLabel2.Text = "ITnetwork summer 2018";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codeEditor)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repetitionLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationCount)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filter)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private FastColoredTextBoxNS.FastColoredTextBox codeEditor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown repetitionLimit;
        private System.Windows.Forms.NumericUpDown generationCount;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotkeysToolStripMenuItem;
        private System.Windows.Forms.Timer backupTimer;
        private System.Windows.Forms.CheckBox ignoreLineEndings;
        private System.Windows.Forms.Label label2;
        private FastColoredTextBoxNS.FastColoredTextBox filter;
        private System.Windows.Forms.CheckBox ignoreWhitespace;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem insertMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maleNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem femaleNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surnameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSPhoneNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailAddressSuffixToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem integerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem strongPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOutputToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SaveFileDialog outputSaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem separatorStyleToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

