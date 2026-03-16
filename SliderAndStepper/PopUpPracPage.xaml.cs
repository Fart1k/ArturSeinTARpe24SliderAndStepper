using System.Threading.Tasks;

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
            HeightRequest = 60
        };
        moistatusBtn.Clicked += MoistatusBtn_Clicked;


        rebusedBtn = new Button
        {
            FontSize = 36,
            Text = "Rebused",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60
        };
        rebusedBtn.Clicked += RebusedBtn_Clicked;


        sonastikBtn = new Button
        {
            FontSize = 36,
            Text = "Sõnastik",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60
        };
        sonastikBtn.Clicked += SonastikBtn_Clicked;


        tahestikBtn = new Button
        {
            FontSize = 36,
            Text = "Mõistatused",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60
        };
        tahestikBtn.Clicked += TahestikBtn_Clicked;


        korrutustabelBtn = new Button
        {
            FontSize = 36,
            Text = "Mõistatused",
            FontFamily = "Socafe",
            BackgroundColor = Colors.DarkMagenta,
            TextColor = Colors.White,
            CornerRadius = 10,
            HeightRequest = 60
        };
        korrutustabelBtn.Clicked += KorrutustabelBtn_Clicked;

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Padding = new Thickness(0, 50, 0, 0),

            Children = { moistatusBtn, rebusedBtn, sonastikBtn, tahestikBtn, korrutustabelBtn }
        };
	}

    private void KorrutustabelBtn_Clicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void TahestikBtn_Clicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void SonastikBtn_Clicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void RebusedBtn_Clicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async void MoistatusBtn_Clicked(object? sender, EventArgs e)
    {
        bool result = await DisplayAlertAsync("Kinnita", "Kas sa oled kindel?", "Jah", "Ei");

        if (result)
        {
            await DisplayAlertAsync("Jätkame", "Sinu valik: Jah", "Ok");
            await MoistatusGame();
        }
        else
        {
            await DisplayAlertAsync("Ei jätka", "Sinu valik: Ei", "Ok");
            return;
        }
        return;
    }

    private async Task MoistatusGame()
    {
        // await DisplayActionSheetAsync("Mis on kool?", "Koht kus õpivad inimesed", "Vangla");


    }
}