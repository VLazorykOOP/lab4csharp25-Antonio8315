using System;

namespace Task_3
{
    public class Task_3
    {
        class MatrixUint
        {
            // ПОЛЯ
            protected uint[,] IntArray;
            protected int n, m;
            protected int codeError;
            protected static int num_m;

            // КОНСТРУКТОРИ
            public MatrixUint()
            {
                n = 1;
                m = 1;
                IntArray = new uint[n, m];
                IntArray[0, 0] = 0;
                num_m++;
            }

            public MatrixUint(int sizeN, int sizeM)
            {
                n = sizeN;
                m = sizeM;
                IntArray = new uint[n, m];
                num_m++;
            }

            public MatrixUint(int sizeN, int sizeM, uint value)
            {
                n = sizeN;
                m = sizeM;
                IntArray = new uint[n, m];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        IntArray[i, j] = value;
                num_m++;
            }

            // Деструктор
            ~MatrixUint()
            {
                Console.WriteLine("Об'єкт MatrixUint знищено");
            }

            // МЕТОДИ

            // Введення елементів з клавіатури
            public void InputIntArray()
            {
                Console.Write("Введіть розмір матриці (n m): ");
                n = int.Parse(Console.ReadLine()!);
                m = int.Parse(Console.ReadLine()!);
                IntArray = new uint[n, m];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write($"Елемент [{i},{j}]: ");
                        IntArray[i, j] = uint.Parse(Console.ReadLine()!);
                    }
            }

            // Виведення елементів на екран
            public void PrintMatrix()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                        Console.Write(IntArray[i, j] + "\t");
                    Console.WriteLine();
                }
            }

            // Присвоює елементам масиву вектора деякого значення, яке задається як параметр
            public void ChangeMatrixByEnteredParameter(uint value)
            {
                Console.Write("Введіть параметр: ");
                uint parametr = uint.Parse(Console.ReadLine()!);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        IntArray[i, j] = parametr;
            }

            // Cтатичний метод, що підраховує кількість векторів даного типу
            public static int CountMatrices()
            {
                return num_m;
            }

            // Присвоює елементам масиву вектора деякого значення (параметр)
            public void ChangeMatrixByParameterl(uint value)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        IntArray[i, j] = value;
            }

            // ВЛАСТИВОСТІ

            // Повертають розмірність матриці (доступні лише для читання);
            public int Rows => n;
            public int Cols => m;

            // Дозволяє отримати-встановити значення поля codeError (доступні для читання і запису).
            public int CodeError
            {
                get => codeError;
                set => codeError = value;
            }

            // ІНДЕКСАТОРИ

            // З двома індексами, які відповідають індексам масиву;
            public uint this[int i, int j]
            {
                get
                {
                    if (i < 0 || j < 0 || i >= n || j >= m)
                    {
                        codeError = -1;
                        return 0;
                    }
                    return IntArray[i, j];
                }
                set
                {
                    if (i < 0 || j < 0 || i >= n || j >= m)
                        codeError = -1;
                    else
                        IntArray[i, j] = value;
                }
            }

            // З одним індексом, що дозволяє звертатися за індексом kдо двомірного масиву ( k = i*m + j); 
            public uint this[int k]
            {
                get
                {
                    int i = k / m;
                    int j = k % m;
                    return this[i, j];
                }
                set
                {
                    int i = k / m;
                    int j = k % m;
                    this[i, j] = value;
                }
            }

            //ПЕРЕВАНТАЖЕННЯ

            // Унарна операція ++
            public static MatrixUint operator ++(MatrixUint matrix)
            {
                for (int i = 0; i < matrix.n; i++)
                    for (int j = 0; j < matrix.m; j++)
                        matrix.IntArray[i, j]++;
                return matrix;
            }

            // Унарна операція --
            public static MatrixUint operator --(MatrixUint matrix)
            {
                for (int i = 0; i < matrix.n; i++)
                    for (int j = 0; j < matrix.m; j++)
                        matrix.IntArray[i, j]--;
                return matrix;
            }

            // Сталі true і false
            public static bool operator true(MatrixUint matrix)
            {
                if (matrix.n == 0 || matrix.m == 0)
                    return false;
                foreach (uint val in matrix.IntArray)
                    if (val != 0) return true;
                return false;
            }
            public static bool operator false(MatrixUint matrix)
            {
                if (matrix.n == 0 || matrix.m == 0)
                    return true;
                foreach (uint val in matrix.IntArray)
                    if (val != 0) return false;
                return true;
            }

            // Унарна логічна операція ! (заперечення)
            public static bool operator !(MatrixUint matrix)
            {
                return matrix.n == 0 || matrix.m == 0;
            }

            // Унарна побітова операція ~ (заперечення)
            public static MatrixUint operator ~(MatrixUint matrix)
            {
                MatrixUint result = new MatrixUint(matrix.n, matrix.m);
                for (int i = 0; i < matrix.n; i++)
                    for (int j = 0; j < matrix.m; j++)
                        result.IntArray[i, j] = ~matrix.IntArray[i, j];
                return result;
            }

            // АРИФМЕТИЧНІ БІНАРНІ ОПЕРАЦІЇ

            // a. + додавання:
            // i. для двох матриць
            public static MatrixUint operator +(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] + b.IntArray[i, j];
                return result;
            }

            // ii. для матриці та скаляра типу uint
            public static MatrixUint operator +(MatrixUint a, uint scalar)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] + scalar;
                return result;
            }

            // b. - (віднімання): 
            // i. для двох матриць
            public static MatrixUint operator -(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] - b.IntArray[i, j];
                return result;
            }

            // ii. для матриці та скаляра типу uint
            public static MatrixUint operator -(MatrixUint a, uint scalar)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] - scalar;
                return result;
            }

            // c. *(множення) 
            // i. для двох матриць
            public static MatrixUint operator *(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] * b.IntArray[i, j];
                return result;
            }

            // ii. для матриці та скаляра типу uint
            public static MatrixUint operator *(MatrixUint a, uint scalar)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] * scalar;
                return result;
            }

            // d. /(ділення) 
            // i. для двох матриць
            public static MatrixUint operator /(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = b.IntArray[i, j] != 0 ? a.IntArray[i, j] / b.IntArray[i, j] : 0;
                return result;
            }

            // ii. для матриці та скаляра типу uint
            public static MatrixUint operator /(MatrixUint a, uint scalar)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                if (scalar == 0) return result;
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] / scalar;
                return result;
            }

            //e. %(остача від ділення) 
            // i. для двох матриць
            public static MatrixUint operator %(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = b.IntArray[i, j] != 0 ? a.IntArray[i, j] % b.IntArray[i, j] : 0;
                return result;
            }

            // ii. для матриці та скаляра типу uint
            public static MatrixUint operator %(MatrixUint a, uint scalar)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                if (scalar == 0) return result;
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] % scalar;
                return result;
            }

            // ПОБІТОВІ БІНАРНІ ОПЕРАЦІЇ

            // a. | (побітове додавання) 
            // i. для двох матриць
            public static MatrixUint operator |(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] | b.IntArray[i, j];
                return result;
            }

            // ii. для матриці та скаляра типу uint;
            public static MatrixUint operator |(MatrixUint a, uint scalar)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] | scalar;
                return result;
            }

            // b. ^ (побітове додавання за модулем 2) 
            // i. для двох матриць
            public static MatrixUint operator ^(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] ^ b.IntArray[i, j];
                return result;
            }

            // ii. для матриці та скаляра типу uint;
            public static MatrixUint operator ^(MatrixUint a, uint scalar)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] ^ scalar;
                return result;
            }

            // c. | (побітове множення) 
            // i. двох векторів
            public static MatrixUint operator &(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] & b.IntArray[i, j];
                return result;
            }

            // ii. вектора і скаляра типу uint;
            public static MatrixUint operator &(MatrixUint a, uint scalar)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] & scalar;
                return result;
            }

            // d. >> (побітовий зсув право)
            // i. для двох матриць
            public static MatrixUint operator >>(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] >> (int)b.IntArray[i, j];
                return result;
            }

            // ii. для матриці та скаляра типу uint;
            public static MatrixUint operator >>(MatrixUint a, int shift)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] >> shift;
                return result;
            }

            // e. << (побітовий зсув ліво)
            // i. для двох матриць

            public static MatrixUint operator <<(MatrixUint a, MatrixUint b)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] << (int)b.IntArray[i, j];
                return result;
            }

            // ii. для матриці та скаляра типу uint;
            public static MatrixUint operator <<(MatrixUint a, int shift)
            {
                MatrixUint result = new MatrixUint(a.n, a.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        result.IntArray[i, j] = a.IntArray[i, j] << shift;
                return result;
            }

            // Операція == (рівність)
            public static bool operator ==(MatrixUint a, MatrixUint b)
            {
                if (a.n != b.n || a.m != b.m) return false;
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        if (a.IntArray[i, j] != b.IntArray[i, j])
                            return false;
                return true;
            }

            // Операція != (нерівність)
            public static bool operator !=(MatrixUint a, MatrixUint b) => !(a == b);

            // Equals - для == і !=
            public override bool Equals(object? obj)
            {
                if (obj is MatrixUint other)
                    return this == other;
                return false;
            }

            // GetHashCode - для == і !=
            public override int GetHashCode()
            {
                int hash = 17;
                foreach (uint val in IntArray)
                    hash = hash * 31 + val.GetHashCode();
                return hash;
            }

            // ПОРІВНЯННЯ
            // a. > (більше) для двох векторів; 
            public static bool operator >(MatrixUint a, MatrixUint b)
            {
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        if (a.IntArray[i, j] <= b.IntArray[i, j])
                            return false;
                return true;
            }

            // b. >= (більше рівне) для двох векторів;
            public static bool operator >=(MatrixUint a, MatrixUint b)
            {
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < a.m; j++)
                        if (a.IntArray[i, j] < b.IntArray[i, j])
                            return false;
                return true;
            }

            // c. < (менше) для двох векторів;
            public static bool operator <(MatrixUint a, MatrixUint b) => !(a >= b);

            // d. <=(менше рівне) для двох векторів.
            public static bool operator <=(MatrixUint a, MatrixUint b) => !(a > b);
        }

        public void main3()
        {
            MatrixUint matrix1 = new MatrixUint();
            MatrixUint matrix2 = new MatrixUint(2, 2);
            MatrixUint matrix3 = new MatrixUint(3, 3, 1);

            matrix2.InputIntArray();
            matrix2.PrintMatrix();
            Console.WriteLine("Кількість створених матриць: " + MatrixUint.CountMatrices());
        }
    }
}
