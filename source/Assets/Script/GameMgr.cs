using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    enum State
    {
        Main,
        GameOver
    }
    int score = 0;
    State state = State.Main;

    public void StartGameOver()
    {
        state = State.GameOver;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (state == State.Main)
        {
            score += 1;
        }
    }

    private void OnGUI()
    {
        DrawScore();
        float CenterX = Screen.width / 2;
        float CenterY = Screen.height / 2;
        if (state == State.GameOver)
        {
            DrawGameOver(CenterX, CenterY);
            if (DrawRetryButton(CenterX, CenterY))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    bool DrawRetryButton(float CenterX, float CenterY)
    {
        GUI.skin.button.fontSize = 32;
        GUI.contentColor = Color.black;
        float ofsY = 100;
        float w = 160;
        float h = 64;
        Rect rect = new(CenterX - w / 2, CenterY + ofsY, w, h);
        if (GUI.Button(rect, "RETRY"))
        {
            return true;
        }
        return false;
    }

    void DrawGameOver(float CenterX, float CenterY)
    {
        GUI.skin.label.fontSize = 96;
        GUI.contentColor = Color.magenta;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        float w = 400;
        float h = 100;
        Rect position = new(CenterX - w * 1.5f, CenterY - h, w * 3, h * 2);
        GUI.Label(position, "GAME VERNITIES");
    }

    void DrawScore()
    {
        GUI.skin.label.fontSize = 64;
        GUI.contentColor = Color.blue;
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        Rect position = new Rect(50, -40, 800, 200);
        GUI.Label(position, string.Format("Hanami power: {0}", score));
    }
}
