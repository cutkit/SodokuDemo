using SodokuDemo.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuDemo.DAO
{
    class SodokuDAO
    {
        int[,] Grid;
       
        public SodokuDAO(int[,] grid)
        {
            this.Grid = grid;
        }

        internal Point FindPosition()
        {
            Point point = new Point(-1, -1);
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (Grid[y,x] == 0)
                    {
                        point.Y = y;
                        point.X = x;
                        return point;
                    }
                }
            }
            return point;
            
        }   

        internal bool IsSafe(Point point)
        {
            int value = Grid[point.Y, point.X];
            int x = point.X;
            int y = point.Y;
            for (int i = 0; i < 9; i++)
            {
                if (x != i && Grid[y, i] == value)
                {
                    return false;
                }
                if (y != i && Grid[i, x] == value)
                {
                    return false;
                }
            }
            int Ay = y / 3 * 3;
            int Ax = x / 3 * 3;
            for (int i = Ay; i < Ay + 3; i++)
            {
                for (int j = Ax; j < Ax + 3; j++)
                {
                    if (y != i && x != j && Grid[y,x] == Grid[i,j] )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        internal bool IsEnd()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    if (Grid[i,j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        internal bool BackTrack(Point point)
        {
            int[] arrNumber = RandomNumberDAO.Instance.RandomOneNine();
            if (IsEnd())
            {
                return true;
            }
            else
            {
                //for (int x = 1; x <= 9; x++)
                //{
                //    Grid[point.Y, point.X] = x;
                //    if (IsSafe(point))
                //    {
                //        if (BackTrack(FindPosition()))
                //        {
                //            return true;
                //        }
                //    }
                //}
                foreach (int item in arrNumber)
                {
                    Grid[point.Y, point.X] = item;
                    if (IsSafe(point))
                    {
                        if (BackTrack(FindPosition()))
                        {
                            return true;
                        }
                    }
                }
                Grid[point.Y, point.X] = 0;
            }
            return false;
        }
    }
}

