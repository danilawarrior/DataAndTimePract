namespace DataAndTimePract.ClockPages;

public partial class AlarmClockPage : ContentPage
{
    public AlarmClockPage()
    {
        InitializeComponent();
    }

    CancellationTokenSource alarmCancellation;

    private void OnSwitchToggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            SetAlarm();
        }
        else
        {
            // ���������� ����������
            if (alarmCancellation != null)
            {
                alarmCancellation.Cancel();
            }
        }
    }

    private async void SetAlarm()
    {
        alarmCancellation = new CancellationTokenSource();

        TimeSpan selectedTime = timePicker.Time;
        DateTime now = DateTime.Now;
        DateTime alarmTime = new DateTime(now.Year, now.Month, now.Day, selectedTime.Hours, selectedTime.Minutes, 0);

        if (alarmTime <= now)
        {
            alarmTime = alarmTime.AddDays(1); // ��������� +1 ���� ���� ��������� ����� ��� ������
        }

        TimeSpan timeToAlarm = alarmTime - now;

        try
        {
            await Task.Delay(timeToAlarm, alarmCancellation.Token);

            await DisplayAlert("���������", "����� ����������!", "OK");
        }
        catch (TaskCanceledException)
        {
            // ��������� ��������
        }
    }
}

