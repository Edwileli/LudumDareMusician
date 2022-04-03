using UnityEngine;

public class ActivateIntro : MonoBehaviour
{
    public GameObject introToActivate = null;

    void Awake()
    {
        if (introToActivate)
        {
            introToActivate.SetActive(true);
        }
    }
}
