// See https://aka.ms/new-console-template for more information

//Day 1

Console.WriteLine("-------------- DAY 1 ----------------");
var elves = Day1.PopulateElvesList("../../../Day 1/elfs.txt");

var mostValuableElf = Day1.FindMostValuedElf(elves!);
Console.WriteLine($"Most valuable elf has {mostValuableElf} calories");

Console.WriteLine($"Three most valuable elves have a caloriesum of: {Day1.ReturnWeightForThreeMostValuableElves(elves!)}");

Console.WriteLine();
//Day 2
Console.WriteLine("-------------- DAY 2 ----------------");

var matches = Day2.PopulateMatchesTask1("../../../Day 2/rockpaperscissors.txt");

var totalPoints = matches.Sum(x => x.Point);
Console.WriteLine($"Task 1: {totalPoints}");

var matches2 = Day2.PopulateMatchesTask2("../../../Day 2/rockpaperscissors.txt");
var totalPoints2 = matches2.Sum(x => x.Point);
Console.WriteLine($"Task 2: {totalPoints2}");
