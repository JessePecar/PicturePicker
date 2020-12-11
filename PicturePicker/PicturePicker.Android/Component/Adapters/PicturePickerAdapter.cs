using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using PicturePicker.Droid.Component.Holders;
using PicturePicker.Droid.Component.Models;
using System;
using System.Collections.Generic;

namespace PicturePicker.Droid.Component.Adapters
{
    public class PicturePickerAdapter : RecyclerView.Adapter
    {
        private readonly Context _context;
        private readonly List<PicturePickerModel> _models;

        public PicturePickerAdapter(Context context, List<PicturePickerModel> models)
        {
            _context = context;
            _models = models;
        }


        public override int ItemCount => _models.Count;



        public override long GetItemId(int position)
        {
            return position;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {

                PicturePickerModel model = _models[position];

                PicturePickerHolder pickerHolder = holder as PicturePickerHolder;
                pickerHolder.pickerTitle.SetText(model.Name.ToCharArray(), 0, model.Name.Length);
                pickerHolder.pickerImage.SetImageResource(model.Picture);
                pickerHolder.ItemView.Click += (s, e) => model.OnClick.Invoke(model.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(_context);
            View view = inflater.Inflate(Resource.Layout.PickerListView, null);
            return new PicturePickerHolder(view);
        }

    }
}