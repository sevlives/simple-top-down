using Godot;
using System;
using System.Collections.Generic;

namespace SimpleTopDown.Scripts.Player.States
{
    public class MovementManager : Node
    {
        private BaseState _currentState;
        private Dictionary<MovementState, BaseState> _moveStates;

        public override void _Ready()
        {
            _moveStates = new Dictionary<MovementState, BaseState>()
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
            _currentState = _moveStates[newState];
            _currentState.Enter();
        }

        public void Init(TempController player)
        {
            foreach (var child in GetChildren())
            {
                var state = child as BaseState;
                if (state == null) continue;
                state.Player = player;
            }
            ChangeState(MovementState.Idle);
        }

        public void ManageInput(InputEvent @event)
        {
            MovementState newState = _currentState.DoInput(@event);
            if (newState != MovementState.Null)
            {
                ChangeState(newState);
            }
        }

        public void ManagePhysics(float delta)
        {
            MovementState newState = _currentState.DoPhysics(delta);
            if (newState != MovementState.Null)
            {
                ChangeState(newState);
            }
        }
    }    
}