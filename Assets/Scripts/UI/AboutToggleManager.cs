using UnityEngine;

public class AboutToggleManager : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;

    public void ToggleVisibility()
    {
        objectA.SetActive(!objectA.activeSelf);
        objectB.SetActive(!objectB.activeSelf);
    }
}
