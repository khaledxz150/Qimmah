using Qimmah.Enums.Navigation;

namespace Qimmah.Attributes.FilterAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ActiveTabAttribute : Attribute
    {
        public ActiveTabAttribute(TabOptions tab)
        {
            Tab = tab;
        }

        public TabOptions Tab { get; private set; } 
    }
}
