// using Godot;
// using System;
// using System.Collections.Generic;

// namespace SimpleTopDown.Scripts.Player.States
// {
//     public class StateManager : Node
//     {
//         private BaseState _currentState;
//         private Dictionary<AnimationState, BaseState> _states;
//         public string DebugState {get;set;}
        
//         public override void _Ready()
//         {
//             _states = new Dictionary<AnimationState, BaseState>()
//             {
//                 [AnimationState.Idle] = (BaseState)GetNode<Node>("Idle"),
//                 [AnimationState.Move] = (BaseState)GetNode<Node>("Move"),
//             };
//         }
        
//         private void ChangeState(AnimationState newState)
//         {
//             if (_currentState != null)
//             {
//                 _currentState.Exit();
//             }
//             _currentState = _states[newState];
//             _currentState.Enter();
//             DebugState = newState.ToString();
            
//         }
        
//         public void Init(PlayerController Player)
//         {
//             foreach (var child in GetChildren())
//             {
//                 var state = child as BaseState;
//                 if (state == null) continue;
//                 state.Player = Player;
//             }
//             ChangeState(AnimationState.Idle);
//         }
        
//         public void ManageInput(InputEvent @event)
//         {
//             AnimationState newState = _currentState.DoInput(@event);
//             if (newState != AnimationState.Null)
//             {
//                 ChangeState(newState);
//             }
//         }
        
//         public void ManagePhysics(float delta)
//         {
//             AnimationState newState = _currentState.DoPhysics(delta);
//             if (newState != AnimationState.Null)
//             {
//                 ChangeState(newState);
//             }
//         }
//     }
// }