using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public List<int> Grades { get; set; } = new List<int>();

    public double AverageGrade => Grades.Count > 0 ? Grades.Average() : 0;
}

class Program
{
    private List<Student> students = new List<Student>();

    static void Main()
    {
        Program program = new Program();
        program.Run();
    }

    void Run()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:\n0 Добавить студента\n1 Добавить оценку\n2 Вывести оценки студента\n3 Вывести отсортированный список студентов\n4 Выйти\nВыберите опцию:");

            string option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    AddStudent();
                    break;
                case "1":
                    AddGrade();
                    break;
                case "2":
                    PrintStudentGrades();
                    break;
                case "3":
                    PrintSortedStudents();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверная опция. Попробуйте снова.");
                    break;
            }
        }
    }

    void AddStudent()
    {
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();
        students.Add(new Student { Name = name });
        Console.WriteLine("Студент добавлен.");
    }

    void AddGrade()
    {
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.Name == name);
        if (student != null)
        {
            Console.Write("Введите оценку: ");
            if (int.TryParse(Console.ReadLine(), out int grade))
            {
                student.Grades.Add(grade);
                Console.WriteLine("Оценка добавлена.");
                Console.WriteLine($"Оценки студента {student.Name}: {string.Join(", ", student.Grades)}");
            }
            else
            {
                Console.WriteLine("Неверный формат оценки.");
            }
        }
        else
        {
            Console.WriteLine("Студент не найден.");
        }
    }

    void PrintStudentGrades()
    {
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.Name == name);
        if (student != null)
        {
            Console.WriteLine($"Оценки студента {student.Name}: {string.Join(", ", student.Grades)}");
        }
        else
        {
            Console.WriteLine("Студент не найден.");
        }
    }

    void PrintSortedStudents()
    {
        var sortedStudents = students.OrderByDescending(s => s.AverageGrade).ToList();
        Console.WriteLine("Список студентов, отсортированный по среднему баллу:");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Name}: {student.AverageGrade:F2}");
        }
    }
}
