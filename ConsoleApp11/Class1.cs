using PRTelegramBot.Attributes;
using PRTelegramBot.Helpers;
using PRTelegramBot.Helpers.TG;
using PRTelegramBot.Models;
using PRTelegramBot.Models.CallbackCommands;
using PRTelegramBot.Models.InlineButtons;
using PRTelegramBot.Models.Interface;
using PRTelegramExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace PRTelegramExample.TelegramCommands
{
    public class LessonTwo
    {

        #region Reply
        [SlashHandler("/start")]
        public static async Task Example(ITelegramBotClient botClient, Update update)
        {
            var message = "Вітаю в Телеграм-боті Abitap\nКоманди:\n-/menu\n-/start\n-/help";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }

        [SlashHandler("/menu")]
        public static async Task Menu(ITelegramBotClient botClient, Update update)
        {
            var message = "Меню";

            var menuListString = new List<string>();

            menuListString.Add("Зв'язатися з викладачем");

            menuListString.Add("Abitap");

            menuListString.Add("Youtube");

            menuListString.Add("Корисна література");

            menuListString.Add("Тести");

            var menu = MenuGenerator.ReplyKeyboard(2, menuListString);

            var option = new OptionMessage();
            option.MenuReplyKeyboardMarkup = menu;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, option);
        }
        #endregion

        #region Slash
        [SlashHandler("/help")]
        [ReplyMenuHandler("Зв'язатися з викладачем")]
        public static async Task Help(ITelegramBotClient botClient, Update update)
        {
            var message = "Telegram: @Kostiantyn_Dvirnychuk\nEmail: k.dvirnychuk@chnu.edu.ua";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }

        #endregion
        [ReplyMenuHandler("Youtube")]
        public static async Task Youtube(ITelegramBotClient botClient, Update update)
        {
            var message = "Youtube";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Programming and Chess", "https://www.youtube.com/channel/UC2ce6AnjhV6T2rF2lb_MXqQ/videos");

            menu.Add(url);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [ReplyMenuHandler("Корисна література")]
        public static async Task Book(ITelegramBotClient botClient, Update update)
        {
            var message = "Корисна література";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Посібник з Java", "https://abitap.com/1424-2/");
            var url1 = new InlineURL("Посібник з WEB", "https://abitap.com/posibnyk-z-web/");
            var url2 = new InlineURL("Книга по патернах", "https://abitap.com/knyga-po-paternah/");

            menu.Add(url);
            menu.Add(url1);
            menu.Add(url2);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [ReplyMenuHandler("Тести")]
        public static async Task Tests(ITelegramBotClient botClient, Update update)
        {
            var message = "Тести з теми:";

            List<IInlineContent> menu = new List<IInlineContent>();

            var testOne = new InlineCallback("HTML 5 та CSS 3", CustomTHeader.TestOne);
            var testTwo = new InlineCallback("Мова програмування C# 12 (.NET 8)", CustomTHeader.TestTwo);
            var testThree = new InlineCallback("Патерни проектування", CustomTHeader.TestThree);

            menu.Add(testOne);
            menu.Add(testTwo);
            menu.Add(testThree);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back2)]
        public static async Task Back2 (ITelegramBotClient botClient, Update update)
        {
            var message = "Тести з теми:";

            List<IInlineContent> menu = new List<IInlineContent>();

            var testOne = new InlineCallback("HTML 5 та CSS 3", CustomTHeader.TestOne);
            var testTwo = new InlineCallback("Мова програмування C# 12 (.NET 8)", CustomTHeader.TestTwo);
            var testThree = new InlineCallback("Патерни проектування", CustomTHeader.TestThree);

            menu.Add(testOne);
            menu.Add(testTwo);
            menu.Add(testThree);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.TestOne)]
        public static async Task TestOne(ITelegramBotClient botClient, Update update)
        {
            var message = "HTML 5 та CSS 3";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Тест. Про HTML5", "https://abitap.com/test-pro-html5/");
            var exampleTwo = new InlineURL("Тест. Елементи HTML 5", "https://abitap.com/test-elementy-html-5/");
            var exampleThree = new InlineURL("Тест. Форми на HTML5", "https://abitap.com/test-formy-na-html5/");
            var exampleFour = new InlineURL("Тест. Елементи структури сторінки", "https://abitap.com/test-elementy-struktury-storinky/");
            var exampleFive = new InlineURL("Тест 1. Селектори CSS 3", "https://abitap.com/test-selektory-css-3/");
            var exampleSix = new InlineURL("Тест 2. Селектори CSS 3", "https://abitap.com/test-2-selektory-css-3/");
            var exampleSeven = new InlineURL("Тест 1. Властивості CSS 3", "https://abitap.com/test-1-vlastyvosti-css-3/");
            var exampleEight = new InlineURL("Тест 2. Властивості CSS 3", "https://abitap.com/test-2-vlastyvosti-css-3/");
            var exampleNine = new InlineURL("Тести до розділу верстки", "https://abitap.com/testy-do-rozdilu-verstky/");
            var exampleTen = new InlineURL("Тести. Адаптивний дизайн", "https://abitap.com/testy-adaptyvnyj-dyzajn/");
            var exampleEleven = new InlineURL("Тести. Мультимедіа CSS 3", "https://abitap.com/testy-multymedia-css-3/");
            var back2 = new InlineCallback("<- Назад", CustomTHeader.Back2);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(back2);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.TestTwo)]
        public static async Task TestTwo(ITelegramBotClient botClient, Update update)
        {
            var message = "Мова програмування C# 12 (.NET 8)";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Тест. Вступ у C#", "https://abitap.com/1-10-test/");
            var exampleTwo = new InlineURL("Тест 1. Базові елементи мови C#", "https://abitap.com/test/");
            var exampleThree = new InlineURL("Тест 2. Базові елементи мови C#", "https://abitap.com/test-2/");
            var exampleFour = new InlineURL("Тест 3. Базові елементи мови C#", "https://abitap.com/test-3/");
            var exampleFive = new InlineURL("Тест. Управляючі конструкції", "https://abitap.com/test-upravlyayuchi-konstrukcziyi/");
            var exampleSix = new InlineURL("Тест. Масиви та перерахування", "https://abitap.com/test-masyvy-ta-pererahuvannya/");
            var exampleSeven = new InlineURL("Тест. Методи", "https://abitap.com/test-metody/");
            var exampleEight = new InlineURL("Тест. Класи", "https://abitap.com/test-klasy/");
            var exampleNine = new InlineURL("Тест. Класи та структури", "https://abitap.com/test-klasy-ta-struktury/");
            var exampleTen = new InlineURL("Тест. Видимість змінних та простори імен", "https://abitap.com/test-do-temy-7/");
            var exampleEleven = new InlineURL("Тест 1. Доступ до членів класу", "https://abitap.com/test-1-dostup-do-chleniv-klasu/");
            var exampleTwelve = new InlineURL("Тест 2. Доступ до членів класу", "https://abitap.com/test-2-dostup-do-chleniv-klasu/");
            var exampleThirteen = new InlineURL("Тест. Особливості null", "https://abitap.com/test-osoblyvosti-null/");
            var exampleFourteen = new InlineURL("Тест 1. ООП на С#", "https://abitap.com/test-1-oop-na-s/");
            var exampleFifteen = new InlineURL("Тест 2. ООП на С#", "https://abitap.com/test-2-oop-na-s/");
            var exampleSixteen = new InlineURL("Тест. Узагальнення", "https://abitap.com/test-uzagalnennya/");
            var exampleSeventeen = new InlineURL("Тест. Обробка винятків", "https://abitap.com/test-obrobka-vynyatkiv/");
            var exampleEighteen = new InlineURL("Тест. Делегати, події та лямбди", "https://abitap.com/testy/");
            var exampleNineteen = new InlineURL("Тести 1 по інтерфейсах", "https://abitap.com/testy-1-po-interfejsah/");
            var exampleTwenty = new InlineURL("Тести 2 по інтерфейсах", "https://abitap.com/testy-2-po-interfejsah/");
            var exampleTwentyOne = new InlineURL("Тест. Інші можливості ООП на С#", "https://abitap.com/testy-2/");
            var back2 = new InlineCallback("<- Назад", CustomTHeader.Back2);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve); 
            menu.Add(exampleThirteen); 
            menu.Add(exampleFourteen); 
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(exampleNineteen);
            menu.Add(exampleTwenty);
            menu.Add(exampleTwentyOne);
            menu.Add(back2);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.TestThree)]
        public static async Task TestThree(ITelegramBotClient botClient, Update update)
        {
            var message = "Патерни проектування";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Тест. Основи патернів проектування", "https://abitap.com/test-osnovy-paterniv-proektuvannya/");
            var exampleTwo = new InlineURL("Тест. Породжуючі патерни", "https://abitap.com/test-porodzhuyuchi-paterny/");
            var exampleThree = new InlineURL("Тест. Патерни поведінки", "https://abitap.com/test-paterny-povedinky/");
            var exampleFour = new InlineURL("Тест. Структурні патерни", "https://abitap.com/test-strukturni-paterny/");
            var exampleFive = new InlineURL("Тест. Принципи SOLID", "https://abitap.com/test-prynczypy-solid/");
            var back2 = new InlineCallback("<- Назад", CustomTHeader.Back2);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(back2);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }
        #region Inline

        [ReplyMenuHandler("Abitap")]
        public static async Task Inline(ITelegramBotClient botClient, Update update)
        {
            var message = "Abitap";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Abitap", "https://abitap.com/");
            var exampleOne = new InlineCallback(".NET MAUI", CustomTHeader.ExampleOne);
            var exampleTwo = new InlineCallback(".ASP .NET MVC", CustomTHeader.ExampleTwo);
            var exampleThree = new InlineCallback("Entity Framework Core 7", CustomTHeader.ExampleThree);
            var exampleFour = new InlineCallback("HTML 5 та CSS 3", CustomTHeader.ExampleFour);
            var exampleFive = new InlineCallback("Java", CustomTHeader.ExampleFive);
            var exampleSix = new InlineCallback("Python", CustomTHeader.ExampleSix);
            var exampleSeven = new InlineCallback("Windows Forms", CustomTHeader.ExampleSeven);
            var exampleEight = new InlineCallback("Алгоритми та структури даних", CustomTHeader.ExampleEight);
            var exampleNine = new InlineCallback("Мова програмування C# 12 (.NET 8)", CustomTHeader.ExampleNine);
            var exampleTen = new InlineCallback("Патерни проектування", CustomTHeader.ExampleTen);

            menu.Add(url);
            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne)]
        public static async Task InlineExample1(ITelegramBotClient botClient, Update update)
        {
            var message = ".NET MAUI";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL(".NET MAUI", "https://abitap.com/category/net-maui/");
            var exampleOne1 = new InlineCallback("Вступ", CustomTHeader.ExampleOne1);
            var exampleTwo1 = new InlineCallback("Створення графічних інтерфейсів", CustomTHeader.ExampleTwo1);
            var exampleThree1 = new InlineCallback("Елементи компоновки", CustomTHeader.ExampleThree1);
            var exampleFour1 = new InlineCallback("Елементи керування", CustomTHeader.ExampleFour1);
            var exampleFive1 = new InlineCallback("Ресурси та стилі", CustomTHeader.ExampleFive1);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne1);
            menu.Add(exampleTwo1);
            menu.Add(exampleThree1);
            menu.Add(exampleFour1);
            menu.Add(exampleFive1);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo)]
        public static async Task InlineExample2(ITelegramBotClient botClient, Update update)
        {
            var message = "ASP .NET MVC";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("ASP .NET MVC", "https://abitap.com/category/asp-net-mvc/");
            var exampleOne2 = new InlineURL("Вступ:\n-Перший сайт", "https://abitap.com/pershyj-sajt/");
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne2);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThree)]
        public static async Task InlineExample3(ITelegramBotClient botClient, Update update)
        {
            var message = "Entity Framework Core 7";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Entity Framework Core 7", "https://abitap.com/category/entity-framework-core-7/");
            var exampleOne3 = new InlineCallback("Вступ", CustomTHeader.ExampleOne3);
            var exampleTwo3 = new InlineCallback("Провайдери БД", CustomTHeader.ExampleTwo3);
            var exampleThree3 = new InlineCallback("Створення Моделей", CustomTHeader.ExampleThree3);
            var exampleFour3 = new InlineCallback("Відношення між моделями", CustomTHeader.ExampleFour3);
            var exampleFive3 = new InlineCallback("Успадкування", CustomTHeader.ExampleFive3);
            var exampleSix3 = new InlineCallback("Запити та LINQ to entities", CustomTHeader.ExampleSix3);
            var exampleSeven3 = new InlineCallback("SQL", CustomTHeader.ExampleSeven3);
            var exampleEight3 = new InlineCallback("Додатково", CustomTHeader.ExampleEight3);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne3);
            menu.Add(exampleTwo3);
            menu.Add(exampleThree3);
            menu.Add(exampleFour3);
            menu.Add(exampleFive3);
            menu.Add(exampleSix3);
            menu.Add(exampleSeven3);
            menu.Add(exampleEight3);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFour)]
        public static async Task InlineExample4(ITelegramBotClient botClient, Update update)
        {
            var message = "HTML 5 та CSS 3";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("HTML 5 та CSS 3", "https://abitap.com/category/html-5-ta-css-3/");
            var exampleOne4 = new InlineCallback("Про HTML5", CustomTHeader.ExampleOne4);
            var exampleTwo4 = new InlineCallback("Елементи HTML5", CustomTHeader.ExampleTwo4);
            var exampleThree4 = new InlineCallback("Форми на HTML5", CustomTHeader.ExampleThree4);
            var exampleFour4 = new InlineCallback("Елементи структури сторінки", CustomTHeader.ExampleFour4);
            var exampleFive4 = new InlineCallback("Селектори CSS3", CustomTHeader.ExampleFive4);
            var exampleSix4 = new InlineCallback("Властивості CSS3", CustomTHeader.ExampleSix4);
            var exampleSeven4 = new InlineCallback("Верстка", CustomTHeader.ExampleSeven4);
            var exampleEight4 = new InlineCallback("Адаптивний дизайн", CustomTHeader.ExampleEight4);
            var exampleNine4 = new InlineCallback("Анімація", CustomTHeader.ExampleNine4);
            var exampleTen4 = new InlineCallback("Мультимедія", CustomTHeader.ExampleTen4);
            var exampleEleven4 = new InlineCallback("Flexbox", CustomTHeader.ExampleEleven4);
            var exampleTwelve4 = new InlineCallback("Grid Layout", CustomTHeader.ExampleTwelve4);
            var exampleThirteen4 = new InlineCallback("Змінні CSS3", CustomTHeader.ExampleThirteen4);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne4);
            menu.Add(exampleTwo4);
            menu.Add(exampleThree4);
            menu.Add(exampleFour4);
            menu.Add(exampleFive4);
            menu.Add(exampleSix4);
            menu.Add(exampleSeven4);
            menu.Add(exampleEight4);
            menu.Add(exampleNine4);
            menu.Add(exampleTen4);
            menu.Add(exampleEleven4);
            menu.Add(exampleTwelve4);
            menu.Add(exampleThirteen4);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFive)]
        public static async Task InlineExample5(ITelegramBotClient botClient, Update update)
        {
            var message = "Java";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Java", "https://abitap.com/category/java/");
            var exampleOne5 = new InlineCallback("Вступ", CustomTHeader.ExampleOne5);
            var exampleTwo5 = new InlineCallback("Основи мови Java", CustomTHeader.ExampleTwo5);
            var exampleThree5 = new InlineCallback("ООП на Java", CustomTHeader.ExampleThree5);
            var exampleFour5 = new InlineCallback("Обробка винятків", CustomTHeader.ExampleFour5);
            var exampleFive5 = new InlineCallback("Колекції", CustomTHeader.ExampleFive5);
            var exampleSix5 = new InlineCallback("Робота з файлами", CustomTHeader.ExampleSix5);
            var exampleSeven5 = new InlineCallback("Робота з рядками", CustomTHeader.ExampleSeven5);
            var exampleEight5 = new InlineCallback("Лямбди-вирази", CustomTHeader.ExampleEight5);
            var exampleNine5 = new InlineCallback("Багатопоточність", CustomTHeader.ExampleNine5);
            var exampleTen5 = new InlineCallback("Stream API", CustomTHeader.ExampleTen5);
            var exampleEleven5 = new InlineCallback("Сокети", CustomTHeader.ExampleEleven5);
            var exampleTwelve5 = new InlineCallback("Робота з БД", CustomTHeader.ExampleTwelve5);
            var exampleThirteen5 = new InlineCallback("Модульність", CustomTHeader.ExampleThirteen5);
            var exampleFourteen5 = new InlineCallback("Додаткові класи", CustomTHeader.ExampleFourteen5);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne5);
            menu.Add(exampleTwo5);
            menu.Add(exampleThree5);
            menu.Add(exampleFour5);
            menu.Add(exampleFive5);
            menu.Add(exampleSix5);
            menu.Add(exampleSeven5);
            menu.Add(exampleEight5);
            menu.Add(exampleNine5);
            menu.Add(exampleTen5);
            menu.Add(exampleEleven5);
            menu.Add(exampleTwelve5);
            menu.Add(exampleThirteen5);
            menu.Add(exampleFourteen5);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSix)]
        public static async Task InlineExample6(ITelegramBotClient botClient, Update update)
        {
            var message = "Python";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Python", "https://abitap.com/category/python/");
            var exampleOne6 = new InlineCallback("Вступ та перша програма", CustomTHeader.ExampleOne6);
            var exampleTwo6 = new InlineCallback("Синтаксис та типи даних", CustomTHeader.ExampleTwo6);
            var exampleThree6 = new InlineCallback("Оператор", CustomTHeader.ExampleThree6);
            var exampleFour6 = new InlineCallback("Керуючі конструкції (цикли, оператори)", CustomTHeader.ExampleFour6);
            var exampleFive6 = new InlineCallback("Списки", CustomTHeader.ExampleFive6);
            var exampleSix6 = new InlineCallback("Словники", CustomTHeader.ExampleSix6);
            var exampleSeven6 = new InlineCallback("Набори", CustomTHeader.ExampleSeven6);
            var exampleEight6 = new InlineCallback("Обробка винятків", CustomTHeader.ExampleEight6);
            var exampleNine6 = new InlineCallback("Модуль та пакети", CustomTHeader.ExampleNine6);
            var exampleTen6 = new InlineCallback("Робота з файлами директоріями", CustomTHeader.ExampleTen6);
            var exampleEleven6 = new InlineCallback("Рядки", CustomTHeader.ExampleEleven6);
            var exampleTwelve6 = new InlineCallback("Класи та об'єкти (ООП)", CustomTHeader.ExampleTwelve6);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne6);
            menu.Add(exampleTwo6);
            menu.Add(exampleThree6);
            menu.Add(exampleFour6);
            menu.Add(exampleFive6);
            menu.Add(exampleSix6);
            menu.Add(exampleSeven6);
            menu.Add(exampleEight6);
            menu.Add(exampleNine6);
            menu.Add(exampleTen6);
            menu.Add(exampleEleven6);
            menu.Add(exampleTwelve6);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSeven)]
        public static async Task InlineExample7(ITelegramBotClient botClient, Update update)
        {
            var message = "Windows Forms";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Windows Forms", "https://abitap.com/category/35-grafichni-windows-zastosunky/");
            var exampleOne7 = new InlineCallback("Вступ", CustomTHeader.ExampleOne7);
            var exampleTwo7 = new InlineCallback("Провайдери БД", CustomTHeader.ExampleTwo7);
            var exampleThree7 = new InlineCallback("Створення Моделей", CustomTHeader.ExampleThree7);
            var exampleFour7 = new InlineCallback("Відношення між моделями", CustomTHeader.ExampleFour7);
            var exampleFive7 = new InlineCallback("Успадкування", CustomTHeader.ExampleFive7);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne7);
            menu.Add(exampleTwo7);
            menu.Add(exampleThree7);
            menu.Add(exampleFour7);
            menu.Add(exampleFive7);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleEight)]
        public static async Task InlineExample8(ITelegramBotClient botClient, Update update)
        {
            var message = "Алгоритми та структури даних:\n-Деякі програми на C#11";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Алгоритми та структури даних:\n-Деякі програми на C#11", "https://abitap.com/category/algorytmy-ta-struktury-danyh/");
            var exampleOne8 = new InlineURL("Задача від Google по алгоритмам та структурам даних", "https://abitap.com/zadacha-vid-google-po-algorytmam-ta-strukturam-danyh/");
            var exampleTwo8 = new InlineURL("Завдання із співбесід на структури даних та алгоритми", "https://abitap.com/zavdannya-iz-spivbesid-na-struktury-danyh-ta-algorytmy/");
            var exampleThree8 = new InlineURL("Задача із співбесіди. Метод двох покажчиків", "https://abitap.com/zadacha-iz-spivbesidy-metod-dvoh-pokazhchykiv/");
            var exampleFour8 = new InlineURL("Простий приклад динамічного програмування. Співбесіда", "https://abitap.com/prostyj-pryklad-dynamichnogo-programuvannya-spivbesida/");
            var exampleFive8 = new InlineURL("Дерева. Перша задача на бінарні дерева", "https://abitap.com/dereva-persha-zadacha-na-binarni-dereva/");
            var exampleSix8 = new InlineURL("Задача із співбесіди на бінарні дерева", "https://abitap.com/zadacha-iz-spivbesidy-na-binarni-dereva/");
            var exampleSeven8 = new InlineURL("Задача на знаходження елемента в масиві на співбесіді", "https://abitap.com/zadacha-na-znahodzhennya-elementa-v-masyvi-na-spivbesidi/");
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne8);
            menu.Add(exampleTwo8);
            menu.Add(exampleThree8);
            menu.Add(exampleFour8);
            menu.Add(exampleFive8);
            menu.Add(exampleSix8);
            menu.Add(exampleSeven8);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleNine)]
        public static async Task InlineExample9(ITelegramBotClient botClient, Update update)
        {
            var message = "Мова програмування C# 12 (.NET 8)";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Мова програмування C# 12 (.NET 8)", "https://abitap.com/category/c/");
            var exampleOne9 = new InlineCallback("Вступ(перша програма)", CustomTHeader.ExampleOne9);
            var exampleTwo9 = new InlineCallback("Змінні, типи даних та операції", CustomTHeader.ExampleTwo9);
            var exampleThree9 = new InlineCallback("Керуючі конструкці(цикли, умови)", CustomTHeader.ExampleThree9);
            var exampleFour9 = new InlineCallback("Масиви. Перерахування", CustomTHeader.ExampleFour9);
            var exampleFive9 = new InlineCallback("Методи", CustomTHeader.ExampleFive9);
            var exampleSix9 = new InlineCallback("Класи, об'єкти та структури", CustomTHeader.ExampleSix9);
            var exampleSeven9 = new InlineCallback("Видимість змінних та простори імен", CustomTHeader.ExampleSeven9);
            var exampleEight9 = new InlineCallback("Доступ до членів класу", CustomTHeader.ExampleEight9);
            var exampleNine9 = new InlineCallback("Особливості null", CustomTHeader.ExampleNine9);
            var exampleTen9 = new InlineCallback("ООП на C#", CustomTHeader.ExampleTen9);
            var exampleEleven9 = new InlineCallback("Узагальнені типи", CustomTHeader.ExampleEleven9);
            var exampleTwelve9 = new InlineCallback("Обробка винятків", CustomTHeader.ExampleTwelve9);
            var exampleThirteen9 = new InlineCallback("Делегати, події та лямбди", CustomTHeader.ExampleThirteen9);
            var exampleFourteen9 = new InlineCallback("Інтерфейси", CustomTHeader.ExampleFourteen9);
            var exampleFifteen9 = new InlineCallback("Інші можливості ООП на C#", CustomTHeader.ExampleFifteen9);
            var exampleSixteen9 = new InlineCallback("Патерни / шаблони", CustomTHeader.ExampleSixteen9);
            var exampleSeventeen9 = new InlineCallback("Колекції", CustomTHeader.ExampleSeventeen9);
            var exampleEighteen9 = new InlineCallback("Робота з рядками", CustomTHeader.ExampleEighteen9);
            var exampleNineteen9 = new InlineCallback("Робота з датою та часом", CustomTHeader.ExampleNineteen9);
            var exampleTwenty9 = new InlineCallback("Деякі необхідні класи та структури .NET", CustomTHeader.ExampleTwenty9);
            var exampleTwentyOne9 = new InlineCallback("Багатопоточність", CustomTHeader.ExampleTwentyOne9);
            var exampleTwentyTwo9 = new InlineCallback("Паралельне програмування та бібліотека TPL", CustomTHeader.ExampleTwentyTwo9);
            var exampleTwentyThree9 = new InlineCallback("Асинхронне програмування", CustomTHeader.ExampleTwentyThree9);
            var exampleTwentyFour9 = new InlineCallback("LINQ", CustomTHeader.ExampleTwentyFour9);
            var exampleTwentyFive9 = new InlineCallback("Parallel LINQ", CustomTHeader.ExampleTwentyFive9);
            var exampleTwentySix9 = new InlineCallback("Рефлексія", CustomTHeader.ExampleTwentySix9);
            var exampleTwentySeven9 = new InlineCallback("Dynamic Language Runtime", CustomTHeader.ExampleTwentySeven9);
            var exampleTwentyEight9 = new InlineCallback("Збирач сміття, керування пам'яттю та вказівники", CustomTHeader.ExampleTwentyEight9);
            var exampleTwentyNine9 = new InlineCallback("Робота з файловою системою", CustomTHeader.ExampleTwentyNine9);
            var exampleThirty9 = new InlineCallback("Робота з JSON", CustomTHeader.ExampleThirty9);
            var exampleThirtyOne9 = new InlineCallback("Робота з XML", CustomTHeader.ExampleThirtyOne9);
            var exampleThirtyTwo9 = new InlineCallback("Процедури і домени застосунку", CustomTHeader.ExampleThirtyTwo9);
            var exampleThirtyThree9 = new InlineCallback("Публікації програми", CustomTHeader.ExampleThirtyThree9);
            var exampleThirtyFour9 = new InlineCallback("Нове в C#11", CustomTHeader.ExampleThirtyFour9);
            var exampleThirtyFive9 = new InlineCallback("Нове в C#12", CustomTHeader.ExampleThirtyFive9);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne9);
            menu.Add(exampleTwo9);
            menu.Add(exampleThree9);
            menu.Add(exampleFour9);
            menu.Add(exampleFive9);
            menu.Add(exampleSix9);
            menu.Add(exampleSeven9);
            menu.Add(exampleEight9);
            menu.Add(exampleNine9);
            menu.Add(exampleTen9);
            menu.Add(exampleEleven9);
            menu.Add(exampleTwelve9);
            menu.Add(exampleThirteen9);
            menu.Add(exampleFourteen9);
            menu.Add(exampleFifteen9);
            menu.Add(exampleSixteen9);
            menu.Add(exampleSeventeen9);
            menu.Add(exampleEighteen9);
            menu.Add(exampleNineteen9);
            menu.Add(exampleTwenty9);
            menu.Add(exampleTwentyOne9);
            menu.Add(exampleTwentyTwo9);
            menu.Add(exampleTwentyThree9);
            menu.Add(exampleTwentyFour9);
            menu.Add(exampleTwentyFive9);
            menu.Add(exampleTwentySix9);
            menu.Add(exampleTwentySeven9);
            menu.Add(exampleTwentyEight9);
            menu.Add(exampleTwentyNine9);
            menu.Add(exampleThirty9);
            menu.Add(exampleThirtyOne9);
            menu.Add(exampleThirtyTwo9);
            menu.Add(exampleThirtyThree9);
            menu.Add(exampleThirtyFour9);
            menu.Add(exampleThirtyFive9);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTen)]
        public static async Task InlineExample10(ITelegramBotClient botClient, Update update)
        {
            var message = "Патерни проектування";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Патерни проектування", "https://abitap.com/category/paterny-proektuvannya/");
            var exampleOne10 = new InlineCallback("Основи патернів проектування", CustomTHeader.ExampleOne10);
            var exampleTwo10 = new InlineCallback("Подорожуючі патерни", CustomTHeader.ExampleTwo10);
            var exampleThree10 = new InlineCallback("Патерни поведінки", CustomTHeader.ExampleThree10);
            var exampleFour10 = new InlineCallback("Структурні патерни", CustomTHeader.ExampleFour10);
            var exampleFive10 = new InlineCallback("Принципи SOLID", CustomTHeader.ExampleFive10);
            var exampleSix10 = new InlineCallback("Додаткові принципи та патерни", CustomTHeader.ExampleSix10);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne10);
            menu.Add(exampleTwo10);
            menu.Add(exampleThree10);
            menu.Add(exampleFour10);
            menu.Add(exampleFive10);
            menu.Add(exampleSix10);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back)]
        public static async Task Back(ITelegramBotClient botClient, Update update)
        {
            var message = "Abitap";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Abitap", "https://abitap.com/");
            var exampleOne = new InlineCallback(".NET MAUI", CustomTHeader.ExampleOne);
            var exampleTwo = new InlineCallback(".ASP .NET MVC", CustomTHeader.ExampleTwo);
            var exampleThree = new InlineCallback("Entity Framework Core 7", CustomTHeader.ExampleThree);
            var exampleFour = new InlineCallback("HTML 5 та CSS 3", CustomTHeader.ExampleFour);
            var exampleFive = new InlineCallback("Java", CustomTHeader.ExampleFive);
            var exampleSix = new InlineCallback("Python", CustomTHeader.ExampleSix);
            var exampleSeven = new InlineCallback("Windows Forms", CustomTHeader.ExampleSeven);
            var exampleEight = new InlineCallback("Алгоритми та структури даних", CustomTHeader.ExampleEight);
            var exampleNine = new InlineCallback("Мова програмування C# 12 (.NET 8)", CustomTHeader.ExampleNine);
            var exampleTen = new InlineCallback("Патерни проектування", CustomTHeader.ExampleTen);

            menu.Add(url);
            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne1)]
        public static async Task InlineExampleOne1(ITelegramBotClient botClient, Update update)
        {
            var message = "Вступ";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Створення кросплатформних додатків на .NET", "https://abitap.com/1-1-stvorennya-krosplatformnyh-dodatkiv-na-net/");
            var exampleTwo = new InlineURL("Створення проекта", "https://abitap.com/1-2-stvorennya-proekta/");
            var exampleThree = new InlineURL("Перший додаток для Android", "https://abitap.com/1-3-pershyj-dodatok-dlya-android/");
            var exampleFour = new InlineURL("Перший додаток на Windows", "https://abitap.com/1-4-pershyj-dodatok-na-windows/");
            var exampleFive = new InlineURL("Перша програма на iOS", "https://abitap.com/1-5-persha-programa-na-ios/");
            var exampleSix = new InlineURL("Перша програма для Mac OS", "https://abitap.com/1-6-persha-programa-dlya-mac-os/");
            var back1 = new InlineCallback("<- Назад", CustomTHeader.Back1);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(back1);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo1)]
        public static async Task InlineExampleTwo1(ITelegramBotClient botClient, Update update)
        {
            var message = "Створення графічних інтерфейсів";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Додаток на .NET MAUI", "https://abitap.com/2-1-dodatok-na-net-maui/");
            var exampleTwo = new InlineURL("Сторінки та XAML", "https://abitap.com/2-2-storinky-ta-xaml/");
            var exampleThree = new InlineURL("Взаємодія XAML і C#", "https://abitap.com/2-3-vzayemodiya-xaml-i-c/");
            var exampleFour = new InlineURL("Створення інтерфейсу з коду C#", "https://abitap.com/2-4-stvorennya-interfejsu-z-kodu-c/");
            var exampleFive = new InlineURL("Метод LoadFromXaml та завантаження XAML", "https://abitap.com/2-5-metod-loadfromxaml-ta-zavantazhennya-xaml/");
            var back1 = new InlineCallback("<- Назад", CustomTHeader.Back1);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(back1);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThree1)]
        public static async Task InlineExampleThree1(ITelegramBotClient botClient, Update update)
        {
            var message = "Елементи компановки";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("StackLayout, HorizontalStackLayout та VerticalStackLayout", "https://abitap.com/3-1-stacklayout-horizontalstacklayout-ta-verticalstacklayout/");
            var exampleTwo = new InlineURL("AbsoluteLayout", "https://abitap.com/3-2-absolutelayout/");
            var exampleThree = new InlineURL("Контейнер Grid", "https://abitap.com/3-3-kontejner-grid/");
            var back1 = new InlineCallback("<- Назад", CustomTHeader.Back1);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back1);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFour1)]
        public static async Task InlineExamplFour1(ITelegramBotClient botClient, Update update)
        {
            var message = "Елементи керування";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Розміри та позиціонування елементів на сторінці", "https://abitap.com/4-1-rozmiry-ta-pozyczionuvannya-elementiv-na-storinczi/");
            var exampleTwo = new InlineURL("Робота з кольором", "https://abitap.com/4-2-robota-z-kolorom/");
            var exampleThree = new InlineURL("Стилізація тексту", "https://abitap.com/4-3-stylizacziya-tekstu/");
            var exampleFour = new InlineURL("Кнопки", "https://abitap.com/4-4-knopky/");
            var exampleFive = new InlineURL("Label", "https://abitap.com/4-5-label/");
            var exampleSix = new InlineURL("Текстові поля", "https://abitap.com/4-6-tekstovi-polya/");
            var exampleSeven = new InlineURL("BoxView", "https://abitap.com/4-3-boxview/");
            var exampleEight = new InlineURL("ScrollView", "https://abitap.com/4-8-scrollview/");
            var exampleNine = new InlineURL("Робота із зображеннями. Елемент Image", "https://abitap.com/4-9-robota-iz-zobrazhennyamy-element-image/");
            var exampleTen = new InlineURL("Контейнер Frame", "https://abitap.com/4-10-kontejner-frame/");
            var exampleEleven = new InlineURL("DatePicker та TimePicker", "https://abitap.com/4-11-datepicker-ta-timepicker/");
            var exampleTwelve = new InlineURL("Stepper та Slider", "https://abitap.com/4-12-stepper-ta-slider/");
            var exampleThirteen = new InlineURL("Switch та CheckBox", "https://abitap.com/4-13-switch-ta-checkbox/");
            var exampleFourteen = new InlineURL("Клас RadioButton", "https://abitap.com/4-14-klas-radiobutton/");
            var exampleFifteen = new InlineURL("Елемент Picker", "https://abitap.com/4-15-element-picker/");
            var exampleSixteen = new InlineURL("Клас TableView", "https://abitap.com/4-16-klas-tableview/");
            var exampleSeventeen = new InlineURL("Клас WebView", "https://abitap.com/4-17-klas-webview/");
            var exampleEighteen = new InlineURL("Спливаючі вікна", "https://abitap.com/4-18-splyvayuchi-vikon/");
            var exampleNineteen = new InlineURL("ProgressBar і ActivityIndicator", "https://abitap.com/4-19-progressbar-i-activityindicator/");
            var back1 = new InlineCallback("<- Назад", CustomTHeader.Back1);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(exampleNineteen);
            menu.Add(back1);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFive1)]
        public static async Task InlineExampleFive1(ITelegramBotClient botClient, Update update)
        {
            var message = "Ресурси та стилі";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Ресурси", "https://abitap.com/5-1-resursy/");
            var exampleTwo = new InlineURL("Стилі", "https://abitap.com/5-2-styli/");
            var back1 = new InlineCallback("<- Назад", CustomTHeader.Back1);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(back1);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back1)]
        public static async Task InlineBack1(ITelegramBotClient botClient, Update update)
        {
            var message = ".NET MAUI";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL(".NET MAUI", "https://abitap.com/category/net-maui/");
            var exampleOne1 = new InlineCallback("Вступ", CustomTHeader.ExampleOne1);
            var exampleTwo1 = new InlineCallback("Створення графічних інтерфейсів", CustomTHeader.ExampleTwo1);
            var exampleThree1 = new InlineCallback("Елементи компоновки", CustomTHeader.ExampleThree1);
            var exampleFour1 = new InlineCallback("Елементи керування", CustomTHeader.ExampleFour1);
            var exampleFive1 = new InlineCallback("Ресурси та стилі", CustomTHeader.ExampleFive1);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne1);
            menu.Add(exampleTwo1);
            menu.Add(exampleThree1);
            menu.Add(exampleFour1);
            menu.Add(exampleFive1);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne3)]
        public static async Task InlineExamplOne3(ITelegramBotClient botClient, Update update)
        {
            var message = "Вступ";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Entity Framework Core 7", "https://abitap.com/1-1-entity-framework-core-6/");
            var exampleTwo = new InlineURL("Перша програма", "https://abitap.com/1-2-persha-programa/");
            var exampleThree = new InlineURL("Підключення до існуючої бази даних", "https://abitap.com/1-3-pidklyuchennya-do-isnuyuchoyi-bazy-danyh/");
            var exampleFour = new InlineURL("Керування БД", "https://abitap.com/1-4-keruvannya-bd/");
            var exampleFive = new InlineURL("Операції з даними (CRUD)", "https://abitap.com/1-5-operacziyi-z-danymy-crud/");
            var exampleSix = new InlineURL("Конфігурація підключень", "https://abitap.com/4-6-tekstovi-polya/https://abitap.com/1-6-konfiguracziya-piklyuchen/");
            var exampleSeven = new InlineURL("Логування операцій", "https://abitap.com/1-7-loguvannya-operaczij/");
            var exampleEight = new InlineURL("Керування схемою БД та міграції", "https://abitap.com/1-8-keruvannya-shemoyu-bd-ta-migracziyi/");
            var back3 = new InlineCallback("<- Назад", CustomTHeader.Back3);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(back3);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo3)]
        public static async Task InlineExampleTwo3(ITelegramBotClient botClient, Update update)
        {
            var message = "Провайдери БД";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("MS SQL Server", "https://abitap.com/2-1-ms-sql-server/");
            var exampleTwo = new InlineURL("MySQL", "https://abitap.com/2-2-mysql/");
            var exampleThree = new InlineURL("PostgreSQL", "https://abitap.com/2-3-postgresql/");
            var back3 = new InlineCallback("<- Назад", CustomTHeader.Back3);


            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back3);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThree3)]
        public static async Task InlineExamplThree3(ITelegramBotClient botClient, Update update)
        {
            var message = "Створення моделей";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Fluent API та анотації даних", "https://abitap.com/3-1-fluent-api-ta-anotacziyi-danyh/");
            var exampleTwo = new InlineURL("Визначення моделей", "https://abitap.com/3-2-vyznachennya-modelej/");
            var exampleThree = new InlineURL("Властивості сутності", "https://abitap.com/3-3/");
            var exampleFour = new InlineURL("Конструктори сутностей", "https://abitap.com/3-4-konstruktory-sutnostej/");
            var exampleFive = new InlineURL("Використання полів сутності", "https://abitap.com/3-5-vykorystannya-poliv-sutnosti/");
            var exampleSix = new InlineURL("Співставлення стовпців та таблиць", "https://abitap.com/3-6-spivstavlennya-stovpcziv-ta-tablycz/");
            var exampleSeven = new InlineURL("Обов’язкові та необов’язкові властивості", "https://abitap.com/3-7-obovyazkovi-ta-neobovyazkovi-vlastyvosti/");
            var exampleEight = new InlineURL("Налаштування ключів", "https://abitap.com/3-8-nalashtuvannya-klyuchiv/");
            var exampleNine = new InlineURL("Налаштування індексів", "https://abitap.com/3-9-nalashtuvannya-indeksiv/");
            var exampleTen = new InlineURL("Генерація значень властивостей та стовпців", "https://abitap.com/3-10-generacziya-znachen-vlastyvostej-ta-stovpcziv/");
            var exampleEleven = new InlineURL("Установка обмежень", "https://abitap.com/3-11-ustanovka-obmezhen/");
            var exampleTwelve = new InlineURL("Конфігурація моделей", "https://abitap.com/3-12-konfiguracziya-modelej/");
            var exampleThirteen = new InlineURL("Ініціалізація бази даних початковими даними", "https://abitap.com/3-13-iniczializacziya-bazy-danyh-pochatkovymy-danymy/");
            var back3 = new InlineCallback("<- Назад", CustomTHeader.Back3);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(back3);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFour3)]
        public static async Task InlineExamplFour3(ITelegramBotClient botClient, Update update)
        {
            var message = "Відношення між моделями";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Зовнішні ключі та навігаційні властивості", "https://abitap.com/4-1-zovnishni-klyuchi-ta-navigaczijni-vlastyvosti/");
            var exampleTwo = new InlineURL("Налаштування зовнішнього ключа", "https://abitap.com/4-2-nalashtuvannya-zovnishnogo-klyucha/");
            var exampleThree = new InlineURL("Каскадне видалення", "https://abitap.com/4-3-kaskadne-vydalennya/");
            var exampleFour = new InlineURL("Завантаження пов’язаних даних. Метод Include", "https://abitap.com/4-4-zavantazhennya-povyazanyh-danyh-metod-include/");
            var exampleFive = new InlineURL("Явне завантаження / Explicit loading", "https://abitap.com/4-5-yavne-zavantazhennya-explicit-loading/");
            var exampleSix = new InlineURL("Ліниве завантаження / Lazy loading", "https://abitap.com/4-6-linyve-zavantazhennya-lazy-loading/");
            var exampleSeven = new InlineURL("Відношення один до одного", "https://abitap.com/4-7-vidnoshennya-odyn-do-odnogo/");
            var exampleEight = new InlineURL("Відношення один до багатьох", "https://abitap.com/4-8-vidnoshennya-odyn-do-bagatoh/");
            var exampleNine = new InlineURL("Відношення багато до багатьох", "https://abitap.com/4-9-vidnoshennya-bagato-do-bagatoh/");
            var exampleTen = new InlineURL("Комплексні типи", "https://abitap.com/4-10-kompleksni-typy/");
            var exampleEleven = new InlineURL("Ієрархічні дані", "https://abitap.com/4-11-iyerarhichni-dani/");
            var back3 = new InlineCallback("<- Назад", CustomTHeader.Back3);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(back3);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFive3)]
        public static async Task InlineExampleFive3(ITelegramBotClient botClient, Update update)
        {
            var message = "Успадкування";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Успадкування", "https://abitap.com/5-1-uspadkuvannya/");
            var exampleTwo = new InlineURL("Підхід TPT – Table Per Type", "https://abitap.com/5-2-pidhid-tpt-table-per-type/");
            var back3 = new InlineCallback("<- Назад", CustomTHeader.Back3);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(back3);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSix3)]
        public static async Task InlineExamplSix3(ITelegramBotClient botClient, Update update)
        {
            var message = "Запити в LINQ to Entities";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Вступ в LINQ to Entities", "https://abitap.com/6-1-vstup-v-linq-to-entities/");
            var exampleTwo = new InlineURL("Вибірка та фільтрація", "https://abitap.com/6-2-vybirka-ta-filtracziya/");
            var exampleThree = new InlineURL("Сортування та проекція з бази даних", "https://abitap.com/6-3-sortuvannya-ta-proekcziya-z-bazy-danyh/");
            var exampleFour = new InlineURL("З’єднання та групування таблиць", "https://abitap.com/6-4-zyednannya-ta-grupuvannya-tablycz/");
            var exampleFive = new InlineURL("Операції з множинами", "https://abitap.com/6-5-operacziyi-z-mnozhynamy/");
            var exampleSix = new InlineURL("Агрегатні операції", "https://abitap.com/6-6-agregatni-operacziyi/");
            var exampleSeven = new InlineURL("Відстеження об’єктів та AsNoTracking", "https://abitap.com/6-7-vidstezhennya-obyektiv-ta-asnotracking/");
            var exampleEight = new InlineURL("Виконання запитів", "https://abitap.com/6-8-vykonannya-zapytiv/");
            var exampleNine = new InlineURL("IEnumerable та IQueryable", "https://abitap.com/6-9-ienumerable-ta-iqueryable%ef%bf%bc/");
            var exampleTen = new InlineURL("Фільтри запитів рівня моделі", "https://abitap.com/6-10-filtry-zapytiv-rivnya-modeli/");
            var back3 = new InlineCallback("<- Назад", CustomTHeader.Back3);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(back3);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSeven3)]
        public static async Task InlineExampleSeven3(ITelegramBotClient botClient, Update update)
        {
            var message = "SQL";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Виконання SQL-запитів", "https://abitap.com/6-11-vykonannya-sql-zapytiv/");
            var exampleTwo = new InlineURL("Збережені функції", "https://abitap.com/7-2-zberezheni-funkcziyi/");
            var exampleThree = new InlineURL("Збережені процедури", "https://abitap.com/7-3-zberezheni-proczedury/");
            var back3 = new InlineCallback("<- Назад", CustomTHeader.Back3);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back3);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleEight3)]
        public static async Task InlineExamplEight3(ITelegramBotClient botClient, Update update)
        {
            var message = "Додатково";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Паралелізм", "https://abitap.com/8-1-paralelizm/");
            var exampleTwo = new InlineURL("Провайдери логування", "https://abitap.com/8-2-provajdery-loguvannya/");
            var exampleThree = new InlineURL("Скомпільовані запити", "https://abitap.com/8-3-skompilovani-zapyty/");
            var exampleFour = new InlineURL("Проекція запитів на представлення", "https://abitap.com/8-4-proekcziya-zapytiv-na-predstavlennya/");
            var exampleFive = new InlineURL("Збереження історії змін", "https://abitap.com/8-5-zberezhennya-istoriyi-zmin/");
            var back3 = new InlineCallback("<- Назад", CustomTHeader.Back3);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(back3);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back3)]
        public static async Task InlineBack3(ITelegramBotClient botClient, Update update)
        {
            var message = "Entity Framework Core 7";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Entity Framework Core 7", "https://abitap.com/category/entity-framework-core-7/");
            var exampleOne3 = new InlineCallback("Вступ", CustomTHeader.ExampleOne3);
            var exampleTwo3 = new InlineCallback("Провайдери БД", CustomTHeader.ExampleTwo3);
            var exampleThree3 = new InlineCallback("Створення Моделей", CustomTHeader.ExampleThree3);
            var exampleFour3 = new InlineCallback("Відношення між моделями", CustomTHeader.ExampleFour3);
            var exampleFive3 = new InlineCallback("Успадкування", CustomTHeader.ExampleFive3);
            var exampleSix3 = new InlineCallback("Запити та LINQ to entities", CustomTHeader.ExampleSix3);
            var exampleSeven3 = new InlineCallback("SQL", CustomTHeader.ExampleSeven3);
            var exampleEight3 = new InlineCallback("Додатково", CustomTHeader.ExampleEight3);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne3);
            menu.Add(exampleTwo3);
            menu.Add(exampleThree3);
            menu.Add(exampleFour3);
            menu.Add(exampleFive3);
            menu.Add(exampleSix3);
            menu.Add(exampleSeven3);
            menu.Add(exampleEight3);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne4)]
        public static async Task InlineExamplOne4(ITelegramBotClient botClient, Update update)
        {
            var message = "Про HTML5";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("HTML це", "https://abitap.com/html-cze/");
            var exampleTwo = new InlineURL("Елементи та атрибути HTML5", "https://abitap.com/1-2-elementy-ta-atrybuty-html5/");
            var exampleThree = new InlineURL(" Створення HTML-документа", "https://abitap.com/1-3-stvorennya-html-dokumenta/");
            var exampleFour = new InlineURL("Різновиди синтаксису HTML5", "https://abitap.com/1-4-riznovydy-syntaksysu-html5/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo4)]
        public static async Task InlineExampleTwo4(ITelegramBotClient botClient, Update update)
        {
            var message = "Елементи HTML5";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Елемент head та метадані веб-сторінки", "https://abitap.com/2-1-element-head-ta-metadani-veb-storinky/");
            var exampleTwo = new InlineURL("Елементи групування", "https://abitap.com/2-2-elementy-grupuvannya/");
            var exampleThree = new InlineURL("Заголовки", "https://abitap.com/zagolovky/");
            var exampleFour = new InlineURL("Форматування тексту", "https://abitap.com/2-4-formatuvannya-tekstu/");
            var exampleFive = new InlineURL("Робота із зображеннями", "https://abitap.com/2-5-robota-iz-zobrazhennyamy/");
            var exampleSix = new InlineURL("Списки", "https://abitap.com/2-6-spysky/");
            var exampleSeven = new InlineURL("Елемент details", "https://abitap.com/2-7-element-details/");
            var exampleEight = new InlineURL("Список визначень", "https://abitap.com/2-8-spysok-vyznachen/");
            var exampleNine = new InlineURL("Таблиці", "https://abitap.com/2-9-tablyczi/");
            var exampleTen = new InlineURL("Посилання", "https://abitap.com/2-10-posylannya/");
            var exampleEleven = new InlineURL("Елементи figure та figcaption", "https://abitap.com/2-11-elementy-figure-ta-figcaption%ef%bf%bc/");
            var exampleTwelve = new InlineURL("Фрейми", "https://abitap.com/2-12-frejmy/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThree4)]
        public static async Task InlineExamplThree4(ITelegramBotClient botClient, Update update)
        {
            var message = " Форми на HTML 5";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Форми", "https://abitap.com/3-1-formy/");
            var exampleTwo = new InlineURL("Елементи форм", "https://abitap.com/3-2-elementy-form/");
            var exampleThree = new InlineURL("Кнопки", "https://abitap.com/3-3-knopky/");
            var exampleFour = new InlineURL("Текстові поля", "https://abitap.com/3-4-tekstovi-polya/");
            var exampleFive = new InlineURL("Мітки та автофокус", "https://abitap.com/3-5-mitky-ta-avtofokus/");
            var exampleSix = new InlineURL("Елементи для введення чисел", "https://abitap.com/3-6-elementy-dlya-vvedennya-chysel/");
            var exampleSeven = new InlineURL("Прапорці та перемикачі", "https://abitap.com/3-7-praporczi-ta-peremykachi/");
            var exampleEight = new InlineURL("Елементи для введення кольорів, url, email, телефону", "https://abitap.com/3-8-elementy-dlya-vvedennya-koloriv-url-email-telefonu/");
            var exampleNine = new InlineURL("Елементи для введення дати та часу", "https://abitap.com/3-9-elementy-dlya-vvedennya-daty-ta-chasu/");
            var exampleTen = new InlineURL("Відправка файлів", "https://abitap.com/3-10-vidpravka-fajliv/");
            var exampleEleven = new InlineURL("Список select", "https://abitap.com/3-11-spysok-select/");
            var exampleTwelve = new InlineURL("Елемент textarea", "https://abitap.com/3-12-element-textarea/");
            var exampleThirteen = new InlineURL("Валідація форми", "https://abitap.com/3-13-validacziya-formy/");
            var exampleFourteen = new InlineURL("Елементи fieldset і legend", "https://abitap.com/3-14-elementy-fieldset-i-legend/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFour4)]
        public static async Task InlineExampleFour4(ITelegramBotClient botClient, Update update)
        {
            var message = "Елементи структури сторінки";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Елемент article", "https://abitap.com/4-1-element-article/");
            var exampleTwo = new InlineURL("Елемент section", "https://abitap.com/4-2-element-section/");
            var exampleThree = new InlineURL("Елемент nav", "https://abitap.com/element-nav/");
            var exampleFour = new InlineURL("Елементи header, footer та address", "https://abitap.com/elementy-header-footer-ta-address/");
            var exampleFive = new InlineURL("Елемент aside", "https://abitap.com/4-5-element-aside/");
            var exampleSix = new InlineURL("Елемент main", "https://abitap.com/element-main/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFive4)]
        public static async Task InlineExamplFive4(ITelegramBotClient botClient, Update update)
        {
            var message = "Селектори CSS 3";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Що таке стилі сайту ?", "https://abitap.com/shho-take-styli-sajtu/");
            var exampleTwo = new InlineURL("Селектори", "https://abitap.com/5-2-selektory/");
            var exampleThree = new InlineURL("Селектори нащадків", "https://abitap.com/5-3-selektory-nashhadkiv/");
            var exampleFour = new InlineURL("Селектори дочірніх елементів", "https://abitap.com/5-4-selektory-dochirnih-elementiv/");
            var exampleFive = new InlineURL("Селектори елементів одного рівня", "https://abitap.com/5-5-selektory-elementiv-odnogo-rivnya/");
            var exampleSix = new InlineURL("Псевдокласи", "https://abitap.com/5-6-psevdoklasy/");
            var exampleSeven = new InlineURL("Псевдокласи дочірніх елементів", "https://abitap.com/5-7-psevdoklasy-dochirnih-elementiv/");
            var exampleEight = new InlineURL("Псевдокласи форм", "https://abitap.com/5-8-psevdoklasy-form/");
            var exampleNine = new InlineURL("Псевдоелементи", "https://abitap.com/5-9-psevdoelementy/");
            var exampleTen = new InlineURL("Селектори атрибутів", "https://abitap.com/selektory-atrybutiv/");
            var exampleEleven = new InlineURL("Успадкування стилів", "https://abitap.com/5-11-uspadkuvannya-styliv/");
            var exampleTwelve = new InlineURL("Каскадність стилів", "https://abitap.com/5-12-kaskadnist-styliv/");
            var exampleThirteen = new InlineURL("Псевдокласи :is() та :where()", "https://abitap.com/5-13-psevdoklasy-is-ta-where/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSix4)]
        public static async Task InlineExampleSix4(ITelegramBotClient botClient, Update update)
        {
            var message = "Властивості CSS 3";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Колір в CSS 3", "https://abitap.com/6-1-kolir-v-css-3/");
            var exampleTwo = new InlineURL("Шрифти", "https://abitap.com/6-2-shryfty/");
            var exampleThree = new InlineURL("Зовнішні шрифти", "https://abitap.com/6-3-zovnishni-shryfty/");
            var exampleFour = new InlineURL("Висота шрифта", "https://abitap.com/6-4-vysota-shryfta/");
            var exampleFive = new InlineURL("Форматування тексту", "https://abitap.com/6-5-formatuvannya-tekstu/");
            var exampleSix = new InlineURL("Стилі для тексту", "https://abitap.com/6-6-styli-tekstu/");
            var exampleSeven = new InlineURL("Стилі для списків", "https://abitap.com/6-7-styli-dlya-spyskiv/");
            var exampleEight = new InlineURL("Стилізація таблиць", "https://abitap.com/6-8-stylizacziya-tablycz/");
            var exampleNine = new InlineURL("Блокова модель", "https://abitap.com/6-9-blokova-model/");
            var exampleTen = new InlineURL("Зовнішні відступи (margin)", "https://abitap.com/6-10-zovnishni-vidstupy-margin/");
            var exampleEleven = new InlineURL("Внутрішні відступи (padding)", "https://abitap.com/6-11-vnutrishni-vidstupy/");
            var exampleTwelve = new InlineURL("Границі", "https://abitap.com/6-12-granyczi/");
            var exampleThirteen = new InlineURL("Розміри елементів", "https://abitap.com/6-13-rozmiry-elementiv/");
            var exampleFourteen = new InlineURL("Фон елементів", "https://abitap.com/6-14-fon-elementiv/");
            var exampleFifteen = new InlineURL("Створення тіні у елемента", "https://abitap.com/6-15-stvorennya-tini-u-elementa/");
            var exampleSixteen = new InlineURL("Контури елементів", "https://abitap.com/6-16-kontury-elementiv/");
            var exampleSeventeen = new InlineURL("Обтікання елементів", "https://abitap.com/6-17-obtikannya-elementiv/");
            var exampleEighteen = new InlineURL("Прокрутка елементів", "https://abitap.com/6-18-prokrutka-elementiv/");
            var exampleNineteen = new InlineURL("Лінійний градієнт", "https://abitap.com/6-19-linijnyj-gradiyent/");
            var exampleTwenty = new InlineURL("Радіальний градієнт", "https://abitap.com/6-20-radialnyj-gradiyent/");
            var exampleTwentyOne = new InlineURL("Стилізація елемента details", "https://abitap.com/6-21-stylizacziya-elementa-details/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(exampleNineteen);
            menu.Add(exampleTwenty);
            menu.Add(exampleTwentyOne);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSeven4)]
        public static async Task InlineExampleSeven4(ITelegramBotClient botClient, Update update)
        {
            var message = "Верстка";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Блокова верстка", "https://abitap.com/blokova-verstka/");
            var exampleTwo = new InlineURL("Вкладені плаваючі блоки", "https://abitap.com/7-2-vkladeni-plavayuchi-bloky/");
            var exampleThree = new InlineURL("Вирівнювання стовпців по висоті", "https://abitap.com/7-3-vyrivnyuvannya-stovpcziv-po-vysoti/");
            var exampleFour = new InlineURL("Властивість display", "https://abitap.com/7-4-vlastyvist-display/");
            var exampleFive = new InlineURL("Створення панелі навігації", "https://abitap.com/7-5-stvorennya-paneli-navigacziyi/");
            var exampleSix = new InlineURL("Вирівнювання плаваючих елементів", "https://abitap.com/7-6-vyrivnyuvannya-plavayuchyh-elementiv/");
            var exampleSeven = new InlineURL("Створення найпростішого макета", "https://abitap.com/7-7-stvorennya-najprostishogo-maketa/");
            var exampleEight = new InlineURL("Позиціювання елементів", "https://abitap.com/7-8-pozycziyuvannya-elementiv/");
            var exampleNine = new InlineURL("Властивість z-index", "https://abitap.com/7-9-vlastyvist-z-index/");
            var exampleTen = new InlineURL("Фіксоване позиціювання", "https://abitap.com/7-10-fiksovane-pozycziyuvannya/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleEight4)]
        public static async Task InlineExampleEight4(ITelegramBotClient botClient, Update update)
        {
            var message = "Адаптивний дизайн";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Введення в адаптивний дизайн", "https://abitap.com/8-1-vvedennya-v-adaptyvnyj-dyzajn/");
            var exampleTwo = new InlineURL("Метатег viewport", "https://abitap.com/8-2-metateg-viewport%ef%bf%bc/");
            var exampleThree = new InlineURL("Media Query в CSS", "https://abitap.com/8-3-media-query-v-css/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleNine4)]
        public static async Task InlineExampleNine4(ITelegramBotClient botClient, Update update)
        {
            var message = "Анімація";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Трансформації", "https://abitap.com/9-1-transformacziyi/");
            var exampleTwo = new InlineURL("Переходи", "https://abitap.com/9-2-perehody/");
            var exampleThree = new InlineURL("Анімація", "https://abitap.com/9-3-animacziya/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTen4)]
        public static async Task InlineExampleTen4(ITelegramBotClient botClient, Update update)
        {
            var message = "Мультимедіа";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Відео", "https://abitap.com/10-1-video/");
            var exampleTwo = new InlineURL("Аудіо", "https://abitap.com/10-2-audio/");
            var exampleThree = new InlineURL("Media API. Управління відео з JavaScript", "https://abitap.com/10-3-media-api-upravlinnya-video-z-javascript/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleEleven4)]
        public static async Task InlineExampleEleven4(ITelegramBotClient botClient, Update update)
        {
            var message = "Flexbox";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Що таке Flexbox. Flex Container", "https://abitap.com/11-1-shho-take-flexbox-flex-container/");
            var exampleTwo = new InlineURL("Напрямок flex-direction", "https://abitap.com/11-2-napryamok-flex-direction/");
            var exampleThree = new InlineURL("flex-wrap", "https://abitap.com/11-3-flex-wrap/");
            var exampleFour = new InlineURL("flex-flow. Порядок елементів", "https://abitap.com/11-4-flex-flow-poryadok-elementiv/");
            var exampleFive = new InlineURL("Вирівнювання елементів. justify-content", "https://abitap.com/11-5-vyrivnyuvannya-elementiv-justify-content/");
            var exampleSix = new InlineURL("Вирівнювання елементів. align-items та align-self", "https://abitap.com/11-6-vyrivnyuvannya-elementiv-align-items-ta-align-self/");
            var exampleSeven = new InlineURL("Вирівнювання рядків та стовпців. align-content", "https://abitap.com/11-7-vyrivnyuvannya-ryadkiv-ta-stovpcziv-align-content/");
            var exampleEight = new InlineURL("Управління елементами. flex-basis, flex-shrink та flex-grow", "https://abitap.com/11-8-upravlinnya-elementamy-flex-basis-flex-shrink-ta-flex-grow/");
            var exampleNine = new InlineURL("Багатоколоночний дизайн на Flexbox", "https://abitap.com/11-9-bagatokolonochnyj-dyzajn-na-flexbox/");
            var exampleTen = new InlineURL("Макет сторінки на Flexbox", "https://abitap.com/11-10-maket-storinky-na-flexbox/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwelve4)]
        public static async Task InlineExamplTwelve4(ITelegramBotClient botClient, Update update)
        {
            var message = "Grid Layout";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Що таке Grid Layout. Grid Container", "https://abitap.com/12-1-shho-take-grid-layout-grid-container/");
            var exampleTwo = new InlineURL("Рядки та стовпці", "https://abitap.com/12-2-ryadky-ta-stovpczi/");
            var exampleThree = new InlineURL("Функція repeat та властивість grid", "https://abitap.com/12-3-funkcziya-repeat-ta-vlastyvist-grid/");
            var exampleFour = new InlineURL("Розміри рядків та стовпців", "https://abitap.com/12-4-rozmiry-ryadkiv-ta-stovpcziv/");
            var exampleFive = new InlineURL("Відступи між стовпцями та рядками", "https://abitap.com/12-5-vidstupy-mizh-stovpczyamy-ta-ryadkamy/");
            var exampleSix = new InlineURL("Позиціювання елементів", "https://abitap.com/12-6-pozycziyuvannya-elementiv/");
            var exampleSeven = new InlineURL("Накладення елементів", "https://abitap.com/12-7-nakladennya-elementiv/");
            var exampleEight = new InlineURL("Напрямок та порядок елементів", "https://abitap.com/12-8-napryamok-ta-poryadok-elementiv/");
            var exampleNine = new InlineURL("Іменовані grid-лінії", "https://abitap.com/12-9-imenovani-grid-liniyi/");
            var exampleTen = new InlineURL("Іменовані grid-лінії та функція repeat", "https://abitap.com/12-10-imenovani-grid-liniyi-ta-funkcziya-repeat/");
            var exampleEleven = new InlineURL("Області гріда", "https://abitap.com/12-13-oblasti-grida/");
            var exampleTwelve = new InlineURL("Макет сторінки в Grid Layout", "https://abitap.com/12-12-maket-storinky-v-grid-layout/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThirteen4)]
        public static async Task InlineExampleThirteen4(ITelegramBotClient botClient, Update update)
        {
            var message = "Змінні CSS3";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Стилізація за допомогою змінних", "https://abitap.com/13-1-stylizacziya-za-dopomogoyu-zminnyh/");
            var exampleTwo = new InlineURL("Створення тем CSS за допомогою змінних", "https://abitap.com/13-2-stvorennya-tem-css-za-dopomogoyu-zminnyh/");
            var exampleThree = new InlineURL("Стилі CSS як сховище даних", "https://abitap.com/13-3-styli-css-yak-shovyshhe-danyh/");
            var back4 = new InlineCallback("<- Назад", CustomTHeader.Back4);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back4);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back4)]
        public static async Task InlineBack4(ITelegramBotClient botClient, Update update)
        {
            var message = "HTML 5 та CSS 3";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("HTML 5 та CSS 3", "https://abitap.com/category/html-5-ta-css-3/");
            var exampleOne4 = new InlineCallback("Про HTML5", CustomTHeader.ExampleOne4);
            var exampleTwo4 = new InlineCallback("Елементи HTML5", CustomTHeader.ExampleTwo4);
            var exampleThree4 = new InlineCallback("Форми на HTML5", CustomTHeader.ExampleThree4);
            var exampleFour4 = new InlineCallback("Елементи структури сторінки", CustomTHeader.ExampleFour4);
            var exampleFive4 = new InlineCallback("Селектори CSS3", CustomTHeader.ExampleFive4);
            var exampleSix4 = new InlineCallback("Властивості CSS3", CustomTHeader.ExampleSix4);
            var exampleSeven4 = new InlineCallback("Верстка", CustomTHeader.ExampleSeven4);
            var exampleEight4 = new InlineCallback("Адаптивний дизайн", CustomTHeader.ExampleEight4);
            var exampleNine4 = new InlineCallback("Анімація", CustomTHeader.ExampleNine4);
            var exampleTen4 = new InlineCallback("Мультимедія", CustomTHeader.ExampleTen4);
            var exampleEleven4 = new InlineCallback("Flexbox", CustomTHeader.ExampleEleven4);
            var exampleTwelve4 = new InlineCallback("Grid Layout", CustomTHeader.ExampleTwelve4);
            var exampleThirteen4 = new InlineCallback("Змінні CSS3", CustomTHeader.ExampleThirteen4);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne4);
            menu.Add(exampleTwo4);
            menu.Add(exampleThree4);
            menu.Add(exampleFour4);
            menu.Add(exampleFive4);
            menu.Add(exampleSix4);
            menu.Add(exampleSeven4);
            menu.Add(exampleEight4);
            menu.Add(exampleNine4);
            menu.Add(exampleTen4);
            menu.Add(exampleEleven4);
            menu.Add(exampleTwelve4);
            menu.Add(exampleThirteen4);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne5)]
        public static async Task InlineExampleOne5(ITelegramBotClient botClient, Update update)
        {
            var message = "Вступ";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Вступ", "https://abitap.com/java/");
            var exampleTwo = new InlineURL("Перша програма на Java у Windows", "https://abitap.com/1-2-persha-programa-na-java-u-windows/");
            var exampleThree = new InlineURL("Перша програма в IntelliJ IDEA", "https://abitap.com/persha-programa-v-intellij-idea/");
            var back5 = new InlineCallback("<- Назад", CustomTHeader.Back5);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back5);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo5)]
        public static async Task InlineExampleTwo5(ITelegramBotClient botClient, Update update)
        {
            var message = "Основи мови Java";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Структура програми", "https://abitap.com/2-1-struktura-programy-2/");
            var exampleTwo = new InlineURL("Змінні та константи", "https://abitap.com/2-2-zminni-ta-konstanty/");
            var exampleThree = new InlineURL("Типи даних", "https://abitap.com/2-3-typy-danyh/");
            var exampleFour = new InlineURL("Консольне введення/виведення в Java", "https://abitap.com/2-4-konsolne-vvedennya-vyvedennya-v-java/");
            var exampleFive = new InlineURL("Арифметичні операції", "https://abitap.com/2-5-aryfmetychni-operacziyi/");
            var exampleSix = new InlineURL("Порозрядні операції", "https://abitap.com/2-6-porozryadni-operacziyi/");
            var exampleSeven = new InlineURL("Умовні вирази", "https://abitap.com/2-7-umovni-vyrazy/");
            var exampleEight = new InlineURL("Операції присвоєння та пріоритет операцій", "https://abitap.com/2-8-operacziyi-prysvoyennya-ta-priorytet-operaczij/");
            var exampleNine = new InlineURL("Перетворення базових типів даних", "https://abitap.com/2-9-peretvorennya-bazovyh-typiv-danyh/");
            var exampleTen = new InlineURL("Умовні конструкції", "https://abitap.com/2-10-umovni-konstrukcziyi/");
            var exampleEleven = new InlineURL("Цикли", "https://abitap.com/2-11-czykly/");
            var exampleTwelve = new InlineURL("Масиви", "https://abitap.com/2-12-masyvy/");
            var exampleThirteen = new InlineURL("Методи", "https://abitap.com/2-13-metody/");
            var exampleFourteen = new InlineURL("Параметри методів", "https://abitap.com/2-14-parametry-metodiv/");
            var exampleFifteen = new InlineURL("Оператор return та результат методу", "https://abitap.com/2-15-operator-return-ta-rezultat-metodu/");
            var exampleSixteen = new InlineURL("Перевантаження методів", "https://abitap.com/2-16-perevantazhennya-metodiv/");
            var exampleSeventeen = new InlineURL("Рекурсивні функції", "https://abitap.com/2-17-rekursyvni-funkcziyi/");
            var exampleEighteen = new InlineURL("Введення в обробку винятків", "https://abitap.com/2-18-vvedennya-v-obrobku-vynyatkiv/");
            var back5 = new InlineCallback("<- Назад", CustomTHeader.Back5);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(back5);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThree5)]
        public static async Task InlineExampleThree5(ITelegramBotClient botClient, Update update)
        {
            var message = "ООП на Java";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Класи та об’єкти", "https://abitap.com/3-1-klasy-ta-obyekty/");
            var exampleTwo = new InlineURL("Пакети", "https://abitap.com/3-2-pakety/");
            var exampleThree = new InlineURL("Модифікатори доступу та інкапсуляція", "https://abitap.com/3-3-modyfikatory-dostupu-ta-inkapsulyacziya/");
            var exampleFour = new InlineURL("Статичні члени та модифікатор static", "https://abitap.com/3-4-statychni-chleny-ta-modyfikator-static/");
            var exampleFive = new InlineURL("Об’єкти як параметри методів", "https://abitap.com/3-5-obyekty-yak-parametry-metodiv/");
            var exampleSix = new InlineURL("Внутрішні та вкладені класи", "https://abitap.com/3-6-vnutrishni-ta-vkladeni-klasy/");
            var exampleSeven = new InlineURL("Успадкування", "https://abitap.com/3-7-uspadkuvannya/");
            var exampleEight = new InlineURL("Абстрактні класи", "https://abitap.com/3-8-abstraktni-klasy/");
            var exampleNine = new InlineURL("Ієрархія успадкування та перетворення типів", "https://abitap.com/3-9-iyerarhiya-uspadkuvannya-ta-peretvorennya-typiv/");
            var exampleTen = new InlineURL("Інтерфейси", "https://abitap.com/3-10-interfejsy/");
            var exampleEleven = new InlineURL("Інтерфейси в механізмі зворотного виклику", "https://abitap.com/3-11-interfejsy-v-mehanizmi-zvorotnogo-vyklyku/");
            var exampleTwelve = new InlineURL("Перерахування enum", "https://abitap.com/3-12-pererahuvannya-enum/");
            var exampleThirteen = new InlineURL("Клас Object та його методи", "https://abitap.com/3-13-klas-object-ta-jogo-metody/");
            var exampleFourteen = new InlineURL("Узагальнення (Generics)", "https://abitap.com/3-14-uzagalnennya-generics/");
            var exampleFifteen = new InlineURL("Обмеження узагальнень", "https://abitap.com/3-15-obmezhennya-uzagalnen/");
            var exampleSixteen = new InlineURL("Успадкування та узагальнення", "https://abitap.com/3-16-uspadkuvannya-ta-uzagalnennya/");
            var exampleSeventeen = new InlineURL("Типи посилань та копіювання об’єктів", "https://abitap.com/3-17-typy-posylan-ta-kopiyuvannya-obyektiv/");
            var exampleEighteen = new InlineURL("Records", "https://abitap.com/3-18-records/");
            var back5 = new InlineCallback("<- Назад", CustomTHeader.Back5);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(back5);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFour5)]
        public static async Task InlineExampleFour5(ITelegramBotClient botClient, Update update)
        {
            var message = "Обробка винятків";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Обробка виняткових ситуацій", "https://abitap.com/4-1-obrobka-vynyatkovyh-sytuaczij/");
            var exampleTwo = new InlineURL("Класи винятків", "https://abitap.com/4-2-klasy-vynyatkiv/");
            var exampleThree = new InlineURL("Створення своїх класів винятків", "https://abitap.com/4-3-stvorennya-svoyih-klasiv-vynyatkiv/");
            var back5 = new InlineCallback("<- Назад", CustomTHeader.Back5);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back5);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFive5)]
        public static async Task InlineExampleFive5(ITelegramBotClient botClient, Update update)
        {
            var message = "Колекції";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Типи колекцій. Інтерфейс Collection", "https://abitap.com/5-1-typy-kolekczij-interfejs-collection/");
            var exampleTwo = new InlineURL("Клас ArrayList та інтерфейс List", "https://abitap.com/klas-arraylist-ta-interfejs-list/");
            var exampleThree = new InlineURL("Черги та клас ArrayDeque", "https://abitap.com/5-3-chergy-ta-klas-arraydeque/");
            var exampleFour = new InlineURL("Стек", "https://abitap.com/5-4-stek/");
            var exampleFive = new InlineURL("Клас LinkedList", "https://abitap.com/5-5-klas-linkedlist/");
            var exampleSix = new InlineURL("Інтерфейс Set та клас HashSet", "https://abitap.com/5-6-interfejs-set-ta-klas-hashset/");
            var exampleSeven = new InlineURL("SortedSet, NavigableSet, TreeSet", "https://abitap.com/5-7-sortedset-navigableset-treeset/");
            var exampleEight = new InlineURL("Інтерфейси Comparable та Comparator. Сортування", "https://abitap.com/5-8-interfejsy-comparable-ta-comparator-sortuvannya/");
            var exampleNine = new InlineURL("Інтерфейс Map та клас HashMap", "https://abitap.com/5-9-interfejs-map-ta-klas-hashmap/");
            var exampleTen = new InlineURL("Інтерфейси SortedMap та NavigableMap. Клас TreeMap", "https://abitap.com/5-10-interfejsy-sortedmap-ta-navigablemap-klas-treemap/");
            var exampleEleven = new InlineURL("Ітератори", "https://abitap.com/5-11-iteratory/");
            var back5 = new InlineCallback("<- Назад", CustomTHeader.Back5);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(back5);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSix5)]
        public static async Task InlineExampleSix5(ITelegramBotClient botClient, Update update)
        {
            var message = "Робота з файлами";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Потоки введення-виведення", "https://abitap.com/6-1-potoky-vvedennya-vyvedennya/");
            var exampleTwo = new InlineURL("Читання та запис файлів. FileInputStream та FileOutputStream", "https://abitap.com/6-2-chytannya-ta-zapys-fajliv-fileinputstream-ta-fileoutputstream/");
            var exampleThree = new InlineURL("Закриття потоків", "https://abitap.com/6-3-zakryttya-potokiv/");
            var exampleFour = new InlineURL("Класи ByteArrayInputStream та ByteArrayOutputStream", "https://abitap.com/6-4-klasy-bytearrayinputstream-ta-bytearrayoutputstream/");
            var exampleFive = new InlineURL("Буферизовані потоки BufferedInputStream та BufferedOutputStream", "https://abitap.com/6-5-buferyzovani-potoky-bufferedinputstream-ta-bufferedoutputstream/");
            var exampleSix = new InlineURL("Форматоване введення та виведення. PrintStream та PrintWriter", "https://abitap.com/6-6-formatovane-vvedennya-ta-vyvedennya-printstream-ta-printwriter/");
            var exampleSeven = new InlineURL("Класи DataOutputStream та DataInputStream", "https://abitap.com/6-7-klasy-dataoutputstream-ta-datainputstream/");
            var exampleEight = new InlineURL("Читання та запис текстових файлів", "https://abitap.com/6-8-chytannya-ta-zapys-tekstovyh-fajliv/");
            var exampleNine = new InlineURL("Буферизація символьних потоків. BufferedReader і BufferedWriter", "https://abitap.com/6-9-buferyzacziya-symvolnyh-potokiv-bufferedreader-i-bufferedwriter/");
            var exampleTen = new InlineURL("Серіалізація", "https://abitap.com/6-10-serializacziya/");
            var exampleEleven = new InlineURL("Клас File. Робота з файлами та каталогами", "https://abitap.com/6-11-klas-file-robota-z-fajlamy-ta-katalogamy/");
            var exampleTwelve = new InlineURL("Робота с ZIP-архівами", "https://abitap.com/6-12-robota-s-zip-arhivamy/");
            var exampleThirteen = new InlineURL("Клас Console", "https://abitap.com/6-13-klas-console/");
            var back5 = new InlineCallback("<- Назад", CustomTHeader.Back5);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(back5);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }
        
        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSeven5, CustomTHeader.ExampleEight5, CustomTHeader.ExampleNine5, CustomTHeader.ExampleTen5, CustomTHeader.ExampleEleven5, CustomTHeader.ExampleTwelve5, CustomTHeader.ExampleThirteen5, CustomTHeader.ExampleFourteen5)]
        public static async Task InlineExampleSevenFourteen5(ITelegramBotClient botClient, Update update)
        {
            var message = "Нажаль на сайті немає інформації щодо цього параграфу\nВи можете звернутися до викладача за допомогою команди /help\nАбо повернутися назад";

            List<IInlineContent> menu = new List<IInlineContent>();

            var back5 = new InlineCallback("<- Назад", CustomTHeader.Back5);

            menu.Add(back5);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back5)]
        public static async Task InlineBack5(ITelegramBotClient botClient, Update update)
        {
            var message = "Java";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Java", "https://abitap.com/category/java/");
            var exampleOne5 = new InlineCallback("Вступ", CustomTHeader.ExampleOne5);
            var exampleTwo5 = new InlineCallback("Основи мови Java", CustomTHeader.ExampleTwo5);
            var exampleThree5 = new InlineCallback("ООП на Java", CustomTHeader.ExampleThree5);
            var exampleFour5 = new InlineCallback("Обробка винятків", CustomTHeader.ExampleFour5);
            var exampleFive5 = new InlineCallback("Колекції", CustomTHeader.ExampleFive5);
            var exampleSix5 = new InlineCallback("Робота з файлами", CustomTHeader.ExampleSix5);
            var exampleSeven5 = new InlineCallback("Робота з рядками", CustomTHeader.ExampleSeven5);
            var exampleEight5 = new InlineCallback("Лямбди-вирази", CustomTHeader.ExampleEight5);
            var exampleNine5 = new InlineCallback("Багатопоточність", CustomTHeader.ExampleNine5);
            var exampleTen5 = new InlineCallback("Stream API", CustomTHeader.ExampleTen5);
            var exampleEleven5 = new InlineCallback("Сокети", CustomTHeader.ExampleEleven5);
            var exampleTwelve5 = new InlineCallback("Робота з БД", CustomTHeader.ExampleTwelve5);
            var exampleThirteen5 = new InlineCallback("Модульність", CustomTHeader.ExampleThirteen5);
            var exampleFourteen5 = new InlineCallback("Додаткові класи", CustomTHeader.ExampleFourteen5);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne5);
            menu.Add(exampleTwo5);
            menu.Add(exampleThree5);
            menu.Add(exampleFour5);
            menu.Add(exampleFive5);
            menu.Add(exampleSix5);
            menu.Add(exampleSeven5);
            menu.Add(exampleEight5);
            menu.Add(exampleNine5);
            menu.Add(exampleTen5);
            menu.Add(exampleEleven5);
            menu.Add(exampleTwelve5);
            menu.Add(exampleThirteen5);
            menu.Add(exampleFourteen5);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne6)]
        public static async Task InlineExampleOne6(ITelegramBotClient botClient, Update update)
        {
            var message = "Вступ та перша програма";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Що таке python?", "https://abitap.com/1-1-shho-take-python/");
            var exampleTwo = new InlineURL("Встановлення інтерпретатора python", "https://abitap.com/1-2-vstanovlennya-interpretatora-python/");
            var exampleThree = new InlineURL("Середовище розробки PyCharm (-)", "https://abitap.com/1-3-seredovyshhe-rozrobky-pycharm/");
            var exampleFour = new InlineURL("Перша програма “Hello, World!” (-)", "https://abitap.com/1-4-persha-programa-hello-world/");
            var back6 = new InlineCallback("<- Назад", CustomTHeader.Back6);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(back6);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo6, CustomTHeader.ExampleThree6, CustomTHeader.ExampleFour6, CustomTHeader.ExampleFive6, CustomTHeader.ExampleSix6, CustomTHeader.ExampleSeven6, CustomTHeader.ExampleEight6, CustomTHeader.ExampleNine6, CustomTHeader.ExampleTen6, CustomTHeader.ExampleEleven6, CustomTHeader.ExampleTwelve6)]
        public static async Task InlineExampleTwoTwelve6(ITelegramBotClient botClient, Update update)
        {
            var message = "Нажаль на сайті немає інформації щодо цього параграфу\nВи можете звернутися до викладача за допомогою команди /help\nАбо повернутися назад";

            List<IInlineContent> menu = new List<IInlineContent>();

            var back6 = new InlineCallback("<- Назад", CustomTHeader.Back6);

            menu.Add(back6);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back6)]
        public static async Task InlineBack6(ITelegramBotClient botClient, Update update)
        {
            var message = "Python";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Python", "https://abitap.com/category/python/");
            var exampleOne6 = new InlineCallback("Вступ та перша програма", CustomTHeader.ExampleOne6);
            var exampleTwo6 = new InlineCallback("Синтаксис та типи даних", CustomTHeader.ExampleTwo6);
            var exampleThree6 = new InlineCallback("Оператор", CustomTHeader.ExampleThree6);
            var exampleFour6 = new InlineCallback("Керуючі конструкції (цикли, оператори)", CustomTHeader.ExampleFour6);
            var exampleFive6 = new InlineCallback("Списки", CustomTHeader.ExampleFive6);
            var exampleSix6 = new InlineCallback("Словники", CustomTHeader.ExampleSix6);
            var exampleSeven6 = new InlineCallback("Набори", CustomTHeader.ExampleSeven6);
            var exampleEight6 = new InlineCallback("Обробка винятків", CustomTHeader.ExampleEight6);
            var exampleNine6 = new InlineCallback("Модуль та пакети", CustomTHeader.ExampleNine6);
            var exampleTen6 = new InlineCallback("Робота з файлами директоріями", CustomTHeader.ExampleTen6);
            var exampleEleven6 = new InlineCallback("Рядки", CustomTHeader.ExampleEleven6);
            var exampleTwelve6 = new InlineCallback("Класи та об'єкти (ООП)", CustomTHeader.ExampleTwelve6);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne6);
            menu.Add(exampleTwo6);
            menu.Add(exampleThree6);
            menu.Add(exampleFour6);
            menu.Add(exampleFive6);
            menu.Add(exampleSix6);
            menu.Add(exampleSeven6);
            menu.Add(exampleEight6);
            menu.Add(exampleNine6);
            menu.Add(exampleTen6);
            menu.Add(exampleEleven6);
            menu.Add(exampleTwelve6);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne7)]
        public static async Task InlineExampleOne7(ITelegramBotClient botClient, Update update)
        {
            var message = "Вступ";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Перший проект", "https://abitap.com/1-1-pershyj-proekt/");
            var exampleTwo = new InlineURL("Перший елемент управління. Перша подія", "https://abitap.com/1-2-pershyj-element-upravlinnya-persha-podiya/");
            var back7 = new InlineCallback("<- Назад", CustomTHeader.Back7);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(back7);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo7)]
        public static async Task InlineExampleTwo7(ITelegramBotClient botClient, Update update)
        {
            var message = "Робота з формами";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Основи властивості форм", "https://abitap.com/2-1-osnovy-vlastyvosti-form/");
            var exampleTwo = new InlineURL("Взаємодія між формами", "https://abitap.com/2-2-vzayemodiya-mizh-formamy/");
            var exampleThree = new InlineURL("Події форми", "https://abitap.com/2-3-podiyi-formy/");
            var exampleFour = new InlineURL("Непрямокутні форми", "https://abitap.com/2-4-nepryamokutni-formy/");
            var back7 = new InlineCallback("<- Назад", CustomTHeader.Back7);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(back7);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThree7)]
        public static async Task InlineExampleThree7(ITelegramBotClient botClient, Update update)
        {
            var message = "Контейнери";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Динамічне додавання елементів", "https://abitap.com/3-1-dynamichne-dodavannya-elementiv/");
            var exampleTwo = new InlineURL("GroupBox, Panel та FlowLayoutPanel", "https://abitap.com/3-2-groupbox-panel-ta-flowlayoutpanel/");
            var exampleThree = new InlineURL("Елемент TableLayoutPanel", "https://abitap.com/3-3-element-tablelayoutpanel/");
            var exampleFour = new InlineURL("Розміри елементів та їх позиціонування", "https://abitap.com/3-4-rozmiry-elementiv-ta-yih-pozyczionuvannya/");
            var exampleFive = new InlineURL("TabControl та SplitContainer", "https://abitap.com/3-5-tabcontrol-ta-splitcontainer/");
            var back7 = new InlineCallback("<- Назад", CustomTHeader.Back7);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(back7);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFour7)]
        public static async Task InlineExampleFour7(ITelegramBotClient botClient, Update update)
        {
            var message = "Елементи управління";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Кнопка", "https://abitap.com/4-1-knopka/");
            var exampleTwo = new InlineURL("Текстове поле TextBox", "https://abitap.com/4-2-tekstove-pole-textbox/");
            var exampleThree = new InlineURL("Елемент MaskedTextBox", "https://abitap.com/4-3-element-maskedtextbox/");
            var exampleFour = new InlineURL("RadioButton та CheckBox", "https://abitap.com/4-4-radiobutton-ta-checkbox/");
            var exampleFive = new InlineURL("Елемент ListBox", "https://abitap.com/4-5-element-listbox/");
            var exampleSix = new InlineURL("Елемент ComboBox", "https://abitap.com/4-6-element-combobox/");
            var exampleSeven = new InlineURL("Прив`язка даних в ListBox та ComboBox", "https://abitap.com/4-7-pryvyazka-danyh-v-listbox-ta-combobox/");
            var exampleEight = new InlineURL("Елемент CheckedListBox", "https://abitap.com/4-8-element-checkedlistbox/");
            var exampleNine = new InlineURL("Елемент ImageList", "https://abitap.com/4-9-element-imagelist/");
            var exampleTen = new InlineURL("Елемент ListView", "https://abitap.com/4-10-element-listview/");
            var exampleEleven = new InlineURL("Елемент TreeView", "https://abitap.com/4-11-element-treeview/");
            var exampleTwelve = new InlineURL("NumericUpDown та DomainUpDown", "https://abitap.com/4-12-numericupdown-ta-domainupdown/");
            var exampleThirteen = new InlineURL("TrackBar, Timer та ProgressBar", "https://abitap.com/4-13-trackbar-timer-ta-progressbar/");
            var exampleFourteen = new InlineURL("DateTimePicker та MonthCalendar", "https://abitap.com/4-14-datetimepicker-ta-monthcalendar/");
            var exampleFifteen = new InlineURL("Елемент PictureBox", "https://abitap.com/4-15-element-picturebox/");
            var exampleSixteen = new InlineURL("Елемент MessageBox", "https://abitap.com/4-16-element-messagebox/");
            var exampleSeventeen = new InlineURL("OpenFileDialog та SaveFileDialog", "https://abitap.com/4-17-openfiledialog-ta-savefiledialog/");
            var exampleEighteen = new InlineURL("FontDialog та ColorDialog", "https://abitap.com/4-18-fontdialog-ta-colordialog/");
            var back7 = new InlineCallback("<- Назад", CustomTHeader.Back7);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(back7);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFive7)]
        public static async Task InlineExampleFive7(ITelegramBotClient botClient, Update update)
        {
            var message = "Меню і панель інструментів";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Панель інструментів ToolStrip", "https://abitap.com/5-1-panel-instrumentiv-toolstrip/");
            var exampleTwo = new InlineURL("Елемент MenuStrip", "https://abitap.com/5-2-element-menustrip/");
            var exampleThree = new InlineURL("Елемент StatusStrip", "https://abitap.com/5-3-element-statusstrip/");
            var exampleFour = new InlineURL("Контекстне меню ContextMenuStrip", "https://abitap.com/5-4-kontekstne-menyu-contextmenustrip/");
            var back7 = new InlineCallback("<- Назад", CustomTHeader.Back7);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(back7);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back7)]
        public static async Task InlineBack7(ITelegramBotClient botClient, Update update)
        {
            var message = "Windows Forms";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Windows Forms", "https://abitap.com/category/35-grafichni-windows-zastosunky/");
            var exampleOne7 = new InlineCallback("Вступ", CustomTHeader.ExampleOne7);
            var exampleTwo7 = new InlineCallback("Провайдери БД", CustomTHeader.ExampleTwo7);
            var exampleThree7 = new InlineCallback("Створення Моделей", CustomTHeader.ExampleThree7);
            var exampleFour7 = new InlineCallback("Відношення між моделями", CustomTHeader.ExampleFour7);
            var exampleFive7 = new InlineCallback("Успадкування", CustomTHeader.ExampleFive7);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne7);
            menu.Add(exampleTwo7);
            menu.Add(exampleThree7);
            menu.Add(exampleFour7);
            menu.Add(exampleFive7);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne9)]
        public static async Task InlineExampleOne9(ITelegramBotClient botClient, Update update)
        {
            var message = "Вступ (перша програма)";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Що таке .NET?", "https://abitap.com/1-1/");
            var exampleTwo = new InlineURL(".NET Framework і .NET 7", "https://abitap.com/1-2/");
            var exampleThree = new InlineURL("Мова С#", "https://abitap.com/1-3-mova-s/");
            var exampleFour = new InlineURL("Керований та некерований код. JIT-компіляція", "https://abitap.com/1-4-kerovanyj-ta-nekerovanyj-kod-jit-kompilyacziya/");
            var exampleFive = new InlineURL("Початок роботи у Visual Studio", "https://abitap.com/1-5-pochatok-roboty-u-visual-studio/");
            var exampleSix = new InlineURL("Перша програма у Visual Studio", "https://abitap.com/persha-programa-u-visual-studio/");
            var exampleSeven = new InlineURL("Українська літера “і” при виведенні на консоль", "https://abitap.com/1-7-ukrayinska-litera-i-pry-vyvedenni-na-konsol/");
            var exampleEight = new InlineURL("Компіляція у командному рядку з .NET CLI", "https://abitap.com/1-8-kompilyacziya-u-komandnomu-ryadku-z-net-cli/");
            var exampleNine = new InlineURL("Перша програма на MacOS", "https://abitap.com/1-9-persha-programa-na-macos/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo9)]
        public static async Task InlineExampleTwo9(ITelegramBotClient botClient, Update update)
        {
            var message = "Змінні, типи даних та операції";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Структура програми. Інструкції програми", "https://abitap.com/2-1-struktura-programy/");
            var exampleTwo = new InlineURL("Структура програми. Регістрозалежність. Коментарі", "https://abitap.com/2-2-struktura-programy-registrozalezhnist-komentari/");
            var exampleThree = new InlineURL("csproj-файл проекту", "https://abitap.com/2-3/");
            var exampleFour = new InlineURL("Змінні", "https://abitap.com/zminni/");
            var exampleFive = new InlineURL("Константи", "https://abitap.com/2-5-konstanty/");
            var exampleSix = new InlineURL("Логічні, цілочисельні та дійсні літерали", "https://abitap.com/2-6-logichni-czilochyselni-ta-dijsni-literaly/");
            var exampleSeven = new InlineURL("Символьні та рядкові літерали", "https://abitap.com/2-7-symvolni-ta-ryadkovi-literaly/");
            var exampleEight = new InlineURL("Типи даних", "https://abitap.com/2-8-typy-danyh/");
            var exampleNine = new InlineURL("Особливості використання типів даних", "https://abitap.com/osoblyvosti-vykorystannya-typiv-danyh/");
            var exampleTen = new InlineURL("Консольне виведення", "https://abitap.com/konsolne-vyvedennya/");
            var exampleEleven = new InlineURL("Консольне введення", "https://abitap.com/2-11-konsolne-vvedennya/");
            var exampleTwelve = new InlineURL("Арифметичні операції", "https://abitap.com/2-12-aryfmetychni-operacziyi/");
            var exampleThirteen = new InlineURL("Асоціативність арифметичних операторів", "https://abitap.com/2-13-asocziatyvnist-aryfmetychnyh-operatoriv/");
            var exampleFourteen = new InlineURL("Порозрядні логічні операції", "https://abitap.com/2-14-porozryadni-logichni-operacziyi/");
            var exampleFifteen = new InlineURL("Представлення від’ємних чисел", "https://abitap.com/podannya-vidyemnyh-chysel/");
            var exampleSixteen = new InlineURL("Операції зсуву", "https://abitap.com/2-16-operacziyi-zsuvu/");
            var exampleSeventeen = new InlineURL("Операції присвоєння", "https://abitap.com/2-17-operacziyi-prysvoyennya/");
            var exampleEighteen = new InlineURL("Перетворення базових типів даних", "https://abitap.com/2-18-peretvorennya-bazovyh-typiv-danyh/");
            var exampleNineteen = new InlineURL("Звужуючі та розширюючі перетворення", "https://abitap.com/2-19-zvuzhuyuchi-ta-rozshyryuyuchi-peretvorennya/");
            var exampleTwenty = new InlineURL("Неявні перетворення даних", "https://abitap.com/neyavni-peretvorennya-danyh/");
            var exampleTwentyOne= new InlineURL("Неявні перетворення даних", "https://abitap.com/2-21-yavni-peretvorennya-danyh/");
            var exampleTwentyTwo = new InlineURL("Втрата даних. Сhecked", "https://abitap.com/2-22-vtrata-danyh-shecked/");
            var exampleTwentyThree = new InlineURL("Операції порівняння", "https://abitap.com/operacziyi-porivnyannya/");
            var exampleTwentyFour = new InlineURL("Логічні оператори", "https://abitap.com/2-24-logichni-operatory/");
            var exampleTwentyFive = new InlineURL("Пріоритет операторів", "https://abitap.com/priorytet-operatoriv/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(exampleNineteen);
            menu.Add(exampleTwenty);
            menu.Add(exampleTwentyOne);
            menu.Add(exampleTwentyTwo);
            menu.Add(exampleTwentyThree);
            menu.Add(exampleTwentyFour);
            menu.Add(exampleTwentyFive);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThree9)]
        public static async Task InlineExampleTHree9(ITelegramBotClient botClient, Update update)
        {
            var message = "Керуючі конструкції (цикли, умови)";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Умовна конструкція if", "https://abitap.com/umovna-konstrukcziya-if/");
            var exampleTwo = new InlineURL("Конструкція розгалуження if … else", "https://abitap.com/konstrukcziya-rozgaluzhennya-if-else/");
            var exampleThree = new InlineURL("Тернарна операція", "https://abitap.com/3-3-ternarna-operacziya/");
            var exampleFour = new InlineURL("Цикл for", "https://abitap.com/3-4/");
            var exampleFive = new InlineURL("Цикл до while", "https://abitap.com/czykl-do-while/");
            var exampleSix = new InlineURL("Цикл while", "https://abitap.com/3-6-czykl-while/");
            var exampleSeven = new InlineURL("Цикл foreach", "https://abitap.com/czykl-foreach/");
            var exampleEight = new InlineURL("Оператори continue та break", "https://abitap.com/3-8-operatory-continue-ta-break/");
            var exampleNine = new InlineURL("Вкладені цикли", "https://abitap.com/3-9-vkladeni-czykly/");
            var exampleTen = new InlineURL("Конструкція switch/case", "https://abitap.com/3-10-konstrukcziya-switch-case/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFour9)]
        public static async Task InlineExampleFour9(ITelegramBotClient botClient, Update update)
        {
            var message = "Масиви. Перерахування";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Масиви", "https://abitap.com/masyvy/");
            var exampleTwo = new InlineURL("Індекси та отримання елементів масиву", "https://abitap.com/indeksy-ta-otrymannya-elementiv-masyvu/");
            var exampleThree = new InlineURL("Довжина масиву Length. Повернення елементів з кінця масиву", "https://abitap.com/vlastyvist-length-ta-dovzhyna-masyvu/");
            var exampleFour = new InlineURL("Перебір масивів", "https://abitap.com/perebir-masyviv/");
            var exampleFive = new InlineURL("Багатовимірні масиви", "https://abitap.com/4-5-bagatovymirni-masyvy/");
            var exampleSix = new InlineURL("Масив масивів – зубчастий масив", "https://abitap.com/4-6-masyv-masyviv-zubchatyj-masyv/");
            var exampleSeven = new InlineURL("Основні поняття масивів", "https://abitap.com/4-7-osnovni-ponyattya-masyviv/");
            var exampleEight = new InlineURL("Перерахування (enum)", "https://abitap.com/4-8-pererahuvannya-enum/");
            var exampleNine = new InlineURL("Перерахування. Тип та значення констант перерахування", "https://abitap.com/pererahuvannya-typ-ta-znachennya-konstant-pererahuvannya/");
            var exampleTen = new InlineURL("Розв’язання деяких типових задач на масиви", "https://abitap.com/rozvyazannya-deyakyh-typovyh-zadach-na-masyvy/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFive9)]
        public static async Task InlineExampleFive9(ITelegramBotClient botClient, Update update)
        {
            var message = "Методи";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Визначення методів", "https://abitap.com/5-1-vyznachennya-metodiv/");
            var exampleTwo = new InlineURL("Методи", "https://abitap.com/5-2-metody/");
            var exampleThree = new InlineURL("Скорочений запис методів", "https://abitap.com/5-3-skorochenyj-zapys-metodiv/");
            var exampleFour = new InlineURL("Параметри методів", "https://abitap.com/5-4-parametry-metodiv/");
            var exampleFive = new InlineURL("Відповідність параметрів та аргументів за типом даних", "https://abitap.com/5-5-vidpovidnist-parametriv-ta-argumentiv-za-typom-danyh/");
            var exampleSix = new InlineURL("Необов’язкові параметри", "https://abitap.com/5-6-neobovyazkovi-parametry/");
            var exampleSeven = new InlineURL("Іменовані параметри", "https://abitap.com/5-7-imenovani-parametry/");
            var exampleEight = new InlineURL("Повернення значення та оператор return", "https://abitap.com/5-8-povernennya-znachennya-ta-operator-return/");
            var exampleNine = new InlineURL("Скорочена версія методів із результатом", "https://abitap.com/skorochena-versiya-metodiv-iz-rezultatom/");
            var exampleTen = new InlineURL("Вихід із методу", "https://abitap.com/5-10-vyhid-iz-metodu/");
            var exampleEleven = new InlineURL("Передача параметрів за значенням", "https://abitap.com/5-11-peredacha-parametriv-za-znachennyam/");
            var exampleTwelve = new InlineURL("Передача параметрів за посиланням та модифікатор ref", "https://abitap.com/5-12-peredacha-parametriv-za-posylannyam-ta-modyfikator-ref/");
            var exampleThirteen = new InlineURL("Вихідні параметри. Модифікатор out", "https://abitap.com/5-13-vyhidni-parametry-modyfikator-out/");
            var exampleFourteen = new InlineURL("Вхідні параметри. Модифікатор in", "https://abitap.com/5-14-vhidni-parametry-modyfikator-in/");
            var exampleFifteen = new InlineURL("Масив параметрів та ключове слово params", "https://abitap.com/5-15-masyv-parametriv-ta-klyuchove-slovo-params/");
            var exampleSixteen = new InlineURL("Масив в якості параметра", "https://abitap.com/5-16-masyv-v-yakosti-parametra/");
            var exampleSeventeen = new InlineURL("Рекурсивна функція факторіалу", "https://abitap.com/rekursyvna-funkcziya-faktorialu/");
            var exampleEighteen = new InlineURL("Рекурсивна функція Фібоначчі", "https://abitap.com/5-18-rekursyvna-funkcziya-fibonachchi/");
            var exampleNineteen = new InlineURL("Рекурсія vs Цикли", "https://abitap.com/5-19-rekursiya-vs-czykly/");
            var exampleTwenty = new InlineURL("Локальні функції", "https://abitap.com/5-20-lokalni-funkcziyi/");
            var exampleTwentyOne = new InlineURL("Статичні локальні функції", "https://abitap.com/5-21-statychni-lokalni-funkcziyi/");
            var exampleTwentyTwo = new InlineURL("Повернення з методу результату оператора switch", "https://abitap.com/5-22-povernennya-z-metodu-rezultatu-operatora-switch/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(exampleNineteen);
            menu.Add(exampleTwenty);
            menu.Add(exampleTwentyOne);
            menu.Add(exampleTwentyTwo);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSix9)]
        public static async Task InlineExampleSix9(ITelegramBotClient botClient, Update update)
        {
            var message = "Класи, об'єкти та структури";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Об’єкт та клас", "https://abitap.com/klasy/");
            var exampleTwo = new InlineURL("Поля та методи класу", "https://abitap.com/6-2-polya-ta-metody-klasu/");
            var exampleThree = new InlineURL("Створення об’єкта класу", "https://abitap.com/6-3-stvorennya-obyekta-klasu/");
            var exampleFour = new InlineURL("Звернення до функціональності класу", "https://abitap.com/6-4-zvernennya-do-funkczionalnosti-klasu/");
            var exampleFive = new InlineURL("Константи класу", "https://abitap.com/6-5-konstanty-klasu/");
            var exampleSix = new InlineURL("Додавання класу у Visual Studio", "https://abitap.com/6-6-dodavannya-klasu-do-visual-studio/");
            var exampleSeven = new InlineURL("Створення конструкторів", "https://abitap.com/6-7-stvorennya-konstruktoriv/");
            var exampleEight = new InlineURL("Ключове слово this", "https://abitap.com/6-8-klyuchove-slovo-this/");
            var exampleNine = new InlineURL("Ланцюжок викликів конструкторів", "https://abitap.com/6-9-lanczyuzhok-vyklykiv-konstruktoriv/");
            var exampleTen = new InlineURL("Ініціалізатори об’єктів", "https://abitap.com/6-10-iniczializatory-obyektiv/");
            var exampleEleven = new InlineURL("Деконструктори", "https://abitap.com/dekonstruktory/");
            var exampleTwelve = new InlineURL("Клас Program та метод Main. Програми верхнього рівня", "https://abitap.com/6-12-klas-program-ta-metod-main-programy-verhnogo-rivnya/");
            var exampleThirteen = new InlineURL("Визначення структури", "https://abitap.com/6-13-vyznachennya-struktury/");
            var exampleFourteen = new InlineURL("Створення об’єкта структури", "https://abitap.com/6-14-stvorennya-obyekta-struktury/");
            var exampleFifteen = new InlineURL("Ініціалізація полів по замовчуванню структури", "https://abitap.com/6-15-iniczializacziya-poliv-po-zamovchuvannyu/");
            var exampleSixteen = new InlineURL("Конструктори структури", "https://abitap.com/6-16-konstruktory-struktury/");
            var exampleSeventeen = new InlineURL("Ініціалізатор структури. Копіювання структури за допомогою with.", "https://abitap.com/iniczializator-struktury-kopiyuvannya-struktury-za-dopomogoyu-with/");
            var exampleEighteen = new InlineURL("Відмінності структур та класів", "https://abitap.com/6-18-vidminnosti-struktur-ta-klasiv/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSeven9)]
        public static async Task InlineExampleSeven9(ITelegramBotClient botClient, Update update)
        {
            var message = "Видимість змінних та простори імен";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Типи-значення та типи-посилання", "https://abitap.com/7-1-typy-znachennya-ta-typy-posylannya/");
            var exampleTwo = new InlineURL("Складові типи", "https://abitap.com/7-2-skladovi-typy/");
            var exampleThree = new InlineURL("Копіювання значень", "https://abitap.com/kopiyuvannya-znachen/");
            var exampleFour = new InlineURL("Типи-посилання всередині типів-значень", "https://abitap.com/7-3-typy-posylannya-vseredyni-typiv-znachen/");
            var exampleFive = new InlineURL("Об’єкти класів як параметри методів", "https://abitap.com/7-5-obyekty-klasiv-yak-parametry-metodiv/");
            var exampleSix = new InlineURL("Область видимості змінних", "https://abitap.com/7-6-oblast-vydymosti-zminnyh/");
            var exampleSeven = new InlineURL("Простори імен", "https://abitap.com/7-7-prostory-imen/");
            var exampleEight = new InlineURL("Підключення простору імен", "https://abitap.com/7-8-pidklyuchennya-prostoru-imen/");
            var exampleNine = new InlineURL("Вкладені простори імен", "https://abitap.com/7-9-vkladeni-prostory-imen/");
            var exampleTen = new InlineURL("Простір імен рівня файлу", "https://abitap.com/7-10-prostir-imen-rivnya-fajlu/");
            var exampleEleven = new InlineURL("Глобальні простори імен", "https://abitap.com/7-11-globalni-prostory-imen/");
            var exampleTwelve = new InlineURL("Підключення просторів імен за замовчуванням", "https://abitap.com/7-12-pidklyuchennya-prostoriv-za-zamovchuvannyam/");
            var exampleThirteen = new InlineURL("Відключення просторів імен за замовчуванням", "https://abitap.com/7-13-vidklyuchennya-prostoriv-imen-za-zamovchuvannyam/");
            var exampleFourteen = new InlineURL("Підключення та відключення окремих просторів імен", "https://abitap.com/7-14-pidklyuchennya-ta-vidklyuchennya-okremyh-prostoriv-imen/");
            var exampleFifteen = new InlineURL("Створення бібліотеки класів", "https://abitap.com/7-15-stvorennya-biblioteky-klasiv/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleEight9)]
        public static async Task InlineExampleEight9(ITelegramBotClient botClient, Update update)
        {
            var message = "Доступ до членів класу";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Модифікатори доступу", "https://abitap.com/8-1-modyfikatory-dostupu/");
            var exampleTwo = new InlineURL("Модифікатори в рамках поточного проекту", "https://abitap.com/8-2-modyfikatory-v-ramkah-potochnogo-proektu/");
            var exampleThree = new InlineURL("Модифікатори в рамках збірок", "https://abitap.com/8-3-modyfikatory-v-ramkah-zbirok/");
            var exampleFour = new InlineURL("Визначення властивостей", "https://abitap.com/vyznachennya-vlastyvostej/");
            var exampleFive = new InlineURL("Властивості тільки для читання та тільки для запису", "https://abitap.com/8-5-vlastyvosti-tilky-dlya-chytannya-ta-tilky-dlya-zapysu/");
            var exampleSix = new InlineURL("Обчислювані властивості", "https://abitap.com/8-6-obchyslyuvani-vlastyvosti/");
            var exampleSeven = new InlineURL("Модифікатори доступу властивостей", "https://abitap.com/8-7-modyfikatory-dostupu-vlastyvostej/");
            var exampleEight = new InlineURL("Автоматичні властивості", "https://abitap.com/8-8-avtomatychni-vlastyvosti/");
            var exampleNine = new InlineURL("Блок init", "https://abitap.com/blok-init/");
            var exampleTen = new InlineURL("Скорочений запис властивостей", "https://abitap.com/8-10-skorochenyj-zapys-vlastyvostej/");
            var exampleEleven = new InlineURL("Перевантаження методів", "https://abitap.com/8-11-perevantazhennya-metodiv/");
            var exampleTwelve = new InlineURL("Статичні поля", "https://abitap.com/8-12-statychni-polya/");
            var exampleThirteen = new InlineURL("Статичні властивості", "https://abitap.com/8-13-statychni-vlastyvosti/");
            var exampleFourteen = new InlineURL("Статичні методи", "https://abitap.com/8-14-statychni-metody/");
            var exampleFifteen = new InlineURL("Статичні конструктори", "https://abitap.com/8-15-statychni-konstruktory/");
            var exampleSixteen = new InlineURL("Статичні класи", "https://abitap.com/8-16-statychni-klasy/");
            var exampleSeventeen = new InlineURL("Статичний імпорт", "https://abitap.com/988-2/");
            var exampleEighteen = new InlineURL("Поля для читання та модифікатор readonly", "https://abitap.com/8-17-polya-dlya-chytannya-ta-modyfikator-readonly/");
            var exampleNineteen = new InlineURL("Порівняння полів для читання з константами", "https://abitap.com/8-18-porivnyannya-poliv-dlya-chytannya-z-konstantamy/");
            var exampleTwenty = new InlineURL("Структури для читання", "https://abitap.com/8-19-struktury-dlya-chytannya/");
            var exampleTwentyOne = new InlineURL("Псевдоніми типів", "https://abitap.com/8-21-psevdonimy-typiv/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(exampleNineteen);
            menu.Add(exampleTwenty);
            menu.Add(exampleTwentyOne);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleNine9)]
        public static async Task InlineExampleNine9(ITelegramBotClient botClient, Update update)
        {
            var message = "Особливості null";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Null та типи-посилання", "https://abitap.com/9-1/");
            var exampleTwo = new InlineURL("Відключення nullable-контексту", "https://abitap.com/9-2-vidklyuchennya-nullable-kontekstu/");
            var exampleThree = new InlineURL("Nullable-контекст на рівні ділянки коду", "https://abitap.com/9-3-nullable-kontekst-na-rivni-dilyanky-kodu/");
            var exampleFour = new InlineURL("Оператор ! (null-forgiving operator)", "https://abitap.com/9-4-operator-null-forgiving-operator/");
            var exampleFive = new InlineURL("Виключення ділянки коду з nullable-контексту", "https://abitap.com/vyklyuchennya-dilyanky-kodu-z-nullable-kontekstu/");
            var exampleSix = new InlineURL("Null та типи-значення", "https://abitap.com/null-ta-typy-znachennya/");
            var exampleSeven = new InlineURL("Властивості Value, HasValue та метод GetValueOrDefault", "https://abitap.com/9-7-vlastyvosti-value-ta-hasvalue-ta-metod-getvalueordefault/");
            var exampleEight = new InlineURL("Приведення nullable-типів", "https://abitap.com/9-8-pryvedennya-nullable-typiv/");
            var exampleNine = new InlineURL("Операції з nullable-типами", "https://abitap.com/9-9-operacziyi-z-nullable-typamy/");
            var exampleTen = new InlineURL("Перевірка на null. Null guard", "https://abitap.com/perevirka-na-null-null-guard/");
            var exampleEleven = new InlineURL("Оператор ??", "https://abitap.com/operator/");
            var exampleTwelve = new InlineURL("Оператор умовного null", "https://abitap.com/9-12-operator-umovnogo-null/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTen9)]
        public static async Task InlineExampleTen9(ITelegramBotClient botClient, Update update)
        {
            var message = "ООП на C#";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Успадкування", "https://abitap.com/10-1-uspadkuvannya/");
            var exampleTwo = new InlineURL("Доступ до членів класу із спадкоємця", "https://abitap.com/10-2-dostup-do-chleniv-klasu-iz-spadkoyemczya/");
            var exampleThree = new InlineURL("Ключове слово base", "https://abitap.com/10-3-klyuchove-slovo-base/");
            var exampleFour = new InlineURL("Конструктори у похідних класах", "https://abitap.com/10-4-konstruktory-u-pohidnyh-klasah/");
            var exampleFive = new InlineURL("Порядок виклику конструкторів", "https://abitap.com/10-5-poryadok-vyklyku-konstruktoriv/");
            var exampleSix = new InlineURL("Перетворення (приведення) типів", "https://abitap.com/10-6-peretvorennya-pryvedennya-typiv/");
            var exampleSeven = new InlineURL("Висхідні перетворення. Upcasting", "https://abitap.com/10-7-vyshidni-peretvorennya-upcasting/");
            var exampleEight = new InlineURL("Низхідні перетворення. Downcasting", "https://abitap.com/10-8-nyzhidni-peretvorennya-downcasting/");
            var exampleNine = new InlineURL("Способи перетворень", "https://abitap.com/10-9-sposoby-peretvoren/");
            var exampleTen = new InlineURL("Перевизначення методів", "https://abitap.com/10-10-perevyznachennya-metodiv/");
            var exampleEleven = new InlineURL("Перевизначення властивостей", "https://abitap.com/10-11-perevyznachennya-vlastyvostej/");
            var exampleTwelve = new InlineURL("Заборона перевизначення", "https://abitap.com/10-12-zaborona-perevyznachennya/");
            var exampleThirteen = new InlineURL("Приховування методів", "https://abitap.com/pryhovuvannya-metodiv/");
            var exampleFourteen = new InlineURL("Приховування властивостей", "https://abitap.com/10-14-pryhovuvannya-vlastyvostej/");
            var exampleFifteen = new InlineURL("Приховування змінних та констант", "https://abitap.com/10-15-pryhovuvannya-zminnyh-ta-konstant/");
            var exampleSixteen = new InlineURL("Відмінності перевизначення та приховування", "https://abitap.com/10-16-vidminnosti-perevyznachennya-ta-pryhovuvannya/");
            var exampleSeventeen = new InlineURL("Абстрактні класи", "https://abitap.com/10-17-abstraktni-klasy/");
            var exampleEighteen = new InlineURL("Абстрактні члени класу", "https://abitap.com/10-18-abstraktni-chleny-klasu/");
            var exampleNineteen = new InlineURL("Приклад абстрактного класу", "https://abitap.com/10-19-pryklad-abstraktnogo-klasu/");
            var exampleTwenty = new InlineURL("Клас System.Object, метод ToString", "https://abitap.com/10-20-klas-system-object-metod-tostring%ef%bf%bc%ef%bf%bc/");
            var exampleTwentyOne = new InlineURL("Метод GetHashCode", "https://abitap.com/10-21-metod-gethashcode/");
            var exampleTwentyTwo = new InlineURL("Отримання типу об’єкта та метод GetType", "https://abitap.com/10-22-otrymannya-typu-obyekta-ta-metod-gettype/");
            var exampleTwentyThree = new InlineURL("Метод Equals", "https://abitap.com/10-23-metod-equals/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(exampleThirteen);
            menu.Add(exampleFourteen);
            menu.Add(exampleFifteen);
            menu.Add(exampleSixteen);
            menu.Add(exampleSeventeen);
            menu.Add(exampleEighteen);
            menu.Add(exampleNineteen);
            menu.Add(exampleTwenty);
            menu.Add(exampleTwentyOne);
            menu.Add(exampleTwentyTwo);
            menu.Add(exampleTwentyThree);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleEleven9)]
        public static async Task InlineExampleEleven9(ITelegramBotClient botClient, Update update)
        {
            var message = "Узагальнені типи";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Узагальнення", "https://abitap.com/11-1-uzagalnennya/");
            var exampleTwo = new InlineURL("Використання кількох універсальних параметрів", "https://abitap.com/11-3-vykorystannya-kilkoh-universalnyh-parametriv/");
            var exampleThree = new InlineURL("Узагальнені методи", "https://abitap.com/11-3-uzagalneni-metody/");
            var exampleFour = new InlineURL("Передумови для створення обмежень узагальнень", "https://abitap.com/obmezhennya-uzagalnen/");
            var exampleFive = new InlineURL("Обмеження узагальнень в методах", "https://abitap.com/11-5-obmezhennya-uzagalnen-v-metodah/");
            var exampleSix = new InlineURL("Обмеження узагальнень в типах", "https://abitap.com/11-6-obmezhennya-uzagalnen-v-typah/");
            var exampleSeven = new InlineURL("Типи обмежень та стандартні обмеження", "https://abitap.com/11-7-typy-obmezhen-ta-standartni-obmezhennya/");
            var exampleEight = new InlineURL("Обмеження при декількох універсальних параметрах", "https://abitap.com/11-8-obmezhennya-pry-dekilkoh-universalnyh-parametrah/");
            var exampleNine = new InlineURL("Успадкування узагальнених типів", "https://abitap.com/11-9-uspadkuvannya-uzagalnenyh-typiv/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwelve9)]
        public static async Task InlineExampleTwelve9(ITelegramBotClient botClient, Update update)
        {
            var message = "Обробка винятків";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Обробка виняткових ситуацій", "https://abitap.com/12-1-obrobka-vynyatkovyh-sytuaczij/");
            var exampleTwo = new InlineURL("Блок catch та фільтри винятків", "https://abitap.com/12-2-blok-catch-ta-filtry-vynyatkiv/");
            var exampleThree = new InlineURL("Типи винятків. Клас Exception", "https://abitap.com/12-3-typy-vynyatkiv-klas-exception/");
            var exampleFour = new InlineURL("Генерація винятку та оператор throw", "https://abitap.com/12-4-generacziya-vynyatku-ta-operator-throw/");
            var exampleFive = new InlineURL("Створення класів винятків", "https://abitap.com/12-5-stvorennya-klasiv-vynyatkiv/");
            var exampleSix = new InlineURL("Пошук блока catch при обробці винятків", "https://abitap.com/12-6-poshuk-bloka-catch-pry-obrobczi-vynyatkiv/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThirteen9)]
        public static async Task InlineExampleThirteen9(ITelegramBotClient botClient, Update update)
        {
            var message = "Делегати, події та лямбди";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Делегати", "https://abitap.com/delegaty/");
            var exampleTwo = new InlineURL("Застосування делегатів", "https://abitap.com/13-2-zastosuvannya-delegativ/");
            var exampleThree = new InlineURL("Анонімні методи", "https://abitap.com/13-3-anonimni-metody/");
            var exampleFour = new InlineURL("Лямбда-вирази", "https://abitap.com/13-4/");
            var exampleFive = new InlineURL("Події", "https://abitap.com/13-5-podiyi/");
            var exampleSix = new InlineURL("Коваріантність та контраваріантність делегатів", "https://abitap.com/13-6-kovariantnist-ta-kontravariantnist-delegativ/");
            var exampleSeven = new InlineURL("Делегати Action, Predicate та Func", "https://abitap.com/13-7-delegaty-action-predicate-ta-func/");
            var exampleEight = new InlineURL("Замикання", "https://abitap.com/13-8-zamykannya/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFourteen9)]
        public static async Task InlineExampleFourteen9(ITelegramBotClient botClient, Update update)
        {
            var message = "Інтерфейси";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Визначення інтерфейсу", "https://abitap.com/14-1-vyznachennya-interfejsu/");
            var exampleTwo = new InlineURL("Застосування інтерфейсів", "https://abitap.com/14-2/");
            var exampleThree = new InlineURL("Явна реалізація інтерфейсів", "https://abitap.com/14-3-yavna-realizacziya-interfejsiv/");
            var exampleFour = new InlineURL("Реалізація інтерфейсів в похідних класах", "https://abitap.com/14-4-realizacziya-interfejsiv-v-pohidnyh-klasah/");
            var exampleFive = new InlineURL("Успадкування інтерфейсів", "https://abitap.com/uspadkuvannya-interfejsiv/");
            var exampleSix = new InlineURL("Інтерфейси в узагальненнях", "https://abitap.com/14-6-interfejsy-v-uzagalnennyah/");
            var exampleSeven = new InlineURL("Копіювання об’єктів. Інтерфейс ICloneable", "https://abitap.com/14-7-kopiyuvannya-obyektiv-interfejs-icloneable/");
            var exampleEight = new InlineURL("Сортування об’єктів. Інтерфейс IComparable", "https://abitap.com/14-8-sortuvannya-obyektiv-interfejs-icomparable/");
            var exampleNine = new InlineURL("Коваріантність та контраваріантність узагальнених інтерфейсів", "https://abitap.com/14-9-kovariantnist-ta-kontravariantnist-uzagalnenyh-interfejsiv/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFifteen9)]
        public static async Task InlineExampleFifteen9(ITelegramBotClient botClient, Update update)
        {
            var message = "Інші можливості ООП на С#";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Вкладені класи", "https://abitap.com/15-1-vkladeni-klasy/");
            var exampleTwo = new InlineURL("Перевантаження операторів", "https://abitap.com/15-2-perevantazhennya-operatoriv/");
            var exampleThree = new InlineURL("Перевантаження операцій перетворення типів", "https://abitap.com/15-3-perevantazhennya-operaczij-peretvorennya-typiv/");
            var exampleFour = new InlineURL("Індексатори", "https://abitap.com/2653-2/");
            var exampleFive = new InlineURL("Змінні-посилання та повернення посилання", "https://abitap.com/15-5-zminni-posylannya-ta-povernennya-posylannya/");
            var exampleSix = new InlineURL("Методи розширення", "https://abitap.com/15-6-metody-rozshyrennya/");
            var exampleSeven = new InlineURL("Часткові класи та методи", "https://abitap.com/15-7-chastkovi-klasy-ta-metody/");
            var exampleEight = new InlineURL("Анонімні типи", "https://abitap.com/15-8-anonimni-typy/");
            var exampleNine = new InlineURL("Кортежі", "https://abitap.com/15-9-kortezhi/");
            var exampleTen = new InlineURL("Records", "https://abitap.com/15-10-records/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSixteen9)]
        public static async Task InlineExampleSixteen9(ITelegramBotClient botClient, Update update)
        {
            var message = "Патерни / шаблони";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Патерн типів", "https://abitap.com/16-1-patern-typiv/");
            var exampleTwo = new InlineURL("Патерн властивостей", "https://abitap.com/16-2-patern-vlastyvostej/");
            var exampleThree = new InlineURL("Патерни кортежів", "https://abitap.com/16-3-patterny-kortezhiv/");
            var exampleFour = new InlineURL("Позиційний патерн", "https://abitap.com/pozyczijnyj-patern/");
            var exampleFive = new InlineURL("Реляційний та логічний патерни", "https://abitap.com/16-5-relyaczijnyj-ta-logichnyj-paterny/");
            var exampleSix = new InlineURL("Патерни списків", "https://abitap.com/1-3/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSeventeen9)]
        public static async Task InlineExampleSeventeen9(ITelegramBotClient botClient, Update update)
        {
            var message = "Колекції";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Список List<T>", "https://abitap.com/17-1-spysok-list-2/");
            var exampleTwo = new InlineURL("Список LinkedList<T>", "https://abitap.com/17-2-spysok-linkedlistt/");
            var exampleThree = new InlineURL("Клас Queue<T>", "https://abitap.com/17-3-klas-queuet/");
            var exampleFour = new InlineURL("Клас Stack<T>", "https://abitap.com/17-4-klas-stack/");
            var exampleFive = new InlineURL("Колекція Dictionary<K, V>", "https://abitap.com/17-5-kolekcziya-dictionary-k-v/");
            var exampleSix = new InlineURL("Клас ObservableCollection", "https://abitap.com/17-6-klas-observablecollection/");
            var exampleSeven = new InlineURL("Інтерфейси IEnumerable та IEnumerator", "https://abitap.com/17-7-interfejsy-ienumerable-ta-ienumerator/");
            var exampleEight = new InlineURL("Ітератори та оператор yield", "https://abitap.com/17-8-iteratory-ta-operator-yield/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleEighteen9)]
        public static async Task InlineExampleEighteen9(ITelegramBotClient botClient, Update update)
        {
            var message = "Робота з рядками";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Рядки та клас String", "https://abitap.com/18-1-ryadky-ta-klas-string/");
            var exampleTwo = new InlineURL("Операції з рядками", "https://abitap.com/18-2-operacziyi-z-ryadkamy/");
            var exampleThree = new InlineURL("Форматування та інтерполяція рядків", "https://abitap.com/18-3-formatuvannya-ta-interpolyacziya-ryadkiv/");
            var exampleFive = new InlineURL("Клас StringBuilder", "https://abitap.com/klas-stringbuilder/");
            var exampleSix = new InlineURL("Регулярні вирази", "https://abitap.com/18-6-regulyarni-vyrazy/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleNineteen9)]
        public static async Task InlineExampleNineteen9(ITelegramBotClient botClient, Update update)
        {
            var message = "Робота з датою та часом";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Структура DateTime", "https://abitap.com/19-1-struktura-datetime/");
            var exampleTwo = new InlineURL("Форматування дат та часу", "https://abitap.com/19-2-formatuvannya-dat-ta-chasu/");
            var exampleThree = new InlineURL("DateOnly та TimeOnly", "https://abitap.com/19-3-dateonly-ta-timeonly/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwenty9)]
        public static async Task InlineExampleTwenty9(ITelegramBotClient botClient, Update update)
        {
            var message = "Деякі необхідні класи та структури .NET";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Відкладена ініціалізація і тип Lazy", "https://abitap.com/19-1-vidkladena-iniczializacziya-i-typ-lazy/");
            var exampleTwo = new InlineURL("Математичні обчислення та клас Math", "https://abitap.com/20-2-matematychni-obchyslennya-ta-klas-math/");
            var exampleThree = new InlineURL("Parse, TryParse та клас Convert", "https://abitap.com/20-3-parse-tryparse-ta-klas-convert/");
            var exampleFour = new InlineURL("Клас Array та масиви", "https://abitap.com/20-4-klas-array-ta-masyvy/");
            var exampleFive = new InlineURL("Тип Span", "https://abitap.com/20-5-typ-span/");
            var exampleSix = new InlineURL("Індекси та діапазони", "https://abitap.com/20-6-indeksy-ta-diapazony/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentyOne9)]
        public static async Task InlineExampleTwentyOne9(ITelegramBotClient botClient, Update update)
        {
            var message = "Багатопоточність";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Введення у багатопоточність. Клас Thread", "https://abitap.com/21-1-vvedennya-u-bagatopotochnist-klas-thread/");
            var exampleTwo = new InlineURL("Створення потоків. Делегат ThreadStart", "https://abitap.com/21-2/");
            var exampleThree = new InlineURL("Потоки з параметрами і ParameterizedThreadStart", "https://abitap.com/21-3-potoky-z-parametramy-i-parameterizedthreadstart/");
            var exampleFour = new InlineURL("Синхронізація потоків", "https://abitap.com/21-4-synhronizacziya-potokiv/");
            var exampleFive = new InlineURL("Монітори", "https://abitap.com/21-5-monitory/");
            var exampleSix = new InlineURL("Клас AutoResetEvent", "https://abitap.com/21-6-klas-autoresetevent/");
            var exampleSeven = new InlineURL("М’ютекси", "https://abitap.com/21-7-myuteksy/");
            var exampleEight = new InlineURL("Семафори", "https://abitap.com/21-8-semafory/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentyTwo9)]
        public static async Task InlineExampleTwentyTwo9(ITelegramBotClient botClient, Update update)
        {
            var message = "Паралельне програмування та бібліотека TPL";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Задачі та клас Task", "https://abitap.com/22-1-zadachy-y-klass-task/");
            var exampleTwo = new InlineURL("Робота с класом Task", "https://abitap.com/22-2-robota-s-klasom-task/");
            var exampleThree = new InlineURL("Задачі продовження", "https://abitap.com/22-3-zadachi-prodovzhennya/");
            var exampleFour = new InlineURL("Клас Parallel", "https://abitap.com/22-4-klas-parallel/");
            var exampleFive = new InlineURL("Скасування завдань та паралельних операцій. CancellationToken", "https://abitap.com/22-5-skasuvannya-zavdan-ta-paralelnyh-operaczij-cancellationtoken/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentyThree9)]
        public static async Task InlineExampleTwentyThree9(ITelegramBotClient botClient, Update update)
        {
            var message = "Асинхронне програмування";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Асинхронні методи, async та await", "https://abitap.com/asynhronni-metody-async-ta-await/");
            var exampleTwo = new InlineURL("Повернення результату з асинхронного методу", "https://abitap.com/23-2-povernennya-rezultatu-z-asynhronnogo-metodu/");
            var exampleThree = new InlineURL("Послідовне та паралельне виконання. Task.WhenAll та Task.WhenAny", "https://abitap.com/23-3-poslidovne-ta-paralelne-vykonannya-task-whenall-ta-task-whenany/");
            var exampleFour = new InlineURL("Обробка помилок у асинхронних методах", "https://abitap.com/23-4-obrobka-pomylok-u-asynhronnyh-metodah/");
            var exampleFive = new InlineURL("Асинхронні стріми", "https://abitap.com/23-5-asynhronni-strimy/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentyFour9)]
        public static async Task InlineExampleTwentyFour9(ITelegramBotClient botClient, Update update)
        {
            var message = "LINQ";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Основи LINQ", "https://abitap.com/osnovy-linq/");
            var exampleTwo = new InlineURL("Проекція даних", "https://abitap.com/24-2-proekcziya-danyh/");
            var exampleThree = new InlineURL("Фільтрація колекції", "https://abitap.com/24-3-filtracziya-kolekcziyi/");
            var exampleFour = new InlineURL("Сортування", "https://abitap.com/24-4-sortuvannya/");
            var exampleFive = new InlineURL("Об’єднання, перетин та різниця колекцій", "https://abitap.com/24-5-obyednannya-peretyn-ta-riznyczya-kolekczij/");
            var exampleSix = new InlineURL("Агрегатні операції", "https://abitap.com/24-6-agregatni-operacziyi/");
            var exampleSeven = new InlineURL("Методи Skip та Take", "https://abitap.com/24-7-metody-skip-ta-take/");
            var exampleEight = new InlineURL("Групування", "https://abitap.com/24-8-grupuvannya/");
            var exampleNine = new InlineURL("З’єднання колекцій", "https://abitap.com/24-9-zyednannya-kolekczij/");
            var exampleTen = new InlineURL("Перевірка наявності та отримання елементів", "https://abitap.com/24-10-perevirka-nayavnosti-ta-otrymannya-elementiv/");
            var exampleEleven = new InlineURL("Відкладене та негайне виконання LINQ", "https://abitap.com/24-11-vidkladene-ta-negajne-vykonannya-linq/");
            var exampleTwelve = new InlineURL("Делегати у запитах LINQ", "https://abitap.com/24-12-delegaty-u-zapytah-linq/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(exampleTwelve);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentyFive9)]
        public static async Task InlineExampleTwentyFive9(ITelegramBotClient botClient, Update update)
        {
            var message = "Parallel LINQ";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Вступ в Parallel LINQ. Метод AsParallel", "https://abitap.com/25-1-vstup-v-parallel-linq-metod-asparallel/");
            var exampleTwo = new InlineURL("Метод AsOrdered", "https://abitap.com/25-2-metod-asordered/");
            var exampleThree = new InlineURL("Обробка помилок та скасування операції", "https://abitap.com/25-3-obrobka-pomylok-ta-skasuvannya-operacziyi/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentySix9)]
        public static async Task InlineExampleTwentySix9(ITelegramBotClient botClient, Update update)
        {
            var message = "Рефлексія";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Вступ в рефлексію. Клас System.Type", "https://abitap.com/26-1-vstup-v-refleksiyu-klas-system-type/");
            var exampleTwo = new InlineURL("Застосування рефлексії та дослідження типів", "https://abitap.com/26-2-zastosuvannya-refleksiyi-ta-doslidzhennya-typiv/");
            var exampleThree = new InlineURL("Дослідження методів та конструкторів за допомогою рефлексії", "https://abitap.com/26-3-doslidzhennya-metodiv-ta-konstruktoriv-za-dopomogoyu-refleksiyi/");
            var exampleFour = new InlineURL("Дослідження полів та властивостей за допомогою рефлексії", "https://abitap.com/26-4-doslidzhennya-poliv-ta-vlastyvostej-za-dopomogoyu-refleksiyi/");
            var exampleFive = new InlineURL("Динамічне завантаження збірок та пізнє зв’язування", "https://abitap.com/26-5-dynamichne-zavantazhennya-zbirok-ta-piznye-zvyazuvannya/");
            var exampleSix = new InlineURL("Атрибути в .NET", "https://abitap.com/26-6-atrybuty-v-net/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentySeven9)]
        public static async Task InlineExampleTwentySeven9(ITelegramBotClient botClient, Update update)
        {
            var message = "Dynamic Language Runtime";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("DLR в C#. Ключове слово dynamic", "https://abitap.com/27-1-dlr-v-c-klyuchove-slovo-dynamic/");
            var exampleTwo = new InlineURL("DynamicObject та ExpandoObject", "https://abitap.com/27-2-dynamicobject-ta-expandoobject/");
            var exampleThree = new InlineURL("Використання IronPython в .NET", "https://abitap.com/27-3-vykorystannya-ironpython-v-net/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentyEight9)]
        public static async Task InlineExampleTwentyEight9(ITelegramBotClient botClient, Update update)
        {
            var message = "Збирач сміття, керування пам’яттю та вказівники";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Збирач сміття", "https://abitap.com/28-1-zbyrach-smittya/");
            var exampleTwo = new InlineURL("Фіналізовані об’єкти", "https://abitap.com/28-2-finalizovani-obyekty/");
            var exampleThree = new InlineURL("Конструкція using", "https://abitap.com/28-3-konstrukcziya-using/");
            var exampleFour = new InlineURL("Покажчики", "https://abitap.com/28-4-pokazhchyky/");
            var exampleFive = new InlineURL("Покажчики на структури, члени класів та масиви", "https://abitap.com/28-5-pokazhchyky-na-struktury-chleny-klasiv-ta-masyvy/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwentyNine9)]
        public static async Task InlineExampleTwentyNine9(ITelegramBotClient botClient, Update update)
        {
            var message = "Робота з файловою системою";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Робота з дисками", "https://abitap.com/robota-z-dyskamy/");
            var exampleTwo = new InlineURL("Робота з каталогами", "https://abitap.com/29-2-robota-z-katalogamy/");
            var exampleThree = new InlineURL("Робота із файлами. Класи File та FileInfo", "https://abitap.com/29-3-robota-iz-fajlamy-klasy-file-ta-fileinfo/");
            var exampleFour = new InlineURL("FileStream. Читання та запис файлу", "https://abitap.com/29-4-filestream-chytannya-ta-zapys-fajlu/");
            var exampleFive = new InlineURL("Читання та запис текстових файлів. StreamReader та StreamWriter", "https://abitap.com/29-5-chytannya-ta-zapys-tekstovyh-fajliv-streamreader-ta-streamwriter/");
            var exampleSix = new InlineURL("Бінарні файли. BinaryWriter та BinaryReader", "https://abitap.com/29-6-binarni-fajly-binarywriter-ta-binaryreader/");
            var exampleSeven = new InlineURL("Архівація та стиснення файлів", "https://abitap.com/29-7-arhivacziya-ta-stysnennya-fajliv/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThirty9)]
        public static async Task InlineExampleThirty9(ITelegramBotClient botClient, Update update)
        {
            var message = "Робота з JSON";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Серіалізація в JSON. JsonSerializer", "https://abitap.com/30-1-serializacziya-v-json-jsonserializer/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThirtyOne9)]
        public static async Task InlineExampleThirtyOne9(ITelegramBotClient botClient, Update update)
        {
            var message = "Робота з XML";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("XML-документи", "https://abitap.com/31-1-xml-dokumenty/");
            var exampleTwo = new InlineURL("Робота з XML за допомогою класів System.Xml", "https://abitap.com/31-2-robota-z-xml-za-dopomogoyu-klasiv-system-xml/");
            var exampleThree = new InlineURL("Зміна XML-документа", "https://abitap.com/31-3-zmina-xml-dokumenta/");
            var exampleFour = new InlineURL("XPath", "https://abitap.com/31-4-xpath/");
            var exampleFive = new InlineURL("Linq to Xml. Створення документа XML", "https://abitap.com/31-5-linq-to-xml-stvorennya-dokumenta-xml/");
            var exampleSix = new InlineURL("Вибірка елементів у LINQ to XML", "https://abitap.com/31-6-vybirka-elementiv-u-linq-to-xml/");
            var exampleSeven = new InlineURL("Зміна документа в LINQ to XML", "https://abitap.com/31-7-zmina-dokumenta-v-linq-to-xml/");
            var exampleEight = new InlineURL("Серіалізація у XML. XmlSerializer", "https://abitap.com/31-8-serializacziya-u-xml-xmlserializer/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThirtyTwo9)]
        public static async Task InlineExampleTrirtyTwo9(ITelegramBotClient botClient, Update update)
        {
            var message = "Процеси і домени застосунку";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Процеси", "https://abitap.com/32-1-proczesy/");
            var exampleTwo = new InlineURL("Домени програм", "https://abitap.com/32-2-domeny-program/");
            var exampleThree = new InlineURL("AssemblyLoadContext та динамічне завантаження та вивантаження збірок", "https://abitap.com/32-3-assemblyloadcontext-ta-dynamichne-zavantazhennya-ta-vyvantazhennya-zbirok/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThirtyThree9)]
        public static async Task InlineExampleThirtyThree9(ITelegramBotClient botClient, Update update)
        {
            var message = "Публікація програми";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Native AOT", "https://abitap.com/33-1-native-aot/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThirtyFour9)]
        public static async Task InlineExampleThirtyFour9(ITelegramBotClient botClient, Update update)
        {
            var message = "Нове в C# 11";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Нове в С# 11", "https://abitap.com/34-1-nove-v-s-11/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThirtyFive9)]
        public static async Task InlineExampleThirtyFive9(ITelegramBotClient botClient, Update update)
        {
            var message = "Нове в C# 12";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Нове в С# 12", "https://abitap.com/35-1-nove-v-c12/");
            var back9 = new InlineCallback("<- Назад", CustomTHeader.Back9);

            menu.Add(exampleOne);
            menu.Add(back9);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back9)]
        public static async Task InlineBack9(ITelegramBotClient botClient, Update update)
        {
            var message = "Мова програмування C# 12 (.NET 8)";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Мова програмування C# 12 (.NET 8)", "https://abitap.com/category/c/");
            var exampleOne9 = new InlineCallback("Вступ(перша програма)", CustomTHeader.ExampleOne9);
            var exampleTwo9 = new InlineCallback("Змінні, типи даних та операції", CustomTHeader.ExampleTwo9);
            var exampleThree9 = new InlineCallback("Керуючі конструкці(цикли, умови)", CustomTHeader.ExampleThree9);
            var exampleFour9 = new InlineCallback("Масиви. Перерахування", CustomTHeader.ExampleFour9);
            var exampleFive9 = new InlineCallback("Методи", CustomTHeader.ExampleFive9);
            var exampleSix9 = new InlineCallback("Класи, об'єкти та структури", CustomTHeader.ExampleSix9);
            var exampleSeven9 = new InlineCallback("Видимість змінних та простори імен", CustomTHeader.ExampleSeven9);
            var exampleEight9 = new InlineCallback("Доступ до членів класу", CustomTHeader.ExampleEight9);
            var exampleNine9 = new InlineCallback("Особливості null", CustomTHeader.ExampleNine9);
            var exampleTen9 = new InlineCallback("ООП на C#", CustomTHeader.ExampleTen9);
            var exampleEleven9 = new InlineCallback("Узагальнені типи", CustomTHeader.ExampleEleven9);
            var exampleTwelve9 = new InlineCallback("Обробка винятків", CustomTHeader.ExampleTwelve9);
            var exampleThirteen9 = new InlineCallback("Делегати, події та лямбди", CustomTHeader.ExampleThirteen9);
            var exampleFourteen9 = new InlineCallback("Інтерфейси", CustomTHeader.ExampleFourteen9);
            var exampleFifteen9 = new InlineCallback("Інші можливості ООП на C#", CustomTHeader.ExampleFifteen9);
            var exampleSixteen9 = new InlineCallback("Патерни / шаблони", CustomTHeader.ExampleSixteen9);
            var exampleSeventeen9 = new InlineCallback("Колекції", CustomTHeader.ExampleSeventeen9);
            var exampleEighteen9 = new InlineCallback("Робота з рядками", CustomTHeader.ExampleEighteen9);
            var exampleNineteen9 = new InlineCallback("Робота з датою та часом", CustomTHeader.ExampleNineteen9);
            var exampleTwenty9 = new InlineCallback("Деякі необхідні класи та структури .NET", CustomTHeader.ExampleTwenty9);
            var exampleTwentyOne9 = new InlineCallback("Багатопоточність", CustomTHeader.ExampleTwentyOne9);
            var exampleTwentyTwo9 = new InlineCallback("Паралельне програмування та бібліотека TPL", CustomTHeader.ExampleTwentyTwo9);
            var exampleTwentyThree9 = new InlineCallback("Асинхронне програмування", CustomTHeader.ExampleTwentyThree9);
            var exampleTwentyFour9 = new InlineCallback("LINQ", CustomTHeader.ExampleTwentyFour9);
            var exampleTwentyFive9 = new InlineCallback("Parallel LINQ", CustomTHeader.ExampleTwentyFive9);
            var exampleTwentySix9 = new InlineCallback("Рефлексія", CustomTHeader.ExampleTwentySix9);
            var exampleTwentySeven9 = new InlineCallback("Dynamic Language Runtime", CustomTHeader.ExampleTwentySeven9);
            var exampleTwentyEight9 = new InlineCallback("Збирач сміття, керування пам'яттю та вказівники", CustomTHeader.ExampleTwentyEight9);
            var exampleTwentyNine9 = new InlineCallback("Робота з файловою системою", CustomTHeader.ExampleTwentyNine9);
            var exampleThirty9 = new InlineCallback("Робота з JSON", CustomTHeader.ExampleThirty9);
            var exampleThirtyOne9 = new InlineCallback("Робота з XML", CustomTHeader.ExampleThirtyOne9);
            var exampleThirtyTwo9 = new InlineCallback("Процедури і домени застосунку", CustomTHeader.ExampleThirtyTwo9);
            var exampleThirtyThree9 = new InlineCallback("Публікації програми", CustomTHeader.ExampleThirtyThree9);
            var exampleThirtyFour9 = new InlineCallback("Нове в C#11", CustomTHeader.ExampleThirtyFour9);
            var exampleThirtyFive9 = new InlineCallback("Нове в C#12", CustomTHeader.ExampleThirtyFive9);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne9);
            menu.Add(exampleTwo9);
            menu.Add(exampleThree9);
            menu.Add(exampleFour9);
            menu.Add(exampleFive9);
            menu.Add(exampleSix9);
            menu.Add(exampleSeven9);
            menu.Add(exampleEight9);
            menu.Add(exampleNine9);
            menu.Add(exampleTen9);
            menu.Add(exampleEleven9);
            menu.Add(exampleTwelve9);
            menu.Add(exampleThirteen9);
            menu.Add(exampleFourteen9);
            menu.Add(exampleFifteen9);
            menu.Add(exampleSixteen9);
            menu.Add(exampleSeventeen9);
            menu.Add(exampleEighteen9);
            menu.Add(exampleNineteen9);
            menu.Add(exampleTwenty9);
            menu.Add(exampleTwentyOne9);
            menu.Add(exampleTwentyTwo9);
            menu.Add(exampleTwentyThree9);
            menu.Add(exampleTwentyFour9);
            menu.Add(exampleTwentyFive9);
            menu.Add(exampleTwentySix9);
            menu.Add(exampleTwentySeven9);
            menu.Add(exampleTwentyEight9);
            menu.Add(exampleTwentyNine9);
            menu.Add(exampleThirty9);
            menu.Add(exampleThirtyOne9);
            menu.Add(exampleThirtyTwo9);
            menu.Add(exampleThirtyThree9);
            menu.Add(exampleThirtyFour9);
            menu.Add(exampleThirtyFive9);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(2, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleOne10)]
        public static async Task InlineExampleOne10(ITelegramBotClient botClient, Update update)
        {
            var message = "Основи патернів проектування";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Вступ", "https://abitap.com/1-1-vstup/");
            var exampleTwo = new InlineURL("Зв’язок між класами та об’єктами", "https://abitap.com/1-2-zvyazok-mizh-klasamy-ta-obyektamy/");
            var exampleThree = new InlineURL("Інтерфейси та абстрактні класи", "https://abitap.com/1-3-interfejsy-ta-abstraktni-klasy/");
            var back10 = new InlineCallback("<- Назад", CustomTHeader.Back10);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(back10);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleTwo10)]
        public static async Task InlineExampleTwo10(ITelegramBotClient botClient, Update update)
        {
            var message = "Породжуючі патерни";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Фабричний метод (Factory Method)", "https://abitap.com/2-1-fabrychnyj-metod-factory-method/");
            var exampleTwo = new InlineURL("Абстрактна фабрика (Abstract Factory)", "https://abitap.com/2-2-abstraktna-fabryka-abstract-factory/");
            var exampleThree = new InlineURL("Одинак ​​(Singleton, Сінглтон)", "https://abitap.com/2-3-odynak-singleton-singlton/");
            var exampleFour = new InlineURL("Патерн Прототип (Prototype)", "https://abitap.com/2-4-patern-prototyp-prototype/");
            var exampleFive = new InlineURL("Будівельник (Builder)", "https://abitap.com/2-5-budivelnyk-builder/");
            var back10 = new InlineCallback("<- Назад", CustomTHeader.Back10);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(back10);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleThree10)]
        public static async Task InlineExampleThree10(ITelegramBotClient botClient, Update update)
        {
            var message = "Патерни поведінки";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Патерн Стратегія (Strategy)", "https://abitap.com/3-1-pattern-strategiya-strategy/");
            var exampleTwo = new InlineURL("Патерн “Спостерігач” (Observer)", "https://abitap.com/3-2-pattern-sposterigach-observer/");
            var exampleThree = new InlineURL("Патерн Команда (Command)", "https://abitap.com/3-3-patern-komanda-command/");
            var exampleFour = new InlineURL("Шаблонний метод (Template Method)", "https://abitap.com/3-4-shablonnyj-metod-template-method/");
            var exampleFive = new InlineURL("Патерн Ітератор (Iterator)", "https://abitap.com/3-5-patern-iterator-iterator/");
            var exampleSix = new InlineURL("Патерн Стан (State)", "https://abitap.com/3-6-patern-stan-state/");
            var exampleSeven = new InlineURL("Ланцюжок обов’язків (Chain of responsibility)", "https://abitap.com/3-7-lanczyuzhok-obovyazkiv-chain-of-responsibility/");
            var exampleEight = new InlineURL("Патерн Інтерпретатор (Interpreter)", "https://abitap.com/3-8-patern-interpretator-interpreter/");
            var exampleNine = new InlineURL("Патерн Посередник (Mediator)", "https://abitap.com/patern-poserednyk-mediator/");
            var exampleTen = new InlineURL("Патерн Зберігач (Memento)", "https://abitap.com/3-10-patern-zberigach-memento/");
            var exampleEleven = new InlineURL("Патерн Відвідувач (Visitor)", "https://abitap.com/3-11-patern-vidviduvach-visitor/");
            var back10 = new InlineCallback("<- Назад", CustomTHeader.Back10);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(exampleEight);
            menu.Add(exampleNine);
            menu.Add(exampleTen);
            menu.Add(exampleEleven);
            menu.Add(back10);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFour10)]
        public static async Task InlineExampleFour10(ITelegramBotClient botClient, Update update)
        {
            var message = "Структурні патерни";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Патерн Декоратор (Decorator)", "https://abitap.com/4-1-patern-dekorator-decorator/");
            var exampleTwo = new InlineURL("Патерн Адаптер (Adapter)", "https://abitap.com/4-2-patern-adapter-adapter/");
            var exampleThree = new InlineURL("Фасад (Facade)", "https://abitap.com/4-3-fasad-facade/");
            var exampleFour = new InlineURL("Патерн Компонувальник (Composite)", "https://abitap.com/4-4-patern-komponuvalnyk-composite/");
            var exampleFive = new InlineURL("Патерн Заступник (Proxy)", "https://abitap.com/4-5-patern-zastupnyk-proxy/");
            var exampleSix = new InlineURL("Патерн Міст (Bridge)", "https://abitap.com/4-6-patern-mist-bridge/");
            var exampleSeven = new InlineURL("Патерн Пристосуванець (Flyweight)", "https://abitap.com/4-7-patern-prystosuvanecz-flyweight/");
            var back10 = new InlineCallback("<- Назад", CustomTHeader.Back10);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(exampleSeven);
            menu.Add(back10);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleFive10)]
        public static async Task InlineExampleFive10(ITelegramBotClient botClient, Update update)
        {
            var message = "Принципи SOLID";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Принципи SOLID", "https://abitap.com/5-1-prynczypy-solid/");
            var exampleTwo = new InlineURL("Принцип єдиного обов’язку", "https://abitap.com/5-2-prynczyp-yedynogo-obovyazku/");
            var exampleThree = new InlineURL("Принцип відкритості/закритості", "https://abitap.com/5-2-prynczyp-vidkrytosti-zakrytosti/");
            var exampleFour = new InlineURL("Принцип підстановки Лісков", "https://abitap.com/5-4-prynczyp-pidstanovky-liskov/");
            var exampleFive = new InlineURL("Принцип поділу інтерфейсів", "https://abitap.com/5-5-prynczyp-podilu-interfejsiv/");
            var exampleSix = new InlineURL("Принцип інверсії залежностей", "https://abitap.com/5-6-prynczyp-inversiyi-zalezhnostej/");
            var back10 = new InlineCallback("<- Назад", CustomTHeader.Back10);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);
            menu.Add(exampleFive);
            menu.Add(exampleSix);
            menu.Add(back10);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.ExampleSix10)]
        public static async Task InlineExampleSix10(ITelegramBotClient botClient, Update update)
        {
            var message = "Додаткові принципи та патерни";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineURL("Патерн Fluent Builder", "https://abitap.com/patern-fluent-builder/");
            var exampleTwo = new InlineURL("Принцип Tell-Don’t-Ask", "https://abitap.com/6-2-prynczyp-tell-dont-ask/");
            var back10 = new InlineCallback("<- Назад", CustomTHeader.Back10);

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(back10);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }

        [InlineCallbackHandler<CustomTHeader>(CustomTHeader.Back10)]
        public static async Task InlineBack10(ITelegramBotClient botClient, Update update)
        {
            var message = "Патерни проектування";

            List<IInlineContent> menu = new List<IInlineContent>();

            var url = new InlineURL("Патерни проектування", "https://abitap.com/category/paterny-proektuvannya/");
            var exampleOne10 = new InlineCallback("Основи патернів проектування", CustomTHeader.ExampleOne10);
            var exampleTwo10 = new InlineCallback("Подорожуючі патерни", CustomTHeader.ExampleTwo10);
            var exampleThree10 = new InlineCallback("Патерни поведінки", CustomTHeader.ExampleThree10);
            var exampleFour10 = new InlineCallback("Структурні патерни", CustomTHeader.ExampleFour10);
            var exampleFive10 = new InlineCallback("Принципи SOLID", CustomTHeader.ExampleFive10);
            var exampleSix10 = new InlineCallback("Додаткові принципи та патерни", CustomTHeader.ExampleSix10);
            var back = new InlineCallback("<- Назад", CustomTHeader.Back);

            menu.Add(url);
            menu.Add(exampleOne10);
            menu.Add(exampleTwo10);
            menu.Add(exampleThree10);
            menu.Add(exampleFour10);
            menu.Add(exampleFive10);
            menu.Add(exampleSix10);
            menu.Add(back);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message, optins);
        }
        #endregion
    }
}