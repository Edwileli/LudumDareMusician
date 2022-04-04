
public class ActionDrinkCoffee : AAction
{
    public override void PerformAction()
    {
        base.PerformAction();
        actionsManager.EmptySelectedObjectsList();
        Destroy(gameObject.GetComponent<ActionDrinkCoffee>());
    }
}
