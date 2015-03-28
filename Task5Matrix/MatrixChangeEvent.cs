using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Matrix
{
    public class MatrixChangeEvent
    {
        public delegate void ChangeEventHandler(object sender, ChangeEventArgs e);

        public event ChangeEventHandler Change;

        public void ChangedElement(int x, int y)
        {
            OnChange(this, new ChangeEventArgs(x, y));
        }

        protected virtual void OnChange(object sender, ChangeEventArgs e)
        {
            if (Change != null)
            {
                Change(sender, e);
            }
        }
    }
    public class ChangeEventArgs : EventArgs
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public ChangeEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
