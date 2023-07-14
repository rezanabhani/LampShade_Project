// Thread

TaskOne();
TaskTwo();
TaskThree();

static void TaskOne()
{
    for (int i = 0; i < 100; i++)
    Console.WriteLine("Task 1");
}

static void TaskTwo()
{
    for (int i = 0; i < 100; i++)
        Console.WriteLine("Task 2");
}
static void TaskThree()
{
    for (int i = 0; i < 100; i++)
        Console.WriteLine("Task 3");
}

Console.ReadKey();