using System.Collections;

using UnityEngine;

public class JukeBox : MonoBehaviour
{
    #region Fields

    public AudioClip menu;
    public AudioClip menuTap;
    public AudioClip surface;
    public AudioClip underwater;

    private static JukeBox _instance;

    #endregion Fields

    #region Properties

    public static JukeBox instance
    {
        get{return _instance; }
    }

    #endregion Properties

    #region Methods

    public static void AttachTo(MonoBehaviour comp)
    {
        instance.transform.parent = comp.transform;
        instance.transform.localPosition = Vector3.zero;
    }

    public static void PlayMenu()
    {
        instance.Play(instance.menu);
    }

    public static void PlaySurface()
    {
        instance.Play(instance.surface);
    }

    public static void PlayUnderwater()
    {
        instance.Play(instance.underwater);
    }

    public static void Tap()
    {
        instance._Tap();
    }

    void Awake()
    {
        if(!_instance){
            GameObject.DontDestroyOnLoad(gameObject);
            _instance = this;
            AudioListener.volume = PlayerPrefs.GetFloat("sound", 0.5f);
        }else{
            Destroy(gameObject);
        }
    }

    void OnDisable()
    {
        transform.parent = null;
    }

    void Play(AudioClip clip)
    {
        if(audio.clip == clip) return;
        audio.clip = clip;
        audio.loop = true;
        audio.Play();
    }

    void _Tap()
    {
        audio.PlayOneShot(menuTap);
    }

    #endregion Methods
}