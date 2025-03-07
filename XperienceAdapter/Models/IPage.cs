namespace XperienceAdapter.Models;

public interface IPage
{
    static abstract IEnumerable<string> Columns { get; }
}