using System;

namespace PicturePicker.Droid.Component
{
    public class PickerEventArgs : EventArgs
    {
        public PickerEventArgs() { }
        public string SelectedItem { get; }
    }
}