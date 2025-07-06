using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerHealth playerHealth;
    public Weapon specialWeapon;

    public int healAmount = 30;
    public float specialDuration = 5f;

    private bool specialActive;
    private float specialTimer;

    void Update()
    {
        if (GameManager.Instance && !GameManager.Instance.IsPlaying)
            return;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerHealth.Heal(healAmount);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateSpecial();
        }

        if (specialActive)
        {
            specialTimer -= Time.deltaTime;
            if (specialTimer <= 0)
            {
                DeactivateSpecial();
            }
        }
    }

    void ActivateSpecial()
    {
        if (specialWeapon)
        {
            specialWeapon.gameObject.SetActive(true);
            specialActive = true;
            specialTimer = specialDuration;
        }
    }

    void DeactivateSpecial()
    {
        if (specialWeapon)
        {
            specialWeapon.gameObject.SetActive(false);
        }
        specialActive = false;
    }
}
