using System.ComponentModel;

namespace DataAndTimePract.ClockPages;

public partial class ClockPage : ContentPage
{

    int x = 0;
    CancellationTokenSource cancellationTokenSource;
   


    public ClockPage()
    {
        InitializeComponent();
        timePicker.Time = DateTime.Now.TimeOfDay;
    }


    private void timePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
         x++;
        if (x > 6)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
            cancellationTokenSource = new CancellationTokenSource();
            UpdateTimePickerPeriodically(cancellationTokenSource.Token);
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        cancellationTokenSource = new CancellationTokenSource();
        UpdateTimePickerPeriodically(cancellationTokenSource.Token);
    }

    [Obsolete]
    private async Task UpdateTimePickerPeriodically(CancellationToken cancellationToken)
    {   
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(60000, cancellationToken); // ∆дем 1 минуту

            Device.BeginInvokeOnMainThread(() =>
            {
                timePicker.Time = timePicker.Time.Add(TimeSpan.FromMinutes(1));
            });
        }
            
    }
}
