using Godot;
using System;

namespace SimpleTopDown.Scripts.Debug
{
    public class TurretDirection : Position2D
    {
        private Sprite _arrow;
        private Vector2 _arrowOffset = new Vector2(30, 0);
        private const float _rotateSpeed = 1.7f;
        private float _angle;
        // debug property
        public string Angle
        {
            get => _angle.ToString();
        }
        public override void _Ready()
        {
            _arrow = GetNode<Sprite>    ("Arrow");
            _arrow.Offset = _arrowOffset;
        }
        public void DoProcess(float delta)
        {
            Vector2 _mousePosition = GetGlobalMousePosition();
            Vector2 vector = (_mousePosition - GlobalPosition);
            _angle = vector.Angle();
            float _rotation = GlobalRotation;
            float angleDelta = _rotateSpeed * delta;
            _angle = Mathf.LerpAngle(_rotation, _angle, 1f);
            _angle = Mathf.Clamp(_angle, _rotation - angleDelta, _rotation + angleDelta);
            GlobalRotation = _angle;
        }
    }
}