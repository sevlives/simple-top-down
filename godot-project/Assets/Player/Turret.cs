using Godot;
using System;

namespace SimpleTopDown.Assets.Player
{
    public class Turret : Sprite
    {
        private Vector2 _mousePosition;
        private float _rotateSpeed = 1.7f;
        public override void _PhysicsProcess(float delta)
        {
            _mousePosition = GetGlobalMousePosition();
            // Rotated() used due to incorret image importing, thus needs to be rotated 90' clockwise
            Vector2 _vector = (_mousePosition - GlobalPosition).Rotated(Mathf.Pi*.5f);
            float _angle = _vector.Angle();
            float _rotation = GlobalRotation;
            // amount of rotation allowed per frame
            float _angleDelta = _rotateSpeed * delta;
            _angle = Mathf.LerpAngle(_rotation, _angle, 1f);
            _angle = Mathf.Clamp(_angle, _rotation - _angleDelta, _rotation + _angleDelta);
            GlobalRotation = _angle;
        }
    }
}
