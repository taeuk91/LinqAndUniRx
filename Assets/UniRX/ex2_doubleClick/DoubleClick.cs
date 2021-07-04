using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleClick : MonoBehaviour
{
    public Text MyText; //Text GUI
    bool isClicked = false; //첫번째 클릭이 된 상태인가
    float clickTime = 0.0f; //첫번째 클릭 후 흐른 시간

    // Update is called once per frame
    void Update()
    {
        if (isClicked == true)  //이미 첫번째 클릭이 되었다면
        {
            clickTime += Time.deltaTime;  //흐른 시간을 누적 시킨다
        }
    
        if (Input.GetMouseButtonDown(0))  //마우스를 클릭 했다면
        {
            if (isClicked == false) //이번이 첫 클릭이라면
            {
            isClicked = true;
            }
            else        //이번이 두번째 클릭이라면
            {
                if (clickTime <= 0.3f) //첫 클릭 후 0.3초 이내에 클릭되었다면
                {
                    //더블클릭 성공
                    gameObject.GetComponent<Text>().text = "Double Clicked!";
                }
                
                clickTime = 0.0f;
                isClicked = false;
            }
        }
    }
}
