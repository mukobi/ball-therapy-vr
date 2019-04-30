using UnityEngine;
using Valve.VR;

public class Haptics : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;

    public void VibrateLeft(float duration = 1f, float frequency = 150f, float amplitude = 0.5f)
    {
        //Debug.Log("Pulse Left");
        Pulse(duration, frequency, amplitude, SteamVR_Input_Sources.LeftHand);
    }

    public void VibrateRight(float duration = 1f, float frequency = 150f, float amplitude = 0.5f)
    {
        //Debug.Log("Pulse Right");
        Pulse(duration, frequency, amplitude, SteamVR_Input_Sources.RightHand);
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0f, duration, frequency, amplitude, source);
    }
}
