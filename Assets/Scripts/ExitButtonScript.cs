using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButtonScript : MonoBehaviour
{
    public GameObject SkinMenu;
    public void ExitSkinsMenu()
    {
        
        Time.timeScale = 1f;
        GameManager.Instance.IsOnPause = false;
        SkinMenu.SetActive(false);
    }
}
