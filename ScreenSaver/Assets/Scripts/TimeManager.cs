using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeManager : MonoBehaviour {
    public TextMeshProUGUI DateText;
    public TextMeshProUGUI ClockText;
    public TextMeshProUGUI DDayText;

    private string strDate;
    private string strClock;
    private string strDDay;
    
    string[] week = new string[]{"일","월","화","수","목","금","토"};
    int dday1 = 235; // 개학 8월 23일의 DayOfYear 값
    int dday2 = 298; // 중간고사 10월 25일의 DayOfYear 값 & 중간고사는 3일 치름
    int dday3 = 354; // 기말고사 12월 20일의 DayOfYear 값 & 기말고사는 5일 치름

    void Update (){
        // clock 사전
        DateTime time = DateTime.Now;
        string hour = LeadingZero( time.Hour );
        string minute = LeadingZero( time.Minute );
        string second = LeadingZero( time.Second );
        // DDay 사전        
        int today = time.DayOfYear; 
        
        // TMPro, Date
        strDate = time.Month.ToString() + "/" + time.Day.ToString() + " (" +  week[(int)time.DayOfWeek] + ")" ;
        DateText.text = strDate;
        // TMPro, clock
        strClock = hour + ":" + minute + ":" + second;
        ClockText.text = strClock;
        // TMPro, DDay
        strDDay = "D-" + (dday1-today).ToString();
        DDayText.text = strDDay;
    }
    string LeadingZero (int n){
        return n.ToString().PadLeft(2, '0');
    }
}