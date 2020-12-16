using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class SelectionBox : IDisposable
    {
        public string m_file;

        public CheckBox m_checkBox;

        private Panel m_panel;

        private Image m_image;

        public SelectionBox(string file, FlowLayoutPanel pictureLayout)
        {
            m_file = file;

            m_panel = new Panel();
            m_panel.Size = new Size(256, 256);
            pictureLayout.Controls.Add(m_panel);

            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            //Create a copy of the image
            using (Image original = Image.FromFile(file))
            {
                pb.Image = m_image = (Image)original.Clone();
            }
            pb.Width = pb.Height = 256;
            pb.Dock = DockStyle.Fill;
            m_panel.Controls.Add(pb);

            m_checkBox = new CheckBox();
            m_checkBox.Dock = DockStyle.Top;
            m_panel.Controls.Add(m_checkBox);

            m_checkBox.CheckedChanged += M_checkBox_CheckedChanged;
            m_checkBox.Checked = true;
            m_panel.Click += Panel_Click;
            pb.Click += Panel_Click;
        }

        public void Dispose()
        {
            m_image.Dispose();
        }

        private void M_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            m_panel.BackColor = m_checkBox.Checked ? Color.Cyan : Color.Empty;
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            m_checkBox.Checked = !m_checkBox.Checked;
        }
    }
}
