// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть номер завдання: ");
        int n = int.Parse(Console.ReadLine()!);
        switch (n)
        {
        case 1: 
            Task_1.Task_1 myTask_1 = new Task_1.Task_1();
            myTask_1.main1();
        break;
        case 2: 
            Task_2.Task_2 myTask_2 = new Task_2.Task_2();
            myTask_2.main2();
        break;
        default:
            break;
        }
        Main();
    }
}
