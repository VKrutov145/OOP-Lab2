using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace OOP___Lab2
{
    public partial class Form1 : Form
    {
        private string path = "XMLFile1.xml";
        private string pathXsl = "XSLFile1.xsl";
        private ComboBox yearBox;

        public Form1()
        {
            InitializeComponent();
            buildBox(comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6);
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            radioButtonLINQ.Checked = true;
        }
        
        public void buildBox(ComboBox countryBox, ComboBox typeBox, ComboBox classBox, ComboBox yearBox, 
            ComboBox ifNuclearBox, ComboBox lengthBox)
        {
            this.yearBox = yearBox;
            IStrategy s = new LINQ();
            List<Submarine> res = s.AnalyzeFile(new Submarine(), path);
            List<string> subCountry = new List<string>();
            List<string> subType = new List<string>();
            List<string> subClass = new List<string>();
            List<string> subYear = new List<string>();
            List<string> ifSubNuclear = new List<string>();
            List<string> subLength = new List<string>();
            foreach(Submarine elem in res)
            {
                if (!subCountry.Contains(elem.subCountry))
                {
                    subCountry.Add(elem.subCountry);
                }
                if (!subType.Contains(elem.subType))
                {
                    subType.Add(elem.subType);
                }
                if (!subClass.Contains(elem.subClass))
                {
                    subClass.Add(elem.subClass);
                }
                if (!subYear.Contains(elem.subYear))
                {
                    subYear.Add(elem.subYear);
                }
                if (!ifSubNuclear.Contains(elem.ifSubNuclear))
                {
                    ifSubNuclear.Add(elem.ifSubNuclear);
                }
                if (!subLength.Contains(elem.subLength))
                {
                    subLength.Add(elem.subLength);
                }
            }
            subCountry = subCountry.OrderBy(x => x).ToList();
            subType = subType.OrderBy(x => x).ToList();
            subClass = subClass.OrderBy(x => x).ToList();
            subYear = subYear.OrderBy(x => x).ToList();
            ifSubNuclear = ifSubNuclear.OrderBy(x => x).ToList();
            subLength = subLength.OrderBy(x => x).ToList();

            countryBox.Items.AddRange(subCountry.ToArray());
            typeBox.Items.AddRange(subType.ToArray());
            classBox.Items.AddRange(subClass.ToArray());
            yearBox.Items.AddRange(subYear.ToArray());
            ifNuclearBox.Items.AddRange(ifSubNuclear.ToArray());
            lengthBox.Items.AddRange(subLength.ToArray());
        }

        private Submarine OurSearch()
        {
            string[] info = new string[7];
            if (checkBox1.Checked) info[0] = Convert.ToString(comboBox1.Text);
            if (checkBox2.Checked) info[1] = Convert.ToString(comboBox2.Text);
            if (checkBox3.Checked) info[2] = Convert.ToString(comboBox3.Text);
            if (checkBox4.Checked) info[3] = Convert.ToString(comboBox4.Text);
            if (checkBox5.Checked) info[4] = Convert.ToString(comboBox5.Text);
            if (checkBox6.Checked) info[5] = Convert.ToString(comboBox6.Text);
            Submarine idealSearch = new Submarine(info);
            return idealSearch;
        }

        private void ParsingForXML()
        {
            Submarine myTemplate = OurSearch();
            List<Submarine> res;

            if (radioButtonSAX.Checked)
            {
                IStrategy parser = new SAX();
                res = parser.AnalyzeFile(myTemplate, path);
                Output(res);
            }
            else if (radioButtonDOM.Checked)
            {
                IStrategy parser = new DOM();
                res = parser.AnalyzeFile(myTemplate, path);
                Output(res);
            }
            else if (radioButtonLINQ.Checked)
            {
                IStrategy parser = new LINQ();
                res = parser.AnalyzeFile(myTemplate, path);
                Output(res);
            }

        }

        private void Output(List<Submarine> res)
        {
            richTextBox1.Clear();
            foreach(Submarine n in res)
            {
                richTextBox1.AppendText("Країна:" + n.subCountry + "\n");
                richTextBox1.AppendText("Тип човна:" + n.subType + "\n");
                richTextBox1.AppendText("Клас човна:" + n.subClass + "\n");
                richTextBox1.AppendText("Рік прийняття на озброєння:" + n.subYear + "\n");
                richTextBox1.AppendText("Чи має атомний реактор:" + n.ifSubNuclear + "\n");
                richTextBox1.AppendText("Довжина човна:" + n.subLength + "\n");
                richTextBox1.AppendText("----------------------------\n");
            }
        }

        private void IntoHTML()
        {
            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(pathXsl);
            string input = path;
            string result = @"HTML.html";
            xsl.Transform(input, result);
            MessageBox.Show("Готово!");
        }

        private void Clear()
        {
            richTextBox1.Clear();
            radioButtonDOM.Checked = false;
            radioButtonLINQ.Checked = false;
            radioButtonSAX.Checked = false;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;
            comboBox5.Text = null;
            comboBox6.Text = null;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ParsingForXML();
        }

        private void buttonTransToHTML_Click(object sender, EventArgs e)
        {
            var openHTML = System.Diagnostics.Process.Start("HTML.html");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { comboBox1.Enabled = true; }else { comboBox1.Enabled = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { comboBox2.Enabled = true; } else { comboBox2.Enabled = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { comboBox3.Enabled = true; } else { comboBox3.Enabled = false; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { comboBox4.Enabled = true; } else { comboBox4.Enabled = false; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { comboBox5.Enabled = true; } else { comboBox5.Enabled = false; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked) { comboBox6.Enabled = true; } else { comboBox6.Enabled = false; }
        }
    }
}