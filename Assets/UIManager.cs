using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    
    [SerializeField]
    public static int _playerScore;

    [SerializeField]
    public static int _computerScore;

    [SerializeField]
    private TMP_Text _playerScoreText;

    [SerializeField]
    private TMP_Text _computerScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update() {
        UpdateScoreUI();
    }

    // Method to update the score UI
    private void UpdateScoreUI() {
        if (_playerScoreText != null) {
            _playerScoreText.text = "Score " + _playerScore;
            // _playerScoreText.text =  _playerScore.ToString();
        } 

        if (_computerScoreText != null) {
            // _computerScoreText.text = "COMPUTER " + _computerScore;
            _computerScoreText.text = _computerScore.ToString();
        }
    }
}