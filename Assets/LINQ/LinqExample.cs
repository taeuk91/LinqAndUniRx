using System;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


[System.Serializable]
public class Serialization<TKey, TValue> : ISerializationCallbackReceiver{
    [SerializeField]
    List<TKey> keys;
    [SerializeField]
    List<TValue> values;

    Dictionary<TKey, TValue> target;
    public Dictionary<TKey, TValue> ToDictionary()
    {
        return target;
    }

    public Serialization(Dictionary<TKey, TValue> target)
    {
        this.target = target;
    }

    public void OnBeforeSerialize()
    {
        keys = new List<TKey>(target.Keys);
        values = new List<TValue>(target.Values);
    }

    public void OnAfterDeserialize()
    {
        var count = Math.Min(keys.Count, values.Count);
        target = new Dictionary<TKey, TValue>(count);
        for(var i = 0 ; i < count; i++)
        {
            target.Add(keys[i], values[i]);
        }
    }
}

public class LinqExample : MonoBehaviour
{
    public string[] names = {"henry", "태욱", "수영", "별"};
    public int[] quizGrades = {44, 55, 66, 33, 44, 99}; 



    // Start is called before the first frame update
    void Start()
    {
        // 1. Any : names 배열에서 태욱인 name이 있는지 없는지
        //var nameFound = names.Any(name => name == "태욱");
        //Debug.Log("NameFound:" + nameFound);

        // 2. Contains : names 배열에서 태욱을 가지고 있는지
        //var nameFound = names.Contains("태욱");
        //Debug.Log("NameFound:" + nameFound);

        // 3. Distinct : 중복되는 것들을 제거
        // var uniqueName = names.Distinct();
        // foreach(var name in uniqueName){
        //     Debug.Log("Name + " + name);
        // }

        // 4. Where : 컬렉션을 정렬하고 특정 조건으로 새 컬렉션을 만듬
        // 문자열의 길이가 5이상인 것들만 서술
        // var result = names.Where(name => name.Length > 1);
        // foreach(var name in result){
        //     Debug.Log("name:" + name);
        // }

        // 5. 퀴즈
        // var passingGrades = quizGrades.Where(grade => grade > 60);
        // foreach(var grade in passingGrades){
        //     Debug.Log("Grade : " + grade);
        // }

        // 6. 학생정보에서 점수(Value)중 90점 이상을 내림차순으로 정렬
        Dictionary<string, int> studentsAndGrade = new Dictionary<string, int>();

        studentsAndGrade.Add("Henry", 100);
        studentsAndGrade.Add("별", 80);
        studentsAndGrade.Add("수영", 95);
        studentsAndGrade.Add("태욱", 99);

        var sortedList = studentsAndGrade.Where(grade => grade.Value > 90)
                                         .OrderByDescending(grade2 => grade2.Value);
        foreach(var info in sortedList)
        {
            Debug.Log("이름: " + info.Key + ", 점수:" + info.Value);
        }

        // 6-1. Deserialization Dictionary from Json file
        string jsonData = JsonUtility.ToJson(new Serialization<string, int>(studentsAndGrade));
        CreateJsonFile(Application.dataPath + "//LINQ", "StudentInfo", jsonData);

        // 6-2. LINQ to Json file
        string jsonData2 = JsonConvert.SerializeObject(sortedList);
        CreateJsonFile(Application.dataPath + "//LINQ", "SortedList", jsonData2);

        // foreach(var name in names){
        //     if(name =="태욱")
        //     {
        //         Debug.Log("NameFound");
        //     }
        // }


    }

    void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
}
