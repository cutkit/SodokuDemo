using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SodokuDemo.DAO
{
    enum Size
    {
        HeightSodu = 9,
        widthSodu = 9,

        LocationX =0,
        LocationY =0,
        
        WidthButton = 50,
        heighButton = 50

    }
    class AddButton
    {
        int[,] arrNumber = ReadFileText.Instance.ReadFile(fMain.sourceFile);
        Button[,] arrSodu = new Button[(int)Size.widthSodu, (int)Size.HeightSodu];
        Button btn;
        public Button[,] CreatButton()
        {
            //string sourceFile = @"./data/data.txt";
            
            //arrNumber = ReadFileText.Instance.ReadFile(sourceFile);
            //set Location
            int x = 0;
            int y = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn = new Button();
                    btn.Height = (int)Size.heighButton;
                    btn.Width = (int)Size.WidthButton;

                    if (j == 0)
                    {
                        btn.Location = new System.Drawing.Point(x, y);
                    }
                    else
                    {
                        x = arrSodu[i, j - 1].Location.X;
                        btn.Location = new System.Drawing.Point(x += (int)Size.WidthButton, y);
                    }
                    btn.BackColor = Color.PowderBlue;
                    btn.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (arrNumber[i,j] != 0)
                    {
                        btn.Text = arrNumber[i, j].ToString();
                    }
                    
                    arrSodu[i, j] = btn;
                }
                y += (int)Size.heighButton;
                x = 0;
            }
            return arrSodu;
        }
        public Button[,] SolveButton()
        {
            //string sourceFile = @"./data/data.txt";
            string sourceFile = fMain.sourceFile;
            //arrNumber = ReadFileText.Instance.ReadFile(sourceFile);
            SodokuDAO sodokuDAO = new SodokuDAO(arrNumber);
            sodokuDAO.BackTrack(sodokuDAO.FindPosition());
            //set Location
            int x = 0;
            int y = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn = new Button();
                    btn.Height = (int)Size.heighButton;
                    btn.Width = (int)Size.WidthButton;

                    if (j == 0)
                    {
                        btn.Location = new System.Drawing.Point(x, y);
                    }
                    else
                    {
                        x = arrSodu[i, j - 1].Location.X;
                        btn.Location = new System.Drawing.Point(x += (int)Size.WidthButton, y);
                    }
                    btn.BackColor = Color.PowderBlue;
                    btn.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                   
                        btn.Text = arrNumber[i, j].ToString();
                    

                    arrSodu[i, j] = btn;
                }
                y += (int)Size.heighButton;
                x = 0;
            }
            return arrSodu;
        }

    }
}
