using Xunit;
using GC_Board_Game_Cats.Controllers;
using GC_Board_Game_Cats.Models;

namespace GC_Board_Game_Cats.Tests
{
    public class QuizTests
    {
        [Fact]
        public void TestLoadQuestions()
        {
            // Arrange
            var controller = new QuizController();
            var model = new QuizQuestions();

            // Act
            var loadedModel = controller.LoadQuestions(model);

            // Assert
            Assert.NotNull(loadedModel.Questions);
            Assert.NotNull(loadedModel.Answers);
            Assert.NotEmpty(loadedModel.Questions);
            Assert.NotEmpty(loadedModel.Answers);
            Assert.Equal(controller.Questions, loadedModel.Questions);
            Assert.Equal(controller.Answers, loadedModel.Answers);
            Assert.Equal(controller.Questions.Count, loadedModel.Questions.Count);
            Assert.Equal(loadedModel.Questions.Count, loadedModel.Answers.Count);
        }

        [Fact]
        public void TestCheckQuizAnswers()
        {
            // Arrange
            var model = new QuizQuestions();
            var controller = new QuizController();
            var loadedModel = controller.LoadQuestions(model);
            loadedModel.UserAnswers[1] = "Nirvana";  // correct
            loadedModel.UserAnswers[2] = "Chris Cornell"; // wrong
            loadedModel.UserAnswers[3] = ""; // no answer

            // Act
            var result = controller.CheckQuizAnswers(loadedModel);

            // Assert
            Assert.True(result.Results[1]); // correct answer
            Assert.False(result.Results[2]); // wrong answer
            Assert.False(result.Results[3]); // no answer
        }
    }
}