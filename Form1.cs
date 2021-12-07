using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oolpab4part2
{
    public partial class Form1 : Form
    {

        Model model;
        public Form1()
        {
            InitializeComponent();

            model = new Model();
            model.observers += new EventHandler(UpdateFromModel);
        }


        private void UpdateFromModel(object sender, EventArgs e)
        {
            textBox1.Text = model.getValueA().ToString();
            numericUpDown1.Value = model.getValueA();
            trackBar1.Value = model.getValueA();

            textBox2.Text = model.getValueB().ToString();
            numericUpDown2.Value = model.getValueB();
            trackBar2.Value = model.getValueB();

            textBox3.Text = model.getValueC().ToString();
            numericUpDown3.Value = model.getValueC();
            trackBar3.Value = model.getValueC();
        }
        public class Model
        {
            private int valueA;
            private int valueB;
            private int valueC;

            public System.EventHandler observers;

            public void setValueA(int value) {
                if (value <= valueB)
                    valueA = value;
                else if (value <= valueC)
                {
                    valueA = value;
                    valueB = value;
                }
                else
                {
                    valueA = value;
                    valueB = value;
                    valueC = value;
                }
                observers.Invoke(this, null);
            }
            public void setValueB(int value) {
                if ((value >= valueA) && (value <= valueC))
                    valueB = value;
                observers.Invoke(this, null);
            }
            public void setValueC(int value) {
                if (value >= valueB)
                    valueC = value;
                else if (value >= valueA)
                {
                    valueC = value;
                    valueB = value;
                }
                else
                {
                    valueC = value;
                    valueB = value;
                    valueA = value;
                }
                observers.Invoke(this, null);
            }
            public int getValueA() { return valueA; }
            public int getValueB() { return valueB; }
            public int getValueC() { return valueC; }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.setValueA((int)numericUpDown1.Value);
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.setValueB((int)numericUpDown2.Value);
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model.setValueC((int)numericUpDown3.Value);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValueA(int.Parse(textBox1.Text));
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValueB(int.Parse(textBox2.Text));
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValueC(int.Parse(textBox3.Text));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.setValueA(trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            model.setValueB(trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            model.setValueC(trackBar3.Value);
        }
    }
}
