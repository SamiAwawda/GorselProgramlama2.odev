namespace Gorosel_Odevi { 

public partial class Body : ContentPage
{
	public Body()
	{
		InitializeComponent();
	}
    private void OnCalculateClicked(object sender, EventArgs e)
    {
      
        if (double.TryParse(KiloEntry.Text, out double kilo) &&
            double.TryParse(boyEntry.Text, out double boy) &&
            boy > 0 )
        {
            double vki = vki_hesapla(kilo, boy);
            String soncu = sonuc_raporu(vki);
            bmiLabel.Text = $"VKI: {vki:F2} {soncu}";
        }
        else
        {
            bmiLabel.Text = "Invalid input. Please enter valid values.";
        }
    }

    private double vki_hesapla(double kilo, double boy)
    {
        return kilo / (boy * boy);
    }

    

    private void KiloSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        KiloEntry.Text = e.NewValue.ToString("0");

    }

    private void boySlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        boyEntry.Text = e.NewValue.ToString("");

    }
    private String sonuc_raporu(double vki)
    {
        String rapor;

        if (vki < 16)
        {
            rapor = "Ileri düzeyde zayıf";
        }
        else if (16 <= vki && vki <= 16.99)
        {
            rapor = "Orta düzeyde Zayıf";
        }
        else if (17 <= vki && vki <= 18.49)
        {
            rapor = "Hafif Düzeyde Zayıf";
        }
        else if (18.50 <= vki && vki <= 24.9)
        {
            rapor = "Normal kilo";
        }
        else if (25 <= vki && vki <= 29.99)
        {
            rapor = "Hafif şişman / fazla kilolu";
        }
        else if (30 <= vki && vki <= 34.99)
        {
            rapor = "1. derece obez";
        }
        else if (35 <= vki && vki <= 39.99)
        {
            rapor = "2. derece obez";
        }
        else if (vki >= 40)
        {
            rapor = "3. derece obez / Morbid obez";
        }
        else
        {
            rapor = "Hata oldu";
        }

        return rapor;
    }


}
}
