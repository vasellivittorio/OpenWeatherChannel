using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OpenWheatherChannel.Classes;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=391641

namespace OpenWheatherChannel
{
    /// <summary>
    /// Pagina vuota che può essere utilizzata autonomamente oppure esplorata all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += PageLoaded;
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void PageLoaded(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "LoadingCity", true);
            var position = await new GeoLocation().GetCurrentGeoCoordinates();
            var data = await new WebServices().GetCurrentWheatherByGeoCoordinates(position.Latitude, position.Longitude);
            if(data == null)
            {
                var dialog = new MessageDialog("Cannot receive data", "Error");
                await dialog.ShowAsync();
            }
            VisualStateManager.GoToState(this, "DefaultState", true);

            WeaterImage.Source = new BitmapImage(new Uri(String.Format("http://openweathermap.org/img/w/{0}.png", data.weather.First().icon)));
            currentCityLabel.Text = data.name;
            currentTempLabel.Text = data.Temperature;
            currentWeatherLabel.Text = data.weather.First().main;

        }

        

        /// <summary>
        /// Richiamato quando la pagina sta per essere visualizzata in un Frame.
        /// </summary>
        /// <param name="e">Dati dell'evento in cui vengono descritte le modalità con cui la pagina è stata raggiunta.
        /// Questo parametro viene in genere utilizzato per configurare la pagina.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: preparare qui la pagina da visualizzare.

            // TODO: se l'applicazione contiene più pagine, assicurarsi che si stia
            // gestendo il pulsante Indietro dell'hardware effettuando la registrazione per
            // l'evento Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Se si utilizza l'elemento NavigationHelper fornito da alcuni modelli,
            // questo evento viene gestito automaticamente.
        }
    }
}
