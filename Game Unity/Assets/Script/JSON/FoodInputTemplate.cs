using System;
[Serializable]
public class FoodInputTemplate
{
    public string food;
    public double insulin;
    public int bloodsugar;

    public FoodInputTemplate(string food, double insulin, int bloodsugar)
    {
        this.food = food;
        this.insulin = insulin;
        this.bloodsugar = bloodsugar;
    }
}
