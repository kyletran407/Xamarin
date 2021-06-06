namespace XamarinControls.Models
{
    public class ListItem<T> : ListItem
    {
        public T Key { get; set; }

        public ListItem(T key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public abstract class ListItem
    {
        public string Value { get; set; }
    }
}