namespace DataAndTimePract.ClockPages;

public partial class StopWatchPage : ContentPage
{

    bool stopWatchIsRunning = false;
    private TimeSpan elapsedTime = TimeSpan.Zero;
    private DateTime lastStartTime;
    public StopWatchPage()
    {
        InitializeComponent();
    }


    private void btnStartStop_Clicked(object sender, EventArgs e)
    {

        if (stopWatchIsRunning)
        {
            
            stopWatchIsRunning = false;
            btnReset.IsEnabled = true;
        }
        else
         {
          
            stopWatchIsRunning = true;
            lastStartTime = DateTime.Now; 

            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
            {
                if (stopWatchIsRunning)
                {
                    var elapsed = DateTime.Now - lastStartTime; 
                    elapsedTime = elapsedTime.Add(elapsed); 
                    lastStartTime = DateTime.Now; 
                    label.Text = elapsedTime.ToString(@"mm\:ss");
                }
                return true;
            });

            btnReset.IsEnabled = false;

        }
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        stopWatchIsRunning = false;
        elapsedTime = TimeSpan.Zero;
        label.Text = "00:00";
        btnReset.IsEnabled = false;
    }
}
