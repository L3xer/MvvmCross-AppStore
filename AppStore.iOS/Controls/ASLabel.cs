using System;
using UIKit;

namespace AppStore.iOS.Controls
{
    public class SALabel : UILabel
    {
        public string LabelText
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value ?? string.Empty;
                OnTextUpdated(new EventArgs());
            }
        }

        public event EventHandler TextUpdated;
        protected virtual void OnTextUpdated(EventArgs e)
        {
            TextUpdated?.Invoke(this, e);
        }
    }
}