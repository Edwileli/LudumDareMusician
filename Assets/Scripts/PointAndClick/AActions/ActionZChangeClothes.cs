
public class ActionZChangeClothes : AAction
{
    public override void PerformAction()
    {
        base.PerformAction();
        actionsManager.EmptySelectedObjectsList();
        Destroy(gameObject.GetComponent<ActionZChangeClothes>());
    }
}
