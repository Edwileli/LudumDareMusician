using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    private List<AAction> aActionList = new List<AAction>();

    void Awake()
    {
        //populating the list of available actions
        aActionList = new List<AAction>(GetComponents<AAction>());
    }
}
