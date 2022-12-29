using Godot;
using System;

namespace SimpleTopDown.Scripts.Debug
{
    public class MouseDirection : Position2D
    {
        private Sprite _arrow;
        private Vector2 _arrowOffset = new Vector2(30, 0);
        
        public override void _Ready()
        {
            _arrow = GetNode<Sprite>    ("Arrow");
            
            _arrow.Offset = _arrowOffset;
        }

        public override void _Process(float delta)
        {
            Vector2 mousePosition = GetGlobalMousePosition();
            Vector2 vector = mousePosition - GlobalPosition;
            float angle = vector.Angle();
            GlobalRotation = Mathf.LerpAngle(GlobalRotation, angle, 1);
        }
    }
}