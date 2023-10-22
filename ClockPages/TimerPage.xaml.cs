namespace DataAndTimePract.ClockPages;

public partial class TimerPage : ContentPage
{
    public TimerPage()
    {
        InitializeComponent();
    }

    private TimeSpan remainingTime;
    private bool isRunning = false;

    private async void StartButton_Clicked(object sender, EventArgs e)
    {
        if (!isRunning)
        {
            // Получите выбранное время от TimePicker
            var selectedTime = timePicker.Time;

            if (selectedTime.TotalSeconds > 0)
            {
                remainingTime = selectedTime;
                isRunning = true;
                startButton.Text = "Стоп";

                while (remainingTime.TotalSeconds > 0 && isRunning) //totalSeconds общее количество секунд.
                {
                    timerLabel.Text = remainingTime.ToString(@"hh\:mm\:ss");
                    await Task.Delay(1000); // Задержка на 1 секунду
                    remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                }

                isRunning = false;
                startButton.Text = "Старт";
                timerLabel.Text = "Время истекло!";
            }
        }
        else
        {
            isRunning = false;
            startButton.Text = "Старт";
        }
    }

}