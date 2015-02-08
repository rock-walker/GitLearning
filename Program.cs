﻿using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleApplication4
{
	class Program
	{
		static void Main()
		{
			
			var hl = new HttpListener();

			var res = hl.BeginGetContext(StartConnection, hl);
			res.AsyncWaitHandle.WaitOne();
		}

		public static void StartConnection(IAsyncResult res)
		{
			
			 var listener = (HttpListener)res.AsyncState;
			 HttpListenerContext context = listener.EndGetContext(res);
			 // Obtain a response object.
			 HttpListenerResponse response = context.Response;
			 // Construct a response. 
			 string responseString = "<HTML><BODY> Hello world! " + DateTime.Now + "</BODY></HTML>";
			 byte[] buffer = Encoding.UTF8.GetBytes(responseString);
			 // Get a response stream and write the response to it.
			 response.ContentLength64 = buffer.Length;
			 System.IO.Stream output = response.OutputStream;
			 output.Write(buffer, 0, buffer.Length);
			 // You must close the output stream.
			 Thread.Sleep(4000);
			 output.Close();
		}

		public static void EndConnection(IAsyncResult res)
		{
			if (res.IsCompleted)
				Console.WriteLine("cool");
		}
	}
}
