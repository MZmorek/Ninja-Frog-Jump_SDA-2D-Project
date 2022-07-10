using UnityEngine;

namespace FrogNinja.States
{
    public class StateMachine : MonoBehaviour
    {
        BaseState currentState;

        private void Awake()
        {
            EnterState(new MenuState(this));
        }
        public void EnterState(BaseState newState)
        {
            if (currentState != null)
            {
                currentState.ExitState();
            }
            currentState = newState;

            currentState.EnterState();
            
        }
        private void Update()
        {
            currentState.UpdateState();
        }

        private void OnDestroy()
        {
            currentState.ExitState();
        }
    }
}

