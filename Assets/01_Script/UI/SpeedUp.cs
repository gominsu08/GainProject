using TMPro;
using UnityEngine;


public class SpeedUp : MonoBehaviour
{
    public int isTimeScale;
    public TMP_Text text;

    public void SpeedSet()
    {
        if (isTimeScale == 0)
        {
            Time.timeScale = 1.5f;
            text.color = Color.green;
            isTimeScale = 1;
        }
        else if(isTimeScale == 1)
        {
            Time.timeScale = 2.5f;
            text.color = Color.red;
            isTimeScale = 2;
        }
        else if (isTimeScale == 2)
        {
            Time.timeScale = 1;
            text.color = Color.white;
            isTimeScale = 0;
        }
    }
}
