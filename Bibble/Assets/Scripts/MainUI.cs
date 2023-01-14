using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject main;
    
    public GameObject movingBackground;
    public GameObject heroDetails;    
    public GameObject wikiDetails;
    //public GameObject detailsAvatar;

    public Text accountStatus;

    public GameObject signupPanel;
    public InputField emailSignup;
    public InputField passwordSignup;
    public InputField password2Signup;
    public Text topTextSignup;

    public GameObject signinPanel;
    public InputField emailSignin;
    public InputField passwordSignin;
    public Text emailWarning;
    public Text passwordWarning;

    void Start()
    {
        main.transform.localScale = new Vector3(Screen.width / 1400f, Screen.height / 1050f, 1f);
    }

    void Update()
    {
        main.transform.localScale = new Vector3(Screen.width / 1400f, Screen.height / 1050f, 1f);
        heroDetails.transform.position = new Vector3(Input.mousePosition.x + 270f, Input.mousePosition.y - 270f, 0);

        if(Input.mousePosition.y < 600f)
        {
            wikiDetails.transform.position = new Vector3(Input.mousePosition.x + 270f, Input.mousePosition.y + 200f, 0);
        }
        else
        {
            wikiDetails.transform.position = new Vector3(Input.mousePosition.x + 270f, Input.mousePosition.y - 270f, 0);
        }
        
        movingBackground.transform.position = new Vector3(-Input.mousePosition.x / 20f + 700f, -Input.mousePosition.y / 20f + 525f, 0);
    }

    public void PlayGameScene()
    {
        SceneManager.LoadScene("Game");
    }  

    // Signup Menu
    public void RegisterSignupBtnClick()
    {
        if(emailSignup.text == "" || passwordSignup.text == "" || password2Signup.text == "")
        {
            topTextSignup.text = "Please fill all forms.";
            topTextSignup.GetComponent<Text>().color = Color.red;
        }
        else if(passwordSignup.text != password2Signup.text)
        {
            topTextSignup.text = "Please type password again.";
            topTextSignup.GetComponent<Text>().color = Color.red;
            password2Signup.text = "";
        }
        else
        {
            if(PlayerPrefs.GetString("EMAIL") != "")
            {
                topTextSignup.text = "Already exits.";
                topTextSignup.GetComponent<Text>().color = Color.red;
            }
            else
            {
                PlayerPrefs.SetString("EMAIL", emailSignup.text);
                PlayerPrefs.SetString("PASSWORD", passwordSignup.text);
                signupPanel.SetActive(false);
            }
        }
    }

    public void SigninBtnClick()
    {
        emailWarning.gameObject.SetActive(false);
        passwordWarning.gameObject.SetActive(false);
        
        if(emailSignin.text == "" || passwordSignin.text == "")
        {
            emailWarning.gameObject.SetActive(true);
            passwordWarning.gameObject.SetActive(true);
            emailWarning.text = "Enter email address.";
            passwordWarning.text = "Enter password.";
        }
        else
        {
            if(PlayerPrefs.GetString("EMAIL") == "")
            {
                emailWarning.gameObject.SetActive(true);
                emailWarning.text = "Not registered.";
            }            
            else if(!string.Equals(emailSignin.text, PlayerPrefs.GetString("EMAIL")))
            {
                emailWarning.gameObject.SetActive(true);
                emailWarning.text = "Invalid email.";
            }       
            else if(string.Equals(passwordSignin.text, PlayerPrefs.GetString("PASSWORD")))
            {
                passwordWarning.gameObject.SetActive(true);
                passwordWarning.text = "Wrong password.";
            }   
            else
            {
                signinPanel.SetActive(false);
                accountStatus.text = "logged in -               -";
            }  
        }
    }
}
