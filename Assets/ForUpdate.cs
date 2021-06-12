using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForUpdate : MonoBehaviour
{
    List<string> strs = new List<string>();

    private void Start()
    {
        for(int i = 0 ; i < 1000000; i++){
            strs.Add(i.ToString());
        }
    }

    private void Update()
    {
        for(int i = 0 ; i < 1000000 ; i++){
            string str = strs[i];
        }
    }
}
