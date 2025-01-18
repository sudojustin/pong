using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    private Paddle paddleLeft;
    private Paddle paddleRight;

    private UIManager uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        direction = Vector2.one.normalized;  // direction is (1, 1) normalized
        radius = transform.localScale.x / 2; // half the width

        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void InitPaddles(Paddle left, Paddle right) {
        paddleLeft = left;
        paddleRight = right;
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
            paddleRight.IncreaseScore();
            uiManager.AddToPlayerScore();
            Debug.Log("Player score: " + paddleRight.Score);

            if (paddleRight.Score == 3) {
                Debug.Log("Player wins!");
                Time.timeScale = 0;
                enabled = false; // Stop updating the script
            }
        }

        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0) {
            // Add 1 to computerScore
            paddleLeft.IncreaseScore();
            uiManager.AddToComputerScore();
            Debug.Log("Computer score: " + paddleLeft.Score);

            if (paddleLeft.Score == 3) {
                Debug.Log("Computer wins!");
                Time.timeScale = 0;
                enabled = false; // Stop updating the script
            }
        }
    }

    public void ResetBall() {
        Vector2 pos = Vector2.zero;

        // Place ball in the center of the screen
        pos = new Vector2(0, 0);

        // Update the ball's postion
        transform.position = pos;
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