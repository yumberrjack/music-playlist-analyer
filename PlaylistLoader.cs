using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicPlaylistAnalyzer
{

    public class PlaylistLoader
    {
        private static int NumColumns = 8;

        public static List<Song> Load(string dataFilePath)
        {
            List<Song> songsList = new List<Song>();

            try
            {
                using (var read = new StreamReader(dataFilePath))
                {
                    int lineNum = 0;
                    while (!read.EndOfStream)
                    {
                        var line = read.ReadLine();
                        lineNum++;
                        if (lineNum == 1) continue;

                        var info = line.Split('\t');

                        if (info.Length != NumColumns)
                        {
                            throw new Exception($"Row {lineNum} contains {info.Length} when it should contain {NumColumns} values.");
                        }
                        try
                        {
                            string name = info[0];
                            string artist = info[1];
                            string album = info[2];
                            string genre = info[3];
                            int size = Int32.Parse(info[4]);
                            int time = Int32.Parse(info[5]);
                            int year = Int32.Parse(info[6]);
                            int plays = Int32.Parse(info[7]);
                            Song song = new Song(name, artist, album, genre, size, time, year, plays);
                            songsList.Add(song);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Data in row {lineNum} is invalid. ({ e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot open {dataFilePath} ({e.Message}).");
            }
            return songsList;
        }
    }
}
