using Xamarin.Forms;

namespace LoginPageDemo.CustomEffects
{
    public class UnderlineEffect : RoutingEffect
    {
        public const string EffectNamespace = "LoginPageDemo";
        public UnderlineEffect() : base($"{EffectNamespace}.{nameof(UnderlineEffect)}")
        {
        }
    }
}