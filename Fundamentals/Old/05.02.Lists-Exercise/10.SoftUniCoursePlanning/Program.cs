using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> trackOfLessons = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] command = input.Split(":");

                string curentCommand = command[0];
                string lessonTitle = command[1];

                if (curentCommand == "Add")
                {
                    AddOrRemoveLesson(trackOfLessons, curentCommand, lessonTitle);
                }
                else if (curentCommand == "Insert")
                {
                    int index = int.Parse(command[2]);

                    InsertLesson(trackOfLessons, lessonTitle, index);
                }
                else if (curentCommand == "Remove")
                {
                    AddOrRemoveLesson(trackOfLessons, curentCommand, lessonTitle);
                }
                else if (curentCommand == "Swap")
                {
                    string lessonTwoTitle = command[2];

                    SwapLessons(trackOfLessons, lessonTitle, lessonTwoTitle);
                }
                else if (curentCommand == "Exercise")
                {
                    AddExercise(trackOfLessons, lessonTitle);
                }
            }
            for (int i = 1; i <= trackOfLessons.Count; i++)
            {
                Console.WriteLine($"{i}.{trackOfLessons[i - 1]}");
            }
        }

        static void AddOrRemoveLesson(List<string> trackOfLessons, string curentCommand, string lessonTitle)
        {
            if (trackOfLessons.Any(x => x != lessonTitle && curentCommand == "Add"))
            {
                trackOfLessons.Add(lessonTitle);
            }
            else if(trackOfLessons.Any(x => x == lessonTitle && curentCommand == "Remove"))  //???
            {
                trackOfLessons.RemoveAll(x => x == lessonTitle);
                trackOfLessons.RemoveAll(x => x == ($"{lessonTitle}-Exercise"));
            }
        }
        static void InsertLesson(List<string> trackOfLessons, string lessonTitle, int index)
        {
            if (!trackOfLessons.Contains(lessonTitle) && index >= 0 && index < trackOfLessons.Count)
            {
                trackOfLessons.Insert(index, lessonTitle);
            }
        }

        static void AddExercise(List<string> trackOfLessons, string lessonTitle)
        {
            if (trackOfLessons.Contains(lessonTitle))  // && trackOfLessons.Any(x => x != ($"{lessonTitle}-Exercise"))
            {
                int indexOfLessonTitle = trackOfLessons.IndexOf(lessonTitle);

                if (indexOfLessonTitle < trackOfLessons.Count - 1)
                {
                    if (trackOfLessons[indexOfLessonTitle + 1] != ($"{lessonTitle}-Exercise"))
                    {
                        trackOfLessons.Insert((indexOfLessonTitle + 1), ($"{lessonTitle}-Exercise"));
                    }
                }
                else if(indexOfLessonTitle == trackOfLessons.Count - 1)
                {
                    trackOfLessons.Add(($"{lessonTitle}-Exercise"));
                }
            }
            else if (!trackOfLessons.Contains(lessonTitle))
            {
                trackOfLessons.Add(lessonTitle);
                trackOfLessons.Add($"{lessonTitle}-Exercise");
            }
        }
        static void SwapLessons(List<string> trackOfLessons, string lessonTitle, string lessonTwoTitle)
        {
            if (trackOfLessons.Any(x => x == lessonTitle) && trackOfLessons.Any(x => x == lessonTwoTitle))
            {
                int indexOfLessonTitle = trackOfLessons.IndexOf(lessonTitle);
                int indexOflessonTwoTitle = trackOfLessons.IndexOf(lessonTwoTitle);
                //string firstLesson = lessonTitle;

                if (trackOfLessons.Any(x => x == ($"{lessonTitle}-Exercise")) && trackOfLessons.Any(x => x != ($"{lessonTwoTitle}-Exercise")))
                {
                    trackOfLessons[indexOfLessonTitle] = lessonTwoTitle;
                    trackOfLessons[indexOflessonTwoTitle] = lessonTitle;

                    if (indexOflessonTwoTitle + 1 == trackOfLessons.Count)
                    {
                        trackOfLessons.Add(($"{lessonTitle}-Exercise"));
                    }
                    else
                    {
                        trackOfLessons.Insert(indexOflessonTwoTitle + 1, ($"{lessonTitle}-Exercise"));
                    }

                    trackOfLessons.RemoveAt(indexOfLessonTitle + 1);
                }
                else if (trackOfLessons.Any(x => x != ($"{lessonTitle}-Exercise")) && trackOfLessons.Any(x => x == ($"{lessonTwoTitle}-Exercise")))
                {
                    trackOfLessons[indexOfLessonTitle] = lessonTwoTitle;
                    trackOfLessons[indexOflessonTwoTitle] = lessonTitle;

                    if (indexOfLessonTitle + 1 == trackOfLessons.Count)
                    {
                        trackOfLessons.Add(($"{lessonTwoTitle}-Exercise"));
                    }
                    else
                    {
                        trackOfLessons.Insert(indexOfLessonTitle + 1, ($"{lessonTwoTitle}-Exercise"));
                    }
                    trackOfLessons.RemoveAt(indexOflessonTwoTitle + 2);
                }
                else if (trackOfLessons.Any(x => x == ($"{lessonTitle}-Exercise")) && trackOfLessons.Any(x => x == ($"{lessonTwoTitle}-Exercise")))
                {
                    trackOfLessons[indexOfLessonTitle] = lessonTwoTitle;
                    trackOfLessons[indexOflessonTwoTitle] = lessonTitle;
                    trackOfLessons[indexOfLessonTitle + 1] = ($"{lessonTwoTitle}-Exercise");
                    trackOfLessons[indexOflessonTwoTitle + 1] = ($"{lessonTitle}-Exercise");
                }
                else if (trackOfLessons.Any(x => x != ($"{lessonTitle}-Exercise")) && trackOfLessons.Any(x => x != ($"{lessonTwoTitle}-Exercise")))
                {
                    trackOfLessons[indexOfLessonTitle] = lessonTwoTitle;
                    trackOfLessons[indexOflessonTwoTitle] = lessonTitle;
                }



            }
        }
    }
}
