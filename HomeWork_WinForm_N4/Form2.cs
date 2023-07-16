using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_WinForm_N4
{
    public partial class Form2 : Form
    {
        public string sourceText = String.Empty;
        private string fileName;
        public Form2(string text, string fileName)
        {
            InitializeComponent();
            textBox1.Text = text;
            sourceText = text;
            this.fileName = fileName;
        }
       private void buttonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            sourceText = textBox1.Text;
            using (StreamWriter sw = new StreamWriter(this.fileName))
            {
                sw.WriteLine(textBox1.Text);
            }
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
