using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PatternManager : MonoBehaviour
{
    public string pattern="7689";
    public string[] color = { "<color='green'>", "</color>" };
    public Text Pattern_Text;
    public int digit_index = 0;

    public Coroutine game;

    public delegate void MyDelegate(char num);
    public static MyDelegate change_wrong_clr;
    public static MyDelegate change_right_clr;
    public bool message_flag = false;
    private IEnumerator Inum_Game_started_Correct()
    {
        Pattern_Text.text = "PATTERN MATCHED";
        message_flag = true;
        yield return new WaitForSeconds(2);
        message_flag = false;
        generate_new_pattern();

    }
    // Start is called before the first frame update
    void Start()
    {
        Pattern_Text = this.GetComponentInChildren<Text>();
        update_pattern_ui();
        ButtonManager.myDelegate += key_Pressed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void key_Pressed(char digit)
    {
        Debug.Log("Key pressed");
        if(digit== pattern[digit_index])
        {
            //change_clr(digit);
            change_right_clr(digit);
            digit_index++;
            change_color(digit_index);
            if(digit_index==4)
            {
                game = StartCoroutine(Inum_Game_started_Correct());
                //while (message_flag == true) ;
                //generate_new_pattern();
            }
        }
        else
        {
            change_wrong_clr(digit);
        }
    }
    void change_color(int index)
    {
        string new_str = pattern;
        new_str=new_str.Insert(index, color[1]);
        new_str = new_str.Insert(0, color[0]);
        Pattern_Text.text = new_str;
        //Debug.Log(new_str);
    }
    string generate_pattern()
    {
        string ret_str = "";
        for(int i=0;i<4;i++)
        {
            
            
            //return getrandom.Next(min, max);
            ret_str += UnityEngine.Random.Range(1,10).ToString();
            
            
        }
        return ret_str;
    }
    void generate_new_pattern()
    {
        pattern = generate_pattern();
        digit_index = 0;
        update_pattern_ui();
    }
    void update_pattern_ui()
    {
        Pattern_Text.text = pattern;
    }
}
