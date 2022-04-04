using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameManager : MonoBehaviour
{
    public GameObject CanvasActionPrefab = null;
    public GameObject PanelActionsPrefab = null;
    public GameObject ActionButtonPrefab = null;
    public Text ActionDescription = null;
    public GameObject ActionDescriptionPanel = null;

    private GameObject instantiatedCanvas = null;
    private GameObject instantiatedPanel = null;
    private List<GameObject> instantiatedActionButtonList = new List<GameObject>();
    private IEnumerator closeDescriptionCoroutine;

    private SoundManager soundManager = null;

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
        if (!ActionDescription)
        {
            Debug.Log("ActionDescription missing on " + gameObject.name);
        }
        if (!ActionDescriptionPanel)
        {
            Debug.Log("ActionDescriptionPanel missing on " + gameObject.name);
        }



        soundManager = FindObjectOfType<SoundManager>();
        if (!soundManager)
        {
            Debug.Log("soundManager missing on " + gameObject.name);
        }

        ActionDescription.gameObject.SetActive(false);
        ActionDescriptionPanel.SetActive(false);
    }

    public void DisplayPanelAction(Transform canvasTransform, List<AAction> actionList)
    {
        CleanActionCanvas();
        
        soundManager.PlayOpenActionsSound();

        instantiatedCanvas = Instantiate(CanvasActionPrefab);
        instantiatedCanvas.transform.position = canvasTransform.position;
        instantiatedCanvas.transform.rotation = canvasTransform.rotation;

        instantiatedPanel = Instantiate(PanelActionsPrefab, instantiatedCanvas.transform);

        foreach (AAction action in actionList)
        {
            GameObject instantiatedButton = Instantiate(ActionButtonPrefab, instantiatedPanel.transform);
            ActionButton actionButton = instantiatedButton.GetComponent<ActionButton>();
            actionButton.InitActionButton(action.actionSO);
            Button button = actionButton.GetComponent<Button>();
            button.onClick.AddListener(() => action.PerformAction());
            instantiatedActionButtonList.Add(instantiatedButton);

        }

        Canvas canvas = instantiatedCanvas.GetComponent<Canvas>();
        Vector2 movePos = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, canvasTransform.position, canvas.worldCamera, out movePos);
    }

    public void CleanActionCanvas()
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
            soundManager.PlayCloseActionsSound();
            
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

    public void SetDescription(string description)
    {
        ActionDescriptionPanel.SetActive(true);
        ActionDescription.gameObject.SetActive(true);
        ActionDescription.text = description;
        closeDescriptionCoroutine = HideDescription(10);
        StartCoroutine(closeDescriptionCoroutine);
    }

    private IEnumerator HideDescription(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        ActionDescription.gameObject.SetActive(false);
        ActionDescriptionPanel.SetActive(false);
    }
}
