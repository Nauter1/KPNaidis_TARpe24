using Microsoft.Maui.Layouts;

namespace KPNaidis_TARpe24;

public partial class StepperSliderPage : ContentPage
{
	Label lbl;
	Slider sl;
	Stepper st;
	AbsoluteLayout abs;

	public StepperSliderPage()
	{
		lbl = new Label
		{
			BackgroundColor = Color.FromRgb(120, 144, 133),
			Text = ". . ."
		};
		sl = new Slider
		{
			Minimum = 0,
			Maximum = 360,
			Value = 50,
			HorizontalOptions = LayoutOptions.Center,
			MinimumTrackColor = Color.FromRgb(55, 55, 55),
			MaximumTrackColor = Color.FromRgb(0, 0, 0),
			ThumbColor = Color.FromRgb(155, 155, 155),
			WidthRequest = 300
		};
		sl.ValueChanged += Stepper_Slider_ValueChanged;
		st = new Stepper
		{
			Minimum = 0,
			Maximum = 360,
			Increment = 5,
			Value = 25,
			HorizontalOptions = LayoutOptions.Center
		};
		st.ValueChanged += Stepper_Slider_ValueChanged;
		abs = new AbsoluteLayout { Children = { lbl, sl, st } };
		List<View> controls = new List<View> { lbl, sl, st };
		for (int i = 0; i < controls.Count; i++)
		{
			double yKoht = 0.2 + i * 0.2;
			AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, 300, 60));
			AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
		}
		Content = abs;
    }
	private void Stepper_Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
	{
		lbl.Text = $"Stepperi/Slideri Väärtus: {e.NewValue:F0}";
		lbl.FontSize = 24 + e.NewValue / 4;
		lbl.BackgroundColor = Color.FromRgb((int)(e.NewValue * 2.55), (int)(e.NewValue * 2.55), 128);
		lbl.TextColor = Color.FromRgb((int)(255 - e.NewValue * 2.55), (int)(e.NewValue * 2.55), 128);
		lbl.Rotation = e.NewValue;
	}
}