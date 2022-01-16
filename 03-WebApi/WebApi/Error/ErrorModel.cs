namespace WebApi.Error;

public class ErrorModel
{
    public ErrorModel()
    {
        Items = new List<ErrorItem>();
    }

    public ErrorModel(List<ErrorItem> items)
    {
        Items = items;
    }

    public List<ErrorItem> Items { get; set; }

    public class ErrorItem
    {
        public ErrorItem(string description, string code)
        {
            Description = description;
            Code = code;
        }

        public string Description { get; set; }
        public string Code { get; set; }
    }
}
