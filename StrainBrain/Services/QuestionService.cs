namespace StrainBrain.Services;

class QuestionService : IAppServiceProvider<Question>
{
    public QuestionService()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(_serverRootUrl);
    }

    private static QuestionService _instance;
    private const string _serverRootUrl = "http://192.168.2.33:45455";
    HttpClient httpClient;

    public static QuestionService Instance()
    {
        if (_instance == null)
            _instance = new QuestionService();

        return _instance;
    }

    public async Task<IEnumerable<Question>> GetItemsAsync()
    {
        try
        {
            var response = await httpClient.GetStringAsync(httpClient.BaseAddress + "api/Question/GetQuestions");
            var questions = JsonConvert.DeserializeObject<IEnumerable<Question>>(response);

            return questions;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
