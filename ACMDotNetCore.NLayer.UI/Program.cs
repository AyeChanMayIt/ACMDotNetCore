// See https://aka.ms/new-console-template for more information
using ACMDotNetCore.NLayer.BusinessLogic.Services;

Console.WriteLine("Hello, World!");

BL_Blog blblog= new BL_Blog();
blblog.GetBlogs();
