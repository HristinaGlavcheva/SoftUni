using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(List<string> stringsToAdd)
        {
            for (int i = 0; i < stringsToAdd.Count; i++)
            {
                this.Push(stringsToAdd[i]);
            }
        }
    }
}
