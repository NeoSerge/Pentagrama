using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ReadyPlayerMe;
using UnityEngine.Animations;

public class LoadScenes : MonoBehaviour
{

    public Animation moveToPortal;

    //Variables para Cargar avatar
    public string PartnerURL;
    public InputField inputFieldURL;
    public string avatarURL;
    public GameObject parentOfAvatar;
    public GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }


    public void MoveToPortal()
    {
        moveToPortal.Play();
    }

    public void LoadScene(string sceneName)
    {

        StartCoroutine(LoadPortal(sceneName));
    }

    IEnumerator LoadPortal(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void CrearAvatar()
    {
        Application.OpenURL(PartnerURL);
    }

    public void PasteFromClipboard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.multiline = true;
        textEditor.Paste();
        inputFieldURL.text = textEditor.text;
        
    }

    public void LoadAvatar()
    {
        avatarURL = inputFieldURL.text;
        AvatarLoader avatarLoader = new AvatarLoader();
        avatarLoader.LoadAvatar(avatarURL, AvatarImportedCallback, AvatarLoadedCallback);
    }

    private void AvatarImportedCallback(GameObject avatar)
    {
        // called after GLB file is downloaded and imported
        Debug.Log("Avatar Imported!");
    }

    private void AvatarLoadedCallback(GameObject avatar, AvatarMetaData metaData)
    {
        // called after avatar is prepared with components and anim controller 
        Debug.Log("Avatar Loaded!");
        avatar.gameObject.transform.localScale = new Vector3(3.4f, 3.4f, 3.4f);
        avatar.gameObject.transform.position = new Vector3(avatar.gameObject.transform.position.x,-1.9f, avatar.gameObject.transform.position.z);
        
        avatar.transform.SetParent(parentOfAvatar.transform);
        avatar.gameObject.transform.localRotation = Quaternion.Euler(0, mainCamera.gameObject.transform.rotation.y, 0);

        avatar.AddComponent<LockRotation>();

        //foreach (Transform child in avatar.transform)
        //{
        //    if (child.name == "Avatar_Renderer_EyeLeft" || child.name == "Avatar_Renderer_EyeRight"  || 
        //        child.name == "Avatar_Renderer_Head" || child.name == "Avatar_Renderer_Teeth")
        //    {
        //        child.gameObject.layer = 7;
        //    }
        //}

    }

}
