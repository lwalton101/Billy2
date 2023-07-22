// See https://aka.ms/new-console-template for more information

using BillyTheBot;

var token = File.ReadAllText("config.txt");
var billy = new BillyClient(token);
await billy.RunAsync();