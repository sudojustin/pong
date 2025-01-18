using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (SceneManager.GetActiveScene().name != "Game") {
            SceneManager.LoadScene("Game");
        }
    }
}
