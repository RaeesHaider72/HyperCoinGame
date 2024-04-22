using System.Collections.Generic;
using UnityEngine;

public class RuntimeVariables : MonoBehaviour
{

    public int roundNumber;
    public int roundCount;
    public int totalCash;
    public bool isSceneRestarted;

    public List<int> unlockLevels = new List<int>();
    public List<string> roundStatus = new List<string>();

    private static RuntimeVariables _instance;
    public static RuntimeVariables Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RuntimeVariables>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(RuntimeVariables).Name);
                    _instance = singletonObject.AddComponent<RuntimeVariables>();
                }
            }
            DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
