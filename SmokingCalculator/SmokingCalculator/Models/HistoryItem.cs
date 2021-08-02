using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Essentials;

namespace SmokingCalculator.Models
{
    public class HistoryItem
    {

        public long CompletedDate { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }

        const string localFileName = "history.xml";
       
        public static ObservableCollection<HistoryItem> LoadFromFile(string filename)
        {
            string localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);

            //  var assembly = IntrospectionExtensions.GetTypeInfo(typeof(HistoryItem)).Assembly;
            //   Stream stream = assembly.GetManifestResourceStream("SmokingCalculator.Resources.historylist.xml");

            using (var reader = new System.IO.StreamReader(localPath))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<HistoryItem>));
                return (ObservableCollection<HistoryItem>)serializer.Deserialize(reader);
            }
        }

       

        public override string ToString()
        {
            DateTime myDate = new DateTime(CompletedDate);
            // return $"{myDate} {Rating} {Notes}"; for a future versoin
            return $"{myDate}";
        }
    }
}