namespace SliderAndStepper;

public partial class TripsTrapsTrullPage : ContentPage
{
    Grid gr4x1, gr3x3;
    Random rnd = new Random();

    Button uuesti;
    Button playerValik;
    Label label;

    string player = "";
    string[,] ruut = new string[3, 3];
    int kaik = 0;

    int rohelineScore = 0;
    int sinineScore = 0;

    Label scoreLabel;

    public TripsTrapsTrullPage()
    {
        gr4x1 = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star },
            },
        };

        label = new Label
        {
            Text = "Vali kes alustab",
            FontSize = 24,
            HorizontalTextAlignment = TextAlignment.Center
        };

        uuesti = new Button
        {
            Text = "Uus mäng",
            BackgroundColor = Colors.Red,
            WidthRequest = 120,
            HeightRequest = 50
        };
        uuesti.Clicked += Uuesti_Clicked;

        playerValik = new Button
        {
            Text = "Kes alustab?",
            BackgroundColor = Colors.Black,
            TextColor = Colors.White,
            WidthRequest = 120,
            HeightRequest = 50
        };
        playerValik.Clicked += PlayerValik_Clicked;

        scoreLabel = new Label
        {
            Text = "Roheline: 0 | Sinine: 0",
            FontSize = 20,
            HorizontalTextAlignment = TextAlignment.Center
        };

        HorizontalStackLayout nupud = new HorizontalStackLayout
        {
            Spacing = 10,
            HorizontalOptions = LayoutOptions.Center,
            Children = { uuesti, playerValik }
        };

        gr3x3 = Taida_gr3x3();
        gr3x3.HeightRequest = 350;
        gr3x3.WidthRequest = 350;
        gr3x3.HorizontalOptions = LayoutOptions.Center;

        gr4x1.Add(scoreLabel, 0, 0);
        Grid.SetColumnSpan(scoreLabel, 2);

        gr4x1.Add(nupud, 0, 1);
        Grid.SetColumnSpan(nupud, 2);

        gr4x1.Add(gr3x3, 0, 2);
        Grid.SetColumnSpan(gr3x3, 2);

        gr4x1.Add(label, 0, 3);
        Grid.SetColumnSpan(label, 2);

        Content = gr4x1;
    }

    private Grid Taida_gr3x3()
    {
        Grid grid = new Grid();

        for (int i = 0; i < 3; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                BoxView kast = new BoxView
                {
                    BackgroundColor = Colors.White
                };

                Border border = new Border
                {
                    Stroke = Colors.Black,
                    StrokeThickness = 2,
                    Content = kast
                };

                int rida = r;
                int veerg = c;

                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += async (s, e) =>
                {

                    if (string.IsNullOrEmpty(player))
                    {
                        await DisplayAlertAsync("Viga", "Vali enne alustaja!", "OK");
                        return;
                    }

                    if (kast.BackgroundColor != Colors.White)
                        return;

                    if (player == "Roheline")
                    {
                        kast.BackgroundColor = Colors.Green;
                        ruut[rida, veerg] = "R";
                        player = "Sinine";
                        label.Text = "Sinise kord";
                    }
                    else
                    {
                        kast.BackgroundColor = Colors.Blue;
                        ruut[rida, veerg] = "S";
                        player = "Roheline";
                        label.Text = "Rohelise kord";
                    }

                    kaik++;

                    string voitja = VoiduKontroll();

                    if (voitja != null)
                    {
                        string nimi = voitja == "R" ? "Roheline" : "Sinine";

                        if (nimi == "Roheline")
                            rohelineScore++;
                        else
                            sinineScore++;

                        UuendaScore();

                        await DisplayAlertAsync("Võitja", $"{nimi} võitis!", "OK");

                        gr3x3.IsEnabled = false;
                        label.Text = "Vajuta 'Uus mäng'";
                        kaik = 0;
                    }

                    if (kaik == 9)
                    {
                        await DisplayAlertAsync("Viik", "Mäng jäi viiki!", "OK");
                        label.Text = "Vajuta 'Uus mäng'";
                        kaik = 0;
                    }
                };

                kast.GestureRecognizers.Add(tap);
                grid.Add(border, c, r);
            }
        }

        return grid;
    }

    private void UuendaScore()
    {
        scoreLabel.Text = $"Roheline: {rohelineScore} | Sinine: {sinineScore}";
    }

    private string VoiduKontroll()
    {
        for (int i = 0; i < 3; i++)
        {
            if (ruut[i, 0] == ruut[i, 1] &&
                ruut[i, 1] == ruut[i, 2] &&
                ruut[i, 0] != null)
                return ruut[i, 0];
        }

        for (int i = 0; i < 3; i++)
        {
            if (ruut[0, i] == ruut[1, i] &&
                ruut[1, i] == ruut[2, i] &&
                ruut[0, i] != null)
                return ruut[0, i];
        }

        if (ruut[0, 0] == ruut[1, 1] &&
            ruut[1, 1] == ruut[2, 2] &&
            ruut[0, 0] != null)
            return ruut[0, 0];

        if (ruut[0, 2] == ruut[1, 1] &&
            ruut[1, 1] == ruut[2, 0] &&
            ruut[0, 2] != null)
            return ruut[0, 2];

        return null;
    }

    private void PlayerValik_Clicked(object sender, EventArgs e)
    {
        if (player == "" || player == "Sinine")
            player = "Roheline";
        else
            player = "Sinine";

        label.Text = $"{player} alustab";
    }

    private void Uuesti_Clicked(object sender, EventArgs e)
    {
        foreach (var child in gr3x3.Children)
        {
            if (child is Border border && border.Content is BoxView kast)
            {
                kast.BackgroundColor = Colors.White;
            }
        }

        ruut = new string[3, 3];
        kaik = 0;
        player = "";

        gr3x3.IsEnabled = true;
        playerValik.IsEnabled = true;

        rohelineScore = 0;
        sinineScore = 0;
        UuendaScore();

        label.Text = "Vali kes alustab";
    }
}