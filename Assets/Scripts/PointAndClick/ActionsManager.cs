using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public List<InteractiveGameObjectSO> SelectedObjectsList = new List<InteractiveGameObjectSO>(); //0 is currently selected

    private List<AAction> aActionList = new List<AAction>();

    void Awake()
    {
        //populating the list of available actions
        aActionList = new List<AAction>(GetComponents<AAction>());
    }

    public List<AAction> FindAvailableActionForAnObject(InteractiveGameObjectSO objectSO)
    {
        List<AAction> availableActions = new List<AAction>();
        //Debug.Log("objectSO.ActionsForThisObject " + objectSO.ActionsForThisObject.Count);

        foreach (ActionSO actionSO in objectSO.ActionsForThisObject)
        {
            foreach (AAction aAction in aActionList)
            {
                if (aAction.actionSO == actionSO)
                {
                    //Debug.Log("action found in manager");
                    if (actionSO.ListCombination.Count == 0)
                    {
                        //Debug.Log("no combination");
                        aAction.currentInteractiveObject = objectSO;
                        availableActions.Add(aAction);
                    }
                    else
                    {
                        //Debug.Log("combination required: " + actionSO.ListCombination.Count);
                        //Debug.Log("SelectedObjectsList.Count: " + SelectedObjectsList.Count);

                        bool sameLists = CompareInteractiveObjectLists(actionSO.ListCombination, SelectedObjectsList);
                        Debug.Log("sameLists " + sameLists);
                        if (sameLists)
                        {
                            availableActions.Add(aAction);
                        }
                    }
                }
            }
        }
        //Debug.Log("availableActions.Count " + availableActions.Count);
        return availableActions;
    }

    public void SetCurrentInteractiveObject(InteractiveGameObjectSO interactiveObject)
    {
        if(SelectedObjectsList.Count>=3)
        {
            SelectedObjectsList.RemoveAt(0);
        }
        SelectedObjectsList.Add(interactiveObject);
    }

    public void EmptySelectedObjectsList()
    {
        List<InteractiveGameObjectSO> selectedObjectsList = new List<InteractiveGameObjectSO>();
    }

    public bool CompareInteractiveObjectLists(List<InteractiveGameObjectSO> a, List<InteractiveGameObjectSO> b)
    {
        if (a.Count == b.Count)
        {
            bool[] nameFound = new bool[a.Count];
            for (int i = 0; i < a.Count; i++)
            {
                nameFound[i] = false;
                for (int j = 0; j < b.Count; j++)
                {
                    if (a[i].ObjectName == b[j].ObjectName)
                    {
                        Debug.Log("a[i].ObjectName:" + a[i].ObjectName + ", b[j].ObjectName" + b[j].ObjectName);
                        nameFound[i] = true;
                    }
                }
            }

            for (int k = 0; k < nameFound.Length; k++)
            {
                if (nameFound[k] == false)
                {

                    return false;
                }
            }
            return true;

        }
        return false;
    }
}
