using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace LoginPageDemo.Droid.CompoundControls
{
    public class AndroidLoginPageEntry : LinearLayout
    {
        public readonly FrameLayout LeftFrameLayout;
        public readonly ImageView LefImageView;
        public readonly EditText EntryEditText;
        // Code ile initialize edilir. 
        // Diger constructor'ler su anda bize lazim degil 
        // ama axml tarafinda kullanmak isterseniz mutlaka onlarida kullanmalisiniz.
        public AndroidLoginPageEntry(Context context) : base(context)
        {
            // LoginPageEntryLayout'u initialize etmek icin kullaniyoruz
            var inflater = LayoutInflater.From(context);
            inflater.Inflate(Resource.Layout.LoginPageEntryLayout, this);
            // Layout'un icindeki view'leri initialize edelim.
            LeftFrameLayout = FindViewById<FrameLayout>(Resource.Id.LeftView);
            LefImageView = FindViewById<ImageView>(Resource.Id.LeftImage);
            EntryEditText = FindViewById<EditText>(Resource.Id.Entry);
        }
    }
}