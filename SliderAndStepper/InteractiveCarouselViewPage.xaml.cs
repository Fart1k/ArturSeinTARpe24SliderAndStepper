using SliderAndStepper.Services;
using SliderAndStepper.Resources.Localization;

namespace SliderAndStepper;

public partial class InteractiveCarouselViewPage : ContentPage
{
	public class CarouselItems
	{
        public string Title { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string helloWorld { get; set; }
    }
    private CarouselView carouselView;
    private List<CarouselItems> items;
    private int position = 0;

    Button engBtn, etBtn, ruBtn;


    public InteractiveCarouselViewPage()
	{
        Title = AppResources.TitleText;

        items = new List<CarouselItems>
        {
            new CarouselItems
            {
                Title = "C#",
                Details = AppResources.CSharpDesc,
                ImageUrl = "https://tse4.mm.bing.net/th/id/OIP.IBejLuRJ09xlRVSIwrS5DwHaIE?rs=1&pid=ImgDetMain&o=7&rm=3",
                helloWorld = "Console.WriteLine(\"Hello World!\");"

            },
            new CarouselItems
            {
                Title = "Python",
                Details = AppResources.PythonDesc,
                ImageUrl = "https://1.bp.blogspot.com/-bJapstoiThM/XtpvkGBHPKI/AAAAAAAAAqE/Ume0qNfFwk0JSwXZ9qjnB3WKN9dSofeCgCK4BGAsYHg/s1280/language-2024210_1280.png",
                helloWorld = "Print(\"Hello World!\")"
            },
            new CarouselItems
            {
                Title = "JavaScript",
                Details = AppResources.JSDesc,
                ImageUrl = "https://logos-world.net/wp-content/uploads/2023/02/JavaScript-Symbol-500x281.png",
                helloWorld = "console.log(\"Hello World!\");"
            },
            new CarouselItems
            {
                Title = "Java",
                Details = AppResources.JavaDesc,
                ImageUrl = "https://th.bing.com/th/id/R.36f1a4b7c08a60fa161d95d148ba5d45?rik=bO8aQV%2b2fCkd9w&pid=ImgRaw&r=0",
                helloWorld = "System.out.println(\"Hello World!\");"
            },
            new CarouselItems
            {
                Title = "C++",
                Details = AppResources.CPlusDesc,
                ImageUrl = "https://logodix.com/logo/1137946.png",
                helloWorld = "cout << \"Hello World!\";"
            }
        };

        // Localization Buttons and events
        engBtn = new Button
        {
            Text = AppResources.EngBtn,
            Background = Colors.LightBlue,
            TextColor = Colors.White
        };
        engBtn.Clicked += (s, e) =>
        {
            LanguageService.ChangeLanguage("en");
        };


        etBtn = new Button
        {
            Text = AppResources.EtBtn,
            Background = Colors.LightBlue,
            TextColor = Colors.White
        };
        etBtn.Clicked += (s, e) =>
        {
            LanguageService.ChangeLanguage("et");
        };

        ruBtn = new Button
        {
            Text = AppResources.RuBtn,
            Background = Colors.LightBlue,
            TextColor = Colors.White
        };
        ruBtn.Clicked += (s, e) =>
        {
            LanguageService.ChangeLanguage("ru");
        };

        LanguageService.LanguageChanged += RefreshUI;

        carouselView = new CarouselView
        {
            ItemsSource = items,
            HeightRequest = 300,
            IsBounceEnabled = true
        };

        // Buttons layout
        var languageLayout = new HorizontalStackLayout
        {
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.Center,
            Spacing = 10,
            Children =
            {
                engBtn,
                etBtn,
                ruBtn
            }
        };

        // CarouselView template
        carouselView.ItemTemplate = new DataTemplate(() =>
        {
            var frame = new Frame
            {
                CornerRadius = 20,
                HasShadow = true,
                Padding = 0,
                Margin = new Thickness(10),
                BackgroundColor = Colors.Transparent
            };

            var grid = new Grid();

            var image = new Image
            {
                Aspect = Aspect.AspectFit
            };
            image.SetBinding(Image.SourceProperty, "ImageUrl");

            var gradient = new BoxView
            {
                Background = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 1),
                    EndPoint = new Point(0, 0),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Colors.Black.WithAlpha(0.6f), 0),
                        new GradientStop(Colors.Transparent, 1)
                    }
                },
                Opacity = 0.7
            };

            var label = new Label
            {
                TextColor = Colors.White,
                FontSize = 24,
                Margin = new Thickness(20, 0, 20, 50),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Start
            };
            label.SetBinding(Label.TextProperty, "Title");

            var detailsLabel = new Label
            {
                TextColor = Colors.White,
                FontSize = 14,
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.End
            };
            detailsLabel.SetBinding(Label.TextProperty, "Details");

            var tap = new TapGestureRecognizer();
            tap.Tapped += async (s, e) =>
            {
                var tappedItem = ((Frame)s).BindingContext as CarouselItems;
                await DisplayAlertAsync(tappedItem.Title, tappedItem.helloWorld, "OK");
            };
            frame.GestureRecognizers.Add(tap);

            grid.Children.Add(image);
            grid.Children.Add(gradient);
            grid.Children.Add(label);
            grid.Children.Add(detailsLabel);

            frame.Content = grid;
            return frame;
        });


        // Indicator
        var indicatorView = new IndicatorView
        {
            IndicatorColor = Colors.Gray,
            SelectedIndicatorColor = Colors.Blue,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 10)
        };
        carouselView.IndicatorView = indicatorView;


        // Timer
        Device.StartTimer(TimeSpan.FromSeconds(4), () =>
        {
            if (items.Count == 0)
            {
                return false;
            }

            position = (position + 1) % items.Count;
            carouselView.Position = position;

            return true;
        });


        // Content 
        Content = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = GridLength.Auto },
            },

            Children =
            {
                new StackLayout
                {
                    Children =
                    {
                        carouselView,
                        indicatorView
                    }
                },
                languageLayout
            }
        };

        Grid.SetRow(carouselView, 0);
        Grid.SetRow(indicatorView, 0);

        Grid.SetRow(languageLayout, 1);
    }
    public static void RefreshUI()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Application.Current.MainPage = new NavigationPage(new InteractiveCarouselViewPage());

        });
    }
}