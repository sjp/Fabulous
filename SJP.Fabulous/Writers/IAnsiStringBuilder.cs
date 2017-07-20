namespace SJP.Fabulous
{
    public interface IAnsiStringBuilder
    {
        string ToAnsiString();

        string ToAnsiString(params object[] args);
    }
}
