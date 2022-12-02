namespace Calendar.Day_2;

public static class Day2 {
    public static List<RockPapirScissorMatch> Matches { get; set; }

    public static List<RockPapirScissorMatch> PopulateMatchesTask1(string path)
    {
        string[] lines = System.IO.File.ReadAllLines(path);

        List<RockPapirScissorMatch> matches = new();

        foreach (var line in lines)
        {
            var match = line.Split(" ");

            matches.Add(new RockPapirScissorMatch
            {
                Opponent = GetPlayType(match[0]),
                Me = GetPlayType(match[1]),
            });
        }

        foreach (var match in matches)
        {
            match.Point = GetMatchPoints(match);
        }
        return matches;
    }

    public static List<RockPapirScissorMatch> PopulateMatchesTask2(string path)
    {
        string[] lines = System.IO.File.ReadAllLines(path);

        List<RockPapirScissorMatch> matches = new();

        foreach (var line in lines)
        {
            var match = line.Split(" ");
            matches.Add(new RockPapirScissorMatch
            {
                Opponent = GetPlayType(match[0]),
                WhatToDo = WhatToDo(match[1]),
            });
        }

        foreach (var match in matches)
        {
            match.Me = HowToWin(match.Opponent, match.WhatToDo);
        }
        foreach (var match in matches)
        {
            match.Point = GetMatchPoints(match);
        }
        return matches;

    }

    public static RockPaperScissorsEnum HowToWin(RockPaperScissorsEnum opponent, WhatToDoEnum what)
    {
        switch(what)
        {
            case WhatToDoEnum.Win:
                switch (opponent)
                {
                    case RockPaperScissorsEnum.Paper:
                        return RockPaperScissorsEnum.Sciccor;
                    case RockPaperScissorsEnum.Rock:
                        return RockPaperScissorsEnum.Paper;
                    case RockPaperScissorsEnum.Sciccor:
                        return RockPaperScissorsEnum.Rock;
                }
                break;
            case WhatToDoEnum.Draw:
                return opponent;
            case WhatToDoEnum.Lose:
                switch (opponent)
                {
                    case RockPaperScissorsEnum.Paper:
                        return RockPaperScissorsEnum.Rock;
                    case RockPaperScissorsEnum.Rock:
                        return RockPaperScissorsEnum.Sciccor;
                    case RockPaperScissorsEnum.Sciccor:
                        return RockPaperScissorsEnum.Paper;
                }
                break;
        }
        return RockPaperScissorsEnum.Paper;
    }

        private static WhatToDoEnum WhatToDo(string type) => type switch
    {
        "X" => WhatToDoEnum.Lose,
        "Y" => WhatToDoEnum.Draw,
        "Z" => WhatToDoEnum.Win,
    };

    public static int GetMatchPoints(RockPapirScissorMatch match)
    {
        var typePoint = GetPlayTypeValue(match.Me);
        var isWinningpoint = IsWinner(match);
        return typePoint + isWinningpoint;
    }

    public static RockPaperScissorsEnum GetPlayType(string type) => type switch
    {
        "X" => RockPaperScissorsEnum.Rock,
        "Y" => RockPaperScissorsEnum.Paper,
        "Z" => RockPaperScissorsEnum.Sciccor,
        "A" => RockPaperScissorsEnum.Rock,
        "B" => RockPaperScissorsEnum.Paper,
        "C" => RockPaperScissorsEnum.Sciccor,
        _ => throw new ArgumentException()
    };

    public static int GetPlayTypeValue(RockPaperScissorsEnum type) =>
        type switch
        {
            RockPaperScissorsEnum.Rock => 1,
            RockPaperScissorsEnum.Paper => 2,
            RockPaperScissorsEnum.Sciccor => 3
        };

    public static int IsWinner(RockPapirScissorMatch match)
    {
        var point = 0;
        if (match.Opponent == match.Me)
        {
            point = 3;
        }
        else if (match.Opponent is RockPaperScissorsEnum.Paper && match.Me is RockPaperScissorsEnum.Rock)
        {
            point = 0;
        }
        else if (match.Opponent is RockPaperScissorsEnum.Sciccor && match.Me is RockPaperScissorsEnum.Paper)
        {
            point = 0;
        }
        else if(match.Opponent is RockPaperScissorsEnum.Rock && match.Me is RockPaperScissorsEnum.Sciccor)
        {
            point = 0;
        }
        else
        {
            point = 6;
        }
        return point;
    }
}