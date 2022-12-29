using Godot;
using System;

namespace SimpleTopDown.Scripts.Menu
{
    public class PauseScreen : Control
    {
        private Node _game;
        private Button _menuButton;
        private Button _quitButton;

        public override void _Ready()
        {
            _game = GetParent();
            _menuButton = GetNode<Button>   ("CenterContainer/GRatio/CenterContainer/GRatio/VBoxContainer/CenterContainer/GRatioH/VBoxContainer/Menu");
            _quitButton = GetNode<Button>   ("CenterContainer/GRatio/CenterContainer/GRatio/VBoxContainer/CenterContainer/GRatioH/VBoxContainer/Quit");

            _menuButton.Connect("pressed", this, nameof(OnMenuPressed));
            _quitButton.Connect("pressed", this, nameof(OnQuitPressed));

            LoadCustomCursor("res://assets/cursor_center.png");
            Input.MouseMode = Input.MouseModeEnum.Confined;

            this.Hide();
            this.PauseMode = PauseModeEnum.Process;
        }
        
        public override void _UnhandledInput(InputEvent @event)
        {
            ToggleScreen();
        }

        private void LoadCustomCursor(string path)
        {
            Texture image = (Texture)GD.Load(path);
            Vector2 hotspot = new Vector2(image.GetWidth() / 2, image.GetHeight() / 2);
            Input.SetCustomMouseCursor(image, Input.CursorShape.Arrow, hotspot);
        }
        
        private void OnMenuPressed()
        {
            GD.Print("Scene changed to Menu");
        }

        private void OnQuitPressed()
        {
            GetTree().Quit();
        }

        private void ToggleScreen()
        {
            if (Input.IsActionJustPressed("ui_cancel"))
            {
                if (!Visible)
                {
                    _game.GetTree().Paused = true;

                    Input.MouseMode = Input.MouseModeEnum.Visible;
                    Input.SetCustomMouseCursor(null);

                    this.Show();
                }
                else
                {
                    _game.GetTree().Paused = false;

                    Input.MouseMode = Input.MouseModeEnum.Confined;
                    LoadCustomCursor("res://assets/cursor_center.png");

                    this.Hide();
                }
            }
        }
    }
}