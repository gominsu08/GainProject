using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAmmy : MonoBehaviour
{
    private void Awake()
    {

        for (int i = 0; i < DataManager.Instance.StageUse.Count; i++)
        {
            if (i == 0) DataManager.Instance.StageUse[i] = true;
            else DataManager.Instance.StageUse[i] = false;
        }


        for (int i = 0; i < DataManager.Instance.StageClear.Count; i++)
        {
            DataManager.Instance.StageClear[i] = false;
        }
        DataManager.Instance.useStage = 1;
        DataManager.Instance.clearStage = 0;
    }
}
