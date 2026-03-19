namespace KPNaidis_TARpe24;

public partial class TripsTrapsTrull : ContentPage
{
    /*Grid gr3x3,gr3x1;
    Button s_grid;
    bool Side = true;
    bool isRobot = true;
    int size = 3;
    Label TPlayer;
    Random rnd = new Random();
    VerticalStackLayout vsl = new VerticalStackLayout { };
    string[] board = new string[9];
    int[,] wins =
    {
        {0,1,2},
        {3,4,5},
        {6,7,8},
        {0,3,6},
        {1,4,7},
        {2,5,8},
        {0,4,8},
        {2,4,6}
    };
    public TripsTrapsTrull()
	{
        gr3x1 = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1,GridUnitType.Star)},
                new RowDefinition { Height = new GridLength(2,GridUnitType.Star)},
                new RowDefinition { Height = new GridLength(3,GridUnitType.Star)},
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star)}
            }
        };
        s_grid = new Button
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        s_grid.Pressed += (sender, e) =>
        {

                gr3x3 = täida_gr3x3();
                gr3x1.Add(gr3x3, 0, 2);
                gr3x1.SetColumnSpan(gr3x3, 2);

        };
        gr3x1.Add(s_grid, 1, 3);
        TPlayer = new Label
        {
            Text = "Alustage mäng!",
            HorizontalOptions = LayoutOptions.Center, // Keskele horisontaalselt
            VerticalOptions = LayoutOptions.Center,   // Keskele vertikaalselt
            TextColor = Colors.Black,
            FontAttributes = FontAttributes.Bold
        };
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { TPlayer, gr3x1 },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }

    private Grid täida_gr3x3()
    {
        gr3x3 = new Grid();
        for (int i = 0; i < size; i++)
        {
            gr3x3.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gr3x3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        int index = 0;
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                /*BoxView kast = new BoxView
                {
                    Color = Color.FromRgb(199, 199, 199),
                    WidthRequest = 90,
                    HeightRequest = 90,
                    BackgroundColor = Color.FromRgb(255, 255, 0),
                };

                var sideLabel = new Label
                {
                    FontSize = 40,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                var border = new Border
                {
                    Stroke = Colors.Gray,
                    StrokeThickness = 2,
                    WidthRequest = 90,
                    HeightRequest = 90,
                    Content = sideLabel
                };
                gr3x3.Add(border, c, r); 
                int rida = r;
                int veerg = c;
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.CommandParameter = (sideLabel,index);
                tap.Tapped += OnCellTapped;
                border.GestureRecognizers.Add(tap);
            }
        }
        gr3x3.Padding = 10;
        return gr3x3;
    }
    void OnCellTapped(object sender, TappedEventArgs e)
    {
        var data = ((Label label, int index))e.Parameter;

        if (!string.IsNullOrEmpty(data.label.Text))
            return;

        string player = Side ? "X" : "O";

        data.label.Text = player;
        board[data.index] = player;
        


        Side = !Side;
        TPlayer.Text = Side ? "Käik: X" : "Käik: O";

        if (isRobot && !Side)
        {
            BotMove();
        }
        if (CheckWinner(player))
        {
            DisplayAlertAsync("Game Over", $"{player} wins!", "OK");
            isRobot = false;
            ResetGame();
            return;
        }
    }
    bool CheckWinner(string player)
    {
        for (int i = 0; i < 8; i++)
        {
            if (board[wins[i, 0]] == player &&
                board[wins[i, 1]] == player &&
                board[wins[i, 2]] == player)
            {
                return true;
            }
        }

        return false;
    }

    void ResetGame()
    {
        Side = true;
        TPlayer.Text = "Käik: X";

        board = new string[9];

        foreach (var child in gr3x3.Children)
        {
            if (child is Border border && border.Content is Label label)
            {
                label.Text = "";
            }
        }
    }
    void BotMove()
    {
        Random rnd = new Random();

        List<int> free = new List<int>();

        for (int i = 0; i < board.Length; i++)
        {
            if (string.IsNullOrEmpty(board[i]))
                free.Add(i);
        }

        if (free.Count == 0)
            return;

        int move = free[rnd.Next(free.Count)];

        var border = (Border)gr3x3.Children[move];
        var label = (Label)border.Content;

        label.Text = "O";
        board[move] = "O";

        if (CheckWinner("O"))
        {
            DisplayAlertAsync("Mäng läbi", "Bot (O) võitis!", "OK");
            isRobot = false;
            ResetGame();
            return;
        }

        isRobot = true;
        TPlayer.Text = "Käik: X";
    }*/
    Grid gameGrid;
    bool isXTurn = true;
    Label label2;
    bool playVsBot = false;
    Label modeLabel;

    // Board state
    string[] board = new string[9];

    // Winning combinations
    int[,] wins =
    {
        {0,1,2},
        {3,4,5},
        {6,7,8},
        {0,3,6},
        {1,4,7},
        {2,5,8},
        {0,4,8},
        {2,4,6}
    };
    public TripsTrapsTrull()
    {
        Title = "Trips-Traps-Trull";

        label2 = new Label
        {
            Text = "Käik: X",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        modeLabel = new Label
        {
            Text = "Reziim: Mängija vs Mängija",
            FontSize = 18,
            HorizontalOptions = LayoutOptions.Center
        };

        gameGrid = new Grid
        {
            WidthRequest = 250,
            HeightRequest = 250,
            RowSpacing = 0,
            ColumnSpacing = 0,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        // Create rows and columns
        for (int i = 0; i < 3; i++)
        {
            gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        // Create cells
        int index = 0;

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                var cellLabel = new Label
                {
                    FontSize = 40,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                var border = new Border
                {
                    Stroke = Colors.Gray,
                    StrokeThickness = 2,
                    Content = cellLabel
                };

                var tap = new TapGestureRecognizer();
                tap.CommandParameter = (cellLabel, index);
                tap.Tapped += OnCellTapped;

                border.GestureRecognizers.Add(tap);

                gameGrid.Add(border, col, row);

                index++;
            }
        }

        Button btnReset = new Button
        {
            Text = "Reseti väljak",
            FontSize = 22,
            BackgroundColor = Colors.Red,
            TextColor = Colors.White
        };

        btnReset.Clicked += (s, e) => ResetGame();

        Button btnReeglid = new Button
        {
            Text = "Mängu reeglid",
            FontSize = 22,
            BackgroundColor = Colors.Green,
            TextColor = Colors.White
        };
        btnReeglid.Clicked += (s, e) => M2nguReeglid();

        Button btnBot = new Button
        {
            Text = "Mängi boti vastu",
            FontSize = 22,
            BackgroundColor = Colors.Blue,
            TextColor = Colors.White
        };

        btnBot.Clicked += (s, e) =>
        {
            playVsBot = true;
            modeLabel.Text = "Reziim: Mängija vs Bot";
            ResetGame();
        };

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Children = {
                new Label
                {
                    Text = "Trips Traps Trull",
                    FontSize = 28,
                    HorizontalOptions = LayoutOptions.Center
                },
                label2,
                modeLabel,
                gameGrid,
                btnReset,
                btnReeglid,
                btnBot
            }
        };
    }

    void OnCellTapped(object sender, TappedEventArgs e)
    {
        var data = ((Label label, int index))e.Parameter;

        if (!string.IsNullOrEmpty(data.label.Text))
            return;

        string player = isXTurn ? "X" : "O";

        data.label.Text = player;
        if (isXTurn == false)
        {
            data.label.BackgroundColor = Color.FromRgb(255, 0, 0);
        }
        if (isXTurn == false)
        {
            data.label.BackgroundColor = Color.FromRgb(0, 0, 255);
        }
        board[data.index] = player;


        isXTurn = !isXTurn;
        label2.Text = isXTurn ? "Käik: X" : "Käik: O";

        if (playVsBot && !isXTurn)
        {
            BotMove();
        }
        if (CheckWinner(player))
        {
            DisplayAlertAsync("Game Over", $"{player} wins!", "OK");
            playVsBot = false;
            modeLabel.Text = "Reziim: Mängija vs Mängija";
            ResetGame();
            return;
        }
    }

    bool CheckWinner(string player)
    {
        for (int i = 0; i < 8; i++)
        {
            if (board[wins[i, 0]] == player &&
                board[wins[i, 1]] == player &&
                board[wins[i, 2]] == player)
            {
                return true;
            }
        }

        return false;
    }

    void ResetGame()
    {
        isXTurn = true;
        label2.Text = "Käik: X";

        board = new string[9];

        foreach (var child in gameGrid.Children)
        {
            if (child is Border border && border.Content is Label label)
            {
                label.Text = "";
            }
        }
    }
    void M2nguReeglid()
    {
        DisplayAlertAsync("Trips-Traps-Trull reeglid",
           "1. Mängu mängivad kaks mängijat: X ja O.\n\n" +
           "2. Mängijad teevad käike kordamööda.\n\n" +
           "3. X alustab mängu.\n\n" +
           "4. Eesmärk on saada kolm sama märki (X või O) " +
           "horisontaalselt, vertikaalselt või diagonaalselt.\n\n" +
           "5. Kui kõik ruudud on täis ja keegi ei võida, on mäng viik.",
           "OK");
    }
    void BotMove()
    {
        Random rnd = new Random();

        List<int> free = new List<int>();

        for (int i = 0; i < board.Length; i++)
        {
            if (string.IsNullOrEmpty(board[i]))
                free.Add(i);
        }

        if (free.Count == 0)
            return;

        int move = free[rnd.Next(free.Count)];

        var border = (Border)gameGrid.Children[move];
        var label = (Label)border.Content;

        label.Text = "O";
        board[move] = "O";

        if (CheckWinner("O"))
        {
            DisplayAlertAsync("Mäng läbi", "Bot (O) võitis!", "OK");
            playVsBot = false;
            modeLabel.Text = "Reziim: Mängija vs Mängija";
            ResetGame();
            return;
        }

        isXTurn = true;
        label2.Text = "Käik: X";
    }
}
