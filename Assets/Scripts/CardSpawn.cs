using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using MiscUtil.IO;
using UnityEngine;
using UnityEngine.Events;

public class CardSpawn : MonoBehaviour
{
    public GameObject BackCards;

    public bool IsSpawningCard=false;

    public GameObject Hand;

    private CardScript _handCardScript;
    // Start is called before the first frame update

    void Start()
    {
        _handCardScript = Hand.GetComponent<CardScript>();


        StartCoroutine(SpawnCardsCoroutine(13));
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(IsSpawningCard);
    }

    IEnumerator SpawnCardsCoroutine(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            IsSpawningCard = true;
            yield return new WaitForSeconds(1f);
            SpawnCards();
            IsSpawningCard = false;

        }
        StopCoroutine(SpawnCardsCoroutine(amount));
    }

    public void SpawnCards()
    {
        _handCardScript._myEvent.Invoke();
        GameObject backCard = Instantiate(BackCards, gameObject.transform);
        Destroy(backCard, 1f);
        
    }
}
