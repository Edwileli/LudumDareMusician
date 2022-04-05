
public class ActionZSpillWater : AAction
{
    public override void PerformAction()
    {
        base.PerformAction();
        actionsManager.EmptySelectedObjectsList();
        Destroy(gameObject.GetComponent<ActionZSpillWater>());
    }
}
