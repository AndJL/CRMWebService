namespace CRM_Web_Service.QueryBuilders.Definitions.FilterDefinitions
{
    public class EqualFilterDefinition<T> : FilterDefinition<T>
    {
        private readonly string _property;
        private readonly string _value;

        public EqualFilterDefinition(string property, string value)
        {
            _property = property;
            _value = value;
        }

        public override string Render()
        {
            return $"$filter={_property} eq {_value}";
        }
    }
}