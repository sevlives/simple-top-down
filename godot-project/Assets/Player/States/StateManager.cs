using Godot;
using System;
using System.Collections.Generic;

namespace SimpleTopDown.Assets.Player.States
{
    public class StateManager : Node
    {
        private BaseState _currentState;
        private Dictionary<State, BaseState> _states;
        public override void _Ready()
        {
            _states = new Dictionary<State, BaseState>()
            {
                [State.Idle] = (BaseState)GetNode<Node>("Idle"),
                [State.Move] = (BaseState)GetNode<Node>("Move"),
            };
        }
        private void ChangeState(State newState)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            _currentState = _states[newState];
            _currentState.Enter();
            GD.Print(newState); //* debug print
        }
        public void Init(Player Player)
        {
            foreach (var child in GetChildren())
            {
                var state = child as BaseState;
                if (state == null) continue;
                state.Player = Player;
            }
            ChangeState(State.Idle);
        }
        public void ManageInput(InputEvent @event)
        {
            State newState = _currentState.DoInput(@event);
            if (newState != State.Null)
            {
                ChangeState(newState);
            }
        }
        public void ManagePhysics(float delta)
        {
            State newState = _currentState.DoPhysics(delta);
            if (newState != State.Null)
            {
                ChangeState(newState);
            }
        }
    }
}