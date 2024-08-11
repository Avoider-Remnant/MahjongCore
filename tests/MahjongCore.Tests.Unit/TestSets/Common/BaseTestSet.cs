namespace MahjongCore.Tests.Unit.TestSets.Common;

using System.Collections;

public  abstract class BaseTestSet : IEnumerable<object[]>
{
    protected readonly List<object?[]> _data = new();
    
    public IEnumerator<object[]> GetEnumerator()
    {
        return _data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}