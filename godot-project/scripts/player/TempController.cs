using Godot;
using System;
using SimpleTopDown.Scripts.Player.States;
using SimpleTopDown.Scripts.Debug;

namespace SimpleTopDown.Scripts.Player
{
    public class TempController : KinematicBody2D
    {
        private Vector2 _rotateDirection;
        private const float _rotateSpeed = 1.6f;
        private const float _moveSpeed = 6500f;
        private TurretDirection _turret;
        public Position2D Pivot;
        private DebugOverlay _overlay;
        private MovementManager _moveManager;

        public override void _Ready()
        {
            _turret = GetNode<TurretDirection>          ("TurretDirection");
            Pivot = GetNode<Position2D>                 ("Pivot");
            _overlay = GetNode<DebugOverlay>            ("DebugOverlay");
            _moveManager = GetNode<MovementManager>     ("MovementManager");
            
            _overlay.AddStat("Rotation", GetNode<Position2D>("TurretDirection"), "Angle", false);
            _moveManager.Init(this);
        }
        
        public override void _Process(float delta)
        {
            _overlay.UpdateOverlay();
        }
        
        public override void _PhysicsProcess(float delta)
        {
            _turret.DoPhysics(delta, GetGlobalMousePosition());
            _moveManager.ManagePhysics(delta);
        }
    }
}