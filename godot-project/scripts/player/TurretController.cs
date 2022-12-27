using Godot;
using System;

namespace SimpleTopDown.Scripts.Player
{
    public class TurretController : Sprite
    {
        private Vector2 _mousePosition;
        private const float _rotateSpeed = 1.7f;
        public void DoPhysics(float delta)
        {
            _mousePosition = GetGlobalMousePosition();
            // Rotated() used due to incorret image importing, thus needs to be rotated 90' clockwise
            Vector2 vector = (_mousePosition - GlobalPosition).Rotated(Mathf.Pi*.5f);
            float angle = vector.Angle();
            float rotation = GlobalRotation;
            // amount of rotation allowed per frame
            float angleDelta = _rotateSpeed * delta;
            angle = Mathf.LerpAngle(rotation, angle, 1f);
            angle = Mathf.Clamp(angle, rotation - angleDelta, rotation + angleDelta);
            GlobalRotation = angle;
        }
    }
}
//* ChatGPT provided this
// Get the global mouse position
// Vector2 mousePosition = GetViewport().GetMousePosition();

// // Calculate the angle between the object and the mouse position
// float angle = Mathf.Atan2(mousePosition.y - GlobalPosition.y, mousePosition.x - GlobalPosition.x);

// // Rotate the object towards the mouse position
// Transform2D rot = new Transform2D();
// rot.Rotate(Mathf.Lerp(Rotation, angle, Mathf.Clamp(rotationSpeed * delta, 0, 1)));
// Transform = rot * Transform;