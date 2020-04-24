using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class QuestionInput : FirebaseConnect
{
    public InputField foodItem, bolus, bloodsugar;
    public GameObject failedPanel;
    // Start is called before the first frame update

    void Start()
    {
    }

    public void addFoodItem()
    {
        if (
            String.IsNullOrWhiteSpace(foodItem.text) ||
            String.IsNullOrWhiteSpace(bolus.text) ||
            String.IsNullOrWhiteSpace(bloodsugar.text)
           )
        {
            failedPanel.SetActive(true);
            failedPanel.GetComponentInChildren<Text>().text = "Please complete all fields!";
        }
        else
        {
            failedPanel.SetActive(false);
            double bolusFloat = Convert.ToDouble(bolus.text);
            int bloodsugarInt = Int32.Parse(bloodsugar.text);
            FoodInputTemplate item = new FoodInputTemplate(foodItem.text, bolusFloat, bloodsugarInt);
            FirebaseConnect.post("/questions/" + PlayerPrefs.GetString("User","blank"), item);
            clearUI();
            SceneManager.LoadScene("ManageDiabetes");

        }
    }


    public void clearUI()
    {
        foodItem.text = "";
        bolus.text = "";
        bloodsugar.text = "";
    }
}
