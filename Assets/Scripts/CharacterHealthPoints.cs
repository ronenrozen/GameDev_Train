using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthPoints : MonoBehaviour
{

    public static int hp = 100;
    public Text hpLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpLabel.text = "" + hp;
    }
}
