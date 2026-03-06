
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace SliderAndStepper;

public partial class SnowManPage : ContentPage
{
	// Snowman

	Frame hat;
    Ellipse head;
    Ellipse bodyOne;
	Ellipse bodyTwo;

	Slider = 


	Picker picker;
	
	AbsoluteLayout al;
	public SnowManPage()
	{
		hat = new Frame
		{
			WidthRequest = 40,
			HeightRequest = 50,
			BorderColor = Colors.Black,
			BackgroundColor = Colors.LightGray
		};
		head = new Ellipse
		{
			WidthRequest = 75,
			HeightRequest = 75,
			Fill = Colors.White,
			Stroke = Colors.Black,
			StrokeThickness = 2,
		};
		bodyOne = new Ellipse
		{
			WidthRequest = 100,
			HeightRequest = 100,
            Fill = Colors.White,
            Stroke = Colors.Black,
            StrokeThickness = 2,
        };
		bodyTwo = new Ellipse
		{
			WidthRequest = 125,
			HeightRequest = 125,
            Fill = Colors.White,
            Stroke = Colors.Black,
            StrokeThickness = 2,
        };

		var tegevusteList = new List<string>()
		{
			"Peida lumememm",
			"Näita lumememm",
			"Muuda värvi",
			"Sulata",
			"Tantsi"
		};
		picker = new Picker
		{
			Title = "Vali tegevus: ",
			ItemsSource = tegevusteList,
			HorizontalOptions = LayoutOptions.Center
        };
		al = new AbsoluteLayout
		{
			HeightRequest = 400,
			Children = { hat, head, bodyOne, bodyTwo, picker }
		};

		picker.SelectedIndexChanged += PickerSelectedIndexChanged;

        AbsoluteLayout.SetLayoutFlags(bodyTwo, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(bodyTwo, new Rect(0.5, 0.1, 125, 125));

        AbsoluteLayout.SetLayoutFlags(bodyOne, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(bodyOne, new Rect(0.5, -0.23, 100, 100));

        AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(head, new Rect(0.5, -0.43, 75, 75));

        AbsoluteLayout.SetLayoutFlags(hat, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(hat, new Rect(0.5, -0.5, 50, 40));

        AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.5, 1, 50, 40));

        Content = al;


		
    }

    public void PickerSelectedIndexChanged(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}