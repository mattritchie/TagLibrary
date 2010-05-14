using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tagLibrary.Objects
{
    public class FileInformationLocalTypes
    {
        public string FileName { get; set; }
        public TagLib.Tag TagInfo { get; set; }
        public TagLib.Properties Properties { get; set; }
        public long Length { get; set; }
        
        
        //public List<TagLib.IPicture> Pictures { get; set; }
        public string Name { get; set; }

        public FileInformationLocalTypes()
        {
        }

        public FileInformationLocalTypes(string fileName)
        {
            this.FileName = fileName;
        }

        public FileInformationLocalTypes
            (
            string fileName, 
            TagLib.Tag info,
            TagLib.Properties props,
            long length,
          //  List<TagLib.IPicture> pictures,
            string name
            
            )
        {
            this.FileName = fileName;
            this.TagInfo = info;
            this.Properties = props;
            this.Length = length;
            //this.Pictures = pictures;
            this.Name = name;

            
        }
    }
}
