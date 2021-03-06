using System;
using System.Linq;

public class Hurt
{
    private static void Main()
    {
        var number = new Number();

        var num = Console.ReadLine().Split(' ').Select(x => Int32.Parse(x)).ToArray();
        number._width = num[0];
        number._height = num[1];
        number._middle = num[0] / 2;

        var hartArray = new bool[number._width, number._height];

        for (int y = 0; y < number._height; ++y)
        {
            for (int x = 0; x < number._width; ++x)
            {
                if (number.IsBlock(x, y)) Console.Write("hh");
                else Console.Write("  ");
            }
            Console.WriteLine();
        }
    }
}

public class Number
{
    public int _width;
    public int _height;
    public int _middle;

    /// <summary>
    /// 座標にブロックを置くかどうかを判断する
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool IsBlock(int x, int y)
    {
        if (x == _middle)
        {
            if (y == 0 || y == 1) return false;
            else return true;
        }
        else if ((x == 0 && y == 0) || (x == _width - 1 && y == 0))
        {
            return false;
        }
        else
        {
            var distance = Math.Abs(_middle - x);
            for (int i = 0; i < distance; ++i)
            {
                if (y == ((_height - 1) - i)) return false;
            }
            return true;
        }
    }
}