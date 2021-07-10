using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Task2
{
    public class Form : IComponent
    {
        string name;
        List<IComponent> components = new List<IComponent>();

        public Form(string name)
        {
            this.name = name;
        }

        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public string ConvertToString(int depth = 0)
        {
            string tabs = new string(' ', depth);
            string opening = $"{tabs}<form name='{name}'>\n";
            string closure = $"{tabs}</form>";

            StringBuilder body = new StringBuilder(opening);

            foreach (var component in components)
            {
                body.AppendLine(component.ConvertToString(depth + 1));
            }

            body.Append(closure);
            return body.ToString();
        }
    }
}