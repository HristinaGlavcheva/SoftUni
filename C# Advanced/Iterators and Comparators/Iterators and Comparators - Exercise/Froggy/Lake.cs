using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stonesNumbers;

        public Lake(params int[] inputData)
        {
            this.stonesNumbers = new List<int>(inputData);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stonesNumbers.Count; i+=2)
            {
                yield return this.stonesNumbers[i];
            }

            for (int i = stonesNumbers.Count - 1; i >= 0; i-=1)
            {
                if(i % 2 != 0)
                {
                    yield return this.stonesNumbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
