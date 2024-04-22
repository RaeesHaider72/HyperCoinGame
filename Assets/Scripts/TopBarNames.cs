using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarNames : MonoBehaviour
{

    public Text namePlace;
    public List<string> randomNames = new() ;



    public void NewName()
    {
        int x = Random.Range(0, randomNames.Count);
        namePlace.text = randomNames[x];


    }



}
