using System.Collections.Generic;

namespace Rodrigo_.AnimatorSystem
{
    public struct Conditions
    {
        public State currentState;
        public bool isAnimationFinished;
        public bool isAtacking;
    }

    public abstract class State
    {
        public int animationNameHash;

        protected State(int animatioNameHash)
        {
            this.animationNameHash = animatioNameHash;
        }

        public abstract bool isMatchingConditions(in Conditions conditions);
    }

    //Finite State Machine
    public class FSM 
    {
        public Conditions conditions;
        public State currentState;

        List<State> states = new List<State>();

        public void AddState(State state)
        {
            states.Add(state);
        }

        public void Update()
        {
            foreach (var state in states)
            {
                if(state.isMatchingConditions(in conditions))
                {
                    currentState = state;
                    break;
                }
            }
        }
    }
}