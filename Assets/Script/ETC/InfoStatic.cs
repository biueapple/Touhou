using UnityEngine;

public static class InfoStatic
{
    //����ź�� �� �����ӿ� �����̴� �ִ�ġ ���� (deltatime�� ���ؼ� ���)
    public static float HomingRotateSpeed = 45;
    //����Ǵ� �߷°� (�������� ������ �� ���)
    public static float Gravity = 0.8f;
    //�������� ���ƴ��� ��
    public static float PullSpeed = 4;
    //�÷��̾ �װ� �ٽ� �¾�� ��ġ
    public static Vector3 spawnPoint = new Vector3(0, -3.5f, 0);
    //ȭ���� ���κ�
    public static float ScreenLeft = -5;
    public static float ScreenRight = 5;
    public static float ScreenTop = 5;
    public static float ScreenBot = -5;
    //����
    public static uint hit = 100;
    public static uint kill = 1000;
    public static uint point1 = 1000;
    public static uint point10 = 10000;
}
