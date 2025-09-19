using TMPro;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    public TextMeshProUGUI UnitMax;
    public TextMeshProUGUI walletUi;
    public TextMeshProUGUI UserNameUi;
    public TextMeshProUGUI CurrentUnitUi;
    public TextMeshProUGUI GainGoldUi;
    public void Update()
    {
        if (UnitMax != null)
        {
            UnitText();
        }
        if (walletUi != null)
        {
            wallet();
        }
        if (UserNameUi != null)
        {
            NameText();
        }
        if (CurrentUnitUi != null)
        {
            CurrentUnit();
        }
        if (GainGoldUi != null)
        {
            GainGoldText();
        }
    }
    public void wallet()
    {
        walletUi.text = "골드 : " + GameManager.gameMoney + "G";
    }
    public void UnitText()
    {
        UnitMax.text = "유닛 수 : " + GameManager.currentUnits + "/" + GameManager.maxunits;
    }
    public void NameText()
    {
        UserNameUi.text = "사용자 이름 : ";
    }
    public void CurrentUnit()
    {
        CurrentUnitUi.text = "현재 유닛 수 : " + GameManager.currentUnits + "/" + GameManager.maxunits;
    }
    public void GainGoldText()
    {
        GainGoldUi.text = "초당 골드 생산량 : " + GameManager.TotalGainGold + "G";
    }
}