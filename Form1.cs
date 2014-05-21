using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace RegExTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Pattern.Text) &&
                !string.IsNullOrWhiteSpace(Result.Text))
            {
                StringBuilder sb = new StringBuilder();
                Regex regex = new Regex(Pattern.Text);
                using (StringReader sr = new StringReader(Result.Text))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();
                        if (null == line)
                            break;
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] part = line.Split('\t');
                            bool ismatch = regex.IsMatch(part[0]);
                            sb.AppendFormat("{0}\t{1}", part[0], ismatch);
                            sb.AppendLine();
                        }
                    }
                }
                Result.Text = sb.ToString();
            }
        }
    }
}
