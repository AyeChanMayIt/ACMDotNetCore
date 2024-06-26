﻿// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

    Console.WriteLine("Hello, World!");
    string jsonStr = await File.ReadAllTextAsync("data.json");
    var model=JsonConvert.DeserializeObject<MainDTO>(jsonStr);

    foreach (var question in model.questions)
    {
        Console.WriteLine(question.questionName);
    }
    Console.ReadLine();

public class MainDTO
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

