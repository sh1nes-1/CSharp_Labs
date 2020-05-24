
namespace Lab5
{
    internal class MagazineListHandlerEventArgs : System.EventArgs
    {
        public string CollectionName { get; set; }
        public string CollectionChangeType { get; set; }
        public int ElementNumber { get; set; }

        public MagazineListHandlerEventArgs() : this(null, null, 0)
        {          
        }
                
        public MagazineListHandlerEventArgs(string collectionName, string collectionChangeType, int elementNumber)
        {
            CollectionName = collectionName;
            CollectionChangeType = collectionChangeType;
            ElementNumber = elementNumber;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}",
                CollectionName, CollectionChangeType, ElementNumber);
        }
    }
}