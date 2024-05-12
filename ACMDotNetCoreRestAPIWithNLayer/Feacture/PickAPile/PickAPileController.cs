using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ACMDotNetCore.RestAPIWithNLayer.Feacture.PickAPile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private async Task<PickAPile> GetPickAPile()
        {
           var jsonStr= await System.IO.File.ReadAllTextAsync("PickAPile.json");
            var model = JsonConvert.DeserializeObject<PickAPile>(jsonStr);
           return model;
        }

        [HttpGet("question")]
        public async Task<IActionResult> Questions()
        {
            var model= await GetPickAPile();
            return Ok(model.Questions);
        }
        [HttpGet("{question}/{id}")]
        public async Task<IActionResult> PickAnw(int question,int id)
        {
            var model = await GetPickAPile();
            return Ok(model.Answers.FirstOrDefault(x=> x.QuestionId == question && x.AnswerId== id));
        }

        public class PickAPile
        {
            public Question[] Questions { get; set; }
            public Answer[] Answers { get; set; }
        }

        public class Question
        {
            public int QuestionId { get; set; }
            public string QuestionName { get; set; }
            public string QuestionDesp { get; set; }
        }

        public class Answer
        {
            public int AnswerId { get; set; }
            public string AnswerImageUrl { get; set; }
            public string AnswerName { get; set; }
            public string AnswerDesp { get; set; }
            public int QuestionId { get; set; }
        }

    }
}
