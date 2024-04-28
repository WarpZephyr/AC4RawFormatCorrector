namespace AC4RawFormatCorrector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Raw format correcter is used to correct the rawFormat value of Armored Core 4 BND3 archives.");
                Console.WriteLine("Yabber cannot repack this value correctly.");
                Console.WriteLine("Drag and drop a regulation BND3 file after changes have been made onto the exe of this program.");
                Console.WriteLine("Do not use this on regulation.bin, as the rawFormat value is different and hash calculator will handle that.");
                Console.WriteLine("Press any key to close this program, or click the exit button.");
                Console.ReadKey();
            }

            if (args == null)
                return;

            foreach (string arg in args)
            {
                if (arg == null)
                    continue;
                if (!File.Exists(arg))
                    continue;

                // Read the file.
                var file = File.ReadAllBytes(arg);

                // Correct the rawFormat.
                file[12] = 224;

                // Write the file back.
                File.WriteAllBytes(arg, file);
            }
        }
    }
}