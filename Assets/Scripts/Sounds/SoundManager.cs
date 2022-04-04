using FMODUnity;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public EventReference menuButton;
    public EventReference openActions;
    public EventReference closeActions;
    public EventReference performAction;

    public void PlayButtonSound()
    {
        AudioHelpers.PlayEvent(menuButton, this);
    }
    
    public void PlayOpenActionsSound()
    {
        AudioHelpers.PlayEvent(openActions, this);
    }
    
    public void PlayCloseActionsSound()
    {
        AudioHelpers.PlayEvent(closeActions, this);
    }
    
    public void PlayPerformActionSound()
    {
        AudioHelpers.PlayEvent(performAction, this);
    }
}
