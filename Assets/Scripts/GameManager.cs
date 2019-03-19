using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]private Text ScoreText;

    [SerializeField] private GameObject losePanel;

    private Camera cam;
    private int _scores;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        cam = Camera.main;

        float width = cam.pixelWidth;
        float height = cam.pixelHeight;

        BotBorder = cam.ScreenToWorldPoint(new Vector2(0, 0)).y;
        TopBorder = cam.ScreenToWorldPoint(new Vector2(0, height)).y;
        LeftBorder = cam.ScreenToWorldPoint(new Vector2(0, 0)).x;
        RightBorder = cam.ScreenToWorldPoint(new Vector2(width, 0)).x;
    }

    private void Start()
    {
        CreatePlayer();

    }

    private void CreatePlayer()
    {
        var damagable = Player.Instance.GetComponent<Damagable>();
        damagable.DieEvent += OnPlayerDead;
    }


    public void AddScore(int value)
    {
        _scores += value;

        ScoreText.text = _scores.ToString();
    }

    private void OnPlayerDead(Damagable damagable)
    {
        losePanel.SetActive(true);
    }

    public float BotBorder { get; private set; }
    public float TopBorder { get; private set; }
    public float LeftBorder { get; private set; }
    public float RightBorder { get; private set; }
}
