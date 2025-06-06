using System.Collections.Generic;
using UnityEngine;

//�÷��̾� ��ü�� �� Ŭ������ �ڽ��� ������� ������
public class Module : MonoBehaviour
{
    //������ �����
    [SerializeField]
    private List<Attack> weapons = new();
    public List<Attack> Weapons { get { return weapons; } }

    //��� ������� �߻縦 ȣ����
    public void Fire()
    {
        foreach (var weapon in weapons)
        {
            weapon.Fire();
        }
    }
}
