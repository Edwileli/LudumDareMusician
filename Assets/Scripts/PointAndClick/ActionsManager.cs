using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    private List<AAction> aActionList = new List<AAction>();

    void Awake()
    {
        //populating the list of available actions
        aActionList = new List<AAction>(GetComponents<AAction>());
    }

    public List<AAction> FindAvailableActionForAnObject(InteractiveGameObjectSO objectSO)
    {
        List<AAction> availableActions = new List<AAction>();
       
        foreach (ActionSO actionSO in objectSO.ActionsForThisObject)
        {
            foreach (AAction aAction in aActionList)
            {
                if (aAction.actionSO == actionSO)
                {
                    availableActions.Add(aAction);
                }
            }
        }
        return availableActions;
    }
}
