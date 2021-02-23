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
            "/Volumes/TV/roseanne/5/Roseanne S05E01 Terms of Estrangement Part 1 - fiveofseven.mp4",
            "/Volumes/TV/marr/8/Married With Children - 0823 - The Legend of Ironhead Haynes.mp4",
            "/Volumes/TV/home/6/Home.Improvement.S06E14.DVDRip.XviD-SAiNTS.avi",
            "/Volumes/TV/allfam/1/All in the Family 01-05 - Judging Books by Covers.mp4",
            "/Volumes/TV/mamas/6/6x11 Bubba's House Band.AVI",
            "/Volumes/TV/maude/1/Maude.S01-EP05-Maude & The Radical.avi",
            "/Volumes/TV/design/3/S03E22 - Julia Drives Over The First Amendment.avi",
            //"/Volumes/TV/Friends/6/_Friends Season 06 Episode 20 - The One with Mac and C.H.E.E.S.E..avi",
            "/Volumes/TV/Frasier/9/S09E20 - The Love You Fake.avi",
            //"/Volumes/TV/news/1/News Radio %5B1.06%5D Luncheon at the Waldorf.avi",
            "/Volumes/TV/Cheers/8/Cheers - 805 - The Two Faces Of Norm.avi",
            "/Volumes/TV/night/3/Night Court - 3x07 - Dan's Boss.avi",
            "/Volumes/TV/sanford/6/s06e22 The Lucky Streak.avi",
            "/Volumes/TV/Becker/2/Becker S02E24 - Panic On 86th.mpg",
            "/Volumes/TV/norm/2/the.norm.show.218.dvdrip.xvid-ositv.avi",
            "/Volumes/TV/drew/4/The Drew Carey Show - 4x16 - Rats, Kate's Dating A Wrestler.avi",
            "/Volumes/TV/two/2/TGaaG.s2e17.P1.TGaGa.the.Storm.of.the.Century-PHRENiC.avi",
            "/Volumes/TV/dharma/2/_Dharma & Greg - S02E14 - Dharma and Greg on a Hot Tin Roof.avi",
            "/Volumes/TV/Cybill/3/Cybill S3 E08 - Going to Hell in a Limo (Part 1).avi",
            "/Volumes/TV/naked/2/Season 2, Episode 5 A Year in the Life.avi",
            "/Volumes/TV/less/3/Less.Than.Perfect.303.Ain.t.It.A.Shame.Claude.avi",
            "/Volumes/TV/veronica/1/S01E12 - Veronica's Fun and Pirates Are Crazy.avi",
            "/Volumes/TV/Ellen/5/Ellen - 5x13 - The Funeral.avi",
            "/Volumes/TV/laverne/1/Laverne & Shirley S03E07 (Dear Future Model).mp4",
            "/Volumes/TV/taxi/5/Episode 6 crime and punishment.avi",
            "/Volumes/TV/coach/5/Coach S05E05 - Shirley Burleigh, Girlie Friday.mp4",
            "/Volumes/TV/newhart/1/The Bob Newhart Show - S01E20 - A Home is Not Necessarily a House.mp4",
            "/Volumes/TV/wkrp/3/S03E19 - A Simple Little Wedding.avi",
            "/Volumes/TV/marytyler/1/MTM S06E04 (Murray in Love).mp4",
            "/Volumes/TV/perfect/3/3x21 - My Brother, Myself.avi",
            "/Volumes/TV/golden/2/The Golden Girls 02-05 Isn't It Romantic.mkv",
            "/Volumes/TV/murphy/5/S05E01-S05E02 - You Say Potatoe, I Say Potato.mp4",
            "/Volumes/TV/original/2/F.R.I.E.N.D.S. 224 - The One With Barry And Mindy's Wedding.avi",
            "/Volumes/TV/Frasier/8/S08E03 - The Bad Son.avi",
            "/Volumes/TV/seinfeld/3/Seinfeld Season 03 Episode 20 - The Letter.mkv",
            "/Volumes/TV/Cheers/6/Episode 618 Let Sleeping Drakes Lie.avi",
            "/Volumes/TV/simpsons/1/The.Simpsons.S01E07.Call.of.the.Simpsons.DVDRip.x264.mkv",
            "/Volumes/TV/night/9/Night Court - 9x16 - Party Girl  Pt1.avi",
            "/Volumes/TV/new2/2/Newhart s02e12.avi",
            "/Volumes/TV/charles/1/Charles in Charge S05E24 (Seeing is Believing).mp4",
            "/Volumes/TV/george/5/S05E08 - George Tries To Write.avi",
            "/Volumes/TV/mom/4/Mom S04E03 Sparkling Water and Ba-Dinkers.mp4",
            "/Volumes/TV/girlfriends/6/GIRLFRIENDS S06E03 - And Nanny Makes Three.avi",
            "/Volumes/TV/halfhalf/2/Half.&.Half.s02e21.The.Big.Mother.of.Mother's.Day.Rides.Again.Episode.2002.TVRIP.MKV-TVV.mkv",
            "/Volumes/TV/engvall/3/The Bill Engvall Show - 303 - Let it Go.avi",
            "/Volumes/TV/Reba/5/Reba S05E10 - Issues.mp4",
            "/Volumes/TV/will/3/324 Sons & Lovers.mp4",
            "/Volumes/TV/behaving/off/1/Off.Centre.119.Addicted.To.Love.avi",
            "/Volumes/TV/single/4/Living Single - S04 E24 - Never Can Say Goodbye (480p - HULU Web-DL).mp4",
            "/Volumes/TV/3rd/1/Episode 4 - Dick is from Mars, Sally is from Venus.mkv",
            "/Volumes/TV/times/1/Good Times S04E07 (J.J.'s New Career - Pt1).mp4",
            "/Volumes/TV/Empty/5/09 Timing is Everything - fiveofseven.mp4",
            "/Volumes/TV/daves/3/Daves.World.S03E01.DVDRip.x264-TVV.mkv",
            "/Volumes/TV/three/1/Three's Company - S05E22 - Honest Jack Tripper (moviesbyrizzo).avi",
            "/Volumes/TV/amen/2/Amen.S02E17.Deacon.Dearest.TVRip.XviD-Suckafree.avi",
            "/Volumes/TV/227/5/227.s05e08.dsr.x264-regret.mkv",
            "/Volumes/TV/dickvan/2/The New Dick Van Dyke Show - S02E20 Will Baby Make Three.avi",
            "/Volumes/TV/benson/2/Benson.S02E10.The Apartment.mp4",
            "/Volumes/TV/jeffersons/3/Jeffersons S03E15 (Jefferson Airplane).mp4",
            "/Volumes/TV/alf/4/S04E02 - Lies.avi",
            "/Volumes/TV/matters/4/Family Matters - 4x20 - Pulling Teeth (TV-DVDRip Hå®T).avi",
            "/Volumes/TV/maude/4/S04E23 - Carol's Promotion.mp4",
            "/Volumes/TV/design/1/S01E09 - Veda.mkv",
            "/Volumes/TV/Friends/2/Friends Season 02 Episode 01 - The One with Ross's New Girlfriend.avi",
            "/Volumes/TV/Frasier/6/frasier.607-med.avi",
            "/Volumes/TV/Cheers/8/Cheers - 803 - A Bar Is Born.avi",
            "/Volumes/TV/night/9/Night Court - 9x19 - P.S. Do I Know You.avi",
            "/Volumes/TV/chico/3/Chico and the Man - 3x11 - Ready When You Are, CB.avi",
            "/Volumes/TV/martin/3/Martin S03E27 Love is a Beach.avi",
            "/Volumes/TV/wayans/3/15 - Goodbye Mr.Gibbs.avi",
            "/Volumes/TV/inthehouse/2/In the House - 2x01 - Dog Catchers.mp4",
            "/Volumes/TV/foxx/5/Jamie Foxx Show - s05e01 - On Bended Knee.avi",
            "/Volumes/TV/eddie/1/1x09 Big Brother Is Watching.avi",
            "/Volumes/TV/cosby/2/Cosby.S02E17.Fifteen.Minutes.of.Fame.AMZN.WEB-DL.DD+2.0.H.264-AJP69.mkv"
        };
        private LibVLC lib_vlc;

        public MainPage() {
            InitializeComponent();

            Core.Initialize();
            //List<string> options = new List<string>();
            //options.Add("--freetype-opacity=0");
            this.lib_vlc = new LibVLC("--no-sub-autodetect-file", "--sub-track=100");

            this.create_video_view();
            this.init_video();
        }

        public void create_video_view() {
            VideoView v = new VideoView();
            
            v.HorizontalOptions = LayoutOptions.FillAndExpand;
            v.VerticalOptions = LayoutOptions.FillAndExpand;

            this.container.Children.Add(v);
        }

        private int video_index = 0;

        private Media last_media;

        public void init_video() {
            VideoView web = (VideoView)this.container.Children[0];

            if(this.video_index >= this.playlist.Count) {
                return;
            }
            string path = this.playlist[video_index];
                        
            Uri uri = new Uri(path);
            bool set_end = false;
            bool reset = false;
            if(web.MediaPlayer == null) {
                reset = false;
            }

            
            using(Media media = new Media(this.lib_vlc, uri)) {
                
                media.AddOption("--no-sub-autodetect-file");
                media.AddOption("--sub-track=100");
                media.AddOption("--freetype-opacity=0");

                if(this.last_media != null) {
                    this.last_media.Dispose();
                }

                if(!reset) {
                    web.MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
                    set_end = true;
                } else {
                    web.MediaPlayer.Media = media;
                    //this.last_media = web.MediaPlayer.Media;
                }
                this.last_media = web.MediaPlayer.Media;

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
