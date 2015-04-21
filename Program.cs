using System;
using System.Net;
using System.Text;
using System.Threading;

namespace ConsoleApplication4
{
	class ThreadTest
	{
		private static bool done;
		private static object locker = new object();

		static void Main()
		{
			Thread.CurrentThread.Name = "main";
			var t = new Thread(Go);
			t.Name = "worker";
			t.Start();

			Go();
		}

		public static void Go()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.Write(Thread.CurrentThread.Name);
			}
		}
	}
}
