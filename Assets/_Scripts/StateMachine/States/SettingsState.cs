using FrogNinja.UI;

namespace FrogNinja.States
{
    public class SettingsState : BaseState
    {
        public SettingsState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            UIManager.Instance.ShowSettings();
            EventManager.EnterMenu += EventManager_EnterMenu;
        }

        public override void UpdateState()
        {

        }

        public override void ExitState()
        {
            EventManager.EnterMenu -= EventManager_EnterMenu;
        }

        private void EventManager_EnterMenu()
        {
            GoToMenu();
        }
        private void GoToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }
    }
}
