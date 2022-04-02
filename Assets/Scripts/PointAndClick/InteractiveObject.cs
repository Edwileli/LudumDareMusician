using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public InteractiveGameObjectSO ObjectSO = null;

    private List<AAction> actionToDisplay = null;
    private ActionsManager actionsManager = null;
    private UIInGameManager uIInGameManager = null;
    private Camera camera = null;

    void Awake()
    {
        if (!ObjectSO)
        {
            Debug.Log("objectSO missing on " + gameObject.name);
        }

        actionsManager = FindObjectOfType<ActionsManager>();
        if (!actionsManager)
        {
            Debug.Log("actionsManager missing on " + gameObject.name);
        }

        uIInGameManager = FindObjectOfType<UIInGameManager>();
        if (!uIInGameManager)
        {
            Debug.Log("uIInGameManager missing on " + gameObject.name);
        }
        
        camera = FindObjectOfType<Camera>();
        if (!camera)
        {
            Debug.Log("camera missing on " + gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name + " clicked");
        actionToDisplay = actionsManager.FindAvailableActionForAnObject(ObjectSO);
        foreach (AAction aAction in actionToDisplay)
        {
            Debug.Log("action " + aAction.actionSO.ActionName + " is available on this object");            
        }
        Vector3 positionToDisplayActions = Vector3.Lerp(camera.transform.position, transform.position, 0.9f);

        uIInGameManager.DisplayPanelAction(positionToDisplayActions, actionToDisplay);
    }
}
