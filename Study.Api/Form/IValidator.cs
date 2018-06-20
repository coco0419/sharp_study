namespace Study.Api.Form
{
    public interface IValidator
    {
        string Field { get; }

        string Message { get; }

        bool Valid();
    }
}
