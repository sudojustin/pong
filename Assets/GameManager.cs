using UnityEngine;

public class GameManager : MonoBehaviour {

    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    private int paddleLeftScore = 0;
    private int paddleRightScore = 0;

    Ball ball1;
    Paddle paddle1, paddle2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        // Convert screen's pixel coordinate into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint (new Vector2 (0, 0));
        topRight = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, Screen.height));

        // Create ball
        ball1 = Instantiate (ball) as Ball;

        // Create two paddles
        paddle1 = Instantiate (paddle) as Paddle;
        paddle2 = Instantiate (paddle) as Paddle;
        paddle1.Init (true);  // right paddle
        paddle2.Init (false); // left paddle
    }

    void Update() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }

        // Reinstantiate ball and paddles, but only when a score occurs
        if (UIManager._computerScore != paddleLeftScore) {
            paddleLeftScore += 1;

            // Reposition paddles
            paddle1.Init (true);
            paddle2.Init (false);

            // Reposition ball
            ball1.Init ();
        }

        if (UIManager._playerScore != paddleRightScore) {
            paddleRightScore += 1;

            // Reposition paddles
            paddle1.Init (true);
            paddle2.Init (false);

            // Reposition ball
            ball1.Init ();
        }
    }
}