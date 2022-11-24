using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;

// https://www.codewars.com/kata/585894545a8a07255e0002f1/train/csharp

public class ScreenLockingPatterns
{
    public static int CountPatternsFrom(char firstDot, int length)
    {
        var grid = new Grid(length);
        return grid.PatternsFrom(firstDot);
    }

    public static void Test()
    {
        var grid = new Grid(8);

        var x = grid.PatternsFrom('E');
        grid.Print();

        //var x = grid.GetConnections('C', new() { 'B' });
        ////grid.GetConnections('A', new());
        ////grid.GetConnections('F', new());
        ////grid.GetConnections('I', new());
        ////grid.GetConnections('B', new());
        ////grid.GetConnections('D', new());

        //foreach (var v in x)
        //{
        //    Console.WriteLine($"H - {v.Name}");
        //}


    }

    private sealed class Grid
    {
        private readonly List<Dot> _dots;
        private readonly int _length;
        private readonly HashSet<string> _paths = new();

        public Grid(int length)
        {
            _length = length;
            _dots = new()
            {
                new(0,0,'A'),
                new(0,1,'B'),
                new(0,2,'C'),
                new(1,0,'D'),
                new(1,1,'E'),
                new(1,2,'F'),
                new(2,0,'G'),
                new(2,1,'H'),
                new(2,2,'I'),
            };
        }

        public void Print()
        {
            foreach (var p in _paths)
            {
                Console.WriteLine(p);
            }
        }

        public int PatternsFrom(char firstDot)
        {
            var dot = _dots.Find(d => d.Name == firstDot);
            Calculate(dot, _length, new());
            return _paths.Count;
        }

        private void Calculate(Dot dot, int length, HashSet<char> visitedDots, Dot parent = null)
        {
            var d = dot with { Parent = parent };
            if (length is 0 or > 9)
            {
               return;
            }

            visitedDots.Add(dot.Name);

            var connections = GetConnections(dot, visitedDots);
            var names = d.GetParentNames();

            if (names.Count == _length)
                _paths.Add(string.Join(" -> ", names));
            
            foreach (var connection in connections)
            {
                Calculate(connection, length - 1, d.GetParentNames(), d);
            }

        }
        private List<Dot> GetConnections(Dot dot, ICollection<char> visitedDots)
        {
            var result = new List<Dot>();

            var unvisitedDots = _dots.Where(d => !visitedDots.Contains(d.Name)).ToList();

            var left = unvisitedDots.Where(d => d.Row == dot.Row && d.Column < dot.Column).MaxBy(x => x.Column);
            var right = unvisitedDots.Where(d => d.Row == dot.Row && d.Column > dot.Column).MinBy(x => x.Column);
            var top = unvisitedDots.Where(d => d.Column == dot.Column && d.Row > dot.Row).MinBy(x => x.Row);
            var bottom = unvisitedDots.Where(d => d.Column == dot.Column && d.Row < dot.Row).MaxBy(x => x.Row);
            var diagonals = unvisitedDots.Where(d => (d.Row > dot.Row && d.Column != dot.Column) || (d.Row < dot.Row && d.Column != dot.Column));

            if (!visitedDots.Contains('E'))
            {
                //remove diagonal opposite
                diagonals = diagonals.Where(d =>
                    !((d.Row == dot.Row + 2 && d.Column == dot.Column + 2) ||
                    (d.Row == dot.Row + 2 && d.Column == dot.Column - 2) ||
                    (d.Row == dot.Row - 2 && d.Column == dot.Column + 2) ||
                    (d.Row == dot.Row - 2 && d.Column == dot.Column - 2)))
                    .ToList();
            }

            if (left is not null)
                result.Add(left);

            if (right is not null)
                result.Add(right);

            if (top is not null)
                result.Add(top);

            if (bottom is not null)
                result.Add(bottom);

            result.AddRange(diagonals);

            return result.OrderBy(c => c.Name).ToList();
        }
    }

    private sealed record Dot(int Row, int Column, char Name)
    {

        public Dot Parent { get; init; }

        public HashSet<char> GetParentNames()
        {
            var result = new HashSet<char> { Name };
            var p = Parent;

            while (p is not null)
            {
                result.Add(p.Name);
                p = p.Parent;
            }

            return result.Reverse().ToHashSet();
        }
    };
}
