
using System.ComponentModel.DataAnnotations;
namespace Qimmah.Attributes;
public class CompareWithKeyAttribute : CompareAttribute
{
    public CompareWithKeyAttribute(string otherProperty) : base(otherProperty) { }

    public override string FormatErrorMessage(string key)
    {
        return GetWord(key.ToAnyType<int>()) ?? base.FormatErrorMessage(key);
    }
}