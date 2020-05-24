
namespace Lab5
{
    internal class ListEntry
    {
        public string CollectionName { get; set; }
        public string CollectionChangeType { get; set; }
        public int ElementNumber { get; set; }
        
        public ListEntry() : this(null, null, 0)
        {          
        }
                
        public ListEntry(string collectionName, string collectionChangeType, int elementNumber)
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