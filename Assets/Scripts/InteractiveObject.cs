using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public InteractiveGameObjectSO objectSO = null;

    // Start is called before the first frame update
    void Awake()
    {
        if(!objectSO)
        {
            Debug.Log("objectSO missing on "+gameObject.name);
        }
    }


}
