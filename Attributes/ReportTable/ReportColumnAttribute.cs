using System.ComponentModel;

namespace Qimmah.Attributes.ReportTable;

[AttributeUsage(AttributeTargets.Class)]
public class ReportRowOptionsAttribute : Attribute
{
    public int ExtraColumns { get; set; }

    public ReportRowOptionsAttribute(int extraColumns)
    {
        ExtraColumns = extraColumns;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class ReportColumnAttribute : Attribute
{
    public string Text { get; private set; }
    public bool IsIncluded { get; set; }
    public bool IsHidden { get; set; }
    [DefaultValue("100px")]
    public string Width { get; set; }
    public bool IsBool { get; set; }
    public string ConditionTrueLocalizaionKey { get; set; }
    public string ConditionFalseLocalizaionKey { get; set; }
    public object ConditionTrueClass { get; private set; }
    public object ConditionFalseClass { get; private set; }
    public int Order { get; private set; }
    public int LocalizationKey { get; set; }

    public ReportColumnAttribute(bool IsIncluded = true, string Width = "", bool IsBool = false, string ConditionTrueLocalizaionKey = null, string ConditionFalseLocalizaionKey = null, string ConditionTrueClass = "", string ConditionFalseClass = "", string Text = null, int Order = int.MaxValue, bool isHidden = false, int LocalizationKey = 0)
    {
        LocalizationKey = LocalizationKey;
        this.Text = Text;
        this.IsIncluded = IsIncluded;
        this.Width = Width;
        this.IsBool = IsBool;
        this.ConditionTrueLocalizaionKey = ConditionTrueLocalizaionKey;
        this.ConditionFalseLocalizaionKey = ConditionFalseLocalizaionKey;
        this.ConditionTrueClass = ConditionTrueClass;
        this.ConditionFalseClass = ConditionFalseClass;
        this.Order = Order;
        IsHidden = isHidden;
    }
}


public class ReportViewDTO
{
    public object Object { get; set; }
    public Dictionary<string, string> Dictionary { get; set; }
    public string TableName { get; set; } = "";
}


