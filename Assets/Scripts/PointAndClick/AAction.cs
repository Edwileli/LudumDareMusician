using UnityEngine;

public abstract class AAction : MonoBehaviour
{
    public ActionSO actionSO = null;

    private TimerManager timerManager = null;
    private UIInGameManager uIInGameManager = null;

    void Awake()
    {
        uIInGameManager = FindObjectOfType<UIInGameManager>();
        if (!uIInGameManager)
        {
            Debug.Log("uIInGameManager missing on " + gameObject.name);
        }

        timerManager = FindObjectOfType<TimerManager>();
        if (!timerManager)
        {
            Debug.Log("timerManager missing on " + gameObject.name);
        }
    }

    public virtual void PerformAction()
    {
        uIInGameManager.CleanActionCanvas();
        uIInGameManager.SetDescription(actionSO.ActionDescription);
        timerManager.AddTime(actionSO.DelayObtained);
    }

    //todo call PerformAction() on button click (delegate)
}
