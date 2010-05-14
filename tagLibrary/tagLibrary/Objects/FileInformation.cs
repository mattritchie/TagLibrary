using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tagLibrary.Objects
{
    public class FileInformation:tagLibrary.Interfaces.iFileInformation
    {
        public FileInformation()
        {
        }

        public FileInformation(Interfaces.iFileInformation info)
            : this
                (
                info.FilePath,
                info.TagInfo
                )
        {
        }

        public FileInformation(string filePath, TagLib.File tagInfo)
        {
            this.FilePath = filePath;
            this.TagInfo = tagInfo;
        }

        #region iFileInformation Members

        public string FilePath
        {
            get;set;
           
        }

        public TagLib.File TagInfo
        {
            get;
            set;

        }

        #endregion
    }
}
