using UnityEngine;

public abstract class AAction : MonoBehaviour
{
    public ActionSO actionSO = null;
    public InteractiveGameObjectSO currentInteractiveObject = null;

    protected ActionsManager actionsManager = null;
    private TimerManager timerManager = null;
    private UIInGameManager uIInGameManager = null;
    private SoundManager soundManager = null;

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

        soundManager = FindObjectOfType<SoundManager>();
        if (!soundManager)
        {
            Debug.Log("soundManager missing on " + gameObject.name);
        }

        actionsManager = FindObjectOfType<ActionsManager>();
        if (!actionsManager)
        {
            Debug.Log("actionsManager missing on " + gameObject.name);
        }
    }

    public virtual void PerformAction()
    {
        if (actionSO.DelayObtained != 0)
        {
            soundManager.PlayPerformActionSound();
        }

        uIInGameManager.CleanActionCanvas();
        uIInGameManager.SetDescription(actionSO.ActionDescription);
        timerManager.AddTime(actionSO.DelayObtained);
    }
}
