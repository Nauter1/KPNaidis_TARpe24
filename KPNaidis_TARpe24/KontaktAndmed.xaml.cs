namespace KPNaidis_TARpe24;

public partial class KontaktAndmed : ContentPage
{
	EntryCell email;
	EntryCell phonet;
	TableView tabelview;
	SwitchCell sc;
	ImageCell ic;
	TableSection fotosection;
	public KontaktAndmed()
    /*{
		sc = new SwitchCell { Text = "N‰ita veel" };
		sc.OnChanged += Sc_OnChanged;
		ic = new ImageCell
		{
			ImageSource = ImageSource.FromFile("dotnet_bot.png"),
			Text = "Foto nimetus",
			Detail = "Foto kirjeldus"
		};
		phonet = new EntryCell
		{
			Label = "Telefon",
			Placeholder = "Sisesta tel. number",
			Keyboard = Keyboard.Telephone
		};
		email = new EntryCell
		{
			Label = "Email",
			Placeholder = "Sisesta email",
			Keyboard = Keyboard.Email
		};

        fotosection = new TableSection();
		new TableSection("KontaktAndmed:")
		{
			email,
			phonet,		
			sc
		};
        Button emailbutton = new Button
        {
            Text = "Email",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };
        emailbutton.Clicked += Saada_email_Clicked;
        Button smsbutton = new Button
        {
            Text = "SMS",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };
        smsbutton.Clicked += Saada_sms_Clicked;
        Button callbutton = new Button
        {
            Text = "Helista",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };
        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Children = {
                new Label
                {
                    Text = "Sıbra Kontakt!",
                    FontSize = 36,
                    FontFamily = "Digital System 400",
                    TextColor = Colors.Black,
                    HorizontalOptions = LayoutOptions.Center
                },
                tabelview,
                emailbutton,
				smsbutton,
				callbutton
				
            }
        };
        fotosection.Title = "Foto:";
        fotosection.Add(ic);
        sc.Text = "Peida";
    }*/
    {
        sc = new SwitchCell { Text = "N‰ita veel" };
        sc.OnChanged += Sc_OnChanged;

        ic = new ImageCell
        {
            ImageSource = ImageSource.FromFile("dotnet_bot.jpg"),
            Text = "Foto nimetus",
            Detail = "Foto kirjeldus"
        };
        phonet = new EntryCell
        {
            Label = "Telefon",
            Placeholder = "Sisesta tel. number",
            Keyboard = Keyboard.Telephone
        };
        email = new EntryCell
        {
            Label = "Email",
            Placeholder = "Sisesta email",
            Keyboard = Keyboard.Email
        };

        fotosection = new TableSection();
        tabelview = new TableView
        {
            Intent = TableIntent.Form,
            Root = new TableRoot
            {
                new TableSection("Kontaktandmed:")
                {
                    phonet,
                    email,
                    sc
                },
                fotosection
            }
        };
        Button emailbutton = new Button
        {
            Text = "Email",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };
        emailbutton.Clicked += Saada_email_Clicked;
        Button smsbutton = new Button
        {
            Text = "SMS",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };
        smsbutton.Clicked += Saada_sms_Clicked;
        Button callbutton = new Button
        {
            Text = "Helista",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };

        // M‰‰rame TableView lehe peamiseks sisuks
        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Children = {
                new Label
                {
                    Text = "Sıbra Kontakt!",
                    FontSize = 36,
                    FontFamily = "Digital System 400",
                    TextColor = Colors.Black,
                    HorizontalOptions = LayoutOptions.Center
                },
                tabelview,
                emailbutton,
                smsbutton,
                callbutton

            }
        };
    }


    private void Sc_OnChanged(object sender, ToggledEventArgs e)
	{
		if (e.Value)
		{
			fotosection.Title = "Foto:";
			fotosection.Add(ic);
			sc.Text = "Peida";
		}
		else
		{
			fotosection.Title = "";
			fotosection.Remove(ic);
			sc.Text = "N‰ita veel";
		}
	}

	private async void Saada_sms_Clicked(object? sender, EventArgs e)
	{
		string phone = phonet.Text;
		var message = "Tere tulemast! Saadan sınumi :D";
		SmsMessage sms = new SmsMessage(message, phone);
		if (phone != null && Sms.Default.IsComposeSupported)
		{
			await Sms.Default.ComposeAsync(sms);
		}
	}
	private async void Saada_email_Clicked(object? sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(email.Text)) return;
		var message = "Tere tulemast! Saadan email :D";
		EmailMessage e_mail = new EmailMessage
		{
			Subject = email.Text,
			Body = message,
			BodyFormat = EmailBodyFormat.PlainText,
			To = new List<string>(new[] { email.Text})
		};
		if (Email.Default.IsComposeSupported)
		{
			await Email.Default.ComposeAsync(e_mail);
		}
		else
		{
			await DisplayAlertAsync("Viga", "E-maili saatmine pole selles seadmes toetatud", "OK");
		}
	}
}