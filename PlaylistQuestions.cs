using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicPlaylistAnalyzer
{

    public static class PlaylistQuestions
    {
        public static string Answer(List<Song> songsList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Answers Pertaining To Playlist");
            sb.AppendLine();
            sb.AppendLine();

            if (songsList.Count() < 1)
            {
                sb.Append("No playlist data available.");
                sb.AppendLine();
                return sb.ToString();
            }

            sb.AppendLine();
            sb.Append("Songs with 200 or more plays: ");
            sb.AppendLine();

            var twoHunOrMore = from Song in songsList where Song.Plays >= 200 orderby Song.Year descending select Song;
            if (twoHunOrMore.Count() > 0)
            {
                foreach (var Song in twoHunOrMore)
                {
                    sb.Append(Song.ToString() + "\n");
                    sb.AppendLine();
                }
            }
            else
            {
                sb.Append("No songs.");
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.Append("Number of Alternative songs: ");

            var numOfAlt = from Song in songsList where Song.Genre == "Alternative" orderby Song.Year descending select Song;
            if (numOfAlt.Count() > 0)
            {
                sb.Append(numOfAlt.Count());
                sb.AppendLine();
            }
            else
            {
                sb.Append("No songs. \n");
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.Append("Number of Hip-Hop/Rap songs: ");
            
            var numOfRap = from Song in songsList where Song.Genre == "Hip-Hop/Rap" orderby Song.Year descending select Song;
            if (numOfRap.Count() > 0)
            {
                sb.Append(numOfRap.Count());
                sb.AppendLine();
            }
            else
            {
                sb.Append("No songs. \n");
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.Append("Songs in the playlist from the album “Welcome to the Fishbowl”: ");
            sb.AppendLine();

            var numSongsFishBowl = from Song in songsList where Song.Album == "Welcome to the Fishbowl" orderby Song.Plays descending select Song;
            if (numSongsFishBowl.Count() > 0)
            {
                foreach (var Song in numSongsFishBowl)
                {
                    sb.Append(Song.ToString() + "\n");
                    sb.AppendLine();
                }
            }
            else
            {
                sb.Append("No songs.\n");
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.Append("Songs in the playlist from before 1970: ");
            sb.AppendLine();           

            var numBefore = from Song in songsList where Song.Year < 1970 orderby Song.Year descending select Song;
            if (numBefore.Count() > 0)
            {
                foreach (var Song in numBefore)
                {
                    sb.Append(Song.ToString() + "\n");
                    sb.AppendLine();
                }
            }
            else
            {
                sb.Append("No songs.\n");
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.Append("Song names that are more than 85 characters long: ");
            sb.AppendLine();
            

            var longerThan = from Song in songsList where Song.Name.Length > 85 orderby Song.Year descending select Song;
            if (longerThan.Count() > 0)
            {
                foreach (var Song in longerThan)
                {
                    sb.Append(Song.ToString() + "\n");
                    sb.AppendLine();
                }
            }
            else
            {
                sb.Append("No songs.\n");
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.Append("Longest song: ");
            sb.AppendLine();
            

            var longest = from Song in songsList orderby Song.Time descending select Song;
            if (longest.Count() > 0)
            {
                sb.Append(longest.First());
                sb.AppendLine();
            }
            else
            {
                sb.Append("No songs.\n");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }

}