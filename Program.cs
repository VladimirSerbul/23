using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main()
        {
            int n = 0;
            string s1 = "";
            string s2 = "";
            
            try
            {
                Console.WriteLine("ведите размерность матрицы");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 1)
                {
                    throw new Exception("некорректно введена размерность массива");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                p();
                return;
            }
            int[,] array = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rnd.Next(1,101);
                }
            }
            Console.WriteLine("исходная матрица");
            for (int i = 0; i <n; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    Console.Write("{0,4}",array[i, j]);
                }
                Console.WriteLine();
            }
            try
            {
                Console.WriteLine("выберите как производить сортировку если по возрастанию то написать 1  если по убыванию то написать 2");
                s1 = Convert.ToString(Console.ReadLine());
                if (s1 != "1" && s1 != "2")
                {
                    throw new Exception("некорректно введены данные");
                    
                }
                Console.WriteLine("выберите то как будем проихводить сортировку если по строкам то нажмите 1 а если по столбцам то нажмите 2");
                s2 = Convert.ToString(Console.ReadLine());
                if (s2 != "1" && s2 != "2")
                {
                    throw new Exception("некорректно введены данные");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                p();
                return;
            }

            if (s2 == "1")
            {
                if (s1 == "1")
                {
                    SortMatrixByRows(array, true);
                }
                else
                {
                    SortMatrixByRows(array, false);
                }
            }
            else
            {
                if (s1 == "1")
                {
                    SortMatrixByColumns(array, true);
                }
                else
                {
                    SortMatrixByColumns(array, false);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
            void p()
            {
                Console.WriteLine("повторить ввод если да то 1 нет то 0");
                string y = Convert.ToString(Console.ReadLine());
                if (y == "1")
                    Main();
                else
                    return;
            }
            p();
            return;
        }
        
           
       
        static void SortMatrixByRows(int[,] matrix, bool flag)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    for (int k = j + 1; k < matrix.GetLength(1); k++)
                    {
                        if ((flag && matrix[i, j] > matrix[i, k]) || (!flag && matrix[i, j] < matrix[i, k]))
                        {
                            int a = matrix[i, j];
                            matrix[i, j] = matrix[i, k];
                            matrix[i, k] = a;
                        }
                    }
                }
            }
        }
        static void SortMatrixByColumns(int[,] matrix, bool flag)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int k = i + 1; k < matrix.GetLength(0); k++)
                    {
                        if ((flag && matrix[i, j] > matrix[k, j]) || (!flag && matrix[i, j] < matrix[k, j]))
                        {
                            int a = matrix[i, j];
                            matrix[i, j] = matrix[k, j];
                            matrix[k, j] = a;
                        }
                    }
                }
            }
        }
        
    }
}