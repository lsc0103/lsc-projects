using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public Slider healthBar;
    public Button healButton;
    public Button dashButton;
    public Button specialButton;

    void Start()
    {
        if (healButton)
            healButton.onClick.AddListener(() => FindObjectOfType<SkillSystem>().playerHealth.Heal(30));
        if (dashButton)
            dashButton.onClick.AddListener(() => FindObjectOfType<PlayerController>().SendMessage("StartDash", SendMessageOptions.DontRequireReceiver));
        if (specialButton)
            specialButton.onClick.AddListener(() => FindObjectOfType<SkillSystem>().SendMessage("ActivateSpecial", SendMessageOptions.DontRequireReceiver));
    }

    public void SetHealth(int value)
    {
        if (healthBar)
            healthBar.value = value;
    }

    public void StartGame()
    {
        if (startPanel)
            startPanel.SetActive(false);
        GameManager.Instance.BeginPlay();
    }
}
