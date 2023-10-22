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
            // �������� ��������� ����� �� TimePicker
            var selectedTime = timePicker.Time;

            if (selectedTime.TotalSeconds > 0)
            {
                remainingTime = selectedTime;
                isRunning = true;
                startButton.Text = "����";

                while (remainingTime.TotalSeconds > 0 && isRunning) //totalSeconds ����� ���������� ������.
                {
                    timerLabel.Text = remainingTime.ToString(@"hh\:mm\:ss");
                    await Task.Delay(1000); // �������� �� 1 �������
                    remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                }

                isRunning = false;
                startButton.Text = "�����";
                timerLabel.Text = "����� �������!";
            }
        }
        else
        {
            isRunning = false;
            startButton.Text = "�����";
        }
    }

}