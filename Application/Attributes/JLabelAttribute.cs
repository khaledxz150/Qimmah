using System.Linq.Expressions;

namespace Qimmah.Attributes;

/// <summary>
/// A custom attribute to specify localization keys for properties.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
public class JLabelAttribute : Attribute
{
    public int Key { get; }

    public JLabelAttribute(int key)
    {
        Key = key;
    }


}

