using Godot;
using System;

namespace SimpleTopDown.Scripts.Player
{
    public class TurretDirection : Position2D
    {
        private Sprite _arrow;
        private Vector2 _arrowOffset = new Vector2(30, 0);
        private Sprite _reticle;
        private const float _traverseSpeed = 1.1f;
        private const float _elevationSpeed = .3f;
        private float _angle;
        // debug property
        public string Angle
        {
            get => _angle.ToString();
        }

        public override void _Ready()
        {
            _arrow = GetNode<Sprite>        ("Arrow");
            _reticle = GetNode<Sprite>      ("Reticle");

            _arrow.Offset = _arrowOffset;
        }
        
        public void DoPhysics(float delta, Vector2 globalMouse)
        {
            MoveTurretArrow(delta, globalMouse);
            MoveTurretReticle(globalMouse);
        }
        
        private void MoveTurretArrow(float delta, Vector2 globalMouse)
        {
            Vector2 vector = globalMouse - GlobalPosition;
            _angle = vector.Angle();
            float rotation = GlobalRotation;
            float angleDelta = _traverseSpeed * delta;
            _angle = Mathf.LerpAngle(rotation, _angle, 1f);
            _angle = Mathf.Clamp(_angle, rotation - angleDelta, rotation + angleDelta);
            GlobalRotation = _angle;
        }
        
        private void MoveTurretReticle(Vector2 globalMouse)
        {
            float distanceToMouse = globalMouse.DistanceTo(GlobalPosition);
            distanceToMouse = Mathf.Lerp(_reticle.Offset.x, distanceToMouse, _elevationSpeed);
            _reticle.Offset = new Vector2(distanceToMouse, 0);
        }
    }
}