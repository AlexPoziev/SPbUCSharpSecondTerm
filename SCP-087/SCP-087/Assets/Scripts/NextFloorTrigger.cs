using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextFloorTrigger : MonoBehaviour
{
    public GameObject Character;

    public TMP_Text HigherFloorText;

    public TMP_Text LowerFloorText;

    private string StringIncrement(string number)
    {
        int.TryParse(number, out var result);

        ++result;

        return result.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        Character.SetActive(false);

        var currentPosition = Character.transform.position;
        Character.transform.position = new Vector3(currentPosition.x, currentPosition.y + 7.63f, currentPosition.z);

        Character.SetActive(true);

        HigherFloorText.text = StringIncrement(HigherFloorText.text);
        LowerFloorText.text = StringIncrement(LowerFloorText.text);
    }
}
