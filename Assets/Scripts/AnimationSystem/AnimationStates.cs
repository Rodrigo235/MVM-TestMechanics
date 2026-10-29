using UnityEngine;

namespace Rodrigo_.AnimatorSystem
{
    public class IdleState : State
    {
        public IdleState(int animationNameHash) : base(animationNameHash) { }

        public override bool isMatchingConditions(in Conditions conditions)
        {
            return true;
        }
    }
}