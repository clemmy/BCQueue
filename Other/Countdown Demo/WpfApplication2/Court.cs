using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.ComponentModel;
using System.Threading;

namespace WpfApplication2
{
    public delegate void Invoker();

    public class Court : TextBlock
    {
        public event EventHandler OnCountDownComplete;
        private static event EventHandler OnTick;
        private static Timer _UpdateTimer = new Timer(new TimerCallback(UpdateTimer), null, 1000, 1000);
        private Invoker _UpdateTimeInvoker;

        public Court()
            : base()
        {
            Init();
        }

        public Court(Inline inline)
            : base(inline)
        {
            Init();
        }

        private void Init()
        {
            Loaded += new RoutedEventHandler(TimerTextBlock_Loaded);
            Unloaded += new RoutedEventHandler(TimerTextBlock_Unloaded);
        }
        ~Court()
        {
            OnTick -= new EventHandler(TimerTextBlock_OnTick);
        }

        /// <summary>
        /// Represents the time remaining for the count down to complete if
        /// the control is initialized as a count down timer
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public TimeSpan TimeSpan
        {
            get { return (TimeSpan)GetValue(TimeSpanProperty); }
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentException();
                SetValue(TimeSpanProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for TimeSpan.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeSpanProperty =
            DependencyProperty.Register("TimeSpan", typeof(TimeSpan), typeof(Court), new UIPropertyMetadata(TimeSpan.Zero));

        public bool IsStarted
        {
            get { return (bool)GetValue(IsStartedProperty); }
            set { SetValue(IsStartedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDisplayTime. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsStartedProperty =
            DependencyProperty.Register("IsStarted", typeof(bool), typeof(Court), new UIPropertyMetadata(false));

        /// <summary        
        /// Format string for displaying the time span value.
        /// </summary>
        public string TimeFormat
        {
            get { return (string)GetValue(TimeFormatProperty); }
            set { SetValue(TimeFormatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimeFormat
        public static readonly DependencyProperty TimeFormatProperty =
            DependencyProperty.Register("TimeFormat", typeof(string), typeof(Court), new UIPropertyMetadata(null));
        /// <summary>
        /// Represents whether the control is a CountDown or regular timer.
        /// </summary>
        public bool IsCountDown
        {
            get { return (bool)GetValue(IsCountDownProperty); }
            set { SetValue(IsCountDownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCountDown
        public static readonly DependencyProperty IsCountDownProperty =
            DependencyProperty.Register("IsCountDown", typeof(bool), typeof(Court), new UIPropertyMetadata(false));

        /// <summary>
        /// Sets the time span to zero and stops the timer.
        /// </summary>
        public void Reset()
        {
            IsStarted = false;
            TimeSpan = TimeSpan.Zero;
        }
        private static void UpdateTimer(object state)
        {
            EventHandler onTick = OnTick;
            if (onTick != null)
                onTick(null, EventArgs.Empty);
        }

        void TimerTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            Binding binding = new Binding("TimeSpan");
            binding.Source = this;
            binding.Mode = BindingMode.OneWay;
            binding.StringFormat = TimeFormat;
            SetBinding(TextProperty, binding);
            _UpdateTimeInvoker = new Invoker(UpdateTime);
            OnTick += new EventHandler(TimerTextBlock_OnTick);
        }

        void TimerTextBlock_Unloaded(object sender, RoutedEventArgs e)
        {
            OnTick -= new EventHandler(TimerTextBlock_OnTick);
        }

        void TimerTextBlock_OnTick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(_UpdateTimeInvoker);
        }

        private void UpdateTime()
        {
            if (IsStarted)
            {
                TimeSpan step = TimeSpan.FromSeconds(1);
                if (IsCountDown)
                {
                    if (TimeSpan >= TimeSpan.FromSeconds(1))
                    {
                        TimeSpan -= step;
                        if (TimeSpan.TotalSeconds <= 0)
                        {
                            TimeSpan = TimeSpan.Zero;
                            IsStarted = false;
                            NotifyCountDownComplete();
                        }
                    }
                }
                else
                {
                    TimeSpan += step;
                }
            }
        }
        private void NotifyCountDownComplete()
        {
            EventHandler handler = OnCountDownComplete;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}