using Android.Content;
using PicturePicker.Components;
using PicturePicker.Droid.Component.Dialog;
using PicturePicker.Droid.Component.Renderer;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(PicturePickerRenderer))]
namespace PicturePicker.Droid.Component.Renderer
{
    public class PicturePickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        private PicturePickerDialog _dialog { get; set; }
        private CustomPicker _element { get; set; }
        public PicturePickerRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null || e.NewElement == null) return;

            if (e.OldElement == null && e.NewElement == null) return;
            _element = e.NewElement as CustomPicker;
            this.Control.Click += OnPickerClick;

        }

        void OnPickerClick(object sender, EventArgs e)
        {
            OpenPicker();
        }

        void OpenPicker()
        {
            CreateNewPickerDialog();
            _dialog.Show();
        }

        void CreateNewPickerDialog()
        {
            CustomPicker view = _element;

            _dialog = new PicturePickerDialog(Context, (o, e) =>
            {
                //Clear focus when it is destroyed
                Control.ClearFocus();
                //Set to null after clearing focus
                _dialog = null;
            });
            
            _dialog.SetListViewItems((name) =>
            {
                view.SelectedItem = name;
                _dialog.Dismiss();
            });
            
            _dialog.SetCancelButton("Cancel", (s, o) =>
            {
                _dialog.Dismiss();
            });

            _dialog.SetPickerTitle(view.Title);

        }
    }

}