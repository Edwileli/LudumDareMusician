using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    private List<AAction> aActionList = new List<AAction>();

    private List<InteractiveGameObjectSO> selectedObjectsList = new List<InteractiveGameObjectSO>(); //0 is currently selected

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
                    if (actionSO.ListCombination.Count == 0)
                    {
                        availableActions.Add(aAction);
                    }
                    else
                    {
                        if(actionSO.ListCombination.Count== selectedObjectsList.Count)
                        {
                            bool sameLists = Enumerable.SequenceEqual(actionSO.ListCombination.OrderBy(e => e), selectedObjectsList.OrderBy(e => e));
                            if (sameLists)
                            {
                                availableActions.Add(aAction);
                            }
                        }
                    }
                }
            }
        }
        return availableActions;
    }

    public void SetCurrentInteractiveObject(InteractiveGameObjectSO interactiveObject)
    {
        if (selectedObjectsList[2] != null)
        {
            selectedObjectsList[2] = selectedObjectsList[1];
        }

        if (selectedObjectsList[1] != null)
        {
            selectedObjectsList[1] = selectedObjectsList[0];
        }

        selectedObjectsList[0] = interactiveObject;
    }
}
