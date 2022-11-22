namespace Library
{
    internal class InfField
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }

        public InfField(string fieldName, string fieldType)
        {
            FieldName = fieldName;
            FieldType = fieldType;
        }

        public InfField()
        {
        }
    }
}
