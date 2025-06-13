namespace Qimmah.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class CustomHtmlAttribute : Attribute
{
    public string Name { get; }
    public string Value { get; }

    public CustomHtmlAttribute(string name, string value)
    {
        Name = name;
        Value = value;
    }
}