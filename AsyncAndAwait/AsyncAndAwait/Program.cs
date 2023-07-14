
//DoWorks();
//Console.ReadKey();

//static void DoWorks()
//{
//    WorkOne();
//    WorkTwo();
//    WorkThree();
//}


//static void WorkOne()
//{
//    //read file
//    Thread.Sleep(2000);
//    Console.WriteLine("work one finished");
//}

//static void WorkTwo()
//{
//    //upload file
//    Thread.Sleep(3000);
//    Console.WriteLine("work two finished");
//}
//static void WorkThree()
//{
//    //read file
//    Thread.Sleep(4000);
//    Console.WriteLine("work two finished");
//}



// var result = await WorkOne();
// Console.WriteLine("Start");
//
// Console.ReadKey();
//
//
// static async Task<string> WorkOne()
// {
//     await Task.Run(() =>
//    {
//        Thread.Sleep(3000);
//        //Console.WriteLine("work one finishid");
//    });
//     return "work one was successful";
// }

DoWorks();
Console.ReadKey();

static async void DoWorks()
{
    var task1 = WorkOne();
   
    var task2 = WorkTwo();
    await task2;
    var task3 = WorkThree();
    Task.WaitAll(task1,task2, task3);
}

static async Task<string> WorkOne()
{
    await Task.Run(() =>
   {
       Thread.Sleep(8000);
       Console.WriteLine("work one finishid in " + DateTime.Now);
   });
    return "work one was successful";
}
static async Task<string> WorkTwo()
{
    await Task.Run(() =>
    {
        Thread.Sleep(4000);
        Console.WriteLine("work Two finishid in " + DateTime.Now);
    });
    return "work Two was successful";
}
static async Task<string> WorkThree()
{
    await Task.Run(() =>
    {
        Thread.Sleep(3000);
        Console.WriteLine("work Three finishid in " + DateTime.Now);
    });
    return "work Three was successful";
}
