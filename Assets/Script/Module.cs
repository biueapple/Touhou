using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    [SerializeField]
    private List<Attack> weapons = new();
    public List<Attack> Weapons { get { return weapons; } }

    public void Fire()
    {
        foreach (var weapon in weapons)
        {
            weapon.Fire();
        }
    }
}
