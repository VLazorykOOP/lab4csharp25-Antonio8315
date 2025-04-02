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

            // Індексатор
            class side<T>
            {
                private T[] arr = new T[100];
                public T this[int i]
                {
                    get { return arr[i]; }
                    set { arr[i] = value; }
                }
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
                triangle1.B = 6;
                triangle1.C = 6;
                Console.WriteLine(triangle1.GetInfo());

                // Звернення до полів трикутника за допомогою індексатора
                var sideA = new Triangle.side<int>(triangle1.A);
                sideA[0] = 10;
                Console.WriteLine(sideA[0]);

                var sideB = new Triangle.side<int>(triangle1.B);
                sideB[1] = 10;
                Console.WriteLine(sideA[1]);
            }
}
}