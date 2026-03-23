
using AndroidX.Core.View.Accessibility;

namespace SliderAndStepper;

public partial class PopUpPracPage : ContentPage
{
	Button moistatusBtn;
    Button rebusedBtn;
    Button sonastikBtn;
    Button tahestikBtn;
    Button korrutustabelBtn;
	public PopUpPracPage()
	{
        moistatusBtn = new Button
		{
			FontSize = 36,
			Text = "Mõistatused",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60,
            CommandParameter = "Moistatused"
        };
        moistatusBtn.Clicked += OnGameButtonClicked;


        rebusedBtn = new Button
        {
            FontSize = 36,
            Text = "Rebused",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60,
            CommandParameter = "Rebused"
        };
        rebusedBtn.Clicked += OnGameButtonClicked;


        sonastikBtn = new Button
        {
            FontSize = 36,
            Text = "Sõnastik",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60,
            CommandParameter = "Sonastik"
        };
        sonastikBtn.Clicked += OnGameButtonClicked;


        tahestikBtn = new Button
        {
            FontSize = 36,
            Text = "Mõistatused",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60,
            CommandParameter = "Tahestik"
        };
        tahestikBtn.Clicked += OnGameButtonClicked;


        korrutustabelBtn = new Button
        {
            FontSize = 36,
            Text = "Mõistatused",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60,
            CommandParameter = "Korrutustabel"
        };
        korrutustabelBtn.Clicked += OnGameButtonClicked;
        

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Padding = new Thickness(0, 50, 0, 0),

            Children = { moistatusBtn, rebusedBtn, sonastikBtn, tahestikBtn, korrutustabelBtn }
        };
	}

    private async void OnGameButtonClicked(object? sender, EventArgs e)
    {
        var button = sender as Button;
        string game = button?.CommandParameter?.ToString();

        bool result = await DisplayAlertAsync("Kinnita", "Kas soovid mängida?", "Jah", "Ei");

        if (!result)
        {
            return;
        }

        switch (game)
        {
            case "Moistatused":
                await MoistatusGame();
                break;
            case "Rebused":
                await RebusedGame();
                break;
            case "Sonastik":
                await SonastikGame();
                break;
            case "Tahestik":
                await TahestikGame();
                break;
            case "Korrutustabel":
                await KorrutustabelGame();
                break;
        }
    }
    private async Task MoistatusGame()
    {
        // await DisplayActionSheetAsync("Mis on kool?", "Koht kus õpivad inimesed", "Vangla");
        string vastus1 = await DisplayActionSheetAsync(
            "Mis on see, mis jookseb, aga jalgu tal pole?",
            "Tühista",
            null,
            "Jõgi",
            "Auto",
            "Koer"
            );
        if (vastus1 == "Jõgi")
        {
            await DisplayAlertAsync("Õige!", "Sinu vastus on õige!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Sinu vastus on vale! Õige vastus on: Jõgi", "OK");
        }

        string vastus2 = await DisplayActionSheetAsync(
            "Mis on see, millel on hambad, aga ei hammusta?",
            "Tühista",
            null,
            "Kamm",
            "koer",
            "Hai"
            );
        if (vastus2 == "Kamm")
        {
            await DisplayAlertAsync("Õige!", "Sinu vastus on õige!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Sinu vastus on vale! Õige vastus on: Kamm", "OK");
        }

        string vastus3 = await DisplayActionSheetAsync(
            "Mis on see, mida saab murda, aga mitte kunagi käega katsuda?",
            "Tühista",
            null,
            "Lubadus",
            "Klaas",
            "Kivi"
            );
        if (vastus3 == "Lubadus")
        {
            await DisplayAlertAsync("Õige!", "Sinu vastus on õige!", "OK");

        }
        else
        {
            await DisplayAlertAsync("Vale!", "Sinu vastus on vale! Õige vastus on: Lubadus", "OK");
        }

        await DisplayAlertAsync("Mäng läbi!", "Aitäh mängimast!", "OK");
    }

    private async Task RebusedGame()
    {
        string vastus1 = await DisplayActionSheetAsync(
            "🐱 + 🐟 = ?",
            "Tühista",
            null,
            "Kass",
            "Kass sööb kala",
            "Koer"
        );

        if (vastus1 == "Kass sööb kala")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Kass sööb kala", "OK");
        }

        
        string vastus2 = await DisplayActionSheetAsync(
            "🌞 + 🕶️ = ?",
            "Tühista",
            null,
            "Päike",
            "Päikeseprillid",
            "Suvi"
        );

        if (vastus2 == "Päikeseprillid")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Päikeseprillid", "OK");
        }

        
        string vastus3 = await DisplayActionSheetAsync(
            "🐝 + 🍯 = ?",
            "Tühista",
            null,
            "Mesi",
            "Mesilane",
            "Mesilane teeb mett"
        );

        if (vastus3 == "Mesilane teeb mett")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Mesilane teeb mett", "OK");
        }
    }

    private async Task SonastikGame()
    {
        throw new NotImplementedException();
    }

    private async Task TahestikGame()
    {
        throw new NotImplementedException();
    }

    private async Task KorrutustabelGame()
    {
        throw new NotImplementedException();
    }
}