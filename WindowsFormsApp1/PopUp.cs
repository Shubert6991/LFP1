﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
        }

        private void PopUp_Load(object sender, EventArgs e)
        {
            for(int i=0; i<Form1.nombTabs.Count; i++)
            {
                comboBox1.Items.Add(Form1.nombTabs[i]);
                comboBox2.Items.Add(Form1.nombTabs[i]);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                       
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
