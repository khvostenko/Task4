using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double scalarMatrixA;
            double scalarMatrixB;

            int subMatrixCountRowA;
            int subMatrixCountColumnA;

            int subMatrixCountRowB;
            int subMatrixCountColumnB;

            Matrix A = ReadFromFile("Matrix1.txt", out scalarMatrixA, out subMatrixCountRowA, out subMatrixCountColumnA);
            Matrix B = ReadFromFile("Matrix2.txt", out scalarMatrixB, out subMatrixCountRowB, out subMatrixCountColumnB);

            Console.WriteLine("Matrix A:");
            A.DisplayMatrix();

            Console.WriteLine("Matrix B:");
            B.DisplayMatrix();

            Console.WriteLine("Matrix A+B:");
            try
            {
                (A + B).DisplayMatrix();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Matrix A-B:");
            try
            {
                (A - B).DisplayMatrix();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Matrix A*B:");
            try
            {
                (A * B).DisplayMatrix();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Matrix comparison:");
            Console.WriteLine(Matrix.Equal(A,B));

            Console.WriteLine("Transponate matrix A: ");
            Matrix.Transponate(A).DisplayMatrix();

            Console.WriteLine("Transponate matrix B: ");
            Matrix.Transponate(B).DisplayMatrix();

            Console.WriteLine("Matrix A*scalar({0}): ", scalarMatrixA);
            (A * scalarMatrixA).DisplayMatrix();

            Console.WriteLine("Sub-Matrix A {0}x{1}:", subMatrixCountRowA, subMatrixCountColumnA);
            Matrix.CreateSubMatrix(A, subMatrixCountRowA, subMatrixCountColumnA).DisplayMatrix();
            Console.ReadLine();
        }

        public static Matrix ReadFromFile(string path, out double scalar, out int subMatrixCountRow, out int subMatrixCountColumn)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                int countRow = Convert.ToInt32(sr.ReadLine());
                int countColumn = Convert.ToInt32(sr.ReadLine());

                Matrix A = new Matrix(countRow, countColumn);

                for (int i = 0; i < countRow; i++)
                {
                    string[] text = sr.ReadLine().Split(' ');
                    for (int j = 0; j < countColumn; j++)
                    {
                        A[i, j] = double.Parse(text[j]);
                    }
                }

                scalar = double.Parse(sr.ReadLine());
                subMatrixCountRow = int.Parse(sr.ReadLine());
                subMatrixCountColumn = int.Parse(sr.ReadLine());

                return A;
            }
        }
    }
}
