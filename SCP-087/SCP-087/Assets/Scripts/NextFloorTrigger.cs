using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextFloorTrigger : MonoBehaviour
{
    public GameObject character;

    public TMP_Text higherFloorText;

    public TMP_Text lowerFloorText;

    private string StringIncrement(string number)
    {
        int.TryParse(number, out var result);

        ++result;

        return result.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        character.SetActive(false);

        var currentPosition = character.transform.position;
        character.transform.position = new Vector3(currentPosition.x, currentPosition.y + 7.63f, currentPosition.z);

        character.SetActive(true);

        higherFloorText.text = StringIncrement(higherFloorText.text);
        lowerFloorText.text = StringIncrement(lowerFloorText.text);
    }
}
