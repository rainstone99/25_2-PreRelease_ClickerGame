using TMPro;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    public TextMeshProUGUI UnitMax;
    public TextMeshProUGUI walletUi;
    public void FixedUpdate()
    {
        Text();
        wallet();
    }
    public void wallet()
    {
        walletUi.text = "골드 : " + UnitScript.gameMoney + "G";
    }
    public void Text()
    {
        UnitMax.text = "유닛 수 : " + GameManager.Instance.currentUnits + "/" + GameManager.Instance.maxunits;
    }
}
