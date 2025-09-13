using UnityEngine;

[CreateAssetMenu(fileName = "SoundDatabase", menuName = "Sound/SoundDatabase")]
public class SoundDatabase : ScriptableObject
{
    [Header("Lobby Scene")]
    public AudioClip _lobbyBgm;

    [Header("Play Scene")]
    public AudioClip _playBgm;
    public AudioClip _playGunFire;
    public AudioClip _playJump;
    public AudioClip _playHit;

    [Header("UI")]
    public AudioClip _settingButtonClick;
    public AudioClip _gameStartButtonClick;

}