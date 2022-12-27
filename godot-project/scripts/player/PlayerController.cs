using Godot;
using System;
using SimpleTopDown.Scripts.Player.States;

namespace SimpleTopDown.Scripts.Player
{
    public class PlayerController : KinematicBody2D
    {
        private Vector2 _velocity;
        public Vector2 Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
            }
        }
        //! fields for physics math
        // public AnimatedSprite AnimSprite {get; set;}
        private StateManager _states;
        private TurretController _turret; 

        public override void _Ready()
        {
            // AnimSprite = GetNode<AnimatedSprite>("Animated Sprite");
            _states = GetNode<StateManager>("StateManager");
            _turret = GetNode<TurretController>("Turret");
            // AnimSprite.Playing = true;
            _states.Init(this);
            // Input.MouseMode = Input.MouseModeEnum.Confined;
        }
        // public override void _Process(float delta)
        // {
        // }
        public override void _UnhandledInput(InputEvent @event)
        {
            _states.ManageInput(@event);
        }
        public override void _PhysicsProcess(float delta)
        {
            _states.ManagePhysics(delta);
            _turret.DoPhysics(delta);
        }
    }
}