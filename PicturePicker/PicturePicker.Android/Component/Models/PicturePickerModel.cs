
using System;

namespace PicturePicker.Droid.Component.Models
{
    public class PicturePickerModel
    {
        public string Name { get; set; }
        public int Picture { get; set; }
        public Action<string> OnClick { get; set; }
    }
}