using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using Newtonsoft.Json;

namespace ACMDotNetCore.RestAPIWithNLayer.Feacture.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProVerbsController : ControllerBase
    {
        private async Task<MMProverbs> GetMmAsync()
        {
            var jsonStr=await System.IO.File.ReadAllTextAsync("MyanmarProverbs.json");
            var model=JsonConvert.DeserializeObject<MMProverbs>(jsonStr);
            return model;
        }
        [HttpGet]
        public async Task<IActionResult> GetTitle()
        {
            var model = await GetMmAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }
        [HttpGet("titleName")]
        public async Task<IActionResult> GetTitleID(string titleName)
        {
            var model=await GetMmAsync();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null) return NotFound();

            var itemId = item.TitleId;
            var lst=model.Tbl_MMProverbs.FirstOrDefault(x=> x.TitleId == itemId);
            return Ok(lst);
        }

        public class MMProverbs
        {
            public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
            public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }
        }

        public class Tbl_Mmproverbstitle
        {
            public int TitleId { get; set; }
            public string TitleName { get; set; }
        }

        public class Tbl_Mmproverbs
        {
            public int TitleId { get; set; }
            public int ProverbId { get; set; }
            public string ProverbName { get; set; }
            public string ProverbDesp { get; set; }
        }

    }
}
