using Godot;
using System;

namespace SimpleTopDown.Scripts.Player.States
{
    public class Idle : BaseState
    {
        public override MovementState DoInput(InputEvent @event)
        {
            if (Input.IsActionPressed("turn_left")
            | Input.IsActionPressed("turn_right")
            | Input.IsActionPressed("forward")
            | Input.IsActionPressed("backward"))
            {
                return MovementState.Move;
            }
            return MovementState.Null;
        }
        
        public override MovementState DoPhysics(float delta)
        {
            return MovementState.Null;
        }
    }
}