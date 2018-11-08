using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuDemo.DAO
{
    class RandomNumberDAO
    {
        private static RandomNumberDAO instance;

        public static  RandomNumberDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomNumberDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        int[] CheckTrungLap(int[] data)
        {
            int[] result = new int[data.Length];
            int index = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[i] != data[j] && result.Contains(data[i]) == false)
                    {
                        result[index] = data[i];
                        index++;
                    }
                }
            }
            return result;
        }
        void CheckSoConThieu(int[] data)
        {
            int index = 0;
            //lay index tu gia tri 0
            for (int i = 0; i < 9; i++)
            {
                if (data[i] == 0)
                {
                    index = i;
                    break;
                }
            }
            for (int i = 1; i <= 9; i++)
            {
                if (data.Contains(i) == false)
                {
                    data[index] = i;
                    index++;
                }
            }

        }
        public int[] RandomOneNine()
        {
            int[] source = new int[9];
            Random rd = new Random();
            for (int i = 0; i < 9; i++)
            {
                source[i] = rd.Next(1, 9);
            }

            int[] result = CheckTrungLap(source);
            CheckSoConThieu(result);
            return result;
        }

    }
}
