using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.ConsoleAppReftiExamples
{
    public class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("http://localhost:5168");
        public async Task RuuAsyn()
        {
            //await ReadAsyn();
            //await EditAsyn(1);
            //await CreatAsyn("Hi", "Hello", "HaHa");
            await UpdateAsyn(4001, "Malaxaigon", "Durin", "Hotpot");
            //await DeleteAsyn(1);
        }
        private async Task ReadAsyn()
        {
            //var lst = await _service.GetBlogs();
            var lst=await _service.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine($"Id=>{item.BlogId}");
                Console.WriteLine($"Title=>{item.BlogTitle}");
                Console.WriteLine($"Author=>{item.BlogAuthor}");
                Console.WriteLine($"Content=>{item.BlogContent}");
                Console.WriteLine("-------------------------");
            }
        }
        private async Task EditAsyn(int id)
        {
            try
            {
                var item = await _service.GetBlogs(id);
                Console.WriteLine($"Id=>{item.BlogId}");
                Console.WriteLine($"Title=>{item.BlogTitle}");
                Console.WriteLine($"Author=>{item.BlogAuthor}");
                Console.WriteLine($"Content=>{item.BlogContent}");
                Console.WriteLine("-------------------------");

            }
            catch(ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                //throw; //target to main process
            }
        }
        private async Task CreatAsyn(string title,string author,string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                var message = await _service.CreateBlogs(blog);
                Console.WriteLine(message);
            }
            catch(ApiException ex)
            {  
                Console.WriteLine(ex.StatusCode.ToString());          
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }
        private async Task UpdateAsyn(int id,string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                var message = await _service.UpdateBlogs(id, blog);
                Console.WriteLine(message);
            }
            catch( ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }        
        }
        private async Task DeleteAsyn(int id)
        {
            try
            {
                var message = await _service.DeleteBlogs(id);
                Console.WriteLine(message);
            }
            catch(ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
