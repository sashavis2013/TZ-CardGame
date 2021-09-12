using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public Transform FirstSuitTransform;
    public Transform LastSuitTransform;
    public Transform TableTransform;
    public bool IsOnPause = false;

    private int m_Score = 0;
    [SerializeField]
    public int Score
    {
        get { return m_Score; }
        set
        {
            if (m_Score == value) return;
            m_Score = value;
            OnScoreChange?.Invoke(m_Score);
        }
    }

    public delegate void OnScoreChangeDelegate(int newVal);
    public event OnScoreChangeDelegate OnScoreChange;


    private int m_MoveSuitIndex = 0;
    [SerializeField]
    public int MoveSuitIndex
    {
        get { return m_MoveSuitIndex; }
        set
        {
            if (m_MoveSuitIndex == value) return;
            m_MoveSuitIndex = value;
            OnSuitChange?.Invoke(m_MoveSuitIndex);
        }
    }

    public delegate void OnSuitChangeDelegate(int newVal);
    public event OnSuitChangeDelegate OnSuitChange;

    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        this.OnScoreChange += ScoreChangeHandler;
    }

    private void ScoreChangeHandler(int newVal)
    {
        ScoreText.text = Score.ToString();
    }







}
