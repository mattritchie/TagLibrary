using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace tagLibrary
{
    public sealed class Filesw
    {
        public Filesw()
        {
        }

        public static List<tagLibrary.Objects.FileInformationLocalTypes> GetAllFileNamesOfMusicFiles(string basePath,string extension)
        {
            Console.WriteLine("Beginning Get Files");
            var listOfMp3Files = DirSearch(basePath, extension);//.Take(20).ToList();

            Console.WriteLine("Beginning Get Tags");
            //var mp3sWithTags = GetMp3FilesWithTags(listOfMp3Files);
            var mp3sWithTags = GetMp3FilesWithTagsOnly(listOfMp3Files);
            
           // SaveToDisk(mp3sWithTags);
            Console.WriteLine("Returning Tags");
            return mp3sWithTags;
                //.Select(s => s.TagInfo.Tag.Title)
                //.ToList()
                //.Select(ss=> new {Artist = ss})
                //.ToList();            
        }

        private static List<tagLibrary.Objects.FileInformation> GetMp3FilesWithTags(List<string> listOfMp3Files)
        {
            var localCollection = new List<tagLibrary.Objects.FileInformation>();

            foreach (var file in listOfMp3Files)
            {
                try
                {
                    Debug.WriteLine(string.Format("trying to check this file {0}", file));

                    localCollection.Add(                        
                        new Objects.FileInformation(
                                file, 
                                TagLib.File.Create(new TagLib.File.LocalFileAbstraction(file))
                                ));

                    Console.ReadLine();
                }
                catch (TagLib.CorruptFileException corrupt)
                {
                    Console.WriteLine(string.Format("Corrupt {0}", corrupt.Message));
                }
                catch (TagLib.UnsupportedFormatException exc)
                {
                    Console.WriteLine(string.Format("unsupported {0}", exc.Message));
                }

                
            }

            return localCollection.OrderBy(d=>d.TagInfo.Tag.Title).ToList();

        }


        public static List<tagLibrary.Objects.FileInformationLocalTypes> GetMp3FilesWithTagsOnly(List<string> listOfMp3Files)
        {
            var localCollection = new List<tagLibrary.Objects.FileInformationLocalTypes>();

            foreach (var file in listOfMp3Files)
            {
                try
                {
                   // Console.WriteLine(string.Format("trying to check this file {0}", file));

                    var taggedFile = TagLib.File.Create(new TagLib.File.LocalFileAbstraction(file));



                    localCollection.Add(
                        new Objects.FileInformationLocalTypes(
                                file,
                                taggedFile.Tag,
                                taggedFile.Properties,
                                taggedFile.Length,
                               // taggedFile.Tag.Pictures.ToList(),
                                taggedFile.Name
                                ));
                }
                catch (TagLib.CorruptFileException corrupt)
                    {
                       // Console.WriteLine(string.Format("Corrupt {0}", corrupt.Message));
                    }
                    catch (TagLib.UnsupportedFormatException exc)
                    {
                    //Console.WriteLine(string.Format("unsupported {0}", exc.Message));
                }

            }

            return localCollection.ToList();

        }


        public const string FileSaveLocation = @"c:\musicxml\musicTempXml.Xml";

        public static void SaveToDisk(List<tagLibrary.Objects.FileInformationLocalTypes> fileInfo)
        {
            throw new NotImplementedException("SHOULDN'T USE THIS ONE SIR");

            Console.WriteLine(string.Format("Beginning to deserialise"));

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(
                fileInfo.GetType()
                );

            x.Serialize(new StreamWriter(FileSaveLocation), fileInfo);

        }


        public static List<String> DirSearch(string sDir, string extension)
        {
            List<string> files = new List<string>();

            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d,extension))
                    {
                        files.Add(f);
                    }
                    
                    files.AddRange(DirSearch(d, extension));
                }
            }
            catch (System.Exception excpt)
            {
                Debug.WriteLine(excpt.Message);
            }
            return files;
        }
    }
}
