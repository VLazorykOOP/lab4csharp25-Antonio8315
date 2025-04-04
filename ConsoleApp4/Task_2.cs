using System;
using System.Security.Cryptography;
namespace Task_2
{
public class Task_2
{
    class VectorUInt
    {
        protected  uint [] IntArray; // масив
        protected  uint size; // розмір вектора
        protected int codeError; // код помилки
        protected static uint num_vec; // кількість векторів

        // КОНСТРУКТОРИ
        public VectorUInt()
        {
            size = 1;
            IntArray = new uint[size];
            IntArray[0] = 0;
        }

        public VectorUInt(uint sizeV)
        {
            size = sizeV;
            IntArray = new uint[size];
            for (int i = 0; i < size; i++)
            {
                IntArray[i] = 0;
            }
        }

        public VectorUInt(uint sizeV, uint value)
        {
            size = sizeV;
            IntArray = new uint[size];
            for (int i = 0; i < size; i++)
            {
                IntArray[i] = value;
            }
        }
        // Деструктор
        ~VectorUInt()
        {
            Console.WriteLine("Об'єкт VectorUInt знищено");
        }

        //МЕТОДИ
        public void InputIntArray(){
            Console.Write("Введіть розмір масиву: ");
            uint size = uint.Parse(Console.ReadLine()!);
            IntArray = new uint[size];
            for (int i = 0; i < size; i++){
                Console.Write($"Елемент {i}: ");
                IntArray[i] = uint.Parse(Console.ReadLine()!);
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Вміст вектора:");
            for (int i = 0; i < IntArray.Length; i++){
                Console.Write(IntArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
    public void main2()
    {
        VectorUInt vector1 = new VectorUInt();
        VectorUInt vector2 = new VectorUInt(5);
        VectorUInt vector3 = new VectorUInt(5, 1);
        vector2.InputIntArray();
        vector2.PrintArray();
    }
}
}