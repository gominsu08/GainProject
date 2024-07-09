using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class TestMing : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public TMP_InputField Input;

    private void Start()
    {
        //string str = "서울시 강남구 역삼동 강남아파트";
        //Regex regex = new Regex(@"[^sex][^섹스]");
        //Match m = regex.Match(str);
        //if (m.Success)
        //{
        //    Debug.Log($"{m.Index} / {m.Value}");
        //}
    }

    public void IN()
    {
        //MatchCollection mc = Regex.Matches(Input.text, @"[sex][섹스]");


        //Regex regex = new Regex(@"[^sex][^섹스]");
        //Match m = regex.Match(textMeshPro.text);

        var text = Input.text;
        var pattern = @"sex|섹스|야스";
        var replaced = Regex.Replace(text, pattern, "***");


        textMeshPro.text = replaced;
    }
}
