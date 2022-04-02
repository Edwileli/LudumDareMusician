using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public Button ButtonComponent = null;
    public Text TextComponent = null;

    private ActionSO actionSO;

    void Awake()
    {
        if (!ButtonComponent)
        {
            Debug.Log("ButtonComponent missing on " + gameObject.name);
        }
        
        if (!TextComponent)
        {
            Debug.Log("TextComponent missing on " + gameObject.name);
        }
    }

    public void InitActionButton(ActionSO actionSO)
    {
        TextComponent.text = actionSO.ActionName;
        this.actionSO = actionSO;
    }

}
