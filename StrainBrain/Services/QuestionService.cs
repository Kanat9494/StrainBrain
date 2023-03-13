namespace StrainBrain.Services;

class QuestionService : IAppServiceProvider<Question>
{
    public QuestionService()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(StrainBrainConstants.SERVER_ROOT_URL);
    }

    //Удалить после тестов
    private List<Question> _questions;
    //Конец удаления
    
    HttpClient httpClient;

    private static QuestionService _instance;
    public static QuestionService Instance()
    {
        if (_instance == null)
            _instance = new QuestionService();

        return _instance;
    }

    //public async Task<IEnumerable<Question>> GetItemsAsync(int questionsCountToskip)
    //{
    //    try
    //    {
    //        var response = await httpClient.GetStringAsync(httpClient.BaseAddress + $"api/Question/GetQuestions/{questionsCountToskip}");
    //        var questions = JsonConvert.DeserializeObject<IEnumerable<Question>>(response);

    //        return questions;
    //    }
    //    catch (Exception ex)
    //    {
    //        return null;
    //    }
    //}

    //удалить этот метод
    public async Task<IEnumerable<Question>> GetItemsAsync(int questionsCountToskip)
    {
        await Task.Delay(3000);

        await Task.Run(async () =>
        {
            _questions = new List<Question>()
            {
                new Question()
                {
                    QuestionId = 1,
                    Title = "Каких камней не бывает в речке?",
                    RightAnswer = "сухих",
                    ChoiceOne = "красных",
                    ChoiceTwo = "мокрых",
                    ChoiceThree = "сухих",
                    ChoiceFour = "драгоценных"
                },
                new Question()
                {
                    QuestionId = 2,
                    Title = "Сколько месяцев в году имеют 28 дней?",
                    RightAnswer = "все месяцы",
                    ChoiceOne = "январь, февраль",
                    ChoiceTwo = "февраль",
                    ChoiceThree = "октябрь, ноябрь",
                    ChoiceFour = "все месяцы"
                },
                new Question()
                {
                    QuestionId = 3,
                    Title = "Что можно видеть с закрытыми глазами?",
                    RightAnswer = "сны",
                    ChoiceOne = "сны",
                    ChoiceTwo = "мечты",
                    ChoiceThree = "кино",
                    ChoiceFour = "мультфильм"
                },
                new Question()
                {
                    QuestionId = 4,
                    Title = "Что в огне не горит и в воде не тонет?",
                    RightAnswer = "лед",
                    ChoiceOne = "лед",
                    ChoiceTwo = "вода",
                    ChoiceThree = "огонь",
                    ChoiceFour = "свет"
                },
                new Question()
                {
                    QuestionId = 5,
                    Title = "Кого австралийцы называют морской осой?",
                    RightAnswer = "медузу",
                    ChoiceOne = "краба",
                    ChoiceTwo = "медузу",
                    ChoiceThree = "кита",
                    ChoiceFour = "рыбу"
                },
                new Question()
                {
                    QuestionId = 6,
                    Title = "У тридцати двух воинов один командир.",
                    RightAnswer = "зубы и язык",
                    ChoiceOne = "месяц и год",
                    ChoiceTwo = "пульт и телевизор",
                    ChoiceThree = "калькулятор и батарея",
                    ChoiceFour = "зубы и язык"
                },
                new Question()
                {
                    QuestionId = 7,
                    Title = "В каком году возникла Кыргызская Республика?",
                    RightAnswer = "В 1992-м году",
                    ChoiceOne = "в 2000-м году",
                    ChoiceTwo = "В 1992-м году",
                    ChoiceThree = "В 1991-м году",
                    ChoiceFour = "В 1993-м году"
                },
                new Question()
                {
                    QuestionId = 8,
                    Title = "Как переводится Земля на кыргызский язык?",
                    RightAnswer = "Жер",
                    ChoiceOne = "Жер-Эне",
                    ChoiceTwo = "Жер",
                    ChoiceThree = "Туулган жер",
                    ChoiceFour = "Кыргызстан"
                },
                new Question()
                {
                    QuestionId = 9,
                    Title = "Настоящее имя Халка?",
                    RightAnswer = "Брюс Беннер",
                    ChoiceOne = "Халк",
                    ChoiceTwo = "Супермен",
                    ChoiceThree = "Брюс Беннер",
                    ChoiceFour = "Питер Паркер"
                },
                new Question()
                {
                    QuestionId = 10,
                    Title = "Кого поцеловала Мадонна на Video Music Awards в 2003 году?",
                    RightAnswer = "Кристину Агилеру",
                    ChoiceOne = "Бритни Спирс",
                    ChoiceTwo = "Кайли Миноуг",
                    ChoiceThree = "Джанет Джексон",
                    ChoiceFour = "Кристину Агилеру"
                },

                new Question()
                {
                    QuestionId = 11,
                    Title = "Какой безалкогольный напиток первым был взят в космос?",
                    RightAnswer = "Кока-Кола",
                    ChoiceOne = "Кока-Кола",
                    ChoiceTwo = "Пепси",
                    ChoiceThree = "Фанта",
                    ChoiceFour = "Спрайт"
                },
                new Question()
                {
                    QuestionId = 12,
                    Title = "Сколько весит костюм Чубакки?",
                    RightAnswer = "3.6 кг",
                    ChoiceOne = "7.7 кг",
                    ChoiceTwo = "6.5 кг",
                    ChoiceThree = "3.6 кг",
                    ChoiceFour = "3 кг"
                },
                new Question()
                {
                    QuestionId = 13,
                    Title = "Кто написал знаменитый дневник, скрываясь от нацистов в Амстердаме?",
                    RightAnswer = "Анна Франк",
                    ChoiceOne = "Бриджит Джонс",
                    ChoiceTwo = "Мария Кюри",
                    ChoiceThree = "Хелен Келлер",
                    ChoiceFour = "Анна Франк"
                },
                new Question()
                {
                    QuestionId = 14,
                    Title = "Что означает термин пиано?",
                    RightAnswer = "В мягком темпе",
                    ChoiceOne = "В бодром темпе",
                    ChoiceTwo = "В умеренно медленном темпе",
                    ChoiceThree = "В мягком темпе",
                    ChoiceFour = "В быстром темпе"
                },
                new Question()
                {
                    QuestionId = 15,
                    Title = "Кто написал эпическую поэму Потерянный рай?",
                    RightAnswer = "Джон Мильтон",
                    ChoiceOne = "Джон Мильтон",
                    ChoiceTwo = "Джон Стейнбек",
                    ChoiceThree = "Джон Китс",
                    ChoiceFour = "Генри Джеймс"
                },
                new Question()
                {
                    QuestionId = 16,
                    Title = "Из чего сделан самый крепкий дом в Трех поросятах?",
                    RightAnswer = "Кирпич",
                    ChoiceOne = "Бамбук",
                    ChoiceTwo = "Камень",
                    ChoiceThree = "Железо",
                    ChoiceFour = "Кирпич"
                },
                new Question()
                {
                    QuestionId = 17,
                    Title = "Как называется маленький пластмассовый кусочек на конце шнурка?",
                    RightAnswer = "Аглет",
                    ChoiceOne = "Чехол",
                    ChoiceTwo = "Аглет",
                    ChoiceThree = "Кружево",
                    ChoiceFour = "Строка"
                },
                new Question()
                {
                    QuestionId = 18,
                    Title = "Сколько длится мгновение?",
                    RightAnswer = "90 секунд",
                    ChoiceOne = "60 секунд",
                    ChoiceTwo = "120 секунд",
                    ChoiceThree = "180 секунд",
                    ChoiceFour = "90 секунд"
                },
                new Question()
                {
                    QuestionId = 19,
                    Title = "Какая игрушка была первой, которую рекламировали по телевидению?",
                    RightAnswer = "Мистер Картофельная Голова",
                    ChoiceOne = "Мистер Картофельная Голова",
                    ChoiceTwo = "Барби",
                    ChoiceThree = "Духовка с Легкой Выпечкой",
                    ChoiceFour = "Ракетный Гонщик"
                },
                new Question()
                {
                    QuestionId = 20,
                    Title = "За какую страну играл Дэвид Бекхэм?",
                    RightAnswer = "Англия",
                    ChoiceOne = "Англия",
                    ChoiceTwo = "Бразилия",
                    ChoiceThree = "Испания",
                    ChoiceFour = "США"
                },
            };
        });

        return _questions;
    }
}
