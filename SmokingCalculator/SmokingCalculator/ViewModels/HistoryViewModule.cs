using SmokingCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmokingCalculator.ViewModels
{
    class HistoryViewModule : INotifyPropertyChanged
    {
        private ObservableCollection<HistoryItem> _history;
        public ObservableCollection<HistoryItem> History
        {
            get { return _history; }
            set
            {
                _history = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(History)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
   
        public ICommand OpenCommand => new Command(Open);
        public ICommand ClearCommand => new Command(Clear);
        const string localFileName = "history.xml";
        string localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);

        public HistoryViewModule()
        {
            if (!File.Exists(localPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true
                };
                using (XmlWriter writer = XmlWriter.Create(localPath, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("ArrayOfHistoryItem");
                    
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            History = new ObservableCollection<HistoryItem>();
            Load();
        }
       public void AddEntry(DateTime date, string rating, string notes)
        {
            //Appends new entry to the XML

            XmlDocument doc = new XmlDocument();
            doc.Load(localPath);

            XmlNode root = doc.DocumentElement;

            //Create a new node.
            XmlElement historyitem = doc.CreateElement("HistoryItem");

            XmlElement dateitem = doc.CreateElement("CompletedDate");
            dateitem.InnerText = date.Ticks.ToString();
            historyitem.AppendChild(dateitem);

            XmlElement ratingitem = doc.CreateElement("Rating");
            ratingitem.InnerText = rating;
            historyitem.AppendChild(ratingitem);

            XmlElement notesitem = doc.CreateElement("Notes");
            notesitem.InnerText = notes;
            historyitem.AppendChild(notesitem);

            //Add the node to the document.
            root.AppendChild(historyitem);
            doc.Save(localPath);

            Console.WriteLine($"Saved history to {localPath}");
        }
        void Load()
        {
            History = HistoryItem.LoadFromFile(localPath);
          
            Console.WriteLine($"history list size: {History.Count}");
            
        }
        void Open()
        {
            if (!File.Exists(localPath)) return;
            Console.WriteLine("=====BEGINNING====");
            Console.WriteLine(File.ReadAllText(localPath));
            Console.WriteLine("=====END====");
        }
        void Clear()
        {
            File.Delete(localPath);
        }
    }
}
