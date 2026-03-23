
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
            Text = "Tähestik",
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
            Text = "Korrutustabel",
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
        string v1 = await DisplayActionSheetAsync(
            "Mis on see, mis jookseb, aga jalgu tal pole?",
            "Tühista",
            null,
            "Jõgi",
            "Auto",
            "Koer"
            );
        if (v1 == "Jõgi")
        {
            await DisplayAlertAsync("Õige!", "Sinu vastus on õige!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Sinu vastus on vale! Õige vastus on: Jõgi", "OK");
        }

        string v2 = await DisplayActionSheetAsync(
            "Mis on see, millel on hambad, aga ei hammusta?",
            "Tühista",
            null,
            "Kamm",
            "koer",
            "Hai"
            );
        if (v2 == "Kamm")
        {
            await DisplayAlertAsync("Õige!", "Sinu vastus on õige!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Sinu vastus on vale! Õige vastus on: Kamm", "OK");
        }

        string v3 = await DisplayActionSheetAsync(
            "Mis on see, mida saab murda, aga mitte kunagi käega katsuda?",
            "Tühista",
            null,
            "Lubadus",
            "Klaas",
            "Kivi"
            );
        if (v3 == "Lubadus")
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
        string v1 = await DisplayActionSheetAsync(
            "🐱 + 🐟 = ?",
            "Tühista",
            null,
            "Kass",
            "Kass sööb kala",
            "Koer"
        );

        if (v1 == "Kass sööb kala")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Kass sööb kala", "OK");
        }

        
        string v2 = await DisplayActionSheetAsync(
            "🌞 + 🕶️ = ?",
            "Tühista",
            null,
            "Päike",
            "Päikeseprillid",
            "Suvi"
        );

        if (v2 == "Päikeseprillid")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Päikeseprillid", "OK");
        }

        
        string v3 = await DisplayActionSheetAsync(
            "🐝 + 🍯 = ?",
            "Tühista",
            null,
            "Mesi",
            "Mesilane",
            "Mesilane teeb mett"
        );

        if (v3 == "Mesilane teeb mett")
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
        string v1 = await DisplayActionSheetAsync(
            "Mida tähendab 'koer'?",
            "Tühista",
            null,
            "Koer",
            "Kass",
            "Lind"
        );

        if (v1 == "Koer")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Koer", "OK");
        }

        string v2 = await DisplayActionSheetAsync(
            "Mida tähendab 'päike'?",
            "Tühista",
            null,
            "Kuu",
            "Päike",
            "Täht"
        );

        if (v2 == "Päike")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Päike", "OK");
        }

        string v3 = await DisplayActionSheetAsync(
            "Mida tähendab 'raamat'?",
            "Tühista",
            null,
            "Vihik",
            "Raamat",
            "Pliiats"
        );

        if (v3 == "Raamat")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Raamat", "OK");
        }
    }

    private async Task TahestikGame()
    {
        string v1 = await DisplayActionSheetAsync(
            "Milline täht tuleb pärast A?",
            "Tühista",
            null,
            "B",
            "C",
            "D"
        );

        if (v1 == "B")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: B", "OK");
        }

        string v2 = await DisplayActionSheetAsync(
            "Milline täht tuleb pärast M?",
            "Tühista",
            null,
            "N",
            "O",
            "L"
        );

        if (v2 == "N")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: N", "OK");
        }

        string v3 = await DisplayActionSheetAsync(
            "Milline täht on viimane tähestikus?",
            "Tühista",
            null,
            "Z",
            "Y",
            "X"
        );

        if (v3 == "Z")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: Z", "OK");
        }
    }

    private async Task KorrutustabelGame()
    {
        string v1 = await DisplayPromptAsync(
            "Küsimus",
            "Kui palju on 2 × 3?",
            "OK",
            "Tühista",
            keyboard: Keyboard.Numeric
        );

        if (v1 == "6")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: 6", "OK");
        }

        string v2 = await DisplayPromptAsync(
            "Küsimus",
            "Kui palju on 4 × 5?",
            "OK",
            "Tühista",
            keyboard: Keyboard.Numeric
        );

        if (v2 == "20")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: 20", "OK");
        }

        string v3 = await DisplayPromptAsync(
            "Küsimus",
            "Kui palju on 6 × 2?",
            "OK",
            "Tühista",
            keyboard: Keyboard.Numeric
        );

        if (v3 == "12")
        {
            await DisplayAlertAsync("Õige!", "Tubli!", "OK");
        }
        else
        {
            await DisplayAlertAsync("Vale!", "Õige vastus: 12", "OK");
        }
    }
}