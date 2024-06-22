using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    private void Awake()
    {
        var obj = FindObjectsOfType<DataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        for (int i = 0; i < clearStage; i++)
        {
            StageClear[i] = true;
        }

        for (int i = 0; i < useStage; i++)
        {
            StageUse[i] = true;
        }

        clearStage = StageClear.Count(item => item == true);
        useStage = StageUse.Count(item => item == true);

    }
    public int currentStage = 0;

    public int currentStageInfo = 0;

    public string quest = "";

    public float currentGold;

    public float CurrentGold
    {
        get {return currentGold;}
        set 
        {
            if (value <= 0)
            {
                currentGold = 0;
            }
            else
            {
                currentGold = value;
            }
        }
    }

    public int enemyCount;
    
    public int waveCount;

    public int itemCount;

    public List<string> buyUnitList = new List<string>();

    public List<bool> StageClear = new List<bool>();

    public List<bool> StageUse = new List<bool>();

    

    public int useStage = 0;

    public int clearStage = 0;

    public string _loginIDSave;
    public string _loginPWSave;
}
