using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using UniRx.Triggers; // 이 using문이 필요


public class DoubleClickRX : MonoBehaviour
{
    public Text MyText;

    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => {
                if(Input.GetKeyDown(KeyCode.Space)){
                    print("한번클릭");
                }
            });

        //매프레임 마우스 클릭 이벤트를 관찰하는 스트림을 정의 한다.
        var clickStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0));

        //이 스트림에 0.3초 간 흘러들어오는 (마우스클릭) 이벤트를 모은다.(Buffer)
        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(300)))
        .Where(x => x.Count >= 2)             //(마우스클릭) 이벤트가 2회 이상 발생한 경우만 필터링
        .SubscribeToText(MyText, x =>         //위 조건을 충족한 경우 GUI의 MyText 컴포넌트에 정보 출력
        string.Format("Double Clicked! Click Count = {0}", x.Count));
    }
}
