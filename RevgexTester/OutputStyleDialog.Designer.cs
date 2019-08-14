namespace RevgexTester {
    partial class OutputStyleDialog {
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.separator1 = new System.Windows.Forms.RadioButton();
            this.separator3 = new System.Windows.Forms.RadioButton();
            this.separator4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.separator5 = new System.Windows.Forms.RadioButton();
            this.separator7 = new System.Windows.Forms.RadioButton();
            this.spaceAroundSeparator = new System.Windows.Forms.CheckBox();
            this.separator6 = new System.Windows.Forms.RadioButton();
            this.separator2 = new System.Windows.Forms.RadioButton();
            this.separatorNone = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(182, 282);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(167, 32);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(9, 282);
            this.okButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(167, 32);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // separator1
            // 
            this.separator1.AutoSize = true;
            this.separator1.Location = new System.Drawing.Point(12, 30);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(338, 22);
            this.separator1.TabIndex = 2;
            this.separator1.Text = "───────────────────────────────────────";
            this.separator1.UseVisualStyleBackColor = true;
            this.separator1.CheckedChanged += new System.EventHandler(this.separator_CheckedChanged);
            // 
            // separator3
            // 
            this.separator3.AutoSize = true;
            this.separator3.Location = new System.Drawing.Point(12, 86);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(338, 22);
            this.separator3.TabIndex = 3;
            this.separator3.Text = "═══════════════════════════════════════";
            this.separator3.UseVisualStyleBackColor = true;
            this.separator3.CheckedChanged += new System.EventHandler(this.separator_CheckedChanged);
            // 
            // separator4
            // 
            this.separator4.AutoSize = true;
            this.separator4.Location = new System.Drawing.Point(12, 114);
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(338, 22);
            this.separator4.TabIndex = 4;
            this.separator4.Text = "▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄";
            this.separator4.UseVisualStyleBackColor = true;
            this.separator4.CheckedChanged += new System.EventHandler(this.separator_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Separator style";
            // 
            // separator5
            // 
            this.separator5.AutoSize = true;
            this.separator5.Location = new System.Drawing.Point(12, 142);
            this.separator5.Name = "separator5";
            this.separator5.Size = new System.Drawing.Size(338, 22);
            this.separator5.TabIndex = 6;
            this.separator5.Text = "▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄";
            this.separator5.UseVisualStyleBackColor = true;
            this.separator5.CheckedChanged += new System.EventHandler(this.separator_CheckedChanged);
            // 
            // separator7
            // 
            this.separator7.AutoSize = true;
            this.separator7.Location = new System.Drawing.Point(12, 198);
            this.separator7.Name = "separator7";
            this.separator7.Size = new System.Drawing.Size(34, 22);
            this.separator7.TabIndex = 7;
            this.separator7.Text = " ";
            this.separator7.UseVisualStyleBackColor = true;
            this.separator7.CheckedChanged += new System.EventHandler(this.separator_CheckedChanged);
            // 
            // spaceAroundSeparator
            // 
            this.spaceAroundSeparator.AutoSize = true;
            this.spaceAroundSeparator.Checked = true;
            this.spaceAroundSeparator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.spaceAroundSeparator.Location = new System.Drawing.Point(12, 254);
            this.spaceAroundSeparator.Name = "spaceAroundSeparator";
            this.spaceAroundSeparator.Size = new System.Drawing.Size(315, 22);
            this.spaceAroundSeparator.TabIndex = 8;
            this.spaceAroundSeparator.Text = "Surround separators with blank lines";
            this.spaceAroundSeparator.UseVisualStyleBackColor = true;
            this.spaceAroundSeparator.CheckedChanged += new System.EventHandler(this.spaceAroundSeparator_CheckedChanged);
            // 
            // separator6
            // 
            this.separator6.AutoSize = true;
            this.separator6.Checked = true;
            this.separator6.Location = new System.Drawing.Point(12, 170);
            this.separator6.Name = "separator6";
            this.separator6.Size = new System.Drawing.Size(338, 22);
            this.separator6.TabIndex = 10;
            this.separator6.TabStop = true;
            this.separator6.Text = "███████████████████████████████████████";
            this.separator6.UseVisualStyleBackColor = true;
            this.separator6.CheckedChanged += new System.EventHandler(this.separator_CheckedChanged);
            // 
            // separator2
            // 
            this.separator2.AutoSize = true;
            this.separator2.Location = new System.Drawing.Point(12, 58);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(338, 22);
            this.separator2.TabIndex = 9;
            this.separator2.Text = "─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─";
            this.separator2.UseVisualStyleBackColor = true;
            this.separator2.CheckedChanged += new System.EventHandler(this.separator_CheckedChanged);
            // 
            // separatorNone
            // 
            this.separatorNone.AutoSize = true;
            this.separatorNone.Location = new System.Drawing.Point(12, 226);
            this.separatorNone.Name = "separatorNone";
            this.separatorNone.Size = new System.Drawing.Size(66, 22);
            this.separatorNone.TabIndex = 11;
            this.separatorNone.Text = " None";
            this.separatorNone.UseVisualStyleBackColor = true;
            this.separatorNone.CheckedChanged += new System.EventHandler(this.separator_CheckedChanged);
            // 
            // OutputStyleDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(358, 323);
            this.Controls.Add(this.separatorNone);
            this.Controls.Add(this.separator6);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.spaceAroundSeparator);
            this.Controls.Add(this.separator7);
            this.Controls.Add(this.separator5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.separator4);
            this.Controls.Add(this.separator3);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OutputStyleDialog";
            this.ShowIcon = false;
            this.Text = "Output Style";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OutputStyleDialog_FormClosed);
            this.Load += new System.EventHandler(this.OutputStyleDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton separator1;
        private System.Windows.Forms.RadioButton separator3;
        private System.Windows.Forms.RadioButton separator4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton separator5;
        private System.Windows.Forms.RadioButton separator7;
        private System.Windows.Forms.CheckBox spaceAroundSeparator;
        private System.Windows.Forms.RadioButton separator6;
        private System.Windows.Forms.RadioButton separator2;
        private System.Windows.Forms.RadioButton separatorNone;
    }
}