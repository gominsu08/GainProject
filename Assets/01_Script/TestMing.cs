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
        //string str = "����� ������ ���ﵿ ��������Ʈ";
        //Regex regex = new Regex(@"[^sex][^����]");
        //Match m = regex.Match(str);
        //if (m.Success)
        //{
        //    Debug.Log($"{m.Index} / {m.Value}");
        //}
    }

    public void IN()
    {
        //MatchCollection mc = Regex.Matches(Input.text, @"[sex][����]");


        //Regex regex = new Regex(@"[^sex][^����]");
        //Match m = regex.Match(textMeshPro.text);

        var text = Input.text;
        var pattern = @"sex|����|�߽�";
        var replaced = Regex.Replace(text, pattern, "***");


        textMeshPro.text = replaced;
    }
}
