using Godot;
using System;

namespace SimpleTopDown.Scripts.Player.States
{
    public class Move : BaseState
    {
        private Vector2 _rotateDirection;
        private const float _rotateSpeed = 1.8f;
        private const float _moveSpeed = 8000f;
        
        public override MovementState DoPhysics(float delta)
        {
                        _rotateDirection.y = (
                Input.GetActionStrength("turn_right")
                - Input.GetActionStrength("turn_left"));
            Player.Pivot.GlobalRotation += _rotateDirection.y * _rotateSpeed * delta;

            float moveDirection = (
                Input.GetActionStrength("forward")
                - Input.GetActionStrength("backward"));
            var xCord = moveDirection * _moveSpeed * delta;
            var velocity = new Vector2(xCord, 0).Rotated(Player.Pivot.Rotation);
            Player.MoveAndSlide(velocity);


            // _rotateDirection.y = (
            //     Input.GetActionStrength("turn_right")
            //     - Input.GetActionStrength("turn_left"));
            // Player.Rotation += _rotateDirection.y * _rotateSpeed * delta;

            // float moveDirection = (
            //     Input.GetActionStrength("backward")
            //     - Input.GetActionStrength("forward"));
            // var yCord = moveDirection * _moveSpeed * delta;
            // Player.Velocity = new Vector2(0, yCord).Rotated(Player.Rotation);
            // Player.MoveAndSlide(Player.Velocity);

            if (_rotateDirection.y == 0 && moveDirection == 0)
            {
                return MovementState.Idle;
            }

            return MovementState.Null;
        }
    }
}