
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.Threading.Tasks;

namespace SliderAndStepper;

public partial class SnowManPage : ContentPage
{
	Random rnd = new Random();
	uint kiirus = 1000;

    // Snowman

    Frame hat;
    Ellipse head;
    Ellipse bodyOne;
	Ellipse bodyTwo;
	Ellipse leftEye;
	Ellipse rightEye;

    Label opacityLabel;
	Slider opacitySlider;

	Label speedLabel;
	Stepper speedStepper;

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
		leftEye = new Ellipse
		{
			WidthRequest = 10,
			HeightRequest = 10,
			Fill = Colors.Black,
			Stroke = Colors.Black,
			StrokeThickness = 1,
		};
		rightEye = new Ellipse
		{
			WidthRequest = 10,
			HeightRequest = 10,
			Fill = Colors.Black,
			Stroke = Colors.Black,
			StrokeThickness = 1,
		};
        // Opacity
        opacityLabel = new Label
		{
			Text = "Muuda lumememme l‰bipaistvust",
			HorizontalOptions = LayoutOptions.Center,
			FontSize = 20
		};

		opacitySlider = new Slider
		{
			Minimum = 0.0,
			Maximum = 1.0,
			Value = 1.0,
			HorizontalOptions = LayoutOptions.Center,
			MinimumTrackColor = Colors.Black,
			MaximumTrackColor = Colors.Black,
			ThumbColor = Colors.Gray,
			WidthRequest = 300
		};

		opacitySlider.ValueChanged += SliderValueChanged;

		// Speed
		speedLabel = new Label
		{
			Text = "Muuda sulamise kiirust",
			HorizontalOptions = LayoutOptions.Center,
			FontSize = 20
		};

		speedStepper = new Stepper
		{
			Minimum = 1000,
			Maximum = 10000,
			Increment = 100,
			Value = 1000,
			HorizontalOptions = LayoutOptions.Center
		};
		speedStepper.ValueChanged += StepperValueChanged;

		// Picker
		var tegevusteList = new List<string>()
		{
			"Peida lumememm",
			"N‰ita lumememm",
			"Muuda v‰rvi",
			"Tagastada v‰rvi",
			"Sulata",
			"Tantsi",
			"R‰‰gi"
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
			Children = { hat, head, bodyOne, bodyTwo, leftEye, rightEye, speedLabel, speedStepper, opacityLabel, opacitySlider, picker }
		};

		picker.SelectedIndexChanged += PickerSelectedIndexChanged;

        AbsoluteLayout.SetLayoutFlags(leftEye, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(leftEye, new Rect(0.46, -0.3, 10, 10));

        AbsoluteLayout.SetLayoutFlags(rightEye, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(rightEye, new Rect(0.54, -0.3, 10, 10));

        AbsoluteLayout.SetLayoutFlags(bodyTwo, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(bodyTwo, new Rect(0.5, 0.1, 125, 125));

        AbsoluteLayout.SetLayoutFlags(bodyOne, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(bodyOne, new Rect(0.5, -0.23, 100, 100));

        AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(head, new Rect(0.5, -0.43, 75, 75));

        

        AbsoluteLayout.SetLayoutFlags(hat, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(hat, new Rect(0.5, -0.5, 50, 40));

        AbsoluteLayout.SetLayoutFlags(speedLabel, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(speedLabel, new Rect(0.5, 0.47, 300, 40));

        AbsoluteLayout.SetLayoutFlags(speedStepper, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(speedStepper, new Rect(0.5, 0.55, 300, 40));

        AbsoluteLayout.SetLayoutFlags(opacityLabel, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(opacityLabel, new Rect(0.5, 0.7, 400, 40));

        AbsoluteLayout.SetLayoutFlags(opacitySlider, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(opacitySlider, new Rect(0.5, 0.8, 300, 40));

        AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.5, 1, 200, 60));

        Content = al;


		
    }

    public void StepperValueChanged(object? sender, ValueChangedEventArgs e)
    {
		kiirus = (uint)e.NewValue;
		speedLabel.Text = $"Stepperi v‰‰rtus on: {kiirus} ms";
    }

    public void SliderValueChanged(object? sender, ValueChangedEventArgs e)
    {
		double opacityValue = e.NewValue;

		head.Opacity = opacityValue;
		bodyOne.Opacity = opacityValue;
		bodyTwo.Opacity = opacityValue;
		hat.Opacity = opacityValue;

		opacityLabel.Text = $"Slider v‰‰rtus on: {e.NewValue:F1}";
    }

    async void PickerSelectedIndexChanged(object? sender, EventArgs e)
    {
        int r = rnd.Next(256);
        int g = rnd.Next(256);
        int b = rnd.Next(256);
        int selectedIndex = picker.SelectedIndex;

		// Peida lumememm
		if (selectedIndex == 0)
		{
            head.Opacity = 0;
            bodyOne.Opacity = 0;
            bodyTwo.Opacity = 0;
            hat.Opacity = 0;
        }

		// N‰ita lumememm
		else if (selectedIndex == 1)
		{
            head.Opacity = 1;
            bodyOne.Opacity = 1;
            bodyTwo.Opacity = 1;
            hat.Opacity = 1;

            head.Scale = 1;
            bodyOne.Scale = 1;
            bodyTwo.Scale = 1;
            hat.Scale = 1;
        }

		// Muuda v‰rvi
		else if (selectedIndex == 2)
		{
			head.Fill = Color.FromRgb(r, g, b);
			bodyOne.Fill = Color.FromRgb(r, g, b);
			bodyTwo.Fill = Color.FromRgb(r, g, b);
        }

		// Tagastada v‰rvi
		else if (selectedIndex == 3)
		{
			head.Fill = Colors.White;
			bodyOne.Fill = Colors.White;
			bodyTwo.Fill = Colors.White;
        }

		// Sulata
		else if (selectedIndex == 4)
		{
			await SulataLumememm();
		}

		// Tantsi
		else if (selectedIndex == 5)
		{
			await Tantsi1();
            await Tantsi2();
            await Tantsi3();
            await Tantsi4();
            await Tantsi5();
            await Tantsi3();
        }
		else if (selectedIndex == 6)
		{
			await TextToSpeech.SpeakAsync("Jıulud tulevad!");
        }
    }

    async Task SulataLumememm()
    {
        await Task.WhenAll(
                    head.ScaleToAsync(0, 1000),
                    bodyOne.ScaleToAsync(0, 2000),
                    bodyTwo.ScaleToAsync(0, 3000),
                    hat.ScaleToAsync(0, 1000),
					leftEye.ScaleToAsync(0, 1000),
					rightEye.ScaleToAsync(0, 1000),

                    head.FadeToAsync(0, kiirus),
                    bodyOne.FadeToAsync(0, kiirus),
                    bodyTwo.FadeToAsync(0, kiirus),
                    hat.FadeToAsync(0, kiirus),
                    leftEye.FadeToAsync(0, kiirus),
                    rightEye.FadeToAsync(0, kiirus)
                );
    }

    private async Task Tantsi5()
    {
        await Task.WhenAll(
				rightEye.TranslateToAsync(-200, 0, 700),
				leftEye.TranslateToAsync(-200, 0, 700),
                hat.TranslateToAsync(200, 0, 700),
                head.TranslateToAsync(-200, 0, 700),
                bodyOne.TranslateToAsync(200, 0, 700),
                bodyTwo.TranslateToAsync(-200, 0, 700)
            );
    }

    private async Task Tantsi4()
    {
        await Task.WhenAll(
				rightEye.TranslateToAsync(200, 0, 700),
				leftEye.TranslateToAsync(200, 0, 700),
                hat.TranslateToAsync(-200, 0, 700),
                head.TranslateToAsync(200, 0, 700),
                bodyOne.TranslateToAsync(-200, 0, 700),
                bodyTwo.TranslateToAsync(200, 0, 700)
            );
    }

    private async Task Tantsi3()
    {
        await Task.WhenAll(
				rightEye.TranslateToAsync(0, 0, 700),
				leftEye.TranslateToAsync(0, 0, 700),
                hat.TranslateToAsync(0, 0, 700),
                head.TranslateToAsync(0, 0, 700),
                bodyOne.TranslateToAsync(0, 0, 700),
                bodyTwo.TranslateToAsync(0, 0, 700)
            );
    }

    private async Task Tantsi2()
    {
        await Task.WhenAll(
				rightEye.TranslateToAsync(-200, 0, 700),
				leftEye.TranslateToAsync(-200, 0, 700),
                hat.TranslateToAsync(-200, 0, 700),
                head.TranslateToAsync(-200, 0, 700),
                bodyOne.TranslateToAsync(-200, 0, 700),
                bodyTwo.TranslateToAsync(-200, 0, 700)
            );
    }

    private async Task Tantsi1()
    {
		await Task.WhenAll(
				rightEye.TranslateToAsync(200, 0, 700),
				leftEye.TranslateToAsync(200, 0, 700),
                hat.TranslateToAsync(200, 0, 700),
				head.TranslateToAsync(200, 0, 700),
                bodyOne.TranslateToAsync(200, 0, 700),
				bodyTwo.TranslateToAsync(200, 0, 700)
            );
    }
}