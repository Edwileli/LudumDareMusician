using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameManager : MonoBehaviour
{
    public GameObject CanvasActionPrefab = null;
    public GameObject PanelActionsPrefab = null;
    public GameObject ActionButtonPrefab = null;

    private GameObject instantiatedCanvas = null;
    private GameObject instantiatedPanel = null;
    private List<GameObject> instantiatedActionButtonList = new List<GameObject>();

    void Awake()
    {
        if (!CanvasActionPrefab)
        {
            Debug.Log("PanelActionParent missing on " + gameObject.name);
        }
        if (!PanelActionsPrefab)
        {
            Debug.Log("PanelActions missing on " + gameObject.name);
        }
        if (!ActionButtonPrefab)
        {
            Debug.Log("ActionButton missing on " + gameObject.name);
        }
    }

    public void DisplayPanelAction(Vector3 position, List<AAction> actionList)
    {
        CleanActionCanvas();

        instantiatedCanvas = Instantiate(CanvasActionPrefab);
        instantiatedCanvas.transform.position = position;

        instantiatedPanel = Instantiate(PanelActionsPrefab, instantiatedCanvas.transform);

        foreach (AAction action in actionList)
        {
            GameObject instantiatedButton = Instantiate(ActionButtonPrefab, instantiatedPanel.transform);
            instantiatedButton.GetComponent<ActionButton>().InitActionButton(action.actionSO);
            instantiatedActionButtonList.Add(instantiatedButton);
        }

        Canvas canvas = instantiatedCanvas.GetComponent<Canvas>();
        Vector2 movePos = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, position, canvas.worldCamera, out movePos);
    }

    private void CleanActionCanvas()
    {
        if (instantiatedCanvas)
        {
            Destroy(instantiatedCanvas);
        }
        if (instantiatedPanel)
        {
            Destroy(instantiatedPanel);
        }
        if (instantiatedActionButtonList.Count > 0)
        {
            foreach (GameObject o in instantiatedActionButtonList)
            {
                Destroy(o);
            }
        }
    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }
}
