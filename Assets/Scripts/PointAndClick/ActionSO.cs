using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "action_so", menuName = "ScriptableObjects/Action")]
public class ActionSO : ScriptableObject
{
    public string ActionTitle = "";
    public string ActionDescription = "";
    public float DelayObtained = 5f;
    public List<InteractiveGameObjectSO> ListCombination = new List<InteractiveGameObjectSO>();
}
