using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace PicturePicker.Droid.Component.Holders
{
    public class PicturePickerHolder : RecyclerView.ViewHolder
    {
        public TextView pickerTitle;
        public ImageView pickerImage;
        public PicturePickerHolder(View picker) : base(picker)
        {
            pickerTitle = picker.FindViewById<TextView>(Resource.Id.userTitle);
            pickerImage = picker.FindViewById<ImageView>(Resource.Id.userImage);
        }
    }
}