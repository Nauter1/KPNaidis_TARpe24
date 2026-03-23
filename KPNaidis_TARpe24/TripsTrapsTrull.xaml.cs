namespace KPNaidis_TARpe24;

public partial class TripsTrapsTrull : ContentPage
{

    Grid gameGrid;
    bool isXTurn = true;
    Label label2;
    bool playVsBot = false;
    Label modeLabel;
    int turnCount = 0;
    int boardSize = 3;


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
            FontSize = 36,
            HorizontalOptions = LayoutOptions.Center,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
        };

        modeLabel = new Label
        {
            Text = "Reziim: Mängija vs Mängija",
            FontSize = 36,
            HorizontalOptions = LayoutOptions.Center,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
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
        for (int i = 0; i < boardSize; i++)
        {
            gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        // Create cells
        int index = 0;

        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
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
            Text = "Reset",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };

        btnReset.Clicked += (s, e) => ResetGame();

        Button btnReeglid = new Button
        {
            Text = "Reeglid",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };
        btnReeglid.Clicked += (s, e) => M2nguReeglid();

        Button btnBot = new Button
        {
            Text = "Automated player",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };

        btnBot.Clicked += (s, e) =>
        {
            playVsBot = true;
            modeLabel.Text = "Reziim: Mängija vs Bot";
            ResetGame();
        };

        Button boardSet = new Button
        {
            Text = "Laua suurus",
            FontSize = 36,
            FontFamily = "Digital System 400",
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            CornerRadius = 10,
            HeightRequest = 60,
        };
        boardSet.Clicked += boardSizeset;

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Children = {
                new Label
                {
                    Text = "Trips Traps Trull",
                    FontSize = 36,
                    FontFamily = "Digital System 400",
                    TextColor = Colors.Black,
                    HorizontalOptions = LayoutOptions.Center
                },
                label2,
                modeLabel,
                gameGrid,
                btnReset,
                btnReeglid,
                btnBot,
                boardSet
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
        if (isXTurn == true)
        {
            data.label.TextColor = Color.FromRgb(255, 0, 0);
        }
        if (isXTurn == false)
        {
            data.label.TextColor = Color.FromRgb(0, 0, 255);
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
            DisplayAlertAsync("Game Over", $"{player} on võitja!", "OK");
            playVsBot = false;
            modeLabel.Text = "Reziim: Mängija vs Mängija";
            ResetGame();
            return;
        }
        turnCount++;
        if (turnCount == (boardSize*boardSize))
        {
            DisplayAlertAsync("Game Over", $"Viik!", "OK");
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
        turnCount = 0;

        board = new string[boardSize*boardSize];

        foreach (var child in gameGrid.Children)
        {
            if (child is Border border && border.Content is Label label)
            {
                label.Text = "";
                label.TextColor = Color.FromRgb(0, 0, 0);
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
        label.TextColor = Color.FromRgb(0, 0, 255);
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
    private async void boardSizeset(object sender, EventArgs e)
    {
        try
        {
            boardSize = int.Parse(await DisplayPromptAsync("Set Number", "Kui suur on laud?", placeholder: "3", keyboard: Keyboard.Numeric));
        }
        catch
        {

        }
        try
        {
            if (boardSize == 0)
            {
                boardSize = 3;
            }
            if (boardSize < 3)
            {
                boardSize = 3;
            }
            gameGrid.RowDefinitions.Clear();
            gameGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < boardSize; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            // Create cells
            int index = 0;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
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
            ResetGame();
        }
        catch
        {

        }
    }
}
