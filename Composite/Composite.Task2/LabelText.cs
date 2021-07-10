using System;

namespace Composite.Task2
{
    public class LabelText : IComponent
    {
        string value;

        public LabelText(string value)
        {
            this.value = value;
        }

        public string ConvertToString(int depth = 0)
        {
            string tabs = new string(' ', depth);

            return $"{tabs}<label value='{value}'/>";
        }
    }
}
