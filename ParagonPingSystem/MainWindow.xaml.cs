using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using ParagonPingSystem.View;

namespace ParagonPingSystem {

    public partial class MainWindow {

        private PingTree _pingTree;

        private readonly Stack<int> _quadrants = new Stack<int>(4);

        private readonly DispatcherTimer _timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(2000)};

        public MainWindow() {
            InitializeComponent();

            _pingTree = FullTree.GetFullTree();

            MessageParent.Visibility = Visibility.Hidden;

            _timer.Tick += (sender, args) => {
                MessageParent.Visibility = Visibility.Hidden;
                _timer.Stop();
            };
        }

        public static readonly DependencyProperty TextsProperty = DependencyProperty.Register(
            "Texts", typeof(string[]), typeof(MainWindow), new PropertyMetadata(new string[4]));

        public string[] Texts {
            get => (string[]) GetValue(TextsProperty);
            private set => SetValue(TextsProperty, value);
        }

        public static readonly DependencyProperty PingPickerOffsetProperty = DependencyProperty.Register(
            "PingPickerOffset", typeof(Vector), typeof(MainWindow), new PropertyMetadata(default(Vector)));

        public Vector PingPickerOffset {
            get => (Vector) GetValue(PingPickerOffsetProperty);
            set => SetValue(PingPickerOffsetProperty, value);
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Escape) {
                ClosePicker();
            }

            if (e.Key != Key.C) return;

            //prevent LineSelector from opening (only thing visible is cursor set to center)
            if (BlackBackground.Opacity.Equals(1.0)) {
                return;
            }

            if (Texts[0] == null) {
                //show the ping picker
                Texts = _pingTree.Texts;
                LineSelector.StartSelection();
            } else {
                ClosePicker();
            }
        }

        private void ShowMessage(string message) {
            PopulateArrows();

            MessageParent.Visibility = Visibility.Visible;
            Message.Text = message;

            _timer.Stop();
            _timer.Start();
        }

        private void PopulateArrows() {
            var quadrants = _quadrants.ToArray();

            Arrows.Children.Clear();

            foreach (var quadrant in quadrants.Reverse()) {
                Arrows.Children.Add(new Arrow {
                    Quadrant = quadrant
                });
            }

            _quadrants.Clear();
        }

        private void ClosePicker() {
            PingPickerOffset *= 0f;

            _quadrants.Clear();

            //reset tree to full
            _pingTree = FullTree.GetFullTree();

            //causes the Ping objects to stop their animation and "hide" (scale = 0)
            Texts = new string[4];

            //clears the lines and stops the selection
            LineSelector.StopSelection();
        }

        private void MainWindow_OnMouseMove(object sender, MouseEventArgs e) {
            LineSelector.RaiseEvent(e);
        }

        private void LineSelector_OnSelect(object sender, RoutedEventArgs e) {
            var selection = (LineSelector.Selection) e.OriginalSource;

            if (selection.Quadrant == -1) {
                return;
            }

            _pingTree = _pingTree.Pings[selection.Quadrant];
            _quadrants.Push(selection.Quadrant);

            PingPickerOffset = selection.Offset;

            if (_pingTree.Pings == null) {
                var message = _pingTree.Phrase ?? _pingTree.Name;

                //final ping
                ShowMessage(message);
                ClosePicker();

                return;
            }

            Texts = _pingTree.Texts;
        }

        private void MainWindow_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            LineSelector.RaiseEvent(e);
        }

        private void Video_OnMediaOpened(object sender, RoutedEventArgs e) {
            var duration = Video.NaturalDuration;

            var animation = new DoubleAnimationUsingKeyFrames {
                Duration = duration
            };

            animation.KeyFrames.Add(new EasingDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.Zero)));

            animation.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1))));

            animation.KeyFrames.Add(new EasingDoubleKeyFrame(0,
                KeyTime.FromTimeSpan(duration.TimeSpan - TimeSpan.FromSeconds(1))));

            animation.KeyFrames.Add(new EasingDoubleKeyFrame(1,
                KeyTime.FromTimeSpan(duration.TimeSpan)));

            Storyboard.SetTarget(animation, BlackBackground);
            Storyboard.SetTargetProperty(animation, new PropertyPath(OpacityProperty));

            var sb = new Storyboard();
            sb.Children.Add(animation);
            sb.RepeatBehavior = RepeatBehavior.Forever;

            sb.Begin();
        }

        private static void MsgBox(string message, MessageBoxImage image) {
            MessageBox.Show(message, "Paragon", MessageBoxButton.OK, image);
        }

        private void Music_OnMediaFailed(object sender, ExceptionRoutedEventArgs e) {
            MsgBox("Can't load music: " + e.ErrorException, MessageBoxImage.Warning);
            MsgBox("Let's go without sound... ^^", MessageBoxImage.Information);
        }

        private void Video_OnMediaFailed(object sender, ExceptionRoutedEventArgs e) {
            MsgBox("Can't load music: " + e.ErrorException, MessageBoxImage.Warning);
            MsgBox("Using backup background image instead of the video.", MessageBoxImage.Information);

            //show background.jpg
            FallbackImage.Visibility = Visibility.Visible;

            //replace gideon pic with steel
            GideonPic.Visibility = Visibility.Hidden;
            SteelPic.Visibility = Visibility.Visible;

            //show all of this stuff :D
            BlackBackground.Opacity = 0;
        }
    }
}