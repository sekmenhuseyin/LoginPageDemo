using System.ComponentModel;
using Android.Graphics.Drawables;
using LoginPageDemo.CustomControls;
using LoginPageDemo.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly:ExportRenderer(typeof(SigninButton),typeof(LoginPageSigninButtonRenderer))]
namespace LoginPageDemo.Droid.CustomRenderers
{
    public class LoginPageSigninButtonRenderer:ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                var roundableShape = new GradientDrawable();
                roundableShape.SetShape(ShapeType.Rectangle);
                roundableShape.SetColor(Element.BackgroundColor.ToAndroid());
                roundableShape.SetCornerRadius(Element.BorderRadius*Resources.DisplayMetrics.Density);
                Control.Background = roundableShape;
                Control.TransformationMethod = null;
                Control.Elevation = 0;
            }
        }
    }
}