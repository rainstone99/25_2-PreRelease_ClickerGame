using UnityEngine;

public class TapOpen : MonoBehaviour
{
    public GameObject OpenTap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Open()
    {
        OpenTap.SetActive(true);
    }
    public void Off()
    {
        OpenTap.SetActive(false);
    }
}
