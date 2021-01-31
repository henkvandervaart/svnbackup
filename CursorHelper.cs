using System;
using System.Windows.Forms;

namespace svnbackup
{
    internal class WaitCursor : IDisposable
    {
        private Control _owner = null;
        private Cursor _origCursor;

        public WaitCursor(Control owner)
        {
            _owner = owner;
            if (_owner != null)
            {
                _origCursor = _owner.Cursor;
                _owner.Cursor = Cursors.WaitCursor;
            }
        }

        public void Dispose()
        {
            if (_owner != null)
            {
                _owner.Cursor = _origCursor;
                _owner = null;
            }
        }
    }
}
