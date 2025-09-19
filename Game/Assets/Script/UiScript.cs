using TMPro;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    public TextMeshProUGUI UnitMax;
    public TextMeshProUGUI walletUi;
    public void Update()
    {
        Text();
        wallet();
    }
    public void wallet()
    {
        walletUi.text = "골드 : " + GameManager.gameMoney + "G";
    }
    public void Text()
    {
        UnitMax.text = "유닛 수 : " + GameManager.currentUnits + "/" + GameManager.maxunits;
    }
}
