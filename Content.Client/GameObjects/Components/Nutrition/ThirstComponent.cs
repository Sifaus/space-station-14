using Content.Shared.GameObjects.Components.Movement;
using Content.Shared.GameObjects.Components.Nutrition;
using Robust.Shared.GameObjects;

#nullable enable

namespace Content.Client.GameObjects.Components.Nutrition
{
    [RegisterComponent]
    public class ThirstComponent : SharedThirstComponent
    {
        private ThirstThreshold _currentThirstThreshold;
        public override ThirstThreshold CurrentThirstThreshold => _currentThirstThreshold;

        public override void HandleComponentState(ComponentState? curState, ComponentState? nextState)
        {
            if (!(curState is ThirstComponentState thirst))
            {
                return;
            }

            _currentThirstThreshold = thirst.CurrentThreshold;

            if (Owner.TryGetComponent(out MovementSpeedModifierComponent movement))
            {
                movement.RefreshMovementSpeedModifiers();
            }
        }
    }
}
