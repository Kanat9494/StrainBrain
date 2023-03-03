namespace StrainBrain.Services;

class QuestionService : IAppServiceProvider<Question>
{
    public QuestionService()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(StrainBrainConstants.SERVER_ROOT_URL);
    }
    
    HttpClient httpClient;

    private static QuestionService _instance;
    public static QuestionService Instance()
    {
        if (_instance == null)
            _instance = new QuestionService();

        return _instance;
    }

    public async Task<IEnumerable<Question>> GetItemsAsync(int questionsCountToskip)
    {
        try
        {
            var response = await httpClient.GetStringAsync(httpClient.BaseAddress + $"api/Question/GetQuestions/{questionsCountToskip}");
            var questions = JsonConvert.DeserializeObject<IEnumerable<Question>>(response);

            return questions;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
