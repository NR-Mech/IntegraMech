namespace Mech.Tests.Base;

public static class TestData
{
    public static IEnumerable<object[]> ValidNames()
    {
        foreach (var name in new List<string>() { "Joao", "Maria" })
        {
            yield return new object[] { name };
        }
    }
}
