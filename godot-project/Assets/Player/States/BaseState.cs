using Godot;
using System;

namespace SimpleTopDown.Assets.Player.States
{
    public class BaseState : Node
    {
        [Export]
        // public string animationName {get; set;} //this is set in editor for each node
        public Player Player {get; set;}

        public void Enter()
        {
            // Player.AnimSprite.Play(animationName);
        }
        public void Exit()
        {}
        public virtual State DoInput(InputEvent @event)
        {
            return State.Null;
        }
        public virtual State DoPhysics(float delta)
        {
            return State.Null;
        }
    }
}