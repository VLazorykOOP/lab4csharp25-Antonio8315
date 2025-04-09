using System;
using System.Security.Cryptography;
namespace Task_1
{
public class Task_1
{
    class Triangle
        {
            protected int a, b, c;
            protected string color;

            // Конструктор, що дозволяє створити екземпляр класу з заданими довжинами сторін
            public Triangle(int a1, int b1, int c1, string color1){
                if (IsValidTriangle(a1, b1, c1))
                {
                a = a1;
                b = b1;
                c = c1;
                color = color1;
                }
                else
                {
                    throw new ArgumentException("Неможливо створити трикутник з такими сторонами!");
                }
            }

            //МЕТОДИ

            // Виводить довжини сторін трикутника
            public string GetSides(){
                return $"Сторони трикутника: a = {a}, b = {b}, c = {c}";
            }
            
            // Виводить периметр
            public int GetPerimetr(){
                return a + b + c;
            }

            //Виводить площу
            public float GetArea(){
                return (float)Math.Sqrt(GetPerimetr()/2 * (GetPerimetr()/2 - a) * (GetPerimetr()/2 - b) * (GetPerimetr()/2 - c));
            }
            
            // Метод перевірки існування трикутника
            private bool IsValidTriangle(int a, int b, int c)
            {
                return a + b > c && a + c > b && b + c > a;
            }

            // Метод для виводу інформації про трикутник
            public string GetInfo()
            {
                return $"Сторони трикутника: a = {a}, b = {b}, c = {c}, Колір: {color}";
            }

            // ВЛАСТИВОСТІ
            
            // Властивості для отримання та встановлення довжин сторін
            public int A
            {
                get { return a; }
                set { if (IsValidTriangle(value, b, c)) a = value; }
            }

            public int B
            {
                get { return b; }
                set { if (IsValidTriangle(a, value, c)) b = value; }
            }

            public int C
            {
                get { return c; }
                set { if (IsValidTriangle(a, b, value)) c = value; }
            }

            // Властивість для отримання кольору (тільки для читання)
            public string Color => color;

            /* ПОЧАТОК 4-Ї ЛАБОРАТОРНОЇ */
            // Індексатор
            public object this[int index]
            {
                get
                {
                    return index switch
                    {
                        0 => a,
                        1 => b,
                        2 => c,
                        3 => color,
                        _ => "ERROR, incorrect index",
                    };
                }
            }
            
            // Оператор ++
            public static Triangle operator ++(Triangle t)
            {
                return new Triangle(t.a + 1, t.b + 1, t.c + 1, t.color);
            }

            // Оператор --
            public static Triangle operator --(Triangle t)
            {
                return new Triangle(t.a - 1, t.b - 1, t.c - 1, t.color);
            }

            // Оператори true / false
            public static bool operator true(Triangle t)
            {
                return t.IsValidTriangle(t.a, t.b, t.c);
            }
            public static bool operator false(Triangle t)
            {
                return !t.IsValidTriangle(t.a, t.b, t.c);
            }

            // Множення сторін на скаляр
            public static Triangle operator *(Triangle t, int scalar)
            {
                return new Triangle(t.a * scalar, t.b * scalar, t.c * scalar, t.color);
            }

            // Перетворення типу Triangle в string ( і навпаки)
            public static implicit operator string(Triangle t)
            {
                return t.GetInfo();
            }
            public static explicit operator Triangle(string str)
            {
                var parts = str.Split(',');
                return new Triangle(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), parts[3]);
            }
        }

            
        public void main1()
            {
                Triangle triangle1 = new Triangle(3, 4, 5, "Red");
                Console.WriteLine(triangle1.GetSides());
                Console.WriteLine(triangle1.GetInfo());
                Console.WriteLine(triangle1.GetPerimetr());
                Console.WriteLine(triangle1.GetArea());

                // Зміна сторін (успішно, бо трикутник існує)
                triangle1.A = 6;
                triangle1.B = 7;
                triangle1.C = 8;
                Console.WriteLine(triangle1.A);
                Console.WriteLine(triangle1.B);
                Console.WriteLine(triangle1.C);

                /* ПОЧАТОК 4-Ї ЛАБОРАТОРНОЇ */
                // Звернення до полів трикутника за допомогою індексатора
                Console.WriteLine(triangle1[0]);
                Console.WriteLine(triangle1[1]);
                Console.WriteLine(triangle1[2]);
                Console.WriteLine(triangle1[3]);
                Console.WriteLine(triangle1[4]); // Помилка

                // Оператор ++
                triangle1++;
                Console.WriteLine(triangle1.GetInfo());

                // Оператор --
                triangle1--;
                Console.WriteLine(triangle1.GetInfo());

                // Перевірка сталих True / False
                Triangle t = new Triangle(3, 4, 5, "Red");
                if (t)
                {
                    Console.WriteLine("Трикутник існує!");
                }
                else
                {
                    Console.WriteLine("Трикутник неіснуючий!");
                }

                // Множення всіх сторін на скаляр (3)
                triangle1 = triangle1 * 3;
                Console.WriteLine(triangle1.GetInfo());
                
                // Перетворення з Triangle в String
                string triangleStr = triangle1;
                Console.WriteLine(triangleStr);

                // Перетворення зі String в Triangle
                Triangle triangle2 = (Triangle)"6,7,8,Blue";
                Console.WriteLine(triangle2.GetInfo());
            }
}
}