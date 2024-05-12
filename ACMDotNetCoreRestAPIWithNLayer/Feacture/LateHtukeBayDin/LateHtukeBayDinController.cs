using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ACMDotNetCore.RestAPIWithNLayer.Feacture.LateHtukeBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LateHtukeBayDinController : ControllerBase
    {
        private readonly LateHtukeBayDin _data;

        private async Task<LateHtukeBayDin> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<LateHtukeBayDin>(jsonStr);
            return model;
        }

        //api/LateHtukeBayDin/question
        [HttpGet("question")] //define endpoint name
        public async Task<IActionResult> question()
        {
            var model= await GetDataAsync();
            return Ok(model.questions);
        }
        [HttpGet]
        public async Task<IActionResult> NumberList()
        {
            var model=await GetDataAsync();
            return Ok(model.numberList);
        }
        [HttpGet("{question}/{no}")]
        public async Task<IActionResult> Answers(int question,int no)
        {
            var model = await GetDataAsync();
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == question && x.answerNo == no));
        }
        public class LateHtukeBayDin
        {
            public Question[] questions { get; set; }
            public Answer[] answers { get; set; }
            public string[] numberList { get; set; }
        }

        public class Question
        {
            public int questionNo { get; set; }
            public string questionName { get; set; }
        }

        public class Answer
        {
            public int questionNo { get; set; }
            public int answerNo { get; set; }
            public string answerResult { get; set; }
        }

    }
}
