namespace DataAndTimePract.ClockPages;

public partial class Reminder : ContentPage
{
	public Reminder()
	{
		InitializeComponent();
        
    }

    private async void bttnok_Clicked(object sender, EventArgs e)
    {
        SetAlarm(entRemind.Text.ToString());
        await DisplayAlert("Успешно!", "Напоминание сохранено.", "OK");
        entRemind.Text = "";
    }
    
    CancellationTokenSource alarmCancellation;


    private async void SetAlarm(string remind)
    {
        alarmCancellation = new CancellationTokenSource();

        TimeSpan selectedTime = timePicker.Time;
        DateTime now = DateTime.Now;
        DateTime alarmTime = new DateTime(now.Year, now.Month, now.Day, selectedTime.Hours, selectedTime.Minutes, 0);

        if (alarmTime <= now)
        {
            alarmTime = alarmTime.AddDays(1); // добавляем +1 день если выбранное время уже прошло
        }

        TimeSpan timeToAlarm = alarmTime - now;

        try
        {
            await Task.Delay(timeToAlarm, alarmCancellation.Token);

            await DisplayAlert("Напоминание", remind.ToString(), "OK");
        }
        catch (TaskCanceledException)
        {
            // будильник выключен
        }
    }
}