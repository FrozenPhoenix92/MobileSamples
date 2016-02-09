using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Samples.Droid.CardViewDemonstration
{
    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        private readonly PhotoAlbum _photoAlbum;

        public event EventHandler<int> ItemClick;

        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            _photoAlbum = photoAlbum;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCardView, parent, false);
            return new PhotoViewHolder(itemView, OnClick);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as PhotoViewHolder;
            if (viewHolder == null) return;
            viewHolder.Image.SetImageResource(_photoAlbum[position].Id);
            viewHolder.Caption.Text = _photoAlbum[position].Caption;
        }

        public override int ItemCount => _photoAlbum.Count;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }
}