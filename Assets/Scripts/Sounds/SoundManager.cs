using FMODUnity;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public EventReference menuButton;

    public void PlayButtonSound()
    {
        AudioHelpers.PlayEvent(menuButton, this);
    }
}
