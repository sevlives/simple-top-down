using Godot;
using System;

namespace SimpleTopDown.Scripts.Player.States
{
    public class Idle : BaseState
    {
        public override AnimationState DoInput(InputEvent @event)
        {
            if (Input.IsActionPressed("turn_left")
            | Input.IsActionPressed("turn_right")
            | Input.IsActionPressed("forward")
            | Input.IsActionPressed("backward"))
            {
                return AnimationState.Move;
            }
            return AnimationState.Null;
        }
        public override AnimationState DoPhysics(float delta)
        {
            return AnimationState.Null;
        }
    }
}