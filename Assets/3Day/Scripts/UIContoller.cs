using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIContoller : MonoBehaviour
{
    public TextMeshProUGUI scoreNum;
    public int totalScore;
    public void UpdateScore(int score)
    {
        //������ UI�� �����ְ� Tostring�� ���ڸ� ���ڷ� �ٲ���
        // +=    a = a+b;     totalscore = totalscore + score
        totalScore += score;
        scoreNum.text = totalScore.ToString();
    }
}
