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
        private StateManager States;
        private Turret Turret;

        public override void _Ready()
        {
            // AnimSprite = GetNode<AnimatedSprite>("Animated Sprite");
            States = GetNode<StateManager>("StateManager");
            Turret = GetNode<Turret>("Turret");
            // AnimSprite.Playing = true;
            States.Init(this);
        }
        // public override void _Process(float delta)
        // {
        // }
        public override void _UnhandledInput(InputEvent @event)
        {
            States.ManageInput(@event);
        }
        public override void _PhysicsProcess(float delta)
        {
            States.ManagePhysics(delta);
            Turret.DoPhysics(delta);
        }
    }
}