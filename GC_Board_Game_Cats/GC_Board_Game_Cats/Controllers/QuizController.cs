using GC_Board_Game_Cats.Models;
using Microsoft.AspNetCore.Mvc;

namespace GC_Board_Game_Cats.Controllers
{
    public class QuizController : Controller
    {
        public Dictionary<int, string> Questions { get; } = new();
        public Dictionary<int, string> Answers { get; } = new();

        public QuizController()
        {
            // Hard-coded questions about 1990-2000 alternative rock
            Questions[1] = "Which band released 'Nevermind' in 1991?";
            Answers[1] = "Nirvana";

            Questions[2] = "Who was the lead singer of Pearl Jam?";
            Answers[2] = "Eddie Vedder";

            Questions[3] = "What album made Soundgarden famous in 1994?";
            Answers[3] = "Superunknown";
        }

        public IActionResult Index()
        {
            var model = LoadQuestions(new QuizQuestions());
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string answer1, string answer2, string answer3)
        {
            var model = LoadQuestions(new QuizQuestions());

            // Handle potential null values and trim whitespace
            model.UserAnswers[1] = answer1;
            model.UserAnswers[2] = answer2;
            model.UserAnswers[3] = answer3;

            // Check the user's answers
            var checkedModel = CheckQuizAnswers(model);
            return View(checkedModel);
        }

        public QuizQuestions LoadQuestions(QuizQuestions model)
        {
            // Load questions and answers into the model
            model.Questions = Questions;
            model.Answers = Answers;
            model.UserAnswers = new Dictionary<int, string>();
            model.Results = new Dictionary<int, bool>();

            // Create empty entries for each question
            foreach (var question in Questions)
            {
                int key = question.Key;
                model.UserAnswers[key] = "";
            }

            return model;
        }

        public QuizQuestions CheckQuizAnswers(QuizQuestions model)
        {
            foreach (var question in model.Questions)
            {
                int key = question.Key;
                model.Results[key] = model.Answers[key] == model.UserAnswers[key];
            }
            return model;
        }
    }
}