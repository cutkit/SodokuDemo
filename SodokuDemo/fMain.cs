using SodokuDemo.DAO;
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

namespace SodokuDemo
{
    public partial class fMain : Form
    {
        public static string sourceFile = null;
        Button[,] arrBtn;
        public fMain()
        {
            InitializeComponent();
            DisplayButton();
        }
        void DisplayButton()
        {
            if (sourceFile != null)
            {

                if (arrBtn == null)
                {
                    AddButton ab = new AddButton();
                    arrBtn = ab.CreatButton();
                }


                for (int i = 0; i < arrBtn.GetLength(0); i++)
                {
                    for (int j = 0; j < arrBtn.GetLength(1); j++)
                    {
                        pnlButton.Controls.Add(arrBtn[i, j]);
                    }
                }
            }
        }
        void ScanFile()
        {
            openFileDialog1.FileName = "Nhập file có dạng txt";
            openFileDialog1.Filter = "Txt Files|*.txt";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                sourceFile = openFileDialog1.FileName;
                sr.Close();
            }

        }
        void Solve()
        {
            AddButton ab = new AddButton();
            arrBtn = ab.SolveButton();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Solve();
            pnlButton.Controls.Clear();
            DisplayButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScanFile();
            DisplayButton();
        }
    }
}
