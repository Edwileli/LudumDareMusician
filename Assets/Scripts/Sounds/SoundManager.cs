using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public EventReference eventReference;
    private EventInstance eventInstance;

    public void PlayButtonSound()
    {
        eventInstance = RuntimeManager.CreateInstance(eventReference);
        RuntimeManager.AttachInstanceToGameObject(
            eventInstance,
            transform
        );
        eventInstance.start();
    }
}
