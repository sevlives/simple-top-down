using Godot;
using System;
using SimpleTopDown.Assets.Player.States;

namespace SimpleTopDown.Assets.Player
{
    public class Player : KinematicBody2D
    {
        public Vector2 Velocity {get; set;}
        //! fields for physics math
        // public AnimatedSprite AnimSprite {get; set;}
        private StateManager _states;

        public override void _Ready()
        {
            // AnimSprite = GetNode<AnimatedSprite>("Animated Sprite");
            _states = GetNode<StateManager>("StateManager");
            // AnimSprite.Playing = true;
            _states.Init(this);
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
        }
    }
}