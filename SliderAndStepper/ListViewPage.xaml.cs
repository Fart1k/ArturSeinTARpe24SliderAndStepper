using System.Collections.ObjectModel;

namespace SliderAndStepper;

public partial class ListViewPage : ContentPage
{
    public class Telefon
    {
        public string Nimetus { get; set; }
        public string Tootja { get; set; }
        public int Hind { get; set; }
        public string Pilt { get; set; }
    }
    public ObservableCollection<Telefon> telefons { get; set; }

    Button btnKustuta, btnLisa;
    ListView list;
	public ListViewPage()
	{
        telefons = new ObservableCollection<Telefon>
        {
            new Telefon {Nimetus="Samsung Galaxy S22 Ultra", Tootja="Samsung", Hind=1349, Pilt="Galaxy.png"},
            new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G NE", Tootja="Xiaomi", Hind=399, Pilt="Xiaomi5GNE.png"},
            new Telefon {Nimetus="iPhone 13 mini", Tootja="Apple", Hind=1179, Pilt="iPhone13.png"}
        };

        btnKustuta = new Button
        {
            Text = "Kustuta"
        };
        btnKustuta.Clicked += Kustuta_Clicked;

        btnLisa = new Button
        {
            Text = "Lisa",
        };
        btnLisa.Clicked += Lisa_Clicked;

        list = new ListView
        {
            HasUnevenRows = true,
            ItemsSource = telefons,
            ItemTemplate = new DataTemplate(() =>
            {
                Label nimetus = new Label { FontSize = 20 };
                nimetus.SetBinding(Label.TextProperty, "Nimetus");

                Label hind = new Label();
                hind.SetBinding(Label.TextProperty, "Hind");

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Vertical,
                        Children =
                        {
                            nimetus, hind
                        }
                    }
                };
            })
        };

        list.ItemTapped += List_ItemTapped;

        Content = list;
	}

    private void Kustuta_Clicked(object obj, EventArgs e)
    {
        Telefon phone = list.SelectedItem as Telefon;

        if (phone != null)
        {
            telefons.Remove(phone);
            list.SelectedItem = null;
        }
    }

    private void Lisa_Clicked(object obj, EventArgs e)
    {
        
    }

    private async void List_ItemTapped(object? sender, ItemTappedEventArgs e)
    {
        Telefon selectedPhone = e.Item as Telefon;

        if (selectedPhone != null)
        {
            await DisplayAlertAsync("Valitud mudel", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "OK");
        }
    }
}