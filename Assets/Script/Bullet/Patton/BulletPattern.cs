using UnityEngine;

public abstract class BulletPattern : ScriptableObject
{
    public abstract PatternInstance CreateInstance();
}
