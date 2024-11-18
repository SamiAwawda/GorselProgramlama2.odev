namespace Gorosel_Odevi;

public partial class ColorPicker : ContentPage
{
 
        int colorR = 0;
        int colorG = 0;
        int colorB = 0;

        public ColorPicker()
        {
            InitializeComponent();
        }

        private void sliderR_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            colorR = (int)e.NewValue;
            UpdateColor();
        }

        private void sliderG_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            colorG = (int)e.NewValue;
            UpdateColor();
        }

        private void sliderB_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            colorB = (int)e.NewValue;
            UpdateColor();
        }

    private void UpdateColor()
    {
        boxv.Color = Color.FromRgb(colorR, colorG, colorB);
        string hexColor = $"#{colorR:X2}{colorG:X2}{colorB:X2}";
        colorCodeLabel.Text = $"Hex: {hexColor}";
    }

    private void ColorCodeLabel_Tapped(object sender, System.EventArgs e)
    {
        string hexColor = $"#{colorR:X2}{colorG:X2}{colorB:X2}";
        Clipboard.SetTextAsync(hexColor);
        DisplayAlert("Kopyalandi", hexColor, "OK");
    }

     void Button_Clicked(object sender, System.EventArgs e)
    {
        
        {
            Random random = new Random();
            colorR = random.Next(256);
            colorG = random.Next(256);
            colorB = random.Next(256);

            sliderR.Value = colorR;
            sliderG.Value = colorG;
            sliderB.Value = colorB;
            UpdateColor();
        }

    }
}