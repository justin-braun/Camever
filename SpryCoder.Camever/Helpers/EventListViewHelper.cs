using System;
using System.Windows.Forms;

namespace SpryCoder.Camever.Helpers
{
    public class EventListViewHelper
    {
        private readonly MainForm _mf;
        public enum LogEntryType { Error, Information }
        public EventListViewHelper(MainForm mainForm)
        {
            _mf = mainForm;
        }

        public void AddEvent(string logText, LogEntryType logType)
        {
            ListViewItem lvi = new ListViewItem(DateTime.Now.ToString());
            lvi.SubItems.Add(logType.ToString());
            lvi.SubItems.Add(logText);

            if (_mf.listViewEvents.Items.Count == 0)
            {
                _mf.listViewEvents.Items.Add(lvi);
            }
            else
            {
                _mf.listViewEvents.Items.Insert(0, lvi);
            }
            

            // Remove entry if greater than 50
            if (_mf.listViewEvents.Items.Count >= 50)
                _mf.listViewEvents.Items.RemoveAt(_mf.listViewEvents.Items.Count - 1);
        }
    }
}
