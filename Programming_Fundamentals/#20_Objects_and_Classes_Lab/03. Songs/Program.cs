using System;
using System.Collections.Generic;

namespace _03._Songs
{
    class Song                                     ///Създаваме нов клас
    {                                              ///Дефинираме неговото състояние / Properties
        public string TypeList { get; set; }       ///Дефинираме неговото състояние / Properties
        public string Name { get; set; }           ///Дефинираме неговото състояние / Properties
        public string Time { get; set; }           ///Дефинираме неговото състояние / Properties
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();            ///Създаваме списък от типа на класа Song

            for (int i = 0; i < numberOfSongs; i++)
            {
                string data = Console.ReadLine();

                string type = data.Split("_")[0];
                string name = data.Split("_")[1];
                string time = data.Split("_")[2];

                Song song = new Song();            // Създава се инстанция на класа Song

                song.TypeList = type;              // Описваме състоянието на обекта
                song.Name = name;                  // Описваме състоянието на обекта
                song.Time = time;                  // Описваме състоянието на обекта

                songs.Add(song);                   // Към списъка songs добавяме новия обект, новата инстанция на класа
            }

            string typeList = Console.ReadLine();  // Четем типът песни, които да принтираме

            if (typeList == "all")                           //Проверяваме дали песноте са от тип typeList и ги принтираме
            {                                                //Проверяваме дали песноте са от тип typeList и ги принтираме
                foreach (Song song in songs)                 //Проверяваме дали песноте са от тип typeList и ги принтираме
                {                                            //Проверяваме дали песноте са от тип typeList и ги принтираме
                    Console.WriteLine(song.Name);            //Проверяваме дали песноте са от тип typeList и ги принтираме
                }                                            //Проверяваме дали песноте са от тип typeList и ги принтираме
            }                                                //Проверяваме дали песноте са от тип typeList и ги принтираме
            else                                             //Проверяваме дали песноте са от тип typeList и ги принтираме
            {                                                //Проверяваме дали песноте са от тип typeList и ги принтираме
                foreach (Song song in songs)                 //Проверяваме дали песноте са от тип typeList и ги принтираме
                {                                            //Проверяваме дали песноте са от тип typeList и ги принтираме
                    if (song.TypeList == typeList)           //Проверяваме дали песноте са от тип typeList и ги принтираме
                    {                                        //Проверяваме дали песноте са от тип typeList и ги принтираме
                        Console.WriteLine(song.Name);        //Проверяваме дали песноте са от тип typeList и ги принтираме
                    }                                        //Проверяваме дали песноте са от тип typeList и ги принтираме
                }                                            //Проверяваме дали песноте са от тип typeList и ги принтираме
            }                               
        }
    }
}
