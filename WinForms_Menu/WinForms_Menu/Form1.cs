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

namespace WinForms_Menu
{
    public partial class Form1 : Form
    {
        Color defaultColor = new Color();
        Color defaultFontColor = new Color();
        ImageList list = null;
        ToolBar toolBar = null;
        ContextMenu cm = null;
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            defaultColor = this.BackColor;
            defaultFontColor = this.ForeColor;
            menuStrip2.Visible = false;
            cm = new ContextMenu();
            MenuItem item = new MenuItem("Open");
            MenuItem item2 = new MenuItem("Rus");
            MenuItem item3 = new MenuItem("Eng");
            cm.MenuItems.Add(item);
            cm.MenuItems.Add(item2);
            cm.MenuItems.Add(item3);
            textBox1.ContextMenu = cm;
            item.Click += openToolStripMenuItem_Click;
            item2.Click += russianToolStripMenuItem_Click;
            item3.Click += englishToolStripMenuItem_Click;
            list = new ImageList();
            list.ImageSize = new Size(50, 50);
            list.Images.Add(new Bitmap(""));//путь к картинке
            toolBar = new ToolBar();
            toolBar.Appearance = ToolBarAppearance.Flat;
            toolBar.BorderStyle = BorderStyle.Fixed3D;
            toolBar.ImageList = list;
            ToolBarButton toolBarButton = new ToolBarButton();
            toolBarButton.Tag = "open";//название кнопки/действия
            toolBarButton.ImageIndex = 0;
            toolBar.Buttons.Add(toolBarButton);
            this.Controls.Add(toolBar);
            toolBar.ButtonClick += ToolBar_ButtonClick;
        }

        private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag)
            {
                case "open":
                    textBox1.Enabled = true;
                    OpenFileDialog dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Text = File.ReadAllText(dialog.FileName, Encoding.Default);//Encoding.Default - для русского
                    }
                    break;
                default:
                    break;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, textBox1.Text);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.White;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
            textBox1.ForeColor = Color.White;
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = defaultColor;
            textBox1.ForeColor = defaultFontColor;
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip2.Visible = true;
            menuStrip1.Visible = false;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;
            menuStrip1.Visible = true;
        }
    }
}