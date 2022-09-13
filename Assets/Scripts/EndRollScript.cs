using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndRollScript : MonoBehaviour
{
    public GameObject Logo;
    private bool LogoFlag=false;

    private Text tex;

    private int state=0;
    private float interval=6.0f;
    private float time = 5.0f;

    private string end = "おわり";
    private string staff1 = "スタッフ\n＜　けーる　＞\nグラフィック\nプログラミング";
    private string staff2 = "スタッフ\n＜　アダ　＞\nサウンド\nプログラミング";
    private string staff3 = "スタッフ\n＜　酢酸カーミン　＞\nプログラミング\nステージ制作";
    private string se =     "スタッフ\n＜　chouette  ＞\nプログラミング\nステージ制作\nデバッグ";
    private string company = "九州工業大学\nプログラミング研究会";

    private Vector3 logPos= new Vector3(0.0f,1.6f,0.0f);

    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<Text>(); 
        Invoke("nextState",time);
        time += interval;
        Invoke("nextState",time);
        time += interval;
        Invoke("nextState",time);
        time += interval;
        Invoke("nextState",time);
        time += interval;
        Invoke("nextState",time);
        time += interval*3;
        Invoke("nextState",time);
    }

    void ChangeText(string str){
        tex.text = str;
    }

    void nextState(){
        state++;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                tex.text = end;
                break;

            case 1:
                tex.text = staff1;
                break;

            case 2:
                tex.text = staff2;
                break;

            case 3:
                tex.text = staff3;
                break;
            
            case 4:
                tex.text = se;
                break;
            
            case 5:
                if(!LogoFlag){
                    Instantiate(Logo,logPos,Quaternion.identity);
                    LogoFlag = true;
                } 
                tex.text = company;
                break;
            
            case 6:
                SceneManager.LoadScene("title");
                break;

            default:
                break;
        }
    }
}
