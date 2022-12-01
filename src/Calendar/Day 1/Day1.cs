namespace Calendar.Day_1;

public static class Day1
{
    public static List<Elf> PopulateElvesList(string path)
    {
        string[] lines = System.IO.File.ReadAllLines(path);

        List<Elf?> elves = new List<Elf?>();

        var calories = 0;
        var order = 1;
        foreach (var line in lines)
        {
            if (line != "")
            {
                calories += int.Parse(line);
            }
            else
            {
                elves.Add(new Elf{OrderId = order, Calories = calories});
                order += 1;
                calories = 0;
            }
        }
        return elves!;
    }
    public static Elf? FindMostValuedElf(List<Elf?> elves)
    {
        return elves.MaxBy(x => x.Calories);
    }

    public static int ReturnWeightForThreeMostValuableElves(List<Elf?> elves)
    {
        return elves.OrderByDescending(x => x.Calories).Take(3).Sum(x => x.Calories);
    }
}