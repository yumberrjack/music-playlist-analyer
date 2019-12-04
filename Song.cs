﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    public class Song
    {
        public string Name;
        public string Artist;
        public string Album;
        public string Genre;
        public int Size;
        public int Time;
        public int Year;
        public int Plays;

        public Song(string name, string artist, string album, string genre,
                    int size, int time, int year, int plays)
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
            return String.Format("Name: {0}  Artist: {1}  Album: {2}  Genre: {3}  Size: {4}  Time: {5}  Year: {6}  Plays: {7}", Name, Artist, Album, Genre, Size, Time, Year, Plays);
        }
    }
}