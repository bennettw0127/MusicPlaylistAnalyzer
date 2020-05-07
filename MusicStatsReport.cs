using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MusicPlaylistAnalyzer
{
    public static class MusicStatsReport
    {
        public static string GenerateText(List<MusicStats> musicStatsList)
        {
            string report = "Music Playlist Report\n\n";

            if (musicStatsList.Count() < 1)
            {
                report += "No data is available\n";

                return report;
            }
            //Q1
            var moreThan200Plays = from musicStats in musicStatsList
                                   where musicStats.Plays >= 200
                                   select musicStats;
            if (moreThan200Plays.Count() > 0)
            {
                report += "Songs that received 200 or more plays:\n";

                foreach (MusicStats musicStats in moreThan200Plays)
                {
                    report += musicStats.ToString() + "\n\n";
                }
            }
            else
            {
                report += "not available\n";
            }
            //Q2
            var altsongs = from musicStats in musicStatsList
                           where musicStats.Genre == "Alternative"
                           select musicStats;
            if (altsongs.Count() > 0)
            {
                report += "Number of Alternative songs: ";
                report += altsongs.Count();
                report += "\n\n";
            }
            else
            {
                report += "not available\n";
            }
            //Q3
            report += "Number of Hip-Hop/Rap songs:";
            var hrsongs = from musicStats in musicStatsList
                           where musicStats.Genre == "Hip-Hop/Rap"
                           select musicStats;
            if (hrsongs.Count() > 0)
            {
                report += hrsongs.Count();
                report += "\n\n";
            }
            else
            {
                report += "not available\n";
            }
            //Q4
            report += "Songs from the album Welcome to the Fishbowl:\n";
            var alsongs = from musicStats in musicStatsList
                           where musicStats.Album == "Welcome to the Fishbowl"
                           select musicStats;
            if (alsongs.Count() > 0)
            {
                foreach (MusicStats musicStats in alsongs)
                {
                    report += musicStats.ToString() + "\n\n";
                }
            }
            else
            {
                report += "not available\n";
            }
            //Q5
            report += "Song from before 1970:\n";
            var oldsongs = from musicStats in musicStatsList
                           where musicStats.Year <= 1970
                           select musicStats;
            if (oldsongs.Count() > 0)
            {
                foreach (MusicStats musicStats in oldsongs)
                {
                    report += musicStats.ToString() + "\n\n";
                }
            }
            else
            {
                report += "not available\n";
            }
            //Q6
            report += "Song names longer than 85 characters:\n";
            var songname = from musicStats in musicStatsList
                           where musicStats.Name.Length > 85
                           select musicStats.Name;
            if (songname.Count() > 0)
            { 
                report += (songname.First()).ToString() + "\n\n";
            }
            else
            {
                report += "not available\n";
            }
            //Q7
            report += "What is the longest song?(longest in Time)\n";
            var longest = from musicStats in musicStatsList where musicStats.Time == 
                          ((from stats in musicStatsList select stats.Time).Max()) select musicStats;



            report +=(longest.First()).ToString();

            return report;
        }
    }
}