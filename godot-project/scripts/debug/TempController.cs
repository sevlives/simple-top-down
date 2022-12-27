using Godot;
using System;

namespace SimpleTopDown.Scripts.Debug
{
    public class TempController : KinematicBody2D
    {
        private Vector2 _rotateDirection;
        private const float _rotateSpeed = 1.8f;
        private const float _moveSpeed = 8000f;
        private TurretDirection _turret;
        private Position2D _body;
        private DebugOverlay _overlay;

        public override void _Ready()
        {
            _turret = GetNode<TurretDirection>("TurretDirection");
            _body = GetNode<Position2D>("Pivot");
            _overlay = GetNode<DebugOverlay>("DebugOverlay");
            _overlay.AddStat("Rotation", GetNode<Position2D>("TurretDirection"), "Angle", false);
        }
        public override void _Process(float delta)
        {
            _overlay.UpdateOverlay();
            _turret.DoProcess(delta);
        }
        public override void _PhysicsProcess(float delta)
        {
            _rotateDirection.y = (
                Input.GetActionStrength("turn_right")
                - Input.GetActionStrength("turn_left"));
            _body.GlobalRotation += _rotateDirection.y * _rotateSpeed * delta;
        }
    }
}