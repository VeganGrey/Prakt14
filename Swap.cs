using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakt13
{
    internal class Swap
    {
        public static double[,] MatrixSwap(double[,] matr)
        {
            double[] mas = new double[matr.GetLength(1)];
            double min = matr[0,0];double max = matr[0,0];
            int kolmax=0;int kolmin=0;
            for(int i=0;i<matr.GetLength(0);i++)
            {
                for(int j=0;j<matr.GetLength(1);j++)
                {
                    if (matr[i,j] > max)
                    {
                        max = matr[i,j];
                        kolmax = i;
                    }
                }
            }
            for(int i = 0;i<matr.GetLength(0);i++)
            {
                for(int j= 0;j<matr.GetLength(1);j++)
                {
                    if (matr[i, j] < min)
                    {
                        min = matr[i, j];
                        kolmin = i;
                    }
                }
            }
            for(int i=0;i<matr.GetLength(1);i++)
            {
                mas[i] = matr[kolmin,i];
                matr[kolmin,i] = matr[kolmax,i];
                matr[kolmax, i] = mas[i];
            }
            return matr;
        }
    }
}
