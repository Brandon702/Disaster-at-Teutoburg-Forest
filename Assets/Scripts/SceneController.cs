using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

class SceneController : MonoBehaviour
{
    private int sceneSection = 0;
    public TMP_Text sceneText;
    public Sprite[] images;
    //Map    0
    //Talk   1
    //Travel 2
    //Forest 3

    public void Start()
    {
        //First scene
        sceneText.text = "The year is 9AD, 36 years ago, The Roman Republic, one of the strongest & most influential nations in all of history had collapsed. In its place, a monarchy had been formed, turning the republic into the \"Roman Empire\".";
        GameObject.Find("ScenePanel").GetComponent<Image>().sprite = images[0];
    }


    /// <summary>
    /// Goes to the next in game scene panel
    /// </summary>
    public void Next()
    {
        //Go to the next section/panel based on position
        //Use scene section int in an if/switch to progress
        sceneSection++;
        if (sceneSection == 1)
        {
            sceneText.text = "This was not the end of disasters for the Roman people however, as many disasters loomed on the horiozon. This tale begins in a Roman Province, only in name, Germania.";
        }
        else if (sceneSection == 2)
        {
            //Play scene one
            sceneText.text = "Winter was approaching in this new \"Province\", & as per Roman Tradition, Varus had ordered his people to begin slowly retreating accross the rhine into more friendly territory.";
        }
        else if (sceneSection == 3)
        {
            sceneText.text = "A young German advisor, Arminius however told Varus of a German revolt in the north that could be easily defeated if he marched immediately.";
        }
        else if (sceneSection == 4)
        {
            sceneText.text = "Chiefs of some German tribes had warned Varus that Arminus was lying, however Varus didnt believe them & prepared to march anyway.";
        }
        else if (sceneSection == 5)
        {
            sceneText.text = "With that, Varus had began the march to the north, through the underdevloped & thin roads through Teutoburg forest.";
        }
        else if (sceneSection == 6)
        {
            sceneText.text = "This would prove to be a fatal mistake that would cause ripples throughout the empire for decades & eternal hatred to all \"barbaric\" people.";
        }
        else if (sceneSection == 8)
        {
            //Start the game here
            sceneText.text = "";
        }
        else if (sceneSection == 9)
        {
            //Game over scenes go here
        }
        else
        {
            sceneText.text = "[Text Failure] \n Scene section: " + sceneSection + "\n Scenes section does not exist.";
        }
    }
}
