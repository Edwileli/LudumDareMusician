
public class ActionCheckStrings : AAction
{
    public override void PerformAction()
    {
        base.PerformAction();
        actionsManager.EmptySelectedObjectsList();
        Destroy(gameObject.GetComponent<ActionCheckStrings>());
    }
}
