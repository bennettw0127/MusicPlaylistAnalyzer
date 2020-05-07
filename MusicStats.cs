using System;

namespace MusicPlaylistAnalyzer
{
    public class MusicStats
    {
        public String Name;
        public String Artist;
        public String Album;
        public String Genre;
        public int Size;
        public int Time;
        public int Year;
        public int Plays;

        public MusicStats(String name, String artist, String album, String genre, int size, int time, int year, int plays)
        {
            Name = name;
            Artist = artist;
            Album = album;
            Genre = genre;
            Size = size;
            Time = time;
            Year = year;
            Plays = plays;
        }
        override public string ToString()
        {
            return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", Name, Artist, Album, Genre, Size, Time, Year, Plays);
        }
    }
}