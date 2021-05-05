using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LibVLCSharp;
using LibVLCSharp.Forms;
using LibVLCSharp.Forms.Shared;
using LibVLCSharp.Shared;
using System.Threading;

namespace video_test
{
    public partial class MainPage : ContentPage
    {
        private List<string> playlist = new List<string>() {
            //add playlist here

        };
        private LibVLC lib_vlc;

         public MainPage() {
            InitializeComponent();

            Core.Initialize();
            //List<string> options = new List<string>();
            //options.Add("--freetype-opacity=0");
            this.lib_vlc = new LibVLC("--no-sub-autodetect-file", "--sub-track=100");

            this.create_video_view();
            this.init_video(false);
        }

        public void create_video_view() {
            VideoView v = new VideoView();
            
            v.HorizontalOptions = LayoutOptions.FillAndExpand;
            v.VerticalOptions = LayoutOptions.FillAndExpand;

            this.container.Children.Add(v);
        }

        private int video_index = 0;

        //private Media last_media;

        public void init_video(bool reset=true) {
            VideoView web = (VideoView)this.container.Children[0];

            if(this.video_index >= this.playlist.Count) {
                return;
            }
            string path = this.playlist[video_index];
                        
            Uri uri = new Uri(path);
            bool set_end = false;
            //bool reset = true;
            /*if(web.MediaPlayer == null) {
                reset = false;
            }*/

            
            using(Media media = new Media(this.lib_vlc, uri)) {
                
                media.AddOption("--no-sub-autodetect-file");
                media.AddOption("--sub-track=100");
                media.AddOption("--freetype-opacity=0");

                /*if(this.last_media != null) {
                    this.last_media.Dispose();
                }*/

                if(!reset) {
                    web.MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
                    set_end = true;
                } else {
                    web.MediaPlayer.Media = null;
                    web.MediaPlayer.Media = media;
                    //this.last_media = web.MediaPlayer.Media;
                }
                //this.last_media = web.MediaPlayer.Media;
                //media.Dispose();
            }

            web.MediaPlayer.Play();
            web.MediaPlayer.Position = 0.99f;
                
            //web.MediaPlayer.AspectRatio = null;
            //web.MediaPlayer.Scale = 0;
            if(set_end) {
                web.MediaPlayer.EndReached += (s, e) => ThreadPool.QueueUserWorkItem(_ => { //async //ThreadPool.QueueUserWorkItem(_
                    this.video_index++;
                    this.init_video();
                });
            }
        }
    }
}