namespace ShoppingListBlazorWasm.Server.Services
{
    public class SqlConnectionConfiguration
    {
        public string Value { get; }

        public SqlConnectionConfiguration(string value) => Value = value;
    }
}
