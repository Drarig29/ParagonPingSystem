using System.Windows;

namespace ParagonPingSystem.View {

    public partial class Arrow {

        public Arrow() {
            InitializeComponent();
        }

        public static readonly DependencyProperty QuadrantProperty = DependencyProperty.Register(
            "Quadrant", typeof(int), typeof(Arrow), new PropertyMetadata(default(int)));

        public int Quadrant {
            get => (int) GetValue(QuadrantProperty);
            set => SetValue(QuadrantProperty, value);
        }
    }
}
