using System;

namespace Task4
{
    class Matrix
    {
        private int countRow;
        private int countColumn;
        private double[,] _matrix;

        public Matrix()
        {
            countRow = 0;
            countColumn = 0;
            _matrix = null;
        }

        public Matrix(int countRow, int countColumn)
        {
            this.countRow = countRow;
            this.countColumn = countColumn;
            _matrix = new double[countRow, countColumn];
            
        }

        public double this[int i, int j]
        {
            get
            {
                if ((i < countRow && i >= 0) && (j < countColumn && j >= 0))
                {
                    return _matrix[i, j];
                }
                else
                {
                    throw new Exception();
                }
            }
            set
            {
                if ((i < countRow && i >= 0) && (j < countColumn && j >= 0))
                {
                    _matrix[i, j] = value;
                }
                else
                {
                    _matrix[i, j] = 0;
                }
            }
        }

        public int GetRow
        {
            get
            {
                return countRow;
            }
            set
            {
                if(countRow>0)
                {
                    countRow = value;
                }
                else
                {
                    countRow = 0;
                }
            }
        }

        public int GetColumn
        {
            get
            {
                return countColumn;
            }
            set
            {
                if (countColumn > 0)
                {
                    countColumn = value;
                }
                else
                {
                    countColumn = 0;
                }
            }
        }

        public void DisplayMatrix()
        {
            for (int i = 0; i < countRow; i++)
            {
                for (int j = 0; j < countColumn; j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.countRow == B.countRow && A.countColumn == B.countColumn)
            {
                Matrix C = new Matrix(A.GetRow, A.GetColumn);
                for (int i = 0; i < A.countRow; i++)
                {
                    for (int j = 0; j < A.countColumn; j++)
                    {
                        C[i, j] = A[i, j] + B[i, j];
                    }
                }

                return C;
            }

            else
            {
                throw new InvalidOperationException();
            }
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.countRow == B.countRow && A.countColumn == B.countColumn)
            {
                Matrix C = new Matrix(A.GetRow, A.GetColumn);
                for (int i = 0; i < A.countRow; i++)
                {
                    for (int j = 0; j < A.countColumn; j++)
                    {
                        C._matrix[i, j] = A._matrix[i, j] - B._matrix[i, j];
                    }
                }
                return C;
            }

            else
            {
                throw new InvalidOperationException();
            } 
        }

        public static Matrix operator *(Matrix A, double scalar)
        {
            Matrix C = new Matrix(A.GetRow, A.GetColumn);

            for (int i = 0; i < A.countRow; i++)
            {
                for (int j = 0; j < A.countColumn; j++)
                {
                    C._matrix[i, j] = A._matrix[i, j] * scalar;
                }
            }
            return C;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.countRow == B.countColumn && A.countColumn == B.countRow) 
            {
                Matrix C = new Matrix(A.GetRow, A.GetRow);

                for (int i = 0; i < A.countRow; i++)
                {
                    for (int j = 0; j < A.countRow; j++)
                    {
                        for (int h = 0; h < A.countColumn; h++)
                        {
                            C[i, j] += A[i, h] * B[h, j];
                        }
                    }
                }

                return C;
            }
            
            else
            {
                throw new InvalidOperationException();
            }
        }

        public static Matrix Transponate(Matrix A)
        {
            Matrix C = new Matrix(A.GetColumn, A.GetRow);

            for (int i = 0; i < A.countRow; i++)
            {
                for (int j = 0; j < A.countColumn; j++)
                {
                    C._matrix[j, i] = A._matrix[i, j];
                }
            }
            return C;
        }

        public static bool Equal(Matrix A, Matrix B)
        {
            if (A.countRow != B.countRow || A.countColumn != B.countColumn)
            {
                return false;
            }

            else
            {
                for (int i = 0; i < A.countRow; i++)
                {
                    for (int j = 0; j < A.countColumn; j++)
                    {
                        if (A._matrix[i, j] != B._matrix[i, j]) 
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static Matrix CreateSubMatrix(Matrix A,int numberRow, int numberColumn)
        {
            if(numberRow<A.countRow && numberColumn<A.countColumn)
            {
                Matrix C = new Matrix(numberRow, numberColumn);

                for(int i=0;i<numberRow;i++)
                {
                    for(int j=0;j<numberColumn;j++)
                    {
                        C[i, j] = A[i, j];
                    }
                }
                return C;
            }

            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
