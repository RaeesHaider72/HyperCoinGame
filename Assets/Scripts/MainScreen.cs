using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{


    public GameObject character1;

    public Transform characPos;


    private void Awake()
    {
       
    }

    private void OnEnable()
    {

        character1.transform.SetPositionAndRotation(characPos.position, characPos.rotation);

    }
    private void Start()
    {
        character1.transform.SetPositionAndRotation(characPos.position, characPos.rotation);
    }
}
