using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EnterName : Form
    {
        public string m_text;

        public EnterName()
        {
            DialogResult = DialogResult.Cancel;
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            m_text = textBox1.Text;
        }
    }
}
