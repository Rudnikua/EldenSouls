using UnityEngine;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour
{
    void Start()
    {
        
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => UISoundManager.Instance.PlayClick());
        }
    }
}
