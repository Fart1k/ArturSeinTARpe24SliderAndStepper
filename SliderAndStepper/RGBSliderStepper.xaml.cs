
using Microsoft.Maui.Layouts;

namespace SliderAndStepper;

public partial class RGBSliderStepper : ContentPage
{
	Frame frameR;
	Stepper stepperR;
	Slider sliderR;

	Frame frameG;
	Stepper stepperG;
	Slider sliderG;

	Frame frameB;
	Stepper stepperB;
	Slider sliderB;

    Stepper sizeStepper;
    Slider sizeSlider;

    Stepper alphaStepper;
    Slider alphaSlider;

	Frame mainColorFrame;

	public RGBSliderStepper()
	{
        // RED
        frameR = new Frame
        {
            WidthRequest = 125,
            HeightRequest = 125,
            CornerRadius = 25,
            BackgroundColor = Colors.Red
        };
		
		stepperR = new Stepper
		{
			Minimum = 0,
			Maximum = 255,
			Increment = 1,
			Value = 0,
			HorizontalOptions = LayoutOptions.Center
		};
		sliderR = new Slider
		{
			Minimum = 0,
			Maximum = 255,
			Value = 0,
			HorizontalOptions = LayoutOptions.Center,
			MinimumTrackColor = Colors.Black,
			MaximumTrackColor = Colors.Red,
			ThumbColor = Colors.Gray,
			WidthRequest = 300
		};

        // GREEN
        frameG = new Frame
        {
            WidthRequest = 125,
            HeightRequest = 125,
            CornerRadius = 25,
            BackgroundColor = Colors.Green
        };
        stepperG = new Stepper
        {
            Minimum = 0,
            Maximum = 255,
            Increment = 1,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center
        };
        sliderG = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.Black,
            MaximumTrackColor = Colors.Green,
            ThumbColor = Colors.Gray,
            WidthRequest = 300
        };

        // BLUE
        frameB = new Frame
        {
            WidthRequest = 125,
            HeightRequest = 125,
            CornerRadius = 25,
            BackgroundColor = Colors.Blue
        };
        stepperB = new Stepper
        {
            Minimum = 0,
            Maximum = 255,
            Increment = 1,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center
        };
        sliderB = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.Black,
            MaximumTrackColor = Colors.Blue,
            ThumbColor = Colors.Gray,
            WidthRequest = 300
        };
        // SIZE
        sizeStepper = new Stepper
        {
            Minimum = 0,
            Maximum = 5,
            Increment = 1,
            Value = 1,
            HorizontalOptions = LayoutOptions.Center
        };
        sizeSlider = new Slider
        {
            Minimum = 0,
            Maximum = 5,
            Value = 1,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.Black,
            MaximumTrackColor = Colors.LightGray,
            ThumbColor = Colors.Gray,
            WidthRequest = 300
        };

        // ALPHA
        alphaStepper = new Stepper
        {
            Minimum = 0,
            Maximum = 1,
            Increment = 0.1,
            Value = 1,
            HorizontalOptions = LayoutOptions.Center
        };
        alphaSlider = new Slider
        {
            Minimum = 0,
            Maximum = 1,
            Value = 1,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.Black,
            MaximumTrackColor = Colors.LightGray,
            ThumbColor = Colors.Gray,
            WidthRequest = 300
        };

        mainColorFrame = new Frame
        {
            WidthRequest = 200,
            HeightRequest = 200,
            CornerRadius = 25,
            BackgroundColor = Colors.Black,
            InputTransparent = true

        };


        sliderR.ValueChanged += Stepper_Slider_ValueChanged;
        stepperR.ValueChanged += Stepper_Slider_ValueChanged;
        sliderG.ValueChanged += Stepper_Slider_ValueChanged;
        stepperG.ValueChanged += Stepper_Slider_ValueChanged;
        sliderB.ValueChanged += Stepper_Slider_ValueChanged;
        stepperB.ValueChanged += Stepper_Slider_ValueChanged;
        sizeSlider.ValueChanged += Stepper_Slider_ValueChanged;
        sizeStepper.ValueChanged += Stepper_Slider_ValueChanged;
        alphaSlider.ValueChanged += Stepper_Slider_ValueChanged;
        alphaStepper.ValueChanged += Stepper_Slider_ValueChanged;


        /*
        List<View> controls = new List<View>
        {
            mainColorFrame, frameR, sliderR, stepperR, frameG, sliderG, stepperG, frameB, sliderB, stepperB
        };

        for (int i = 0; i < controls.Count; i++)
        {
            double yKoht = 0.2 + i * 0.2;
            AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
        }
        */
        Content = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 10,
            Children =
            {
                new HorizontalStackLayout
                {
                    Spacing = 15,
                    HorizontalOptions = LayoutOptions.Center,
                    Children =
                    {
                        frameR, frameG, frameB
                    }
                },

                sliderR, stepperR,
                sliderG, stepperG,
                sliderB, stepperB,
                sizeSlider, sizeStepper,
                alphaSlider, alphaStepper,
                mainColorFrame
            }
        };
    }

    public void Stepper_Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if (sender == sliderR)
        {
            stepperR.Value = sliderR.Value;
            frameR.BackgroundColor = Color.FromRgb((int)sliderR.Value, 0, 0);
        }
            
        else if (sender == stepperR)
        {
            sliderR.Value = stepperR.Value;
        }

        if (sender == sliderG)
        {
            stepperG.Value = sliderG.Value;
            frameG.BackgroundColor = Color.FromRgb(0, (int)sliderG.Value, 0);
        }
        else if (sender == stepperG)
        {
            sliderG.Value = stepperG.Value;
        }

        if (sender == sliderB)
        {
            stepperB.Value = sliderB.Value;
            frameB.BackgroundColor = Color.FromRgb(0, 0, (int)sliderB.Value);
        }
        else if (sender == stepperB)
        {
            sliderB.Value = stepperB.Value;
        }

        if (sender == sizeSlider)
        {
            sizeStepper.Value = sizeSlider.Value;
        }
        else if (sender == sizeStepper)
        {
            sizeSlider.Value = sizeStepper.Value;
        }

        if (sender == alphaSlider)
        {
            alphaStepper.Value = alphaSlider.Value;
        }
        else if (sender == alphaStepper)
        {
            alphaSlider.Value = alphaStepper.Value;
        }

            mainColorFrame.BackgroundColor = Color.FromRgb(
                (int)sliderR.Value,
                (int)sliderG.Value,
                (int)sliderB.Value
            );
        mainColorFrame.Scale = sizeSlider.Value;
        mainColorFrame.Opacity = alphaSlider.Value;

    }
}