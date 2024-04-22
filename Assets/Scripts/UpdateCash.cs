using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCash : MonoBehaviour
{
    public static UpdateCash ins;
    // Start is called before the first frame update
    public Text cashText;


    private void Awake()
    {
        ins = this;
    }
    void Start()
    {
        cashText = GetComponent<Text>();
        UpdateCashUI();
    }

    public void UpdateCashUI()
    {
        cashText.text = RuntimeVariables.Instance.totalCash.ToString();
    }
}
