
public class ActionDrinkWater : AAction
{
    public override void PerformAction()
    {
        base.PerformAction();
        actionsManager.EmptySelectedObjectsList();
        Destroy(gameObject.GetComponent<ActionDrinkWater>());
    }
}
