using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MagicText : MonoBehaviour
{
    public List<string> funnyThings;
    private void OnEnable()
    {
        GetComponent<TMP_Text>().text = funnyThings[UnityEngine.Random.Range(0, funnyThings.Count)];
    }
}
