using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public TextMeshProUGUI UnitMax;
    public TextMeshProUGUI walletUi;
    public TextMeshProUGUI UserNameUi;
    public TextMeshProUGUI CurrentUnitUi;
    public TextMeshProUGUI GainGoldUi;
    public TextMeshProUGUI touchGainGoldUi;
    public TextMeshProUGUI touchUpgradePriceUi;
    public TextMeshProUGUI addMaxLimitPriceUi;
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
        if (touchGainGoldUi != null)
        {
            TouchGainGoldText();
        }
        if (touchUpgradePriceUi != null)
        {
            TouchUpgradePrice();
        }
        if (addMaxLimitPriceUi != null)
        {
            AddMaxLimitPrice();
        }
    }
    public void wallet()
    {
        walletUi.text = "골드 : " + GameManager.gameMoney + "G";
    }
    public void UnitText()
    {
        UnitMax.text = "유닛 수 : " + GameManager.currentUnits + "/" + GameManager.maxUnits;
    }
    public void NameText()
    {
        UserNameUi.text = "사용자 이름 : ";
    }
    public void CurrentUnit()
    {
        CurrentUnitUi.text = "현재 유닛 수 : " + GameManager.currentUnits + "/" + GameManager.maxUnits;
    }
    public void GainGoldText()
    {
        GainGoldUi.text = "초당 골드 생산량 : " + GameManager.TotalGainGold + "G";
    }
    public void TouchGainGoldText()
    {
        touchGainGoldUi.text = "터치 골드 생산량 (Level)\n: " + GameManager.touchGainGold
                             + "G(" + GameManager.touchUpgradeLevel + "Level)";
    }
    public void TouchUpgradePrice()
    {
        touchUpgradePriceUi.text = "구매(" + GameManager.touchUpgradePrice + "G)";
    }
    public void AddMaxLimitPrice()
    {
        addMaxLimitPriceUi.text = "구매(" + GameManager.maxLimitUpgradePrice + "G)";
    }
}