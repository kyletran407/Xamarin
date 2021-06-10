namespace XamarinControls.Models
{
    public class ListItem<T> : ListItem
    {
        public new T Key
        {
            get => (T)_key;
            set => _key = value;
        }

        public ListItem(T key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public abstract class ListItem
    {
        protected object _key;
        public object Key
        {
            get => _key;
            set => _key = value;
        }

        public string Value { get; set; }
    }
}