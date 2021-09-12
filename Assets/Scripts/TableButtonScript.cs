using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TableButtonScript : MonoBehaviour, IPointerDownHandler
{

    public SpriteRenderer TableSpriteRenderer;
    public Sprite NewSprite;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (TableSpriteRenderer.sprite != NewSprite)
        {
            TableSpriteRenderer.sprite = NewSprite;
            PlayerPrefs.SetString("SpriteName", TableSpriteRenderer.sprite.name+".png");
            gameObject.GetComponent<Outline>().enabled = true;

        }

    }

    private void Start()
    {
        if (TableSpriteRenderer.sprite == NewSprite)
        {
            gameObject.GetComponent<Outline>().enabled = true;

        }
        else
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
