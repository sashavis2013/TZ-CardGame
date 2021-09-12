using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardScript : MonoBehaviour
{
    public GameObject CardPrefab;
    public UnityEvent _myEvent;
    // Start is called before the first frame update
    void Start()
    {
        AddCardCreateListener();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnCards()
    {
        Instantiate(CardPrefab, gameObject.transform);
        
    }

    void AddCardCreateListener()
    {
        if (_myEvent == null)
            _myEvent = new UnityEvent();

        _myEvent.AddListener(SpawnCards);
    }
}
