using UnityEngine;

public class MusicManager : MonoBehaviour
{

    HealthSys PlayerHealth;
    GameObject Player;
    [Range(0f, 1f)]
    public float musicVolume = 0.2f;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = Player.transform.Find("HealthSystem").GetComponent<HealthSys>();

    }

    void Start()
    {
        GameObject.FindGameObjectsWithTag("Player");
        AudioManager.Instance.ChangeMusic(AudioManager.SoundType.Music_Menu);
        AudioManager.Instance.SetMusicVolume(musicVolume);
    }

    void Update()
    {
        if (PlayerHealth.isDead())
        {
            AudioManager.Instance.StopMusic();
        }
    }
}
