using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventary",menuName = "Intventary/New Inventary")]
public class Inventary : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
