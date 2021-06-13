using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Profile
{
    // private string name;
    // private int height;
    // public Profile(){
    //     name = Name;
    //     height = Height;
    // }

    public string Name { get; set;}
    public int Height { get; set; }


}

public class LinqExample2 : MonoBehaviour
{
    public Profile[] arrProfiles = {
                new Profile(){Name = "태욱", Height = 180},
                new Profile(){Name = "수영", Height = 160},
                new Profile(){Name = "별이", Height = 40}
            };

    public List<Profile> listProfiles;

    void Start()
    {
        listProfiles.Add( new Profile(){Name = "태욱", Height = 180} );
        // listProfiles.Add( new Profile(){name = "수영", height = 160} );
        // listProfiles.Add( new Profile() {name = "별이", height = 40} );

        Debug.Log(listProfiles[0].Name);

        var profiles = from profile in arrProfiles
                        where profile.Height > 100
                        orderby profile.Height
                        select new{
                            name = profile.Name,
                            InchHeight = profile.Height * 0.393
        };

        foreach(var profile in profiles){
            Debug.Log("이름: " + profile.name + ", 인치: " + profile.InchHeight);
        }

    }

}
