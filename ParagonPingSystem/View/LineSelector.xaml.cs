using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ParagonPingSystem.View {

    public partial class LineSelector {

        private Line _currentLine;

        private Point _lastPosition;
        private Point _currentPosition;

        private Point _center;

        private int _currentQuadrant;

        public struct Selection {

            public Vector Offset { get; set; }

            public int Quadrant { get; set; }

        }

        public LineSelector() {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        public void StartSelection() {
            _center = new Point(ActualWidth / 2, ActualHeight / 2);
            _currentPosition = _center;

            _center = PointToScreen(_center);

            SetCursorPos((int) _center.X, (int) _center.Y);

            NextLine();
        }

        private void UpdateCenter() {
            _center.X = ActualWidth / 2;
            _center.Y = ActualHeight / 2;
        }

        public void StopSelection() {
            Clear();
            _currentLine = null;
        }

        private void NextLine() {
            _lastPosition = _currentPosition;

            _currentLine = new Line {
                X1 = _currentPosition.X,
                Y1 = _currentPosition.Y,
                X2 = _currentPosition.X,
                Y2 = _currentPosition.Y
            };

            Container.Children.Add(_currentLine);
        }

        private void UpdateLine() {
            _currentLine.X2 = _currentPosition.X;
            _currentLine.Y2 = _currentPosition.Y;
        }

        private void Clear() {
            Container.Children.Clear();
        }

        private void LineSelector_OnMouseMove(object sender, MouseEventArgs e) {
            e.Handled = true;

            if (_currentLine == null) {
                return;
            }

            UpdateCenter();

            _currentPosition = e.GetPosition((IInputElement) sender);
            _currentPosition.X = (int) _currentPosition.X;
            _currentPosition.Y = (int) _currentPosition.Y;

            UpdateLine();

            var newQuadrant = Helpers.GetQuadrant(_lastPosition, _currentPosition);

            if (newQuadrant != _currentQuadrant) {
                RaiseEvent(new RoutedEventArgs(LeaveEvent, _currentQuadrant));
                RaiseEvent(new RoutedEventArgs(HoverEvent, newQuadrant));
            }

            _currentQuadrant = newQuadrant;
        }

        private void LineSelector_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            e.Handled = true;

            //check before raising event
            if (_currentLine == null) {
                return;
            }

            UpdateCenter();

            RaiseEvent(new RoutedEventArgs(SelectEvent, new Selection {
                Offset = _currentPosition - _center,
                Quadrant = _currentQuadrant
            }));

            //if SelectEvent showed the final ping, we don't want to call NextLine(), so we return
            if (_currentLine == null) {
                return;
            }

            //updates last position
            NextLine();
        }

        public static readonly RoutedEvent SelectEvent = EventManager.RegisterRoutedEvent(
            "Select", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PingPicker));

        public event RoutedEventHandler Select {
            add => AddHandler(SelectEvent, value);
            remove => RemoveHandler(SelectEvent, value);
        }

        private static readonly RoutedEvent HoverEvent = EventManager.RegisterRoutedEvent(
            "Hover", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(PingPicker));

        public event RoutedEventHandler Hover {
            add => AddHandler(HoverEvent, value);
            remove => RemoveHandler(HoverEvent, value);
        }

        private static readonly RoutedEvent LeaveEvent = EventManager.RegisterRoutedEvent(
            "Leave", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(LineSelector));

        public event RoutedEventHandler Leave {
            add => AddHandler(LeaveEvent, value);
            remove => RemoveHandler(LeaveEvent, value);
        }
    }
}