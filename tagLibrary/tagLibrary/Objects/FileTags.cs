using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tagLibrary.Objects
{
    public class FileTags
    {
        public FileTags()
        {
        }

        public FileTags(
            string fileName,
            List<string> genres,
            string albumTitle,
            string name,
            int audioBitrate,
            System.TimeSpan duration,
            
            List<string> albumArtists,
            uint track,
            uint year
            )
        {
            FileName = fileName;
            Genres = genres;
            AlbumTitle = albumTitle;
            Name = name;
            AudioBitrate = audioBitrate;
            Duration = duration;
            
            AlbumArtists = albumArtists;
            Track = track;
            Year = year;

        }

        
        public List<string> AlbumArtists { get; set; }

        public uint Track {get;set;}
        public uint Year { get; set; }

        public string FileName { get; set; }
        public List<string> Genres { get; set; }
        public string AlbumTitle { get; set; }


        public string Name { get; set; }

        public int AudioBitrate { get; set; }
        public System.TimeSpan Duration { get; set; }
    }
}
