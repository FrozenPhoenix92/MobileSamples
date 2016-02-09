using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;

namespace Samples.Droid.CardViewDemonstration
{
    [Activity(Label = "Демонстрация CardView", Theme = "@android:style/Theme.Material.Light.DarkActionBar", 
        ParentActivity = typeof(MainActivity))]
    public class CardViewActivity : Activity
    {
        private RecyclerView.LayoutManager _layoutManager;
        private PhotoAlbumAdapter _albumAdapter;
        private PhotoAlbum _album;

        private RecyclerView _recyclerView;
        private Button _button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CardViewLayout);

            InitComponents();

            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);

            _album = new PhotoAlbum();
            _albumAdapter = new PhotoAlbumAdapter(_album);
            _albumAdapter.ItemClick += albumAdapter_ItemClick;
            _recyclerView.SetAdapter(_albumAdapter);
        }

        private void InitComponents()
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _button = FindViewById<Button>(Resource.Id.randPickButton);

            _button.Click += button_Click;
        }

        private void button_Click(object sender, System.EventArgs e)
        {
            if (_album == null) return;
            var index = _album.RandomSwap();
            _albumAdapter.NotifyItemChanged(0);
            _albumAdapter.NotifyItemChanged(index);
        }

        private void albumAdapter_ItemClick(object sender, int position)
        {
            var photoNumber = position + 1;
            Toast.MakeText(this, "Номер фото: " + photoNumber, ToastLength.Short).Show();
        }
    }
}