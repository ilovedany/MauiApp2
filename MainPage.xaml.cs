using static System.Net.Mime.MediaTypeNames;
using Microsoft.Maui.Storage;
using System.ComponentModel.Design;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            ClearPreferencesService.CheckAndClearIfNewDay();


            string data = Preferences.Default.Get("result", string.Empty);
            if (data != "")
            {
                Navigation.PushModalAsync(new NewPage1());
            }
            

        }

        public static class PreferenceService
        {
            private const string LastCheckDateKey = "LastCheckDate";

            public static DateTime? GetLastCheckDate()
            {
                if (Preferences.ContainsKey(LastCheckDateKey))
                {
                    return Preferences.Get(LastCheckDateKey, default(DateTime));
                }
                else
                {
                    return null;
                }
            }

            public static void SetLastCheckDate(DateTime date)
            {
                Preferences.Set(LastCheckDateKey, date);
            }
        }

        public static class ClearPreferencesService
        {
            public static void CheckAndClearIfNewDay()
            {
                
                var lastCheckDate = PreferenceService.GetLastCheckDate();

                
                if (!lastCheckDate.HasValue || lastCheckDate.Value.Date != DateTime.Now.Date)
                {
                    
                    Preferences.Clear();

                    
                    PreferenceService.SetLastCheckDate(DateTime.Now);
                }
            }
        }


        public async void OnSaveClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ent1.Text) && !string.IsNullOrWhiteSpace(ent2.Text) && !string.IsNullOrWhiteSpace(ent3.Text))
            {
                
                int number1 = int.Parse(ent1.Text);
                int number2 = int.Parse(ent2.Text);
                int number3 = int.Parse(ent3.Text);

                int result = (number1*6) + (number2*10) - (number3 * 5) + 5;

                string resultstr = result.ToString();

                Preferences.Default.Set("result", resultstr);

                await DisplayAlert("", "Добро пожаловать!", "Начать");

                await Navigation.PushModalAsync(new NewPage1());
            }
            else
            {
                await DisplayAlert("Ошибка", "Пожалуйста, введите данные!", "ОК");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewPage1());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Preferences.Clear();
            
            DisplayAlert("", "очищено", "ок");
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Preferences.Clear();
        }
    }
}


