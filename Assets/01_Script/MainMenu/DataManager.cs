using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public int currentStage = 0;

    public int currentStageInfo = 0;

    public string quest = "";

    public float currentGold;

    public int enemyCount;
    
    public int waveCount;

    public int itemCount;

    public List<string> buyUnitList = new List<string>();

    public List<bool> StageClear = new List<bool>();

    public List<bool> StageUse = new List<bool>();

    private string _loginIDSave;
    private string _joinIDSave;
    private string _joinPWSave;
    private string _loginPWSave;
}
