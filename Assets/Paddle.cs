using UnityEngine;

public class Paddle : MonoBehaviour {
    
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        height = transform.localScale.y;
        speed = 5f;
    }

    public void Init(bool isRightPaddle) {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;

        if (isRightPaddle) {
            // Place paddle on the right of screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; // Move a bit to the left
            input = "PaddleRight";
        } else {
            // Place paddle on the left of screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; // Move a bit to the right
            input = "PaddleLeft";
        }

        // Update this paddle's position
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update() {
        // Move the paddle

        // GetAxis is a number between -1 to 1 (-1 for down, 1 for up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // Restrict paddle movement
        // If paddle is too low and user is continuing to move down, stop
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        }
        // If paddle is too high and user is continuing to move up, stop
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0) {
            move = 0;
        }

        transform.Translate (move * Vector2.up);
    }
}
