using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardRandom : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    public List<Sprite> FrontSprites;
    public Animator Animator;
    private Sprite _spriteToUse;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private int _cardSuite;
    private Color blackedColor;
    private Color defaultColor;
    [SerializeField]
    private bool _canClick;

    private LayoutElement _layoutElement;
    private RectTransform _rectTransform;
    void Start()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _layoutElement = gameObject.GetComponent<LayoutElement>();
        GameManager.Instance.OnSuitChange += SuitChangeHandler;
        _cardSuite = Random.Range(0, 4) ;
        _spriteToUse = FrontSprites[_cardSuite] ;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GoInHand();

        blackedColor = _spriteRenderer.color;
        blackedColor.r = 0.2f;
        blackedColor.g = 0.2f;
        blackedColor.b = 0.2f;

        defaultColor = _spriteRenderer.color;
        defaultColor.r = 1f;
        defaultColor.g = 1f;
        defaultColor.b = 1f;
    }

    private void SuitChangeHandler(int newVal)
    {
        Animator.enabled = false;
        if (_cardSuite!=GameManager.Instance.MoveSuitIndex)
        {
            _layoutElement.minWidth = 0;
            transform.localScale = new Vector3(88, 88, 1);
            _spriteRenderer.color = blackedColor ;
            _spriteRenderer.sortingOrder = 0 ;
            _canClick = false;
        }
        else
        {
            
            transform.localScale = new Vector3(transform.localScale.x+10f, transform.localScale.y, transform.localScale.z);
            _layoutElement.minWidth = 125;
            _spriteRenderer.color = defaultColor;
            _spriteRenderer.sortingOrder = 10;
            _canClick = true;
        }
        //do whatever
    }

    void GoInHand()
    {
        _spriteRenderer.sprite = _spriteToUse;
        switch (_cardSuite)
        {
            case 0:
            {
                gameObject.transform.SetAsFirstSibling();
                if(GameManager.Instance.FirstSuitTransform==null)
                    GameManager.Instance.FirstSuitTransform = gameObject.transform;
                return;
            }

            case 1:
            {
                if (GameManager.Instance.FirstSuitTransform != null)
                        gameObject.transform.SetSiblingIndex(GameManager.Instance.FirstSuitTransform.GetSiblingIndex() + 1);
                else
                    gameObject.transform.SetAsFirstSibling();
                return;
            }
            case 2:
            {
                if(GameManager.Instance.LastSuitTransform!=null)
                    gameObject.transform.SetSiblingIndex(GameManager.Instance.LastSuitTransform.GetSiblingIndex()-1);
                else
                    gameObject.transform.SetAsLastSibling();
                return;
            }
            case 3:
            {
                gameObject.transform.SetAsLastSibling();
                if(GameManager.Instance.LastSuitTransform == null)
                    GameManager.Instance.LastSuitTransform = gameObject.transform;
                return;
            }
            
            default:
            {
                return;
            }
        }
        //Animator.Play("GoInHand2");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("ClickedCard");
        if(!GameManager.Instance.IsOnPause)
            MakeMove();
    }

    public void MakeMove()
    {
        if (_canClick)
        {
            gameObject.transform.localScale.Set(0.45f,0.45f,1);
            gameObject.transform.SetParent(GameManager.Instance.TableTransform);
            StartCoroutine(LerpRectTransformPosition(new Vector2(0f, 0f), 0.5f));
            Animator.enabled = true;
            Animator.Play(("MakeMove"));
            GameManager.Instance.Score++;
            Destroy(gameObject, 2f);
            Debug.Log("ClickedCard");
            _canClick = false;
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnSuitChange -= SuitChangeHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private IEnumerator LerpRectTransformPosition(Vector2 target, float duration)
    {
        float time = 0;
        Vector2 startPosition = _rectTransform.position;


        while (time < duration)
        {
            _rectTransform.position = Vector2.Lerp(startPosition, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _rectTransform.position = target;
    }



}
