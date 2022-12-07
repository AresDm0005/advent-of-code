using Solutions;

PrintAnswers();

void PrintAnswers()
{
    Console.WriteLine($"D1S1: {Day1.FirstStar()} calories for top-1");
    Console.WriteLine($"D1S2: {Day1.SecondStar()} calories for top-3");    
    Console.WriteLine($"D2S1: {Day2.FirstStar()} points of score");
    Console.WriteLine($"D2S2: {Day2.SecondStar()} points of score");
    Console.WriteLine($"D3S1: {Day3.FirstStar()} points of score");
    Console.WriteLine($"D3S2: {Day3.SecondStar()} points of score");
    Console.WriteLine($"D4S1: {Day4.FirstStar()} full overlaps");
    Console.WriteLine($"D4S2: {Day4.SecondStar()} overlaps");
    Console.WriteLine($"D5S1: {Day5.FirstStar()} containers are first");
    Console.WriteLine($"D5S2: {Day5.SecondStar()} containers are first");
}