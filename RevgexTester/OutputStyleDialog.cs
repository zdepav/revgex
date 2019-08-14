using System;
using System.Windows.Forms;

namespace RevgexTester {

    public partial class OutputStyleDialog : Form {

        public OutputSeparatorStyle SeparatorStyle {
            get => separator1.Checked ? OutputSeparatorStyle.Style1
                : separator2.Checked ? OutputSeparatorStyle.Style2
                : separator3.Checked ? OutputSeparatorStyle.Style3
                : separator4.Checked ? OutputSeparatorStyle.Style4
                : separator5.Checked ? OutputSeparatorStyle.Style5
                : separator6.Checked ? OutputSeparatorStyle.Style6
                : separator7.Checked ? OutputSeparatorStyle.Style7
                : OutputSeparatorStyle.None;
            set {
                switch (value) {
                    case OutputSeparatorStyle.Style1:
                        separator1.Checked = true;
                        break;
                    case OutputSeparatorStyle.Style2:
                        separator2.Checked = true;
                        break;
                    case OutputSeparatorStyle.Style3:
                        separator3.Checked = true;
                        break;
                    case OutputSeparatorStyle.Style4:
                        separator4.Checked = true;
                        break;
                    case OutputSeparatorStyle.Style5:
                        separator5.Checked = true;
                        break;
                    case OutputSeparatorStyle.Style6:
                        separator6.Checked = true;
                        break;
                    case OutputSeparatorStyle.Style7:
                        separator7.Checked = true;
                        break;
                    default:
                        separatorNone.Checked = true;
                        break;
                }
            }
        }

        public bool SpaceAroundSeparator {
            get => spaceAroundSeparator.Checked;
            set => spaceAroundSeparator.Checked = value;
        }

        public OutputStyleDialog() {
            InitializeComponent();
        }

        private void OutputStyleDialog_Load(object sender, EventArgs e) { }

        private void okButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void cancelButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void separator_CheckedChanged(object sender, EventArgs e) {
            if (separatorNone.Checked) {
                spaceAroundSeparator.Checked = false;
                spaceAroundSeparator.Enabled = false;
            } else spaceAroundSeparator.Enabled = true;
        }

        private void spaceAroundSeparator_CheckedChanged(object sender, EventArgs e) {
            if (spaceAroundSeparator.Checked && separatorNone.Checked)
                spaceAroundSeparator.Checked = false;
        }

        private void OutputStyleDialog_FormClosed(object sender, FormClosedEventArgs e) {

        }
    }
}
