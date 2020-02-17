using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public Button btn;
    public string s;
    public delegate void MyDelegate(char num);
    public static MyDelegate myDelegate;
    public Coroutine game;
    private IEnumerator Inum_Game_started()
    {
        btn.image.color = Color.red;
        yield return new WaitForSeconds(1);
        btn.image.color = Color.white;
    }
    private IEnumerator Inum_Game_started_Correct()
    {
        btn.image.color = Color.green;
        yield return new WaitForSeconds(1);
        btn.image.color = Color.white;
    }
    public void TaskOnClick()
    {
        Debug.Log("Button pressed");

        myDelegate(s[0]);
    }
    public void generate_event(char c)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        s = this.gameObject.GetComponentInChildren<Text>().text;
        btn.onClick.AddListener(TaskOnClick);
        PatternManager.change_wrong_clr += change_clr_btn;
        PatternManager.change_right_clr += change_clr_btn2;
        //myDelegate(s[0]);
    }

    void change_clr_btn2(char c)
    {
        if (s[0] == c)
        {
            game = StartCoroutine(Inum_Game_started_Correct());
        }
        else
        {
            // game = StartCoroutine(Inum_Game_started_Correct());

        }
    }
    void change_clr_btn(char c)
    {
        if(s[0]==c)
        {
            game = StartCoroutine(Inum_Game_started());
        }
        else
        {
           // game = StartCoroutine(Inum_Game_started_Correct());

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
