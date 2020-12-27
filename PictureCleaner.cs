using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RoutineManagerAudio
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			
			Console.Write("Paste cleanup directory: ");
			
			string dir = Console.ReadLine();
			
			Console.Write("Enter seconds to display each picture: ");
			
			int secs = Convert.ToInt32(Console.ReadLine());
			
			secs *= 1000;
			
			string startArgs = "";
			
			foreach (string fileName in Directory.GetFiles(dir)) {
				
				startArgs = dir.Replace(@"\", @"\\");
				startArgs += "\\" + fileName;
				
				//startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				startInfo.FileName = "cmd.exe";
				startInfo.Arguments = startArgs;
				process.StartInfo = startInfo;
				process.Start();
				
				// thread needs to sleep for "secs" length unless keyboard input is detected
				Thread.sleep(secs);
				
				// if spacebar is clicked
				if (Console.Read() == " ") {
					File.Delete(startArgs);
					
					// kill thread and close Photos
				}
				
				// close Photos
				
				
				
			}
			
		}
		
	}
	
}