using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSurvived : MonoBehaviour
{
    public Text roundText;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        StartCoroutine(AnimateText());
//        roundText.text = PlayerStats.rounds.ToString();
    }

    IEnumerator AnimateText()
    {
        roundText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while(round < PlayerStats.rounds)
        {
            round++;
            roundText.text = round.ToString();
            yield return new WaitForSeconds(.05f);
        }

    }


}
