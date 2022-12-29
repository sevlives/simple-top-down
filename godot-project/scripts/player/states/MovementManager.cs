using Godot;
using System;
using System.Collections.Generic;

namespace SimpleTopDown.Scripts.Player.States
{
    public class MovementManager : Node
    {
        private BaseState _currentState;
        private Dictionary<MovementState, BaseState> _states;

        public override void _Ready()
        {
            _states = new Dictionary<MovementState, BaseState>()
            {
                [MovementState.Idle] = (BaseState)GetNode<Node>("Idle"),
                [MovementState.Move] = (BaseState)GetNode<Node>("Move"),
            };
        }

        private void ChangeState(MovementState newState)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            _currentState = _states[newState];
            _currentState.Enter();
        }

        private void Init(TempController player)
        {
            foreach (var child in GetChildren())
            {
                var state = child as BaseState;
                if (state == null) continue;
                state.Player = player;
            }
            ChangeState(MovementState.Idle);
        }

        private void ManageInput(InputEvent @event)
        {
            MovementState newState = _currentState.DoInput(@event);
            if (newState != MovementState.Null)
            {
                ChangeState(newState);
            }
        }

        private void ManagePhysics(float delta)
        {
            MovementState newState = _currentState.DoPhysics(delta);
            if (newState != MovementState.Null)
            {
                ChangeState(newState);
            }
        }
    }    
}