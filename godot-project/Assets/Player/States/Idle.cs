using Godot;
using System;

namespace SimpleTopDown.Assets.Player.States
{
    public class Idle : BaseState
    {
        public override State DoInput(InputEvent @event)
        {
            if (Input.IsActionPressed("turn_left")
            | Input.IsActionPressed("turn_right")
            | Input.IsActionPressed("forward")
            | Input.IsActionPressed("backward"))
            {
                return State.Move;
            }
            return State.Null;
        }
        public override State DoPhysics(float delta)
        {
            return State.Null;
        }
    }
}