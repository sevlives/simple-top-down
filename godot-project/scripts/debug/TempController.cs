using Godot;
using System;

namespace SimpleTopDown.Scripts.Debug
{
    public class TempController : KinematicBody2D
    {
        private Vector2 _rotateDirection;
        private const float _rotateSpeed = 1.6f;
        private const float _moveSpeed = 6500f;
        private TurretDirection _turret;
        private Position2D _pivot;
        private DebugOverlay _overlay;

        public override void _Ready()
        {
            _turret = GetNode<TurretDirection>("TurretDirection");
            _pivot = GetNode<Position2D>("Pivot");
            _overlay = GetNode<DebugOverlay>("DebugOverlay");
            _overlay.AddStat("Rotation", GetNode<Position2D>("TurretDirection"), "Angle", false);
        }
        
        public override void _Process(float delta)
        {
            _overlay.UpdateOverlay();
        }
        
        public override void _PhysicsProcess(float delta)
        {
            _turret.DoPhysics(delta, GetGlobalMousePosition());

            _rotateDirection.y = (
                Input.GetActionStrength("turn_right")
                - Input.GetActionStrength("turn_left"));
            _pivot.GlobalRotation += _rotateDirection.y * _rotateSpeed * delta;

            float moveDirection = (
                Input.GetActionStrength("forward")
                - Input.GetActionStrength("backward"));
            var xCord = moveDirection * _moveSpeed * delta;
            var velocity = new Vector2(xCord, 0).Rotated(_pivot.Rotation);
            MoveAndSlide(velocity);
        }
    }
}