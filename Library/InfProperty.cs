namespace Library
{
    public class InfProperty
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }

        public InfProperty(string propertyName, string propertyType)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
        }

        public InfProperty()
        {
        }
    }
}
