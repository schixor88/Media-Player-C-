using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace mediaplayer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        

        async private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
            //Represents a UI element that lets the user choose and open files
            FileOpenPicker openPicker = new FileOpenPicker();//fileopenpicker is defined with object as openpicker
            //Picker location:Identifies the storage location that
            //file picker presents to user
            openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;//loaction defined to start the selection
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".3gp");
            openPicker.FileTypeFilter.Add(".mp3");

            //PickSingleFileAsync: Shows the file picker so that the user can pick the
            var file = await openPicker.PickSingleFileAsync();//media plays as stirng of bits
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

            //media is a MediaElement defined in XAML
            media.SetSource(stream, file.ContentType);//send to screen as the file content seleced above
            media.Play();


        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }

        private void mute_Click(object sender, RoutedEventArgs e)
        {
           // media.IsMuted = true;

        }
    }
}
