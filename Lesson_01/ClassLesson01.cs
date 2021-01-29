using System;

public class Class1
{
	public Class1()
	{
		static void Print(string ms, int x, int y)
        {
			Console.SetCursorPosition(x, y);
			Console.WriteLine(ms);
        }
	}
}
