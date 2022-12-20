using Godot;
using System;

namespace SimpleTopDown.Assets.Player.States
{
    public class Move : BaseState
    {
        private Vector2 _rotateDirection;
        private float _rotateSpeed = 1.8f;
        private float _moveSpeed = 8000f;
        public override State DoInput(InputEvent @event)
        {
            return State.Null;
        }
        public override State DoPhysics(float delta)
        {
            _rotateDirection.y = (
                Input.GetActionStrength("turn_right")
                - Input.GetActionStrength("turn_left"));
            Player.Rotation += _rotateDirection.y * _rotateSpeed * delta;

            float _moveDirection = (
                Input.GetActionStrength("backward")
                - Input.GetActionStrength("forward"));
            var yCord = _moveDirection * _moveSpeed * delta;
            Player.Velocity = new Vector2(0, yCord).Rotated(Player.Rotation);
            Player.MoveAndSlide(Player.Velocity);

            if (_rotateDirection.y == 0 && _moveDirection == 0)
            {
                return State.Idle;
            }

            return State.Null;
        }
    }
}