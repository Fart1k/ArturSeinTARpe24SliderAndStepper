using SliderAndStepper.Resources.Localization;
using System.Globalization;

namespace SliderAndStepper.Services
{
    public class LanguageService
    {
        public static event Action? LanguageChanged;

        public static void ChangeLanguage(string languageCode)
        {
            var culture = new CultureInfo(languageCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            AppResources.Culture = culture;
            LanguageChanged?.Invoke();
        }

        
    }
}
