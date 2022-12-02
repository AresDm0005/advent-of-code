using Solutions;

PrintAnswers();

void PrintAnswers()
{
    Console.WriteLine($"D1S1: {Day1.FirstStar()} calories for top-1");
    Console.WriteLine($"D1S2: {Day1.SecondStar()} calories for top-3");    
    Console.WriteLine($"D2S1: {Day2.FirstStar()} points of score");
    Console.WriteLine($"D2S2: {Day2.SecondStar()} points of score");
}