using System;
using System.Linq;
using ReverseRegex;
using System.Drawing;
using System.Windows.Forms;
using RevgexTester.Properties;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RevgexTester {

    public partial class MainForm : Form {

        private bool settingsChanged, allowChangeEvents;

        private readonly List<string> generated;

        private FileInfo currentFile;

        public FileInfo CurrentFile {
            get => currentFile;
            set {
                currentFile = value;
                Text = currentFile?.FullName ?? "";
                Settings.Default.File = Text;
                settingsChanged = true;
            }
        }

        private OutputSeparatorStyle separator;

        private bool spaceAroundSeparator;

        public MainForm() {
            settingsChanged = allowChangeEvents = false;
            generated = new List<string>();
            CurrentFile = File.Exists(Settings.Default.File) ? new FileInfo(Settings.Default.File) : null;
            InitializeComponent();
            openFileDialog.InitialDirectory = saveFileDialog.InitialDirectory = outputSaveFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private string GetSeparatorStyleLabel() {
            string style;
            if (separator != OutputSeparatorStyle.None) {
                style = ((int)separator).ToString();
                style = $"  {style}  ";
            } else style = "None";
            return $"Separator style ({style})";
        }

        private void WriteSeparatorString(TextWriter tw) {
            var s = "";
            switch (separator) {
                case OutputSeparatorStyle.None:
                    return;
                case OutputSeparatorStyle.Style1:
                    s = "───────────────────────────────────────────────────────────────────────────────────────────────────";
                    break;
                case OutputSeparatorStyle.Style2:
                    s = "─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─═─";
                    break;
                case OutputSeparatorStyle.Style3:
                    s = "═══════════════════════════════════════════════════════════════════════════════════════════════════";
                    break;
                case OutputSeparatorStyle.Style4:
                    s = "▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄";
                    break;
                case OutputSeparatorStyle.Style5:
                    s = "▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄█▀█▄";
                    break;
                case OutputSeparatorStyle.Style6:
                    s = "███████████████████████████████████████████████████████████████████████████████████████████████████";
                    break;
                case OutputSeparatorStyle.Style7:
                    s = "";
                    break;
            }
            if (spaceAroundSeparator) {
                tw.WriteLine();
                tw.WriteLine(s);
                tw.WriteLine();
            } else tw.WriteLine(s);
        }

        private void WriteGeneratedDataAsText(TextWriter tw) {
            if (generated.Count == 0) return;
            var first = true;
            foreach (var g in generated) {
                if (!first) WriteSeparatorString(tw);
                tw.WriteLine(g);
                first = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            codeEditor.Text = Settings.Default.Code;
            filter.Text = Settings.Default.Filter;
            generationCount.Value = Settings.Default.GenerationCount;
            repetitionLimit.Value = Settings.Default.RepetitionLimit;
            if (Settings.Default.Hotkeys == "?")
                Settings.Default.Hotkeys = codeEditor.Hotkeys;
            else codeEditor.Hotkeys = Settings.Default.Hotkeys;
            spaceAroundSeparator = Settings.Default.SpaceAroundSeparator;
            if (Settings.Default.SeparatorStyle > 7 || Settings.Default.SeparatorStyle < 0)
                separator = OutputSeparatorStyle.None;
            else separator = (OutputSeparatorStyle)Settings.Default.SeparatorStyle;
            separatorStyleToolStripMenuItem.Text = GetSeparatorStyleLabel();
            allowChangeEvents = true;
        }

        private void panel2_Resize(object sender, EventArgs e) {
            repetitionLimit.Width = generationCount.Width = (panel2.Width - 12) / 2;
            label5.Left = repetitionLimit.Left = ignoreWhitespace.Left = panel2.Width / 2 + 3;
        }

        private void copyButton_Click(object sender, EventArgs e) {
            if (generated.Count > 0) {
                var sw = new StringWriter();
                WriteGeneratedDataAsText(sw);
                Clipboard.SetText(sw.ToString());
            } else MessageBox.Show("Nothing to copy.", "-", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void codeEditor_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            if (allowChangeEvents) {
                Settings.Default.Code = codeEditor.Text;
                settingsChanged = true;
            }
        }

        private void generationCount_ValueChanged(object sender, EventArgs e) {
            if (allowChangeEvents) {
                Settings.Default.GenerationCount = (int)generationCount.Value;
                settingsChanged = true;
            }
        }

        private void repetitionLimit_ValueChanged(object sender, EventArgs e) {
            if (allowChangeEvents) {
                Settings.Default.RepetitionLimit = (int)repetitionLimit.Value;
                settingsChanged = true;
            }
        }

        private void ignoreLineEndings_CheckedChanged(object sender, EventArgs e) {
            if (allowChangeEvents) {
                Settings.Default.IgnoreLineEndings = ignoreLineEndings.Checked;
                settingsChanged = true;
            }
            if (!ignoreLineEndings.Checked)
                ignoreWhitespace.Checked = false;
        }

        private void shortcutsToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var f = new FastColoredTextBoxNS.HotkeysEditorForm(codeEditor.HotkeysMapping)) {
                if (f.ShowDialog() == DialogResult.OK) {
                    codeEditor.HotkeysMapping = f.GetHotkeys();
                    Settings.Default.Hotkeys = codeEditor.Hotkeys;
                    if (allowChangeEvents) settingsChanged = true;
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e) {
            generated.Clear();
            Revgex generator;
            try {
                generator = new Revgex(codeEditor.Text, ignoreLineEndings.Checked, ignoreWhitespace.Checked);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (var i = 0; i < generationCount.Value; ++i)
                generated.Add(generator.Generate((int)repetitionLimit.Value));

            RefreshOutputView();
        }
        
        private void filter_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) => RefreshOutputView();

        private void backupTimer_Tick(object sender, EventArgs e) => Backup();

        private void Backup() {
            if (settingsChanged) {
                Settings.Default.Save();
                settingsChanged = false;
            }
        }

        private void ignoreWs_CheckedChanged(object sender, EventArgs e) {
            if (allowChangeEvents) {
                Settings.Default.IgnoreWhitespace = ignoreWhitespace.Checked;
                settingsChanged = true;
            }
            if (ignoreWhitespace.Checked)
                ignoreLineEndings.Checked = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => Backup();

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            if (codeEditor.Text.Length == 0) {
                CurrentFile = null;
                return;
            }
            if (codeEditor.IsChanged) {
                switch (MessageBox.Show("Do you want to save the previous generator?", "Possibly unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)) {
                    case DialogResult.Yes:
                        saveToolStripMenuItem_Click(sender, EventArgs.Empty);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            codeEditor.Text = "";
            CurrentFile = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (codeEditor.Text.Length > 0) {
                switch (MessageBox.Show("Do you want to save the previous generator?", "Possibly unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)) {
                    case DialogResult.Yes:
                        saveToolStripMenuItem_Click(sender, EventArgs.Empty);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var f = new FileInfo(openFileDialog.FileName);
                    if (f.Length > 10_000_000) {
                        MessageBox.Show("Selected file is too large.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    codeEditor.OpenFile(f.FullName, Encoding.UTF8);
                    CurrentFile = f;
                } catch (Exception ex) {
                    MessageBox.Show("Error has appeared while opening the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveCurrentFile() {
            try {
                codeEditor.SaveToFile(CurrentFile.FullName, Encoding.UTF8);
            } catch (Exception ex) {
                MessageBox.Show("Error has appeared while saving the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (CurrentFile == null) {
                saveAsToolStripMenuItem_Click(sender, e);
            } else SaveCurrentFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    CurrentFile = new FileInfo(saveFileDialog.FileName);
                    SaveCurrentFile();
                } catch (Exception ex) {
                    MessageBox.Show("Error has appeared while saving the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => copyButton_Click(sender, e);

        private void generateToolStripMenuItem_Click(object sender, EventArgs e) => generateButton_Click(sender, e);

        private void saveOutputToolStripMenuItem_Click(object sender, EventArgs e) {
            if (generated.Count == 0) MessageBox.Show("Nothing to save.", "-", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (outputSaveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    using (var sw = new StreamWriter(outputSaveFileDialog.FileName, false, Encoding.UTF8))
                        WriteGeneratedDataAsText(sw);
                } catch {
                    MessageBox.Show("Error has appeared while saving the generated output.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) => codeEditor.Undo();

        private void redoToolStripMenuItem_Click(object sender, EventArgs e) => codeEditor.Redo();

        private void maleNameToolStripMenuItem_Click(object sender, EventArgs e) =>
            codeEditor.InsertText(@"\::maleName;");

        private void femaleNameToolStripMenuItem_Click(object sender, EventArgs e) =>
            codeEditor.InsertText(@"\::femaleName;");

        private void surnameToolStripMenuItem_Click(object sender, EventArgs e) =>
            codeEditor.InsertText(@"\::surname;");

        private void uSPhoneNumberToolStripMenuItem_Click(object sender, EventArgs e) =>
            codeEditor.InsertText(@"\::usPhone;");

        private void emailAddressSuffixToolStripMenuItem_Click(object sender, EventArgs e) =>
            codeEditor.InsertText(@"\::mailSuffix;");

        private void integerToolStripMenuItem_Click(object sender, EventArgs e) =>
            codeEditor.InsertText(@"\::int;");

        private void byteToolStripMenuItem_Click(object sender, EventArgs e) =>
            codeEditor.InsertText(@"\::byte;");

        private void strongPasswordToolStripMenuItem_Click(object sender, EventArgs e) =>
            codeEditor.InsertText(@"\::passwd;");

        private void separatorStyleToolStripMenuItem_Click(object sender, EventArgs e) {
            var dialog = new OutputStyleDialog {
                SeparatorStyle = separator,
                SpaceAroundSeparator = spaceAroundSeparator
            };
            if (dialog.ShowDialog() == DialogResult.OK) {
                Settings.Default.SpaceAroundSeparator = spaceAroundSeparator = dialog.SpaceAroundSeparator;
                Settings.Default.SeparatorStyle = (int)(separator = dialog.SeparatorStyle);
                separatorStyleToolStripMenuItem.Text = GetSeparatorStyleLabel();
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e) =>
            Process.Start("https://www.itnetwork.cz/nezarazene/itnetwork-summer-2018");

        private void RefreshOutputView() {
            var rtb = new RichTextBox { Font = output.Font };
            Regex regex = null;
            try {
                regex = new Regex(filter.Text, RegexOptions.Compiled);
            } catch (Exception ex) {
                rtb.Text = $"Invalid filter:\n{ex.Message}";
                rtb.SelectAll();
                rtb.SelectionColor = Color.Red;
            }
            if (regex != null) {
                var even = false;
                var count = 0;
                int s;
                foreach (var str in generated.Where(str => regex.IsMatch(str))) {
                    s = rtb.TextLength;
                    rtb.AppendText("█ " + str.Replace("\r\n", "\n").Replace('\r', '\n').Replace("\n", "\n█ ") + "\n\n");
                    rtb.Select(s, rtb.TextLength - s);
                    rtb.SelectionColor = even ? Color.DarkSlateBlue : Color.Black;
                    even = !even;
                    ++count;
                }
                s = rtb.TextLength;
                rtb.AppendText($"Generated {generated.Count} strings\n");
                rtb.AppendText($"Filter matched {count} strings");
                rtb.Select(s, rtb.TextLength - s);
                rtb.SelectionColor = Color.Gray;
            }
            output.Rtf = rtb.Rtf;
            output.Select(0, 0);
            output.ScrollToCaret();
            rtb.Dispose();
        }
    }
}
