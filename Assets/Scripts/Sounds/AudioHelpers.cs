using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public static class AudioHelpers
{
    public static EventInstance PlayEvent(EventReference eventReference, MonoBehaviour target)
    {
        var eventInstance = RuntimeManager.CreateInstance(eventReference);
        RuntimeManager.AttachInstanceToGameObject(
            eventInstance,
            target.transform
        );
        eventInstance.start();
        eventInstance.release();

        return eventInstance;
    }

    public static void CueEvent(EventInstance eventInstance)
    {
        eventInstance.getPlaybackState(out var state);
        if (state != PLAYBACK_STATE.STOPPED)
        {
            eventInstance.keyOff();
        }
    }

    public static PARAMETER_ID GetGlobalParameterId(string parameterName)
    {
        RuntimeManager.StudioSystem.getParameterDescriptionByName(parameterName, out var parameterDescription);

        return parameterDescription.id;
    }

    public static void SetGlobalParameter(PARAMETER_ID parameterId, float value)
    {
        RuntimeManager.StudioSystem.setParameterByID(parameterId, value);
    }
}