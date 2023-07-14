
object token = new object();
bool done = false;

Thread t1 = new Thread(Run);
t1.Start();

Thread t2 = new Thread(Run);
t2.Start();

// void Run()
// {
//     ;
//     lock (token)
//     {
//         if (!done)
//         {
//             Console.WriteLine("The End");
//             done = true;
//
//         }
//     }
// }
void Run()
{
    ;
   Monitor.Enter(token);
   try
   {
       if (!done)
       {
           Console.WriteLine("The End");
           done = true;

       }
   }
   finally
   {
       Monitor.Exit(token);
   }

  
}