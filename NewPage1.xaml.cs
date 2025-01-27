
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
        water_count.Text = $"���� ������: {_currentWaterAmount}";

        foods.Add("������", 197);
        foods.Add("������ ��� �����", 193);
        foods.Add("�������", 330);
        foods.Add("���� ���������", 132);
        foods.Add("������������ ����", 92);
        foods.Add("���������� ����", 90);
        foods.Add("������� ������", 260);
        foods.Add("�������", 110);
        foods.Add("�������� � ���������", 150);
        foods.Add("������", 180);
        foods.Add("�������", 220);
        foods.Add("��������� ���������", 160);
        foods.Add("������� ��� � ������", 70);
        foods.Add("�����", 56);
        foods.Add("������ �� �����������", 80);
        foods.Add("�������", 350);
        foods.Add("��������", 190);
        foods.Add("��������� �����", 120);
        foods.Add("������� �������", 75);
        foods.Add("�����", 170);

        foreach (var food in foods.Keys)
        {
            zavtrak.Items.Add(food); // ��������� �������� ���� � Picker           
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

        water_count.Text = $"���� ������: {_currentWaterAmount}";
        Preferences.Set("water_amount", _currentWaterAmount);

        if (e.NewValue == 10)
        {
            DisplayAlert("�� �������!", "�� ������ ������� ���� ����!", "�������!");
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
                call_label_int -= calories; // �������� ������� �� ����������
                callor_label.Text = call_label_int.ToString();
                Preferences.Default.Set("result", call_label_int);
            }
        }
    }

    
}