﻿using ImageFiltersWPF.Models;
using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace ImageFiltersWPF.ViewModels
{
    /// <summary>
    /// Class responsible for storing photo data in application
    /// </summary>
    public class PhotoViewModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PhotoData photoData;

        public PhotoData PhotoData
        {
            get { return photoData; }
            set { photoData = value; OnPropertyChanged(nameof(PhotoData)); }
        }

        private string imageName;

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; OnPropertyChanged(nameof(ImageName)); }
        }

        private BitmapSource originalImage;

        public BitmapSource OriginalImage
        {
            get { return originalImage; }
            set { originalImage = value; OnPropertyChanged(nameof(OriginalImage)); }
        }

        private BitmapSource currentImage;

        public BitmapSource CurrentImage
        {
            get { return currentImage; }
            set { currentImage = value; OnPropertyChanged(nameof(CurrentImage)); }
        }

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}