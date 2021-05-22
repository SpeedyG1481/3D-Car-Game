using UnityEngine;

public class GameController
{
    public static bool DebugMode = true;

    public static float GetMusicVolume => PlayerPrefs.GetFloat("MusicSound");
    public static float GetSfxVolume => PlayerPrefs.GetFloat("SFXSound");
    
    public static void GetDebugInputs()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        Vehicle.Gas = vertical > 0;
        Vehicle.Brake = vertical < 0;
        Vehicle.HorizontalInput = horizontal;
        Vehicle.BoostParam = Input.GetKey(KeyCode.Space);
    }
}