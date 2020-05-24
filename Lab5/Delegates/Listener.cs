using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    internal class Listener
    {
        public List<ListEntry> ListenerList { get; set; }

        public Listener()
        {
            ListenerList = new List<ListEntry>();
        }
        
        public void AddEvent(object source, MagazineListHandlerEventArgs args)
        {
            ListEntry entry = new ListEntry(args.CollectionName, args.CollectionChangeType, args.ElementNumber);
            ListenerList.Add(entry);
        }
        
        public override string ToString()
        {
            return string.Format("{0}", string.Join("\n", ListenerList.Select(x => x.ToString()).ToArray()));
        }
    }
}