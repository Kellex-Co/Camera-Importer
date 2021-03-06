﻿using PDCam.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDCam
{
    public partial class ListPicturesForm : Form
    {
        /// <summary>
        /// The picture box with selection controls.
        /// </summary>
        List<SelectionBox> m_pictures;

        /// <summary>
        /// A list of all the detected files including thumbnails.
        /// </summary>
        List<string> m_allFiles;

        //THM are thumbnail files on a digital camera.
        //They're essentially useless so if it runs into one it will offer the user a dialog box to remove them.
        bool m_askedAboutTHMFiles = false;//Have we asked about removing them?
        bool m_removeTHMFiles = false;//User has requested their deletion.

        public ListPicturesForm(List<string> files)
        {
            m_allFiles = files;
            Icon = Resources.Kellex_Camera;

            //Create a list to store all of the loaded images.
            m_pictures = new List<SelectionBox>(files.Count);

            InitializeComponent();

            foreach (string file in files)
            {
                //If this file is a thumbnail
                if (Path.GetExtension(file).ToUpper() == ".THM")
                {
                    //If we haven't asked about removing them display a dialog box asking to remove THM files yes/no
                    if (!m_askedAboutTHMFiles)
                    {
                        m_askedAboutTHMFiles = true;
                        DialogResult result = MessageBox.Show("Do you want this program to remove the THM files?", "Thumbnail files?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        m_removeTHMFiles = result == DialogResult.Yes;
                    }
                }
                else
                {
                    //This will create the WinForms controls for displaying the image and checkbox.
                    m_pictures.Add(new SelectionBox(file, pictureLayout));
                }
            }
        }

        //Dispose of all the images when the form is closed.
        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            foreach (SelectionBox img in m_pictures)
                img.Dispose();
        }

        //When the IMPORT button is clicked.
        private void button1_Click(object sender, EventArgs e)
        {
            //This is where Kellex stores the photos.
            string root = @"\\noah\Applications\1.) ScanData\Scan Data Entry Folder\Photos";

            //Ask the user for text to prefix all the images with.
            EnterName enterName = new EnterName();
            DialogResult result = enterName.ShowDialog();
            if (result == DialogResult.OK)//This is in case the user clicks the cancel button.
            {
                string namePrefix = enterName.m_text;

                //Find/Create a directory of the current date to move to the images to.
                string directory = Path.Combine(root, DateTime.Now.Date.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(directory))
                {
                    try
                    {
                        Directory.CreateDirectory(directory);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to create the directory \"{DateTime.Now.Date.ToString("yyyy - MM - dd")}\" try to create it manually?\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //Move all the images.
                int i = 1;

                int count = m_pictures.Count(new Func<SelectionBox, bool>((sb) => sb.m_checkBox.Checked));
                if (count > 0)
                {
                    progressBar1.Maximum = count;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;
                    foreach (SelectionBox sb in m_pictures)
                    {
                        if (sb.m_checkBox.Checked)
                        {
                            string file = sb.m_file;
                            string destination;

                            do
                            {
                                destination = Path.Combine(directory, $"{namePrefix} ({i++}){Path.GetExtension(file)}");
                            }
                            //Keep looping until a unique `i` number is found.
                            while (File.Exists(destination));



                            try
                            {
                                File.Move(file, destination);

                                //The user responded YES delete all the THM files found.
                                if (m_removeTHMFiles && sb.m_thumbnailFile != null)
                                {
                                    try
                                    {
                                        File.Delete(sb.m_thumbnailFile);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Failed to delete thumbnail \"{Path.GetFileName(sb.m_thumbnailFile)}\"\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to move image \"{Path.GetFileName(file)}\"\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            progressBar1.Value = progressBar1.Value + 1;
                        }
                    }
                }
            }

            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
