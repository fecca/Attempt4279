namespace Interactions
{
    public class UIInteractionResult : IInteractionResult
    {
        private readonly string _uiAction;

        public UIInteractionResult(string uiAction)
            => _uiAction = uiAction;

        public string GetResult()
            => _uiAction;
    }
}