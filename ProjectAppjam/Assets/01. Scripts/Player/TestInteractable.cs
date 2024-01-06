using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestInteractable : MonoBehaviour,IInteractable
{
    public bool Interact(GameObject performer = null)
    {
        Debug.Log("상화작용 : " + gameObject.name);
        return true;
    }
}
