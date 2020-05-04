using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using KModkit;

public class FlagIdentificationScript : MonoBehaviour
{
    public KMAudio audio;

    public Texture[] flags;
    public Material flagMat;
    public Material blackMat;
    public GameObject flagDisplay;
    public KMSelectable[] answerButton;
    public TextMesh[] buttonText;

    public string correctAnswer;
    public string[] availableAnswers;
    

    static int moduleIdCounter = 1;
    int moduleId = 0;
    public bool isActive = false;

    //Debug.LogFormat("[Flag Identification #{0}] text", moduleId, );


    void Awake()
    {
        GetComponent<KMNeedyModule>().OnNeedyActivation += OnNeedyActivation;
        GetComponent<KMNeedyModule>().OnNeedyDeactivation += OnNeedyDeactivation;
        GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;

        foreach (KMSelectable button in answerButton)
        {
            KMSelectable pressedObject = button;
            button.OnInteract += delegate () { ButtonPress(pressedObject); return false; };
        }
    }

    void Start()
    {
        Material[] temp = flagDisplay.GetComponent<MeshRenderer>().materials;
        temp[1] = blackMat;
        flagDisplay.GetComponent<MeshRenderer>().materials = temp;
        buttonText[0].text = "";
        buttonText[1].text = "";
        buttonText[2].text = "";
        buttonText[3].text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }



    protected void OnTimerExpired()
    {
        
        GetComponent<KMNeedyModule>().OnStrike();
        OnNeedyDeactivation();
    }

    protected void OnNeedyActivation()
    {
        isActive = true;
        Material[] temp = flagDisplay.GetComponent<MeshRenderer>().materials;
        temp[1] = flagMat;
        flagDisplay.GetComponent<MeshRenderer>().materials = temp;
        flagDisplay.GetComponent<MeshRenderer>().materials[1].mainTexture = flags[UnityEngine.Random.Range(0, flags.Length)];
        correctAnswer = flagDisplay.GetComponent<MeshRenderer>().materials[1].mainTexture.name;
        while (true)
        {
            availableAnswers = new string[] { correctAnswer, flags[UnityEngine.Random.Range(0, flags.Length)].name, flags[UnityEngine.Random.Range(0, flags.Length)].name, flags[UnityEngine.Random.Range(0, flags.Length)].name };
            if (!(availableAnswers[0] == availableAnswers[1] || availableAnswers[0] == availableAnswers[2] || availableAnswers[0] == availableAnswers[3] || availableAnswers[1] == availableAnswers[2] || availableAnswers[1] == availableAnswers[3] || availableAnswers[2] == availableAnswers[3]))
            {
                break;
            }
        }
        availableAnswers.Shuffle();
        setTextMesh(0);
        setTextMesh(1);
        setTextMesh(2);
        setTextMesh(3);
        Debug.LogFormat("[Flag Identification #{0}] Selected Flag: {1}", moduleId, correctAnswer);
        Debug.LogFormat("[Flag Identification #{0}] Buttons display: {1}, {2}, {3}, {4} (in reading order)", moduleId, buttonText[0].text, buttonText[1].text, buttonText[2].text, buttonText[3].text);

    }

    void setTextMesh(int pos)
    {
        buttonText[pos].text = availableAnswers[pos];
        switch (buttonText[pos].text)
        {
            case "Czech Republic":
                buttonText[pos].transform.localScale = new Vector3(0.13f, 0.16f, 1);
                break;
            case "Guinea-Bissau":
                buttonText[pos].transform.localScale = new Vector3(0.14f, 0.16f, 1);
                break;
            case "Turkmenistan":
                buttonText[pos].transform.localScale = new Vector3(0.15f, 0.16f, 1);
                break;
            case "Federated States of Micronesia":
                buttonText[pos].transform.localScale = new Vector3(0.07f, 0.14f, 1);
                break;
            case "Burkina Faso":
                buttonText[pos].transform.localScale = new Vector3(0.16f, 0.16f, 1);
                break;
            case "South Africa":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Timor-Leste":
                buttonText[pos].transform.localScale = new Vector3(0.175f, 0.175f, 1);
                break;
            case "Republic of the Congo":
                buttonText[pos].transform.localScale = new Vector3(0.095f, 0.14f, 1);
                break;
            case "San Marino":
                buttonText[pos].transform.localScale = new Vector3(0.19f, 0.18f, 1);
                break;
            case "Afghanistan":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.18f, 1);
                break;
            case "Marshall Islands":
                buttonText[pos].transform.localScale = new Vector3(0.13f, 0.16f, 1);
                break;
            case "North Macedonia":
                buttonText[pos].transform.localScale = new Vector3(0.13f, 0.16f, 1);
                break;
            case "North Korea":
                buttonText[pos].transform.localScale = new Vector3(0.16f, 0.16f, 1);
                break;
            case "Trinidad and Tobago":
                buttonText[pos].transform.localScale = new Vector3(0.105f, 0.14f, 1);
                break;
            case "Saudi Arabia":
                buttonText[pos].transform.localScale = new Vector3(0.16f, 0.17f, 1);
                break;
            case "United Kingdom":
                buttonText[pos].transform.localScale = new Vector3(0.13f, 0.16f, 1);
                break;
            case "Democratic Republic of the Congo":
                buttonText[pos].transform.localScale = new Vector3(0.065f, 0.13f, 1);
                break;
            case "São Tomé and Príncipe":
                buttonText[pos].transform.localScale = new Vector3(0.095f, 0.13f, 1);
                break;
            case "South Korea":
                buttonText[pos].transform.localScale = new Vector3(0.16f, 0.16f, 1);
                break;
            case "Madagascar":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Liechtenstein":
                buttonText[pos].transform.localScale = new Vector3(0.15f, 0.16f, 1);
                break;
            case "South Sudan":
                buttonText[pos].transform.localScale = new Vector3(0.16f, 0.16f, 1);
                break;
            case "Central African Republic":
                buttonText[pos].transform.localScale = new Vector3(0.085f, 0.14f, 1);
                break;
            case "Kyrgyzstan":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Bosnia and Herzegovina":
                buttonText[pos].transform.localScale = new Vector3(0.088f, 0.14f, 1);
                break;
            case "Philippines":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "The Gambia":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Luxembourg":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Saint Vincent and the Grenadines":
                buttonText[pos].transform.localScale = new Vector3(0.065f, 0.12f, 1);
                break;
            case "New Zealand":
                buttonText[pos].transform.localScale = new Vector3(0.15f, 0.16f, 1);
                break;
            case "Switzerland":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Mozambique":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Netherlands":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Equatorial Guinea":
                buttonText[pos].transform.localScale = new Vector3(0.12f, 0.15f, 1);
                break;
            case "Dominican Republic":
                buttonText[pos].transform.localScale = new Vector3(0.105f, 0.14f, 1);
                break;
            case "Kazakhstan":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Montenegro":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Sierra Leone":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "United States":
                buttonText[pos].transform.localScale = new Vector3(0.16f, 0.16f, 1);
                break;
            case "Papua New Guinea":
                buttonText[pos].transform.localScale = new Vector3(0.11f, 0.13f, 1);
                break;
            case "Côte d’Ivoire":
                buttonText[pos].transform.localScale = new Vector3(0.17f, 0.17f, 1);
                break;
            case "Saint Kitts and Nevis":
                buttonText[pos].transform.localScale = new Vector3(0.1f, 0.15f, 1);
                break;
            case "United Arab Emirates":
                buttonText[pos].transform.localScale = new Vector3(0.095f, 0.13f, 1);
                break;
            case "Antigua and Barbuda":
                buttonText[pos].transform.localScale = new Vector3(0.1f, 0.13f, 1);
                break;
            case "El salvador":
                buttonText[pos].transform.localScale = new Vector3(0.18f, 0.18f, 1);
                break;
            case "Bangladesh":
                buttonText[pos].transform.localScale = new Vector3(0.18f, 0.18f, 1);
                break;
            case "Solomon Islands":
                buttonText[pos].transform.localScale = new Vector3(0.13f, 0.15f, 1);
                break;
            case "Saint Lucia":
                buttonText[pos].transform.localScale = new Vector3(0.19f, 0.19f, 1);
                break;
            default:
                buttonText[pos].transform.localScale = new Vector3(0.2f, 0.2f, 1);
                break;

        }
    }

    protected void OnNeedyDeactivation()
    {
        isActive = false;
        Material[] temp = flagDisplay.GetComponent<MeshRenderer>().materials;
        temp[1] = blackMat;
        flagDisplay.GetComponent<MeshRenderer>().materials = temp;
        buttonText[0].text = "";
        buttonText[1].text = "";
        buttonText[2].text = "";
        buttonText[3].text = "";
    }

    protected bool Solve()
    {
        OnNeedyDeactivation();
        GetComponent<KMNeedyModule>().OnPass();

        return false;
    }

    void ButtonPress(KMSelectable button)
    {
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, button.transform);
        button.AddInteractionPunch();
        if (isActive)
        {
            Debug.LogFormat("[Flag Identification #{0}] Pressed {1}", moduleId, button.GetComponentInChildren<TextMesh>().text);
            if (button.GetComponentInChildren<TextMesh>().text == correctAnswer)
            {
                Solve();
            }
            else
            {
                Debug.LogFormat("[Flag Identification #{0}] STRIKE: Pressed {1}, Flag was {2}.", moduleId, button.GetComponentInChildren<TextMesh>().text, correctAnswer);
                GetComponent<KMNeedyModule>().OnStrike();
                Solve();
            }
        }
    }

    //-------------------------------------------------- TP SUPPORT ----------------------------------------------------------------------------

    private readonly string TwitchHelpMessage = "Use !{0} (Country name) to press the button with that name on it. |Use !{0} 1/2/3/4 to press that button in reading order. | Use " +
        "!{0} tl/tr/bl/br to press the button in that position.";


    KMSelectable[] ProcessTwitchCommand(string TPcommand)
    {
        TPcommand = TPcommand.ToLowerInvariant().Trim();
        if (TPcommand == "1" || TPcommand == "tl")
        {
            return new KMSelectable[] { answerButton[0] };
        }
        else if (TPcommand == "2" || TPcommand == "tr")
        {
            return new KMSelectable[] { answerButton[1] };
        }
        else if (TPcommand == "3" || TPcommand == "bl")
        {
            return new KMSelectable[] { answerButton[2] };
        }
        else if (TPcommand == "4" || TPcommand == "br")
        {
            return new KMSelectable[] { answerButton[3] };
        }
        else if (Regex.IsMatch(TPcommand, @"^[a-z| ]+$"))
        {
                 if (TPcommand == buttonText[0].text.ToLowerInvariant()) {
                return new KMSelectable[] { answerButton[0] };
            }
            else if (TPcommand == buttonText[1].text.ToLowerInvariant())
            {
                return new KMSelectable[] { answerButton[1] };
            }
            else if (TPcommand == buttonText[2].text.ToLowerInvariant())
            {
                return new KMSelectable[] { answerButton[2] };
            }
            else if (TPcommand == buttonText[3].text.ToLowerInvariant())
            {
                return new KMSelectable[] { answerButton[3] };
            }

        }

        return null;
    }
}

