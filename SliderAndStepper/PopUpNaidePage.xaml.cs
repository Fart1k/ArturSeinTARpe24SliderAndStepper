namespace SliderAndStepper;

public partial class PopUpNaidePage : ContentPage
{
	public PopUpNaidePage()
	{
		Button alertButton = new Button
		{
			Text = "Teade",
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.Center
		};

		alertButton.Clicked += AlertButton_Clicked;

		Button alertYesNoButton = new Button
		{
			Text = "Jah või ei",
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.Center
		};

		alertYesNoButton.Clicked += AlertYesNoButton_Clicked;

		Button alertListButton = new Button
		{
			Text = "Valik",
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.Center
		};

		alertListButton.Clicked += AlertListButton_Clicked;

		Button alertQuestButton = new Button
		{
			Text = "Küsimus",
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.Center
		};

		alertQuestButton.Clicked += AlertQuestButton_Clicked; 

		Content = new VerticalStackLayout
		{
			Spacing = 20,
			Padding = new Thickness(0, 50, 0, 0),

			Children = { alertButton, alertYesNoButton, alertListButton, alertQuestButton }
		};

		
    }

    private async void AlertQuestButton_Clicked(object? sender, EventArgs e)
    {
		string result1 = await DisplayPromptAsync("Küsimus", "Kuidas läheb?", placeholder: "Tore!");
		string result2 = await DisplayPromptAsync("Vasta", "Millega võrdub 5 + 5?", initialValue:
			"10", maxLength: 2, keyboard: Keyboard.Numeric);
    }

    private async void AlertListButton_Clicked(object? sender, EventArgs e)
    {
        string action = await DisplayActionSheetAsync("Vali tegevus", "Loobu", "Kustutada", "Tantsida", "Laulda", "Joonestada");

        if (action != null && action != "Loobu")
        {
			await DisplayAlertAsync("Valik", "Sa valisid tegevuse: " + action, "OK");
        }
    }

    private async void AlertYesNoButton_Clicked(object? sender, EventArgs e)
    {
        bool result = await DisplayAlertAsync("Kinnita", "Kas olete kindel?", "Jah", "Ei");

		await DisplayAlertAsync("Tulemus", "Te valisite: " + (result ? "Jah" : "Ei"), "OK");
    }

    private async void AlertButton_Clicked(object? sender, EventArgs e)
    {
		await DisplayAlertAsync("Teade", "Teil on uus teade", "OK");
    }
}