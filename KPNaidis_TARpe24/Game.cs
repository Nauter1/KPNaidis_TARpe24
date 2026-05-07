using System;
using System.Collections.Generic;
using System.Text;

namespace KPNaidis_TARpe24
{
    public class Game
    {
        public Player CurrentPlayer { get; private set; }
        public Theme CurrentTheme { get; private set; }

        public Grid GameGrid { get; private set; }

        public event Action? OnGameFinished;

        private readonly Random rng = new();

        private readonly List<int> sequence = new();
        private readonly List<Button> buttons = new();

        private int playerIndex = 0;

        private bool isRunning;

        public Game(Player player, Theme theme)
        {
            CurrentPlayer = player;
            CurrentTheme = theme;

            CreateGrid();
        }

        private void CreateGrid()
        {
            GameGrid = new Grid
            {
                WidthRequest = 300,
                HeightRequest = 300
            };

            for (int i = 0; i < 4; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
                //GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            Color[] colors =
            {
            Colors.DarkRed,
            Colors.DarkBlue,
            Colors.DarkGreen,
            Colors.Gold
        };

            int index = 0;

            for (int row = 0; row < 4; row++)
            {
                var btn = new Button
                {
                    BackgroundColor = colors[index],
                    Opacity = 0.7
                };

                int captured = index;

                btn.Clicked += async (s, e) =>
                {
                    await PlayerPressed(captured);
                };

                buttons.Add(btn);

                GameGrid.Add(btn, /*col,*/ row);

                index++;
                /*for (int col = 0; col < 2; col++)
                {

                }*/
            }
        }

        public async Task Start()
        {
            isRunning = true;

            while (isRunning)
            {
                sequence.Add(rng.Next(0, 4));

                await ShowSequence();

                playerIndex = 0;

                // Wait for player
                while (playerIndex < sequence.Count && isRunning)
                {
                    await Task.Delay(100);
                }

                await Task.Delay(1000);
            }
        }

        private async Task ShowSequence()
        {
            foreach (int index in sequence)
            {
                var btn = buttons[index];

                btn.Opacity = 1;

                await Task.Delay(500);

                btn.Opacity = 0.7;

                await Task.Delay(250);
            }
        }

        private async Task PlayerPressed(int index)
        {
            if (!isRunning)
                return;

            if (sequence[playerIndex] == index)
            {
                playerIndex++;

                CurrentPlayer.Points++;
            }
            else
            {
                isRunning = false;

                await Application.Current.MainPage.DisplayAlert(
                    "Game Over",
                    $"Score: {CurrentPlayer.Points}",
                    "OK");

                OnGameFinished?.Invoke();
            }
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}
