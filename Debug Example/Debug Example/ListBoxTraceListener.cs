using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Debug_Example
{
    internal class ListBoxTraceListener : TraceListener
    {
        private readonly ListBox ListBox;
        private bool CanWriteToListBox;

        public ListBoxTraceListener(ListBox listBox)
        {
            ListBox = listBox;
            ListBox.HandleCreated += ListBox_HandleCreated;
            ListBox.HandleDestroyed += ListBox_HandleDestroyed;
            CanWriteToListBox = false;
        }
        public override void Write(string message)
        {
            WriteIfPossible(message);
        }

        public override void WriteLine(string message)
        {
            WriteIfPossible(message);
        }

        private void ListBox_HandleDestroyed(object sender, EventArgs e)
        {
            CanWriteToListBox = false;
        }

        private void ListBox_HandleCreated(object sender, EventArgs e)
        {
            CanWriteToListBox = true;
        }


        private void WriteIfPossible(string message)
        {
            if (CanWriteToListBox)
            {
                ListBox.Invoke(new Action<string>(WriteInListBox), message);
            }
        }

        private void WriteInListBox(string message)
        {
            ListBox.Items.Insert(0, message);
        }
    }
}
