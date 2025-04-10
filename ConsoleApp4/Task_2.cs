using System;
using System.Linq.Expressions;
using System.Security.Cryptography;
namespace Task_2
{
    public class Task_2
    {
        class VectorUInt
        {
            protected uint[] IntArray; // масив
            protected uint size; // розмір вектора
            protected int codeError; // код помилки
            protected static uint num_vec; // кількість векторів

            // КОНСТРУКТОРИ
            public VectorUInt()
            {
                size = 1;
                IntArray = new uint[size];
                IntArray[0] = 0;
                num_vec++;
            }

            public VectorUInt(uint sizeV)
            {
                size = sizeV;
                IntArray = new uint[size];
                for (int i = 0; i < size; i++)
                {
                    IntArray[i] = 0;
                }
                num_vec++;
            }

            public VectorUInt(uint sizeV, uint value)
            {
                size = sizeV;
                IntArray = new uint[size];
                for (int i = 0; i < size; i++)
                {
                    IntArray[i] = value;
                }
                num_vec++;
            }

            // Спеціальний конструктор. Створює пустий вектор із size = 0. Потрібен для перевантяження True / False
            public VectorUInt(uint p1, uint p2, uint p3)
            {
                size = 0;
                IntArray = new uint[size];
                num_vec++;
            }
            // Деструктор
            ~VectorUInt()
            {
                Console.WriteLine("Об'єкт VectorUInt знищено");
            }

            //МЕТОДИ

            // Введення елементів з клавіатури
            public void InputIntArray()
            {
                Console.Write("Введіть розмір масиву: ");
                uint size = uint.Parse(Console.ReadLine()!);
                IntArray = new uint[size];
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Елемент {i}: ");
                    IntArray[i] = uint.Parse(Console.ReadLine()!);
                }
            }

            // Виведення елементів на екран
            public void PrintArray()
            {
                Console.WriteLine("Вміст вектора:");
                for (int i = 0; i < IntArray.Length; i++)
                {
                    Console.Write(IntArray[i] + " ");
                }
                Console.WriteLine();
            }

            // Присвоює елементам масиву вектора деякого значення, яке задається як параметр
            public void ChangeArrayByEnteredParameter()
            {
                Console.Write("Введіть параметр: ");
                uint parametr = uint.Parse(Console.ReadLine()!);
                for (int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] = parametr;
                }
            }

            // Cтатичний метод, що підраховує кількість векторів даного типу
            public uint NumOfVectors()
            {
                return num_vec;
            }

            // Присвоює елементам масиву вектора деякого значення (параметр)
            public void ChangeArrayByParameter(uint parametr)
            {
                for (int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] = parametr;
                }
            }

            // Перевіряє, чи у масиві всі елементи == 0 (для перевантаження сталих true / false)
            public bool ElementsIsZero()
            {
                bool fullZero = true;
                for (int i = 0; i < IntArray.Length; i++)
                {
                    if (IntArray[i] != 0)
                    {
                        fullZero = false;
                    }
                }
                return fullZero;
            }

            // ВЛАСТИВОСТІ

            // Повертає розмірність вектора (доступні лише для читання);
            public int VlNumOfVectors
            {
                get { return IntArray.Length; }
            }

            // дозволяє отримати-встановити значення поля codeError (доступні для читання і запису)
            public int VlCodeOfError
            {
                get { return codeError; }
                set { codeError = value; }
            }

            // ІНДЕКСАТОР
            public uint this[int index]
            {
                get
                {
                    if (index >= 0 && index < IntArray.Length)
                    {
                        codeError = 0;
                        return IntArray[index];
                    }
                    else
                    {
                        codeError = 1;
                        return 0;
                    }
                }
                set
                {
                    if (index >= 0 && index < IntArray.Length)
                    {
                        codeError = 0;
                        IntArray[index] = value;
                    }
                    else
                    {
                        codeError = 1;
                    }
                }
            }

            // ПЕРЕВАНТАЖЕННЯ

            // Оператор ++
            public static VectorUInt operator ++(VectorUInt v)
            {
                for (int i = 0; i < v.size; i++)
                {
                    v.IntArray[i]++;
                }
                return v;
            }

            // Оператор --
            public static VectorUInt operator --(VectorUInt v)
            {
                for (int i = 0; i < v.size; i++)
                {
                    v.IntArray[i]--;
                }
                return v;
            }

            // Оператори true / false
            public static bool operator true(VectorUInt v)
            {
                return v.size == 0 || v.ElementsIsZero();
            }
            public static bool operator false(VectorUInt v)
            {
                return v.size != 0 || !v.ElementsIsZero();
            }

            // Оператор заперечення "!"
            public static bool operator !(VectorUInt v)
            {
                return v.size != 0;
            }

            // Унарна побітова операція ~
            public static VectorUInt operator ~(VectorUInt v)
            {
                VectorUInt result = new VectorUInt(v.size);
                for (int i = 0; i < v.size; i++)
                {
                    result.IntArray[i] = ~v.IntArray[i];
                }
                return result;
            }

            // АРИФМЕТИЧНІ БІНАРНІ ОПЕРАЦІЇ
            // a. + додавання:
            // i. для двох векторів
            public static VectorUInt operator +(VectorUInt v1, VectorUInt v2)
            {
                uint minSize = Math.Min(v1.size, v2.size);
                VectorUInt result = new VectorUInt(minSize);
                for (int i = 0; i < minSize; i++)
                {
                    result.IntArray[i] = v1.IntArray[i] + v2.IntArray[i];
                }
                return result;
            }

            // ii. для вектора і скаляра типу int
            public static VectorUInt operator +(VectorUInt v, int scalar)
            {
                VectorUInt result = new VectorUInt(v.size);
                for (int i = 0; i < v.size; i++)
                {
                    result.IntArray[i] = v.IntArray[i] + (uint)scalar;
                }
                return result;
            }

            // b. - (віднімання): 
            // i.для двох векторів
            public static VectorUInt operator -(VectorUInt v1, VectorUInt v2)
            {
                uint minSize = Math.Min(v1.size, v2.size);
                VectorUInt result = new VectorUInt(minSize);
                for (int i = 0; i < minSize; i++)
                {
                    uint val1 = v1.IntArray[i];
                    uint val2 = v2.IntArray[i];
                    result.IntArray[i] = val1 > val2 ? val1 - val2 : 0; // щоб уникнути переповнення
                }
                return result;
            }

            // ii. для вектора і скаляра типу int;
            public static VectorUInt operator -(VectorUInt v, int scalar)
            {
                VectorUInt result = new VectorUInt(v.size);
                for (int i = 0; i < v.size; i++)
                {
                    uint val = v.IntArray[i];
                    result.IntArray[i] = val > scalar ? val - (uint)scalar : 0;
                }
                return result;
            }

            // c. *(множення) 
            // i. для двох векторів
            public static VectorUInt operator *(VectorUInt a, VectorUInt b)
            {
                uint minSize = Math.Min(a.size, b.size);
                VectorUInt result = new VectorUInt(minSize);
                for (int i = 0; i < minSize; i++)
                {
                    result.IntArray[i] = a.IntArray[i] * b.IntArray[i];
                }
                return result;
            }

            // ii. для вектора і скаляра типу int;
            public static VectorUInt operator *(VectorUInt a, int scalar)
            {
                VectorUInt result = new VectorUInt(a.size);
                for (int i = 0; i < a.size; i++)
                {
                    result.IntArray[i] = (uint)(a.IntArray[i] * scalar);
                }
                return result;
            }

            // d. / (ділення) 
            // i. для двох векторів
            public static VectorUInt operator /(VectorUInt a, VectorUInt b)
            {
                uint minSize = Math.Min(a.size, b.size);
                VectorUInt result = new VectorUInt(minSize);
                for (int i = 0; i < minSize; i++)
                {
                    result.IntArray[i] = b.IntArray[i] != 0 ? a.IntArray[i] / b.IntArray[i] : 0;
                }
                return result;
            }

            // ii. для вектора і скаляра типу short;
            public static VectorUInt operator /(VectorUInt a, short scalar)
            {
                VectorUInt result = new VectorUInt(a.size);
                for (int i = 0; i < a.size; i++)
                {
                    result.IntArray[i] = scalar != 0 ? a.IntArray[i] / (uint)scalar : 0;
                }
                return result;
            }

            // e. % (остача від ділення) 
            // i. для двох векторів
            public static VectorUInt operator %(VectorUInt a, VectorUInt b)
            {
                uint minSize = Math.Min(a.size, b.size);
                VectorUInt result = new VectorUInt(minSize);
                for (int i = 0; i < minSize; i++)
                {
                    result.IntArray[i] = b.IntArray[i] != 0 ? a.IntArray[i] % b.IntArray[i] : 0;
                }
                return result;
            }

            // ii. для вектора і скаляра типу short;
            public static VectorUInt operator %(VectorUInt a, short scalar)
            {
                VectorUInt result = new VectorUInt(a.size);
                for (int i = 0; i < a.size; i++)
                {
                    result.IntArray[i] = scalar != 0 ? a.IntArray[i] % (uint)scalar : 0;
                }
                return result;
            }

            // ПОБІТОВІ БІНАРНІ ОПЕРАЦІЇ
            // a. | (побітове додавання) 
            // i. для двох векторів
            public static VectorUInt operator |(VectorUInt v1, VectorUInt v2)
            {
                VectorUInt result = new VectorUInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                    result.IntArray[i] = v1.IntArray[i] | v2.IntArray[i];
                return result;
            }

            // ii. для вектора і скаляра типу uint;
            public static VectorUInt operator |(VectorUInt v, uint val)
            {
                VectorUInt result = new VectorUInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                    result.IntArray[i] = v.IntArray[i] | val;
                return result;
            }

            // b. ^ (побітове додавання за модулем 2) 
            // i. для двох векторів
            public static VectorUInt operator ^(VectorUInt v1, VectorUInt v2)
            {
                VectorUInt result = new VectorUInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                    result.IntArray[i] = v1.IntArray[i] ^ v2.IntArray[i];
                return result;
            }

            // ii. для вектора і скаляра типу uint;
            public static VectorUInt operator ^(VectorUInt v, uint val)
            {
                VectorUInt result = new VectorUInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                    result.IntArray[i] = v.IntArray[i] ^ val;
                return result;
            }

            // c. | (побітове множення), Так вже позначав, тому "&" 
            // i. двох векторів
            public static VectorUInt operator &(VectorUInt v1, VectorUInt v2)
            {
                VectorUInt result = new VectorUInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                    result.IntArray[i] = v1.IntArray[i] & v2.IntArray[i];
                return result;
            }

            // ii. вектора і скаляра типу uint
            public static VectorUInt operator &(VectorUInt v, uint val)
            {
                VectorUInt result = new VectorUInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                    result.IntArray[i] = v.IntArray[i] & val;
                return result;
            }

            // d. >> (побітовий зсув право)
            // i. для двох векторів
            public static VectorUInt operator >>(VectorUInt v1, VectorUInt v2)
            {
                VectorUInt result = new VectorUInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                    result.IntArray[i] = v1.IntArray[i] >> (int)v2.IntArray[i];
                return result;
            }

            // ii. для вектора і скаляра типу uint;
            public static VectorUInt operator >>(VectorUInt v, uint val)
            {
                VectorUInt result = new VectorUInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                    result.IntArray[i] = v.IntArray[i] >> (int)val;
                return result;
            }

            // e. << (побітовий зсув ліво)
            // i. для двох векторів
            public static VectorUInt operator <<(VectorUInt v1, VectorUInt v2)
            {
                VectorUInt result = new VectorUInt((uint)v1.IntArray.Length);
                for (int i = 0; i < v1.IntArray.Length; i++)
                    result.IntArray[i] = v1.IntArray[i] << (int)v2.IntArray[i];
                return result;
            }

            // ii. для вектора і скаляра типу uint;
            public static VectorUInt operator <<(VectorUInt v, uint val)
            {
                VectorUInt result = new VectorUInt((uint)v.IntArray.Length);
                for (int i = 0; i < v.IntArray.Length; i++)
                    result.IntArray[i] = v.IntArray[i] << (int)val;
                return result;
            }

            // Операція == (рівність)
            public static bool operator ==(VectorUInt v1, VectorUInt v2)
            {
                if (v1.IntArray.Length != v2.IntArray.Length) return false;

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] != v2.IntArray[i])
                        return false;
                }
                return true;
            }

            // Операція != (нерівність)
            public static bool operator !=(VectorUInt v1, VectorUInt v2)
            {
                return !(v1 == v2);
            }

            // Equals - для == і !=
            public override bool Equals(object? obj)
            {
                if (obj is VectorUInt other)
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
            public static bool operator >(VectorUInt v1, VectorUInt v2)
            {
                if (v1.IntArray.Length != v2.IntArray.Length) throw new ArgumentException("Вектори повинні бути однакової довжини.");

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] <= v2.IntArray[i]) return false; // Якщо є хоча б одне менше або рівне, повертаємо false
                }
                return true;
            }

            // b. >= (більше рівне) для двох векторів;
            public static bool operator >=(VectorUInt v1, VectorUInt v2)
            {
                if (v1.IntArray.Length != v2.IntArray.Length) throw new ArgumentException("Вектори повинні бути однакової довжини.");

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] < v2.IntArray[i]) return false; // Якщо є хоча б одне менше, повертаємо false
                }
                return true;
            }

            // c. < (менше) для двох векторів;
            public static bool operator <(VectorUInt v1, VectorUInt v2)
            {
                if (v1.IntArray.Length != v2.IntArray.Length) throw new ArgumentException("Вектори повинні бути однакової довжини.");

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] >= v2.IntArray[i]) return false; // Якщо є хоча б одне більше або рівне, повертаємо false
                }
                return true;
            }

            // d. <=(менше рівне) для двох векторів.
            public static bool operator <=(VectorUInt v1, VectorUInt v2)
            {
                if (v1.IntArray.Length != v2.IntArray.Length) throw new ArgumentException("Вектори повинні бути однакової довжини.");

                for (int i = 0; i < v1.IntArray.Length; i++)
                {
                    if (v1.IntArray[i] > v2.IntArray[i]) return false; // Якщо є хоча б одне більше, повертаємо false
                }
                return true;
            }
        }
        public void main2()
        {
            VectorUInt vector1 = new VectorUInt();
            VectorUInt vector2 = new VectorUInt(5);
            VectorUInt vector3 = new VectorUInt(5, 1);
            VectorUInt vector4 = new VectorUInt(6);
            VectorUInt vector5 = new VectorUInt(3, 3);
            VectorUInt vector6 = new VectorUInt(0, 0, 0); // Пустий
            VectorUInt vector7 = new VectorUInt(4); // Складається з нулів

            // Для бінарних операцій
            VectorUInt vector8 = new VectorUInt(3, 4);
            VectorUInt vector9 = new VectorUInt(3, 8);

            // МЕТОДИ
            // Введення елементів з клавіатури
            vector1.InputIntArray();

            // Виведення елементів на екран
            vector1.PrintArray();

            // Присвоєння елементам масиву вектора деякого значення, яке задається як параметр
            vector2.ChangeArrayByEnteredParameter();
            vector2.PrintArray();

            // Підрахування кількості векторів даного типу
            Console.WriteLine(vector3.NumOfVectors());

            // Присвоєння елементам масиву вектора деякого значення (параметр)
            vector3.ChangeArrayByParameter(9);
            vector3.PrintArray();

            // ВЛАСТИВОСТІ
            // повернення розмірності вектора
            Console.WriteLine(vector3.VlNumOfVectors);

            // Отримання-встановлення значення поля codeError
            vector4.VlCodeOfError = 404;
            Console.WriteLine(vector4.VlCodeOfError);

            //Звернення до масиву за допомогою індексатора
            Console.WriteLine(vector5[0]);
            Console.WriteLine(vector5[1]);
            Console.WriteLine(vector5[2]);
            Console.WriteLine(vector5[3]); // Помилка (0)
            vector5[0] = 10;
            vector5[1] = 11;
            vector5[2] = 12;
            vector5[3] = 13; // Помилка (запис в codeError)
            vector5.PrintArray();

            // ПЕРЕВАНТАЖЕННЯ
            // Оператори ++ / --
            vector5++;
            vector5.PrintArray();
            vector5--;
            vector5.PrintArray();

            // Перевірка сталих True / False
            if (vector5)
            {
                Console.WriteLine("Вектор пустий, або складається з нулів!");
            }
            else
            {
                Console.WriteLine("Вектор не пустий і не з нулів!");
            }
            if (vector6)
            {
                Console.WriteLine("Вектор пустий, або складається з нулів!");
            }
            else
            {
                Console.WriteLine("Вектор не пустий і не з нулів!");
            }
            if (vector7)
            {
                Console.WriteLine("Вектор пустий, або складається з нулів!");
            }
            else
            {
                Console.WriteLine("Вектор не пустий і не з нулів!");
            }

            // Унарна логічна операція ! "заперечення"
            if (!vector6){
                Console.WriteLine("Вектор не пустий (size != 0)");
            }
            else{
                Console.WriteLine("Вектор пустий (size == 0)");
            }
            if (!vector7){
                Console.WriteLine("Вектор не пустий (size != 0)");
            }
            else{
                Console.WriteLine("Вектор пустий (size == 0)");
            }

            // Унарна побітова операція ~ "заперечення"
            VectorUInt inverted = ~vector3;
            inverted.PrintArray(); 

            // АРИФМЕТИЧНІ БІНАРНІ ОПЕРАЦІЇ
            // a. + додавання:
            // i. для двох векторів
            VectorUInt sumVec = vector8 + vector9;
            Console.WriteLine("Сума векторів: ");
            sumVec.PrintArray();

            // ii. для вектора і скаляра типу int
            VectorUInt addScalar = vector8 + 5;
            Console.WriteLine("Вектор + 5:");
            addScalar.PrintArray();

            // b. - (віднімання): 
            // i. для двох векторів
            VectorUInt diffVec = vector9 - vector8;
            Console.WriteLine("Різниця векторів:");
            diffVec.PrintArray();

            // ii. для вектора і скаляра типу int;
            VectorUInt subScalar = vector8 - 2;
            Console.WriteLine("Вектор - 10:");
            subScalar.PrintArray();

            // c. *(множення)
            // i. для двох векторів
            VectorUInt mulVec = vector8 * vector9;
            Console.WriteLine("vector8 * vector9:");
            mulVec.PrintArray();

            // ii. для вектора і скаляра типу int;
            VectorUInt mulScalar = vector8 * 3;
            Console.WriteLine("vector8 * 3:");
            mulScalar.PrintArray();

            // d. / (ділення) 
            // i. для двох векторів
            VectorUInt divVec = vector9 / vector8;
            Console.WriteLine("vector8 / vector9:");
            divVec.PrintArray();

            // ii. для вектора і скаляра типу short;
            VectorUInt divScalar = vector8 / (short)3;
            Console.WriteLine("vector8 / 3:");
            divScalar.PrintArray();

            // e. % (остача від ділення) 
            // i. для двох векторів
            VectorUInt modVec = vector9 % vector8;
            Console.WriteLine("vector9 % vector8:");
            modVec.PrintArray();

            // ii. для вектора і скаляра типу short;
            VectorUInt modScalar = vector8 % (short)4;
            Console.WriteLine("vector8 % 4:");
            modScalar.PrintArray();

            // ПОБІТОВІ БІНАРНІ ОПЕРАЦІЇ
            // a. | (побітове додавання) 
            // i. для двох векторів
            VectorUInt bitOr = vector8 | vector9;
            Console.WriteLine("vector8 | vector9:");
            bitOr.PrintArray();

            // ii. для вектора і скаляра типу uint;
            VectorUInt bitOrScalar = vector8 | 2;
            Console.WriteLine("vector8 | 2:");
            bitOrScalar.PrintArray();

            // b. ^ (побітове додавання за модулем 2) 
            // i. для двох векторів
            VectorUInt bitXor = vector8 ^ vector9;
            Console.WriteLine("vector8 ^ vector9:");
            bitXor.PrintArray();

            // ii. для вектора і скаляра типу uint;
            VectorUInt bitXorScalar = vector8 ^ 2;
            Console.WriteLine("vector8 ^ 2:");
            bitXorScalar.PrintArray();

            // c. & (побітове множення) 
            // i. двох векторів
            VectorUInt bitAnd = vector8 & vector9;
            Console.WriteLine("vector8 & vector9:");
            bitAnd.PrintArray();

            // ii. вектора і скаляра типу uint;
            VectorUInt bitAndScalar = vector8 & 3;
            Console.WriteLine("vector8 & 3:");
            bitAndScalar.PrintArray();

            // d. >> (побітовий зсув право)
            // i. для двох векторів
            VectorUInt shiftRight = vector8 >> vector9;
            Console.WriteLine("vector8 >> vector9:");
            shiftRight.PrintArray();

            // ii. вектора і скаляра типу uint;
            VectorUInt shiftRightScalar = vector8 >> 1;
            Console.WriteLine("vector8 >> 1:");
            shiftRightScalar.PrintArray();

            // e. << (побітовий зсув ліво)
            // i. для двох векторів
            VectorUInt shiftLeft = vector8 << vector9;
            Console.WriteLine("vector8 << vector9:");
            shiftLeft.PrintArray();

            // ii. вектора і скаляра типу uint;
            VectorUInt shiftLeftScalar = vector8 << 1;
            Console.WriteLine("vector8 << 1:");
            shiftLeftScalar.PrintArray();

            // Операції == та !=
            Console.WriteLine(vector8 == vector9);
            Console.WriteLine(vector8 != vector9);

            // Порівняння
            // a. > (більше) для двох векторів; 
            Console.WriteLine("vector8 > vector9?");
            Console.WriteLine(vector8 > vector9);

            // b. >= (більше рівне) для двох векторів;
            Console.WriteLine("vector8 >= vector9?");
            Console.WriteLine(vector8 >= vector9);

            // c. < (менше) для двох векторів;
            Console.WriteLine("vector8 < vector9?");
            Console.WriteLine(vector8 < vector9);

            // d. <=(менше рівне) для двох векторів.
            Console.WriteLine("vector8 <= vector9?");
            Console.WriteLine(vector8 <= vector9);
        }
    }
}