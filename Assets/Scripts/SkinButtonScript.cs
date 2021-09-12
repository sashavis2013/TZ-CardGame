using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinButtonScript : MonoBehaviour
{
    public GameObject SkinMenu;
    
    public void OpenSkinMenu()
    {
        Time.timeScale = 0f;
        GameManager.Instance.IsOnPause = true;
        SkinMenu.SetActive(true);
    }
}
