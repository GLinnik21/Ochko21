using System;

namespace Laba1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.Write("Enter number of players: ");
			int a = int.Parse(Console.ReadLine());
			while (true) {
				Game game = new Game(a);
				game.startGame();
			}
		}
	}
}
