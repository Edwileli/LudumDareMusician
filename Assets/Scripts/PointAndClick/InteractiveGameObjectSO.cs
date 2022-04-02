using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "object_so", menuName = "ScriptableObjects/InteractiveGameObject")]
public class InteractiveGameObjectSO : ScriptableObject
{
    public string ObjectName = "";
    public Sprite ObjectIcon = null;
    public List<ActionSO> ActionsForThisObject = new List<ActionSO>();
}
