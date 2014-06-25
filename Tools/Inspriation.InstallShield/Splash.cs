using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstallShield
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
           
        }

        private void Splash_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            Mainform obj = new Mainform();
            obj.ShowDialog();
        }
    }
}
