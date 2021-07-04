using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person{
    private string name;
    // 자바에서는 겟 셋 프로퍼티가 없어서 이렇게 사용
    public string GetName(){
        return name;
    }
    public void SetName(string name){
        this.name = name;
    }

    // C#에서는 속성을 제공해줘서 이렇게 사용
    public string Name { get; set; }
}
public class CoroutineWithUsing : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Person person = new Person {Name = null};
        print(person?.Name); // 널이 아니면 Name을 출력
        
    }

}
