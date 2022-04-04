using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCombine : AAction
{
    public override void PerformAction()
    {
        //base.actionsManager.SelectedObjectsList.Add(base.currentInteractiveObject);
        base.PerformAction();
    }
}
