using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tagLibrary;
using System.IO;
using System.Xml.Linq;
namespace tagLibrary
{
	public class Stuff
	{

		const string filePath = @"c:\music\";
		const string ext = @"*.mp3";
		const string RawFileSaveLocation = @"c:\musicxml\musicTempXml.csv";
		const string XmlFileSaveLocation = @"c:\musicxml\musicTempXml.xml";


		//static void Main(string[] args)
		//{
		//    //SaveRawFiles();
		//    //ReadRawFileAndExportTagInfoToXML();

		//    if(!File.Exists(XmlFileSaveLocation))
		//        throw new Exception("D");

		//    var dd = ReadXMLFile(XmlFileSaveLocation);

		//    //read XML file

		//    Console.WriteLine("Finished");
		//    Console.ReadLine();
		//}

		public static void DoLotsOfStuff()
		{
			SaveRawCSVFiles();
			ReadRawFileAndExportTagInfoToXML();
		}

		public static List<tagLibrary.Objects.FileTags> GetContentsOfXmlFile()
		{
			if(!File.Exists(XmlFileSaveLocation))
				throw new Exception(string.Format("FileDidn'tExist {0}", XmlFileSaveLocation));

			return ReadXMLFile(XmlFileSaveLocation);
		}

		private static void ReadRawFileAndExportTagInfoToXML()
		{

			var filePaths = ReadRawFileCSV(RawFileSaveLocation);

			var data = tagLibrary.Filesw.GetMp3FilesWithTagsOnly(filePaths).AsParallel();

			Console.WriteLine(string.Format("Count in data = {0}", data.Count()));

			var tagInfo = ConvertLocalTypesToFileTags(data);

			SaveToXMLFile(tagInfo);
		}

		private static List<tagLibrary.Objects.FileTags> ConvertLocalTypesToFileTags(ParallelQuery<tagLibrary.Objects.FileInformationLocalTypes> data)
		{

			var tagInfo = data
							.AsParallel()
							.Select(m =>
							new tagLibrary.Objects.FileTags(
								m.FileName,
								m.TagInfo.Genres.ToList(),
								m.TagInfo.Album,
								m.Name,
								m.Properties.AudioBitrate,
								m.Properties.Duration,

								m.TagInfo.AlbumArtists.ToList(),
								m.TagInfo.Track,
								m.TagInfo.Year
							)
							)

							.ToList();
			return tagInfo;
		}

		private static List<string> ReadRawFileCSV(string fileLocation)
		{

			var filePaths = File.ReadAllLines(RawFileSaveLocation).ToList();

			return filePaths;
		}

		private static void SaveToXMLFile(List<tagLibrary.Objects.FileTags> tagInfo)
		{
			var x = new System.Xml.Serialization.XmlSerializer(tagInfo.GetType());

			x.Serialize(new StreamWriter(XmlFileSaveLocation), tagInfo);		
		}

		private static List<tagLibrary.Objects.FileTags> ReadXMLFile(string fileLocation)
		{
			var type = new List<tagLibrary.Objects.FileTags>().GetType();

			var x = new System.Xml.Serialization.XmlSerializer(type);

			var xmlReader = System.Xml.XmlReader.Create(fileLocation);

			var d = (List<tagLibrary.Objects.FileTags>)x.Deserialize(xmlReader);

			return d;			
		}

		public static void SaveRawCSVFiles()
		{
			var foundFiles = tagLibrary.Filesw.DirSearch(filePath, ext);
			Console.WriteLine(string.Format("Count in data = {0}", foundFiles.Count()));
			//var data= tagLibrary.Filesw.GetAllFileNamesOfMusicFiles(@"c:\music\", "*");

			var saveLocation = RawFileSaveLocation;

			File.WriteAllLines(saveLocation, foundFiles);
		}
	}
}
