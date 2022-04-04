using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveObject : MonoBehaviour
{
    public InteractiveGameObjectSO ObjectSO = null;

    private List<AAction> actionToDisplay = null;
    private ActionsManager actionsManager = null;
    private UIInGameManager uIInGameManager = null;
    private Camera currentCamera = null;

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

        currentCamera = FindObjectOfType<Camera>();
        if (!currentCamera)
        {
            Debug.Log("camera missing on " + gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log(gameObject.name + " clicked");
            actionsManager.SetCurrentInteractiveObject(ObjectSO);
            actionToDisplay = actionsManager.FindAvailableActionForAnObject(ObjectSO);
            //Vector3 positionToDisplayActions = Vector3.Lerp(currentCamera.transform.position, transform.position, 0.9f);
            Transform canvasTransform = gameObject.GetComponentInChildren<CanvasDisplayPosition>().gameObject.transform;
            uIInGameManager.DisplayPanelAction(canvasTransform, actionToDisplay);
        }
        else
        {
            //Debug.Log("Clicked on the UI");
        }

    }
}
