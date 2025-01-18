using UnityEngine;

public class GameManager : MonoBehaviour {

    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    private int paddleLeftScore = 0;
    private int paddleRightScore = 0;

    Ball ballInstance;
    Paddle paddleRight, paddleLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        // Convert screen's pixel coordinate into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint (new Vector2 (0, 0));
        topRight = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, Screen.height));

        // Create two paddles
        paddleRight = Instantiate (paddle) as Paddle;
        paddleLeft = Instantiate (paddle) as Paddle;
        paddleRight.Init (true);  // right paddle
        paddleLeft.Init (false);  // left paddle

        // Create ball
        ballInstance = Instantiate (ball) as Ball;
        ballInstance.InitPaddles(paddleLeft, paddleRight);
    }

    void Update() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }

        // Reinstantiate ball and paddles, but only when a score occurs
        if (paddleLeft.Score != paddleLeftScore) {
            paddleLeftScore += 1;

            // Reposition paddles
            paddleRight.Init (true);
            paddleLeft.Init (false);

            // Reposition ball
            ballInstance.ResetBall ();
        }

        if (paddleRight.Score != paddleRightScore) {
            paddleRightScore += 1;

            // Reposition paddles
            paddleRight.Init (true);
            paddleLeft.Init (false);

            // Reposition ball
            ballInstance.ResetBall ();
        }
    }
}