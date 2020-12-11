

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using PicturePicker.Droid.Component.Adapters;
using PicturePicker.Droid.Component.Models;
using System;
using System.Collections.Generic;

namespace PicturePicker.Droid.Component.Dialog
{
    public class PicturePickerDialog : Android.App.Dialog
    {
        public PicturePickerDialog(Context context, EventHandler<PickerEventArgs> callBack) : base(context)
        {
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.PicturePicker);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public void SetCancelButton(string buttonText, EventHandler<DialogClickEventArgs> dcea)
        {
            Button cancel = (Button)FindViewById(Resource.Id.CancelButton);
            if (cancel != null)
            {
                cancel.Text = buttonText;
                cancel.Click += (s, e) =>
                {
                    dcea.Invoke(s, null);
                };
            }


        }

        public void SetPickerTitle(string title)
        {
            TextView titleView = (TextView)FindViewById(Resource.Id.PickerTitle);
            if (titleView != null)
                titleView.Text = title;
        }

        public void SetListViewItems(Action<string> itemSelected)
        {
            if (Context.Resources == null) return;
            List<PicturePickerModel> items = new List<PicturePickerModel>();
            for (int i = 0; i < 10; i++)
            {

                items.Add(new PicturePickerModel()
                {
                    Name = i.ToString(),
                    Picture = Resource.Drawable.ic_mtrl_chip_close_circle,
                    OnClick = (name) => { itemSelected.Invoke(name); }
                });

            }
            RecyclerView recyclerView = (RecyclerView)FindViewById(Resource.Id.PickerItems);
            PicturePickerAdapter simple = new PicturePickerAdapter(this.Context, items);
            LinearLayoutManager layoutManager = new LinearLayoutManager(this.Context, LinearLayoutManager.Vertical, false);

            if (recyclerView != null)
            {
                recyclerView.SetLayoutManager(layoutManager);
                recyclerView.SetAdapter(simple);
            }
        }
    }
}