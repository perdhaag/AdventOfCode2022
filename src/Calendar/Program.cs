// See https://aka.ms/new-console-template for more information

//Day 1

var elves = Day1.PopulateElvesList("../../../Day 1/elfs.txt");

var mostValuableElf = Day1.FindMostValuedElf(elves!);
Console.WriteLine("Most valuable elf has " + mostValuableElf!.Calories + " calories");

Console.WriteLine("Three most valuable elves have a caloriesum of: " +  Day1.ReturnWeightForThreeMostValuableElves(elves!));

//Day 2