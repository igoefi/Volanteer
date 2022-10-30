using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] Transform _player;

    [SerializeField] float _firstXPosition;

    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _maxScoreText;

    [SerializeField] PlayerInput input;

    public static int ScoreNum { get; private set; }
    private static int _maxScore;
    private static int _lastMaxScore;
    private void Start()
    {
        ScoreNum = 0;

        _maxScore = PlayerPrefs.GetInt("Score", 0);
        _lastMaxScore = _maxScore;

        _maxScoreText.text = _maxScore.ToString();

        input.LeftSwipeEvent.AddListener(SaveMaxScore);
    }

    void Update()
    {
        ScoreNum = (int)(_player.position.x - _firstXPosition);
        _scoreText.text = ScoreNum.ToString();

        if (ScoreNum > _maxScore)
        {
            _maxScore = ScoreNum;
            _maxScoreText.text = _maxScore.ToString();
        }
    }

    public static void SaveMaxScore()
    {
        if (_maxScore > _lastMaxScore)
            PlayerPrefs.SetInt("Score", _maxScore);
    }
}
