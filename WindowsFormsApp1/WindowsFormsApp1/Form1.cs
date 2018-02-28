using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        int contador = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
           //abrir archivo
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = open.FileName;
                string[] showName = fileName.Split('\\');
                TabPage newPage = new TabPage(showName[showName.Length-1]);
                tabControl1.TabPages.Add(newPage);
                newPage.Name = fileName + contador++;
                TextBox text = new TextBox();
                text.Multiline = true;
                text.Name = fileName;

                text.Size = tabControl1.TabPages[newPage.Name].Size;

                tabControl1.TabPages[newPage.Name].Controls.Add(text);
                text.ScrollBars = ScrollBars.Vertical;
                StreamReader sr = new StreamReader(fileName);
                string line;
                line = sr.ReadLine();
                while (line != null)
                {
                    text.AppendText(line);
                    text.AppendText(Environment.NewLine);
                    line = sr.ReadLine();
                
                }
                sr.Close();
                
                if (contador > 2)
                {
                    toolStripMenuItem2.Enabled = true;
                }
                tabControl1.SelectedTab = newPage;

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CrearPestana();
        }
        public void CrearPestana()
        {
            TabPage newPage = new TabPage("Tab "+contador);
            tabControl1.TabPages.Add(newPage);
            newPage.Name = "tab"+ contador++;
            TextBox test = new TextBox();
            test.Multiline = true;
            test.Name = "text" + contador;
           
            test.Size = tabControl1.TabPages[newPage.Name].Size;

            tabControl1.TabPages[newPage.Name].Controls.Add(test);
            test.ScrollBars = ScrollBars.Vertical;
            if (contador > 2)
            {
                toolStripMenuItem2.Enabled = true;
            }
            tabControl1.SelectedTab = newPage;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void guardarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //guardar archivo
        }
    }
    
}