namespace StrainBrain.Models;

class Question
{
    public int QuestionId { get; set; }
    public string Title { get; set; }
    public string RightAnswer { get; set; }
    public string ChoiceOne { get; set; }
    public string ChoiceTwo { get; set; }
    public string ChoiceThree { get; set; }
    public string ChoiceFour { get; set; }
}
