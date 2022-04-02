using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public InteractiveGameObjectSO objectSO = null;
    public List<AAction> actionToDisplay = null;

    private ActionsManager actionsManager = null;
    void Awake()
    {
        if(!objectSO)
        {
            Debug.Log("objectSO missing on "+gameObject.name);
        }

        actionsManager = FindObjectOfType<ActionsManager>();
        if (!actionsManager)
        {
            Debug.Log("actionsManager missing on " + gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name+" clicked");
        actionToDisplay = actionsManager.FindAvailableActionForAnObject(objectSO);
        foreach (AAction aAction in actionToDisplay)
        {
            Debug.Log("action "+ aAction.actionSO.ActionName + " is available on this object");
        } 
    }
}
