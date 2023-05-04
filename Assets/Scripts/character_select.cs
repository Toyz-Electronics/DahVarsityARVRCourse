using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// For SceneManager.LoadScene()
using UnityEngine.UI;
using TMPro;
using ReadyPlayerMe;// For RPM Avatar importing
using ReadyPlayerMe.AvatarLoader;
using ReadyPlayerMe.QuickStart;


public class character_select : MonoBehaviour
{
    private GameObject rpmAvatar;
    private Vector3 targetPosition;
    private Vector3 newRotation;
    private readonly Vector3 avatarPositionOffset = new Vector3(0, -0.08f, 0);

    [SerializeField]
    [Tooltip("RPM avatar URL or shortcode to load")]
    private string avatarUrl;
    private GameObject avatar;
    private AvatarObjectLoader avatarObjectLoader;
    [SerializeField]
    [Tooltip("Animator to use on loaded avatar")]
    private RuntimeAnimatorController animatorController;
    [SerializeField]
    [Tooltip("If true it will try to load avatar from avatarUrl on start")]
    private bool loadOnStart = true;
    [SerializeField]
    [Tooltip("Preview avatar to display until avatar loads. Will be destroyed after new avatar is loaded")]
    private GameObject previewAvatar;
    [SerializeField]
    private GameObject errorPopup;
    [SerializeField]
    private GameObject rpmPlayerObject;
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private GameObject playerArmature;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(0, 0, 0);
        newRotation = new Vector3(0, 0, 0);
    }

    public void ImportRPMAvatar()
    {
        avatarObjectLoader = new AvatarObjectLoader();
        avatarObjectLoader.OnCompleted += OnLoadCompleted;
        avatarObjectLoader.OnFailed += OnLoadFailed;
        TMP_InputField inputAvatar;// Input from Age Form
        inputAvatar = GameObject.Find("RPMInputField").GetComponent<TMP_InputField>();// Get the Age Input Field
        //avatarUrl = inputAvatar.text;// Assign to playerAge the value of the Age Input Field
        LoadAvatar(inputAvatar.text);

    }

    public void ImportRPMAvatarNewOld()
    {
        rpmPlayerObject.SetActive(true);
    }

    public void ImportDefaultAvatar(GameObject inCharacter)
    {
        Animator defaultAnimator;
        Animator armature;
        playerObject.SetActive(true);
        inCharacter.SetActive(true);

        defaultAnimator = inCharacter.GetComponent<Animator>();
        armature = playerArmature.GetComponent<Animator>();

        armature.avatar = defaultAnimator.avatar;

        if (inCharacter.name == "DahV2")
        {
            armature.applyRootMotion = true;
        }
        else
        {
            armature.applyRootMotion = false;
        }
        
        defaultAnimator.enabled = false;

        DontDestroyOnLoad(playerObject);
        LoadNextScene();
    }

    private void OnLoadFailed(object sender, FailureEventArgs args)
    {
        errorPopup.SetActive(true);
    }

    private void OnLoadCompleted(object sender, CompletionEventArgs args)
    {
        if (previewAvatar != null)
        {
            Destroy(previewAvatar);
            previewAvatar = null;
        }
        SetupAvatar(args.Avatar);
    }

    private void SetupAvatar(GameObject targetAvatar)
    {
        if (avatar != null)
        {
            Destroy(avatar);
        }
        avatar = targetAvatar;
        // Re-parent and reset transforms
        playerObject.SetActive(false);
        rpmPlayerObject.SetActive(true);
        avatar.transform.parent = GameObject.Find("RPM Player").transform;
        avatar.transform.localPosition = avatarPositionOffset;
        avatar.transform.localRotation = Quaternion.Euler(0, 0, 0);
        avatar.tag = "RPMPlayer";
        var controller = GameObject.Find("RPM Player").GetComponent<ThirdPersonController>();
        if (controller != null)
        {
            Debug.Log("the controller isn't null, time to call the setupAvatar script!");
            controller.Setup(avatar, animatorController);
            DontDestroyOnLoad(avatar);
            setupAvatarCompleted();
        }
    }

    public void setupAvatarCompleted()
    {
        GameObject ReadyPlayerMe = GameObject.Find("RPMPlayerParent");
        DontDestroyOnLoad(ReadyPlayerMe);
        LoadNextScene();
    }
    public void LoadAvatar(string url)
    {
        //remove any leading or trailing spaces
        avatarUrl = url.Trim(' ');
        avatarObjectLoader.LoadAvatar(avatarUrl);

    }


    private void LoadNextScene()
    {
        SceneManager.LoadScene("DahCharacterDay");// Go to Tutorial
        //SceneManager.LoadScene("Tutorial");// Go to Tutorial
    }

}