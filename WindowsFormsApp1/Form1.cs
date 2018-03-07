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
using Microsoft.CSharp.RuntimeBinder;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        int contador = 1;
        public static List<string> nombTabs = new List<string>();
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
                nombTabs.Add(fileName);

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
            nombTabs.Add(newPage.Name);
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
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = @"C:\";
            save.Title = "Guardar Archivo";
            save.DefaultExt = "txt";
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            save.FilterIndex = 1;
            save.RestoreDirectory = true;
            
            if (save.ShowDialog() == DialogResult.OK)
            {
                var box = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
                File.WriteAllText(save.FileName, box.Text);
            }

        }
        public void AnalisisLexico()
        {
            //var pop = new PopUp();
            //pop.Show(); 
            Analizador("\n");
            
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            AnalisisLexico();
        }
        public void Analizador(string texto)
        {
            try
            {
                byte[] analizado = Encoding.ASCII.GetBytes(texto);
                int index = 0;
                List<string> a = new List<string>();
                int c=0, f=0, j=0,i=0;
                bool continueL = true;

                while (i<analizado.Length)
                {
                    if (analizado[i] == 32)
                    {
                        index = 0;
                        c++;
                    }
                    else if (analizado[i] == 10)
                    {
                        index = 1;
                        f++;
                        c = 0;
                    }
                    else if (analizado[i] > 64 && analizado[i] < 91 || analizado[i] > 96 && analizado[i] < 123)
                    {
                        index = 2;
                        c++;
                    }
                    else if (analizado[i] > 47 && analizado[i] < 58)
                    {
                        index = 3;
                        c++;
                    }
                    else if (analizado[i] == 43 || analizado[i] == 45)
                    {
                        index = 4;
                        c++;
                    }
                    else if (texto[i] == '!'||texto[i]=='!'||texto[i]=='¿'||texto[i]=='?'||texto[i]==':'||texto[i]==';'||texto[i]=='"'||texto[i]=='('||texto[i]==')'||texto[i]=='-'||texto[i]=='_')
                    {
                        index = 5;
                        c++;
                    }
                    else if(analizado[i] == 46)
                    {
                        index = 6;
                        c++;
                    }
                    else if(analizado[i] == 47)
                    {
                        index = 7;
                        c++;
                    }
                    else
                    {
                        index = 8;
                        c++;
                    }
                    switch (index)
                    {
                        case 0:
                            MessageBox.Show("espacio");
                            i++;
                            break;
                        case 1:
                            MessageBox.Show("enter");
                            i++;
                            break;
                        case 2:
                            MessageBox.Show("Letra");
                            MessageBox.Show(texto[i].ToString());
                            i++;
                            break;
                        case 3:
                            MessageBox.Show("numero");
                            MessageBox.Show(texto[i].ToString());
                            i++;
                            break;
                        case 4:
                            MessageBox.Show("signo");
                            MessageBox.Show(texto[i].ToString());
                            i++;
                            break;
                        case 5:
                            MessageBox.Show("simbolo");
                            MessageBox.Show(texto[i].ToString());
                            i++;
                            break;
                        case 6:
                            MessageBox.Show("punto");
                            MessageBox.Show(texto[i].ToString());
                            i++;
                            break;
                        case 7:
                            MessageBox.Show("comentario");
                            MessageBox.Show(texto[i].ToString());
                            i++;
                            break;
                        case 8:
                            MessageBox.Show("error");
                            MessageBox.Show(texto[i].ToString());
                            i++;
                            break;
                        default:
                            break;
                    }
            }

            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
    
}