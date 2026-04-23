

using System.Threading.Tasks;

namespace SliderAndStepper;

public partial class TableViewPage : ContentPage
{
    EntryCell nimi, email, telefon, kirjeldus;
    ImageCell foto;
    Editor kiriEditor;
    Button btnHelista, btnSms, btnEmail; 
    TableView table;
	public class Contact
	{
        public string Nimi { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Kirjeldus { get; set; }
        public string Kiri { get; set; }
    }
    Contact contact;

	public TableViewPage()
	{
        contact = new Contact
        {
            Nimi = "",
            Email = "",
            Telefon = "",
            Kirjeldus = "",
            Kiri = "",
        };
        BindingContext = contact;

        nimi = new EntryCell { Label = "Nimi" };
        foto = new ImageCell { Text = "Foto" };
        email = new EntryCell { Label = "Email" };
        telefon = new EntryCell { Label = "Telefon" };
        kirjeldus = new EntryCell { Label = "Kirjeldus" };

        kiriEditor = new Editor
        {
            Placeholder = "Sisesta sõnum",
            AutoSize = EditorAutoSizeOption.TextChanges,
        };
        btnHelista = new Button 
        { 
            Text = "Helista",
            Command = new Command(OnHelistaClicked)
        };
        btnSms = new Button 
        { 
            Text = "SMS",
        };
        btnSms.Clicked += OnSmsClicked;

        btnEmail = new Button 
        { 
            Text = "Email", 
        };
        btnEmail.Clicked += OnEmailClicked;

        nimi.SetBinding(EntryCell.TextProperty, "Nimi");
        foto.SetBinding(ImageCell.ImageSourceProperty, "Foto");
        email.SetBinding(EntryCell.TextProperty, "Email");
        telefon.SetBinding(EntryCell.TextProperty, "Telefon");
        kirjeldus.SetBinding(EntryCell.TextProperty, "Kirjeldus");
        kiriEditor.SetBinding(Editor.TextProperty, "Kiri");

        table = new TableView
        {
            Intent = TableIntent.Data,
            Root = new TableRoot
            {
                new TableSection("Kontakt")
                {
                    nimi,
                    foto,
                    email,
                    telefon,
                    kirjeldus
                },

                new TableSection("Sõnum")
                {
                    new ViewCell
                    {
                        View = kiriEditor
                    }
                },

                new TableSection("Lisavõimalused")
                {
                    new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            HorizontalOptions = LayoutOptions.Center,
                            Spacing = 10,
                            Children =
                            {
                                btnHelista,
                                btnEmail,
                                btnSms
                            }
                        }
                    }
                }
            }
        };

        Content = table;
	}


    void OnHelistaClicked(object obj)
    {
        if (PhoneDialer.Default.IsSupported && !string.IsNullOrWhiteSpace(contact.Telefon))
        {
            PhoneDialer.Default.Open(contact.Telefon);
        }

        else
        {
            DisplayAlertAsync("Viga", "Telefoninumber puudub", "OK");
        }
    }

    async void OnSmsClicked(object obj, EventArgs e)
    {
        string phone = contact.Telefon;
        var message = contact.Kiri;
        SmsMessage sms = new SmsMessage(message, phone);
        if (phone != null && Sms.Default.IsComposeSupported)
        {
            await Sms.Default.ComposeAsync(sms);
        }

        /*
        try
        {
            var message = new SmsMessage(contact.Kiri ?? "", contact.Telefon);
            await Sms.Default.ComposeAsync(message);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Viga", ex.Message, "OK");
        }
        */
    }

    async void OnEmailClicked(object obj, EventArgs e)
    {
        try
        {
            var emailMessage = new EmailMessage
            {
                Subject = "Sõnum sõbrale",
                Body = contact.Kiri ?? "",
                To = new List<string>
                {
                    contact.Email
                }
            };

            await Email.Default.ComposeAsync(emailMessage);
        }

        catch (Exception ex)
        {
            await DisplayAlertAsync("Viga", ex.Message, "OK");
        }
    }
}