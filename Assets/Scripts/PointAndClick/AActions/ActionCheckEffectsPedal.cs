
public class ActionCheckEffectsPedal : AAction
{
    public override void PerformAction()
    {
        base.PerformAction();
        actionsManager.EmptySelectedObjectsList();
        Destroy(gameObject.GetComponent<ActionCheckEffectsPedal>());
    }
}
