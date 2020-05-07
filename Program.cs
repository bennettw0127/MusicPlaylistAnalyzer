using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string txtDataFilePath = args[0];
            string reportFilePath = args[1];

            List<MusicStats> musicStatsList = null;

            try
            {
                musicStatsList = MusicStatsLoader.Load(txtDataFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = MusicStatsReport.GenerateText(musicStatsList);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            }
            catch(Exception e)
            {

                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}