using System.ComponentModel;
using System.Reflection;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Widget;
using LoginPageDemo.CustomControls;
using LoginPageDemo.Droid.CompoundControls;
using LoginPageDemo.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//LoginPageEntry elementi LoginPageEntryRenderer kullanilarak render edilecek.
[assembly:ExportRenderer(typeof(LoginPageEntry),typeof(LoginPageEntryRenderer))]
namespace LoginPageDemo.Droid.CustomRenderers
{
    //                                           Ilk PCL karsiligi, Android karsiligi
    public class LoginPageEntryRenderer:ViewRenderer<LoginPageEntry,AndroidLoginPageEntry>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<LoginPageEntry> e)
        {
            base.OnElementChanged(e);
            
            // Control objesi null gelecek
            if (Control == null)
            {
                var androidLoginPageEntry = new AndroidLoginPageEntry(Context);
                // Forms tarafindaki controlun degerlerini android'de 
                // gorunecek controle aktariyoruz.
                androidLoginPageEntry.EntryEditText.Text = Element.Text;
                androidLoginPageEntry.EntryEditText.Hint = Element.Placeholder;
                androidLoginPageEntry.EntryEditText.SetTextColor(Element.TextColor.ToAndroid());
                androidLoginPageEntry.EntryEditText.SetHintTextColor(Element.PlaceholderColor.ToAndroid());
                if (Element.IsPassword)
                {
                    // Gelen element password girisi oldugu icin OR islemi yapiliyor.
                    androidLoginPageEntry.EntryEditText.InputType |= InputTypes.TextVariationPassword;
                }
                else
                {
                    // Gelen element password girisi olmadigi icin ~ ile AND islemi yapiliyor.
                    // ~ operatoru kisace 1 leri 0, 0 lari 1 yapiyor.
                    androidLoginPageEntry.EntryEditText.InputType &= ~InputTypes.TextVariationPassword;
                }
                // Resmimizi yukleyelim
                Assembly assembly = Assembly.GetAssembly(typeof(LoginPageEntry));
                string resource = ((LoginPageEntry) Element).LeftImageSource;
                System.IO.Stream stream = assembly.GetManifestResourceStream(resource);
                Drawable leftImageDrawable = Drawable.CreateFromStream(stream,nameof(AndroidLoginPageEntry));
                androidLoginPageEntry.LefImageView.SetImageDrawable(leftImageDrawable);
                
                // Radius ozelligini veriyoruz biraz karisik gibi gorunebilir ama mantigi cok kolay
                //var radius = ((LoginPageEntry) Element).CornerRadius;//Bu sekilde alirsak 1 pixele karsilik gelir
                var radius = ((LoginPageEntry) Element).CornerRadius*Resources.DisplayMetrics.Density;// Cihazimizin Density'sinide goz onune almamiz gerekir.
                var leftShape = new GradientDrawable();
                leftShape.SetShape(ShapeType.Rectangle);
                leftShape.SetColor(Element.BackgroundColor.ToAndroid());
                // Her koseyi tek tek belirliyoruz sirasi : solUst, sagUst, sagAlt, solAlt
                leftShape.SetCornerRadii(new float[] {radius,radius,0,0,0,0,radius,radius});
                var rightShape = new GradientDrawable();
                rightShape.SetShape(ShapeType.Rectangle);
                rightShape.SetColor(Element.BackgroundColor.ToAndroid());
                // Her koseyi tek tek belirliyoruz sirasi : solUst, sagUst, sagAlt, solAlt
                rightShape.SetCornerRadii(new float[] { 0, 0,radius, radius, radius, radius,  0, 0 });
                androidLoginPageEntry.EntryEditText.Background = rightShape;
                androidLoginPageEntry.LeftFrameLayout.Background = leftShape;
                //"#323542" Bu degeri hardcoded olarak koydum ama en iyisi static class olusturmak oyle kullanmak
                androidLoginPageEntry.SetBackgroundColor(Android.Graphics.Color.ParseColor("#323542"));

                SetNativeControl(androidLoginPageEntry);
            }
            if (e.OldElement != null)
            {
                // Cleaning resources
                // Subscribe
            }
            if (e.NewElement != null)
            {
                // Unsubscribe
                
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.WidthProperty.PropertyName
                || e.PropertyName == VisualElement.HeightProperty.PropertyName)
            {
                // Ikisininde degerlerinin degistigine emin olalim
                if (Element.Width*Element.Height > 0 && Control != null)
                {
                    // Yuklenen resimin boyutlarini ogreniyoruz
                    var bitmap = ((BitmapDrawable) Control.LefImageView.Drawable).Bitmap;
                    var renderedImageWidth = (int) bitmap.Width*Resources.DisplayMetrics.Density;
                    var renderedImageHeight = (int) bitmap.Height*Resources.DisplayMetrics.Density;
                    // Resmimizin icinde bulundugu imageView width ve height yariya dusuruyoruz.
                    Control.LefImageView.LayoutParameters = 
                        new FrameLayout.LayoutParams((int)renderedImageWidth/2,(int)renderedImageHeight/2);
                    // Resmimizin icinde bulundugu framelayout'umuzun padding degerlerini set ederek
                    // resmimizi ortaliyoruz.
                    var width = (int) (Element.Height*Resources.DisplayMetrics.Density);
                    var height = width;
                    Control.LeftFrameLayout.LayoutParameters= new LinearLayout.LayoutParams(width,height);
                    Control.LeftFrameLayout.SetPadding(((int)(width-bitmap.Width)/2), ((int)(height-bitmap.Height)/2), 0, 0);
                }
            }
        }
    }
}