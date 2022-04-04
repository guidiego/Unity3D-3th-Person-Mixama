using UnityEngine;

[System.Serializable]
public class MotorConfiguration
{
    public FloatValue speed;
    public FloatValue runSpeedModifier;
    public FloatValue squatSpeedModifier;
}

[System.Serializable]
public class MotorDynamics
{
    public Vector2Value inputMovementForce;
    public BoolValue runFlag;
    public BoolValue squatFlag;
}

public class Motor : MonoBehaviour
{

    [SerializeField]
    private MotorConfiguration _config;

    [SerializeField]
    private MotorDynamics _dynamics;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private bool CheckIfNeedUpdate()
    {
        return _dynamics.inputMovementForce.Value.magnitude > 0.1f;
    }

    private void Update()
    {
        if (!CheckIfNeedUpdate())
        {
            return;
        }

        float localSpeed = _config.speed.Value;
        Vector2 input = _dynamics.inputMovementForce.Value;
        Vector3 mov = new Vector3(input.x, 0, input.y);

        if (_dynamics.runFlag.Value) localSpeed += _config.runSpeedModifier.Value;
        if (_dynamics.squatFlag.Value) localSpeed += _config.squatSpeedModifier.Value;

        transform.Translate(mov * Time.deltaTime * _config.speed.Value);
    }
}
