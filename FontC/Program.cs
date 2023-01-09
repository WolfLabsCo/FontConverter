using System.Diagnostics;

namespace FontC
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Scans all files in the current directory
			foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory()))
			{
				string name = Path.GetFileNameWithoutExtension(file);
				string extension = Path.GetExtension(file);

				// Processes only .ttf and .otf files
				if (extension == ".ttf" || extension == ".otf")
				{
					Console.WriteLine($"Processing '{name}{extension}'...");

					// Assumes 'Python', 'fonttools' and 'Brotli' installed
					ProcessStartInfo fontTools = new ProcessStartInfo();
					fontTools.FileName = "pyftsubset";
					// Performs no character subsetting, assumes WOFF2 desired output
					fontTools.Arguments = $"\"{name}{extension}\" --unicodes=* --output-file=\"{name}.woff2\" --flavor=woff2";
					fontTools.CreateNoWindow = true;
					
					Process.Start(fontTools);
				}
			}
		}
	}
}