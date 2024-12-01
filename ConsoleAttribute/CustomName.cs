namespace ConsoleAttribute;

[AttributeUsage(AttributeTargets.Field)]
public class CustomName(string name) : Attribute
{
    public readonly string Name = name;
}