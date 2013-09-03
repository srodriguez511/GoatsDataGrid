using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reactive.Linq;

namespace GoatsDataGrid.Model
{
    public class Goat : INotifyPropertyChanged
    {
        private Random _rand = new Random();
        private double MIN_VALUE = -1.0;
        private double MAX_VALUE = 1.0;
        private IObservable<double> _latGenerator;
        private IObservable<double> _lonGenerator;
        private IDisposable _latDispose;
        private IDisposable _lonDispose;

        public Goat()
        {
            _latGenerator = Observable.Generate(
                Lat,
                i => true,
                i => 1,
                i => Lat + Math.Round(_rand.NextDouble() * (MAX_VALUE - MIN_VALUE) + MIN_VALUE, 3),
                i => TimeSpan.FromSeconds(1.00));
            _lonGenerator = Observable.Generate(
                Long,
                i => true,
                i => 1,
                i => Long + Math.Round(_rand.NextDouble() * (MAX_VALUE - MIN_VALUE) + MIN_VALUE, 3),
                i => TimeSpan.FromSeconds(1.00));

            IsSubscribed = true;
        }

        public string Name { get; set; }

        private double _lat;
        public double Lat
        {
            get
            {
                return _lat;
            }
            private set
            {
                _lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        private double _long;
        public double Long
        {
            get
            {
                return _long;
            }
            private set
            {
                _long = value;
                NotifyPropertyChanged("Long");
            }
        }

        private bool _isSubscribed;
        public bool IsSubscribed
        {
            get
            {
                return _isSubscribed;
            }
            set
            {
                if (value)
                {
                    _latDispose = _latGenerator.Subscribe(val => Lat = val);
                    _lonDispose = _lonGenerator.Subscribe(val => Long = val);
                }
                else
                {
                    _latDispose.Dispose();
                    _lonDispose.Dispose();
                }

                _isSubscribed = value;
                NotifyPropertyChanged("IsSubscribed");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
