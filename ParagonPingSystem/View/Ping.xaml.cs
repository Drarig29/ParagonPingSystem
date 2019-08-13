using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ParagonPingSystem.View {

    public partial class Ping {

        private readonly Storyboard _showAnimation;
        private string _text;

        public Ping() {
            InitializeComponent();

            SetScale(this, 0);

            _showAnimation = (Storyboard) Resources["ShowAnimation"];

            // ReSharper disable once PossibleNullReferenceException
            var hoverColor = (Color) ColorConverter.ConvertFromString("#E0A129");
            var hoverBrush = new SolidColorBrush(hoverColor);

            Loaded += (s, a) => {
                var mainWindow = Helpers.FindParent<MainWindow>(this);

                if (mainWindow == null) {
                    if (DesignerProperties.GetIsInDesignMode(this)) {
                        return;
                    }

                    throw new NullReferenceException("MainWindow not found.");
                }

                mainWindow.LineSelector.Hover += (sender, args) => { SetInnerBrush(args.OriginalSource, hoverBrush); };

                mainWindow.LineSelector.Leave += (sender, args) => {
                    SetInnerBrush(args.OriginalSource, Brushes.Black);
                };
            };
        }

        private void SetInnerBrush(object checkTag, Brush brush) {
            //Tag is a string because it's defined in XAML (in PingPicker)

            if (checkTag.ToString() != (string) Tag) return;
            InnerBorder.BorderBrush = brush;
        }

        private static void SetScale(Ping instance, double scale) {
            instance.ScaleTransform.ScaleX = scale;
            instance.ScaleTransform.ScaleY = scale;
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(string), typeof(Ping), new PropertyMetadata("Ping", OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var value = (string) e.NewValue;

            var instance = (Ping) d;
            instance._text = value;

            if (value == null) {
                instance._showAnimation.SkipToFill();

                SetScale(instance, 0);
                return;
            }

            instance._showAnimation.Begin();
        }

        public string Value {
            get => (string) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty XProperty = DependencyProperty.Register(
            "X", typeof(double), typeof(Ping), new PropertyMetadata(default(double)));

        public double X {
            get => (double) GetValue(XProperty);
            set => SetValue(XProperty, value);
        }

        public static readonly DependencyProperty YProperty = DependencyProperty.Register(
            "Y", typeof(double), typeof(Ping), new PropertyMetadata(default(double)));

        public double Y {
            get => (double) GetValue(YProperty);
            set => SetValue(YProperty, value);
        }

        private static readonly RoutedEvent ShowEvent = EventManager.RegisterRoutedEvent(
            "Show", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(Ping));

        public event RoutedEventHandler Show {
            add => AddHandler(ShowEvent, value);
            remove => RemoveHandler(ShowEvent, value);
        }

        private void ShowAnimation_OnCompleted(object sender, EventArgs e) {
            SetScale(this, _text == null ? 0 : 1);
        }
    }
}