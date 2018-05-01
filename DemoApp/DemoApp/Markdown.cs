using System;

namespace DemoApp
{
    static class Markdown
    {
        public static string GetPageContent(int index)
        {
            return pages[index];
        }

        static string[] pages = new string[]
        {
            "# 5 Minute Start: Exploring Xamarin.Forms 3.0\n\n" +
            "Let's get a quick taste of building beautiful mobile apps with Xamarin.Forms 3.0. In this quick walkthrough you will:\n\n" +
            "* Personalize the app\n" +
            "*Extend the app with cross-platform features\n" +
            "* Use FlexLayout and CSS to create a fluid layout\n" +
            "*Deploy to your own device!\n\n" +
            "> If you're on Windows you can use the new Live Reload (Preview) to see your XAML changes without leaving your debug session. " +
            "Simply make changes to your XAML and save the file.",

            "## Personalize the App\n\n" +
            "The My Profile page `UserProfileView.xaml` is looking quite plain.Let's add your own personal touch.\n\n" +
            "1. Locate and open the layout file within the.NET Standard Library project MOVAI > Views.\n" +
            "2. Run the project with F5 to see what you're working with.\n" +
            "On the emulator/simulator you should see something like this:\n\n" +
            "![Profile01](Images/Profile01.png)",
            "### Add A StyleSheet\n\n" +
            "We have a CSS file ready for you, so go ahead and connect that by adding a StyleSheet reference to the XAML.\n\n" +
            "```\n" +
            "<ContentPage.Resources>\n" +
            "<StyleSheet Source=\"../Styles/UserProfileView.css\"/>" +
            "</ContentPage.Resources>\n" +
            "```\n\n" +
            "Save the XAML and take another look. It's a little better, right?\n\n" +
            "![Profile After Stylesheet](Images/ProfileAfterStylesheet.png)"
        };

        //static string Page1 = "# 5 Minute Start: Exploring Xamarin.Forms 3.0\n\n" +
        //    "Let's get a quick taste of building beautiful mobile apps with Xamarin.Forms 3.0. In this quick walkthrough you will:\n\n" +
        //    "* Personalize the app\n" +
        //    "*Extend the app with cross-platform features\n" +
        //    "* Use FlexLayout and CSS to create a fluid layout\n" +
        //    "*Deploy to your own device!\n\n" +
        //    "> If you're on Windows you can use the new Live Reload (Preview) to see your XAML changes without leaving your debug session. " +
        //    "Simply make changes to your XAML and save the file.";

        //static string Page2 = "## Personalize the App\n\n" +
        //    "The My Profile page `UserProfileView.xaml` is looking quite plain.Let's add your own personal touch.\n\n" +
        //    "1. Locate and open the layout file within the.NET Standard Library project MOVAI > Views.\n" +
        //    "2. Run the project with F5 to see what you're working with.\n" +
        //    "On the emulator/simulator you should see something like this:\n\n" +
        //    "![Profile01](Images/Profile01.png)";
    }
}
