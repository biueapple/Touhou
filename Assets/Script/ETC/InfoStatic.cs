using UnityEngine;

public static class InfoStatic
{
    //유도탄이 한 프레임에 움직이는 최대치 설정 (deltatime을 곱해서 사용)
    public static float HomingRotateSpeed = 60;
    //적용되는 중력값 (아이템이 떨어질 때 사용)
    public static float Gravity = 0.8f;
    //아이템을 빨아당기는 힘
    public static float PullSpeed = 2;
}
