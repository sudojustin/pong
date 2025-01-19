using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    
    public int _playerScore = 0;
    public int _computerScore = 0;

    [SerializeField]
    private TMP_Text _playerScoreText;

    [SerializeField]
    private TMP_Text _computerScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        UpdateScoreUI();
    }

    public void AddToPlayerScore() {
        _playerScore += 1;
        UpdateScoreUI();
    }

    public void AddToComputerScore() {
        _computerScore += 1;
        UpdateScoreUI();
    }

    // Method to update the score UI
    private void UpdateScoreUI() {
        if (_playerScoreText != null) {
            _playerScoreText.text = "Score " + _playerScore.ToString();
        } 

        if (_computerScoreText != null) {
            _computerScoreText.text = _computerScore.ToString();
        }
    }
}