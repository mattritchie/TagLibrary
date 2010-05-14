using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tagLibrary.Interfaces
{
    public interface iFileInformation
    {
        string FilePath { get; set; }
        TagLib.File TagInfo { get; set; }
    }
}
