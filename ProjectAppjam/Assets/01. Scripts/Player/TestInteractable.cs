using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestInteractable : MonoBehaviour,IInteractable
{
    public bool Interact(GameObject performer = null)
    {
        Debug.Log("��ȭ�ۿ� : " + gameObject.name);
        return true;
    }
}
