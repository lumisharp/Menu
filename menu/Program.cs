
List<Student> students = [];

Action[] actions =
       [
            AddSudent,
            AddGrade,
            PrintStudentGrades,
           SortedStudent,
           PrintSortedStudent
       ];

while (true)
{
    Console.WriteLine("""
                Меню:
                0. Добавить студента
                1. Добавить оценку
                2. Вывести оценки студента
                3. Отсортировать студентов
                4. Вывести отсортированный список студентов
                Выберите опцию:
                """);

    actions[int.Parse(Console.ReadLine())]();
    /*for (int i = 0; i < actions.Length; i++)
        if (int.Parse(Console.ReadLine()) == i)
        {
            actions[i]();
            break;
        }*/
}
void AddSudent()
{
    Console.WriteLine("Введите имя студента");
    students.Add(new(Console.ReadLine()));
    Console.WriteLine("Студент добавлен.");
}

void AddGrade()
{
    Console.Write("Введите имя студента: ");
    foreach (var student in students)
    {
        if (student.Name == Console.ReadLine())
        {
            Console.Write("Введите оценку: ");
            int grade = int.Parse(Console.ReadLine());
            student.Grades.Add(grade);
            Console.WriteLine("Оценка добавлена.");
            return;
        }
    }

    Console.WriteLine("Студент не найден.");
}

void PrintStudentGrades()
{
    Console.Write("Введите имя студента: ");
    foreach (var student in students)
    {
        if (student.Name == Console.ReadLine())
        {
            Console.WriteLine($"Оценки студента {student.Name}: {string.Join(", ", student.Grades)}");
            return;
        }
    }

    Console.WriteLine("Студент не найден.");
}
void SortedStudent()
{
    List<Student> sortedStudents = new(students);
    for (int i = 0; i < sortedStudents.Count - 1; i++)
        for (int j = i + 1; j < sortedStudents.Count; j++)
        {
            if (AverageGrade(sortedStudents[i]) < AverageGrade(sortedStudents[j]))
            {
                (sortedStudents[j], sortedStudents[i]) = (sortedStudents[i], sortedStudents[j]);
            }
        }
}

void PrintSortedStudent()
{
    Console.WriteLine("Список студентов, отсортированный по среднему баллу:");
    foreach (var student in students)
    {
        Console.WriteLine($"{student.Name}: {AverageGrade(student):F2}");
    }
}

double AverageGrade(Student student)
{

    if (student.Grades.Count == 0)
        return 0;
    return student.Grades.Average();
}
struct Student(string name)
{
    public string Name = name;
    public List<int> Grades = [];


}
