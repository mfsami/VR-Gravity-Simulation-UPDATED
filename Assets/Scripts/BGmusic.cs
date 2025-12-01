using UnityEngine;

public class BGmusic : MonoBehaviour
{

    [SerializeField] private AudioClip bgmusic;
    
    void Start()
    {
        SFXmanager.instance.PlaySFXclip(bgmusic, transform, 1f);
    }


}
