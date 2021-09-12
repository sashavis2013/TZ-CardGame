using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulateMove : MonoBehaviour
{
    public void ChangeMoveSuitIndex()
    {
        GameManager.Instance.MoveSuitIndex = Random.Range(0, 4);
    }
}
