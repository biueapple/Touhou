using UnityEngine;

public static class InfoStatic
{
    //유도탄이 한 프레임에 움직이는 최대치 설정 (deltatime을 곱해서 사용)
    public static float HomingRotateSpeed = 45;
    //적용되는 중력값 (아이템이 떨어질 때 사용)
    public static float Gravity = 0.8f;
    //아이템을 빨아당기는 힘
    public static float PullSpeed = 4;
    //플레이어가 죽고 다시 태어나는 위치
    public static Vector3 spawnPoint = new Vector3(0, -3.5f, 0);
    //화면의 끝부분
    public static float ScreenLeft = -5;
    public static float ScreenRight = 5;
    public static float ScreenTop = 5;
    public static float ScreenBot = -5;
    //점수
    public static uint hit = 100;
    public static uint kill = 1000;
    public static uint point1 = 1000;
    public static uint point10 = 10000;
}
