using Godot;
using System;

namespace SimpleTopDown.Scripts.Player.States
{
    public class BaseState : Node
    {
        // [Export]
        // public string animationName {get; set;} //this is set in editor for each node
        private TempController _player;
        public TempController Player
        {
            get => _player;
            set
            {
                _player = value;
            }
        }

        public void Enter()
        {
            // Player.AnimSprite.Play(animationName);
        }
        
        public void Exit()
        {}
        
        public virtual AnimationState DoInput(InputEvent @event)
        {
            return AnimationState.Null;
        }
        
        public virtual AnimationState DoPhysics(float delta)
        {
            return AnimationState.Null;
        }
    }
}