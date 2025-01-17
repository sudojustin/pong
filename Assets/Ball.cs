using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    // private int _playerScore = 0;
    // private int _computerScore = 0;

    public GameObject a;
    public UIManager script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        direction = Vector2.one.normalized;  // direction is (1, 1) normalized
        radius = transform.localScale.x / 2; // half the width

        // script = a.getComponent<UIManager>();
    }

    public void AddScore(string side) {
        if (side == "player") {
            // _playerScore += 1;
            UIManager._playerScore += 1;
        } else {
            // _computerScore += 1;
            UIManager._computerScore += 1;
        }
    }

    public void Init() {
        Vector2 pos = Vector2.zero;

        // Place ball in the center of the screen
        pos = new Vector2(0, 0);

        // Update the ball's postion
        transform.position = pos;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate (direction * speed * Time.deltaTime);

        // Bounce off top and bottom
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0) {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0) {
            direction.y = -direction.y;
        }

        // Game over
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0) {
            // Add 1 to playerScore
            AddScore("player");
            Debug.Log("Player score: " + UIManager._playerScore);

            Debug.Log ("Right player wins!");

            // For now, just freeze time
            if (UIManager._playerScore == 3) {
                Time.timeScale = 0;
                enabled = false; // Stop updating the script
            }
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0) {
            // Add 1 to computerScore
            AddScore("computer");
            Debug.Log("Computer score: " + UIManager._computerScore);

            Debug.Log ("Left player wins!");

            // For now, just freeze time
            if (UIManager._computerScore == 3) {
                Time.timeScale = 0;
                enabled = false; // Stop updating the script
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Paddle") {
            bool isRight = other.GetComponent<Paddle> ().isRight;

            // If hitting right paddle and moving right, flip direction
            if (isRight == true && direction.x > 0) {
                direction.x = -direction.x;
            }
            // If hitting left paddle and moving left, flip direction
            if (isRight == false && direction.x < 0) {
                direction.x = -direction.x;
            }
        }
    }
}