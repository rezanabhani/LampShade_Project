


Console.WriteLine("main thread");
Thread t1 = new Thread(DoWork);
t1.IsBackground = true;
t1.Start();


static void DoWork()
{
    for (int i = 1; i < 100; i++)
    Console.WriteLine(i.ToString());
}