
namespace MauiApp2;

public partial class NewPage1 : ContentPage
{

    private readonly Dictionary<string, int> foods = new Dictionary<string, int>();

    private int _currentWaterAmount = 0;


    public NewPage1()
	{
		InitializeComponent();

        
        var result1 = Preferences.Default.Get("result", string.Empty);
        
        callor_label.Text = result1;

        _currentWaterAmount = Preferences.Get("water_amount", 0);

        stepper_water.Value = _currentWaterAmount;
        water_count.Text = $"Воды выпито: {_currentWaterAmount}";

        foods.Add("Оливье", 197);
        foods.Add("Селёдка под шубой", 193);
        foods.Add("Холодец", 330);
        foods.Add("Каша гречневая", 132);
        foods.Add("Картофельное пюре", 92);
        foods.Add("Кабачковая икра", 90);
        foods.Add("Котлеты мясные", 260);
        foods.Add("Голубцы", 110);
        foods.Add("Вареники с картошкой", 150);
        foods.Add("Шашлык", 180);
        foods.Add("Сырники", 220);
        foods.Add("Творожная запеканка", 160);
        foods.Add("Куриный суп с лапшой", 70);
        foods.Add("Кефир", 56);
        foods.Add("Компот из сухофруктов", 80);
        foods.Add("Медовик", 350);
        foods.Add("Шарлотка", 190);
        foods.Add("Морковный салат", 120);
        foods.Add("Тушёная капуста", 75);
        foods.Add("Омлет", 170);

        foreach (var food in foods.Keys)
        {
            zavtrak.Items.Add(food); // Добавляем названия блюд в Picker           
        }

        int call_label_int = int.Parse(callor_label.Text);
        callor_label.Text = call_label_int.ToString();

    }
    

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        _currentWaterAmount = (int)e.NewValue;

        water_count.Text = $"Воды выпито: {_currentWaterAmount}";
        Preferences.Set("water_amount", _currentWaterAmount);

        if (e.NewValue == 10)
        {
            DisplayAlert("Ты молодец!", "Ты достиг дневной дозы воды!", "Спасибо!");
        }

    }

    private void zavtrak_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sender is Picker picker && picker.SelectedIndex != -1)
        {
            var selectedFood = picker.Items[picker.SelectedIndex];
            if (foods.TryGetValue(selectedFood, out int calories))
            {
                int call_label_int = int.Parse(callor_label.Text);
                call_label_int -= calories; // Вычитаем калории из оставшихся
                callor_label.Text = call_label_int.ToString();
                Preferences.Default.Set("result", call_label_int);
            }
        }
    }

    
}