

Random rnd = new Random();
//Console.WriteLine(rnd.Next());
var result = rnd.Next(4);
Console.WriteLine(rnd.Next(7));

if (result == 1)
{
    Console.WriteLine("rakab");
}
else if (result == 2)
{
    Console.WriteLine("khaki");
}
else
{
    Console.WriteLine("Sto");
}


// Console.WriteLine(rnd.Next(6)+1);
//Console.WriteLine(rnd.Next(1,7));
//Console.WriteLine(rnd.Next(1,7));
// for (int i = 0; i < 5; i++)
//     Console.Write(rnd.Next(1,7) + "  ");


