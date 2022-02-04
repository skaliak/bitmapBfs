using System;
using System.Collections.Generic;
using System.IO;

public class Bitmap 
{
    public List<List<char>> Matrix {get;} = new List<List<char>>();
    public int Width {get;}
    public int Height {get;}
    public Bitmap(string path)
    {
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var charList = new List<char>();
            Matrix.Add(charList);
            foreach (var c in line)
            {
                charList.Add(c);
            }
            if (Width == 0)
            {
                Width = charList.Count;
            }
        }
        Height = Matrix.Count;
    }

    public int CountAreas()
    {
        int x = 0, y = 0, count = 0;
        while (x < Width && y < Height)
        {
            while (Matrix[y][x] == '0')
            {
                x++;
                if (x == Width)
                {
                    x = 0;
                    y++;
                    if (y == Height)
                        break;
                }
            }
            if (x == Width || y == Height) break;
            count++;
            var q = new Queue<(int x, int y)>();
            q.Enqueue((x, y));
            while (q.Count > 0)
            {
                (var aX, var aY) = q.Dequeue();
                if(Matrix[aY][aX] == '1')
                {
                    Matrix[aY][aX] = '0';
                    foreach (var neighbor in GetNeighbors(aX, aY))
                    {
                        q.Enqueue(neighbor);
                    }
                }
            }
        }
        return count;
    }

    public IEnumerable<(int x, int y)> GetNeighbors(int x, int y)
    {
        var vectors = new (int x, int y) []{(0,1), (0,-1), (1,0), (-1,0)};
        foreach (var v in vectors)
        {
            var newX = x + v.x;
            var newY = y + v.y;
            if (newX < 0 || newX >= Width)
                continue;
            if (newY < 0 || newY >= Height)
                continue;

            yield return (newX, newY); 
        }
    }

    
}