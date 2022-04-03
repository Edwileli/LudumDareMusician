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
        //todo display description
        //todo add time to timer
        //clean canvas
    }

    //todo call PerformAction() on button click (delegate)
}
