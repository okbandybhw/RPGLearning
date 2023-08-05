using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject HpBar;
    [SerializeField] Image HP_BarImg;
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    Character character;

    public void SetTargetCharacter(Character character)
    {
        this.character = character;
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            HpBar.SetActive(true);
            HP_BarImg.fillAmount = Mathf.InverseLerp(0f, (float)character.GetStatsMaxValue(GameData.StatsType.Life), (float)character.GetStatsValue(GameData.StatsType.Life));
            textOnScreen.text = character.transform.name;
        }
        else
        {
            HpBar.SetActive(false);
            textOnScreen.text = "";
        }
    }
}
