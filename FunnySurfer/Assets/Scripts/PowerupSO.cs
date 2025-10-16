using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] public string powerupType;
    [SerializeField] public float valueChange;
    [SerializeField] public float duration;

    public string GetPowerupType { get { return powerupType; } }

    public float GetValueChange { get { return valueChange; } }

    public float GetDuration { get { return duration; } }

}
