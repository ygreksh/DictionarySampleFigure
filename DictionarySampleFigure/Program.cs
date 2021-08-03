using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DictionarySampleFigure
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //тестовая фигура для поиска
            Figure testFigure1 = new Figure() {SideCount = 1111, SideLenght = 1111};  // эту фигуру для поиска вставлю в начало списка
            Figure testFigure2 = new Figure() {SideCount = 5555, SideLenght = 5555};  // эту фигуру вставлю в случайное место в середине списка
            Figure testFigure3 = new Figure() {SideCount = 9999, SideLenght = 9999};  // эту фигуру вставлю в конец списка
            //генерация списка произвольных фигур
            List<Figure> listOfFigures = new List<Figure>();
            int NumbersOfFigures = 10000;    //количество фигур в списке
            int counter = NumbersOfFigures; //счетчик в цикле рандомной генерации
            Random random = new Random();

            listOfFigures.Add(testFigure1); //добавляю тестовую фигуру, которую буду искать в начало списка

            while (counter != 0)
            {
                //Добавляем новую рандомную фигуру
                listOfFigures.Add(new Figure
                {
                    SideCount = random.Next(NumbersOfFigures),
                    SideLenght = random.Next(NumbersOfFigures)
                });
                counter--;
            }
            listOfFigures.Insert(random.Next(listOfFigures.Count),testFigure2); //добавляю вторую тестовую фигуру, которую буду искать, в случайное место внутри списка
            listOfFigures.Add(testFigure3); //добавляю третью тестовую фигуру, которую буду искать, в конец списка
            
            //создаем словарь на базе списка
            Dictionary<Figure, string> dictOfFigures = new Dictionary<Figure, string>();
            foreach (var item in listOfFigures)
            {
                dictOfFigures.Add(item, Path.GetRandomFileName().Replace(".", ""));
            }
            /*
            //вывод в консоль списка
            //Console.WriteLine("Список фигур");
            foreach (var item in listOfFigures)
            {
                //Console.WriteLine(item.ToString());
            }
            
            //вывод в консоль словаря
            //Console.WriteLine("Словарь фигур");
            foreach (var item in dictOfFigures)
            {
                //Console.WriteLine(item.ToString());
            }
            */
            
            //измерение скорости поиска
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            listOfFigures.Contains(testFigure1);
            stopwatch1.Stop();
            Console.WriteLine("Скорость поиска " + testFigure1.ToString() + " в списке: " + stopwatch1.ElapsedTicks);
            stopwatch1.Reset();
            stopwatch1.Start();
            listOfFigures.Contains(testFigure2);
            stopwatch1.Stop();
            Console.WriteLine("Скорость поиска " + testFigure2.ToString() + " в списке: " + stopwatch1.ElapsedTicks);
            stopwatch1.Reset();
            stopwatch1.Start();
            listOfFigures.Contains(testFigure3);
            stopwatch1.Stop();
            Console.WriteLine("Скорость поиска " + testFigure3.ToString() + " в списке: " + stopwatch1.ElapsedTicks);
            stopwatch1.Reset();
            
            stopwatch2.Start();
            dictOfFigures.ContainsKey(testFigure1);
            stopwatch1.Stop();
            Console.WriteLine("Скорость поиска " + testFigure1.ToString() + " в словаре: " + stopwatch2.ElapsedTicks);
            stopwatch2.Reset();
            stopwatch2.Start();
            dictOfFigures.ContainsKey(testFigure2);
            stopwatch1.Stop();
            Console.WriteLine("Скорость поиска " + testFigure2.ToString() + " в словаре: " + stopwatch2.ElapsedTicks);
            stopwatch2.Reset();
            stopwatch2.Start();
            dictOfFigures.ContainsKey(testFigure3);
            stopwatch1.Stop();
            Console.WriteLine("Скорость поиска " + testFigure3.ToString() + " в словаре: " + stopwatch2.ElapsedTicks);
            stopwatch2.Reset();

        }
    }
}