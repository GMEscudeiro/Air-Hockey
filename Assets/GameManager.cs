using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;
    private GUIStyle labelStyle;
    GameObject theBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    public static void Score(string wallID){
        if (wallID == "TopMiddleWall"){
            PlayerScore1++;
        } else {
            PlayerScore2++;
        }
    }

    void OnGUI(){
        GUI.skin = layout;
        labelStyle = new GUIStyle();
        labelStyle.normal.textColor = Color.black;
        labelStyle.fontSize = 120;
        GUI.Label(new Rect(Screen.width - 200, 500, 200, 200), "" + PlayerScore2, labelStyle);
        GUI.Label(new Rect(Screen.width - 200, 950, 100, 200), "" + PlayerScore1, labelStyle);

        if(GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART")){
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if(PlayerScore1 == 10){
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if(PlayerScore2 == 10){
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
