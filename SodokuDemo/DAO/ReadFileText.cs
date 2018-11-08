using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuDemo.DAO
{
    class ReadFileText
    {
        private static ReadFileText instance;

        internal static ReadFileText Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReadFileText();
                }
                return instance;
            }
            set => instance = value;
        }
        private ReadFileText()
        {

        }
        public int[,] ReadFile(string path)
        {
            int[,] arr2 = null;
            string source;
            string sourcetmp;

            string[] sourceResult;

            using (StreamReader sr = new StreamReader(path))
            {
                source = sr.ReadToEnd();
            }
            sourcetmp = source.Replace("\r\n", " ");// remove end line
            sourceResult = sourcetmp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            
            arr2 = new int[sourceResult.Length / 9, sourceResult.Length / 9];
            int count = 0;
            for (int i = 0; i < sourceResult.Length/9; i++)
            {
                for (int j = 0; j < sourceResult.Length/9; j++)
                {
                    if (count < sourceResult.Length)
                    {
                        arr2[i, j] = int.Parse(sourceResult[count]);
                        count++;
                    }
                }
            }
            return arr2;
        }
    }
}
