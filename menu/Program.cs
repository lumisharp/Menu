
List<Student> students = [];

Action[] actions =
       [
            AddSudent,
            AddGrade,
            PrintStudentGrades,
           PrintSortedStudent
       ];

while (true)
{
    Console.WriteLine("""
                Меню:
                а. Добавить студента
                б. Добавить оценку
                в. Вывести оценки студента
                г. Вывести отсортированный список студентов
                Выберите опцию:
                """);

   char choice = Console.ReadKey().KeyChar;

    int index = choice - 'а';
    if (index>= 0 && index < actions.Length)
    {
        actions[index]();
    }
    else
    {
        Console.WriteLine("Неверный выбор");
    }
}
static void AddSudent()
{
    Console.WriteLine("Введите имя студента");
    students.Add(new Student(Console.ReadLine()));
    Console.WriteLine("Студент добавлен.");
}

static void AddGrade()
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

static void PrintStudentGrades()
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
static void SortedStudent()
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

static void PrintSortedStudent()
{
    SortedStudent();
    Console.WriteLine("Список студентов, отсортированный по среднему баллу:");
    foreach (var student in students)
    {
        Console.WriteLine($"{student.Name}: {AverageGrade(student):F2}");
    }
}

static void PrintStudent(List<Student> students )
{
    Console.WriteLine("Список студентов, отсортированный по среднему баллу:");
    foreach (var student in students)
    {
        Console.WriteLine($"{student.Name}: {AverageGrade(student):F2}");
    }
}

static double AverageGrade(Student student)
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
