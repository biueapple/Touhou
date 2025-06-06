using System.Collections.Generic;
using UnityEngine;

//플레이어 기체는 이 클래스로 자신의 무기들을 관리함
public class Module : MonoBehaviour
{
    //보유한 무기들
    [SerializeField]
    private List<Attack> weapons = new();
    public List<Attack> Weapons { get { return weapons; } }

    //모든 무기들의 발사를 호출함
    public void Fire()
    {
        foreach (var weapon in weapons)
        {
            weapon.Fire();
        }
    }
}
