using Godot;
using System;
using System.Collections.Generic;

namespace SimpleTopDown.Scripts.Player.States
{
    public class MovementManager : Node
    {
        private BaseState currentState;
        private Dictionary<MovementState, BaseState> _states;

        public override void _Ready()
        {
            _states = new Dictionary<MovementState, BaseState>()
            {
                [MovementState.Idle] = (BaseState)GetNode<Node>("Idle"),
                [MovementState.Move] = (BaseState)GetNode<Node>("Move"),
            };
        }

        
    }    
}