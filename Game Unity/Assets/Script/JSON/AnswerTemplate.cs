using System;
[Serializable]
public class AnswerTemplate
{
    public double answer;
    public bool correct;

    public AnswerTemplate(double answer, bool correct)
    {
        this.answer = answer;
        this.correct = correct;
    }
}
