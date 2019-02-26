﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BangumiX.Common;
using BangumiX.Properties;

namespace BangumiX.Views
{
    /// <summary>
    /// Interaction logic for Collection.xaml
    /// </summary>
    public partial class MyCollections : UserControl
    {
        public Dictionary<uint, List<Model.Collection>> collect_list;
        public List<Model.Collection> subject_list;
        public Subject SubjectControl;
        public MyCollections()
        {
            InitializeComponent();
            ListViewCollections.SelectionChanged += ListViewCollectionsSelectedIndexChanged;
        }

        public void Switch(ref Dictionary<uint, List<Model.Collection>> ref_ordered_collects)
        {
            collect_list = ref_ordered_collects;
            subject_list = collect_list[3];
            DataContext = subject_list;
            if (subject_list == null) ListViewCollections.SelectedIndex = -1;
            else ListViewCollections.SelectedIndex = 0;
            NavigationListView.SelectedItem = WatchingButton.Parent;
            return;
        }

        private void WishButtonClick(object sender, RoutedEventArgs e)
        {
            ListViewCollections.ItemsSource = null;
            subject_list = collect_list[1];
            ListViewCollections.ItemsSource = subject_list;
            if (subject_list == null) ListViewCollections.SelectedIndex = -1;
            else ListViewCollections.SelectedIndex = 0;
            NavigationListView.SelectedItem = ((Button)sender).Parent;
            return;
        }
        private void WatchingButtonClick(object sender, RoutedEventArgs e)
        {
            ListViewCollections.ItemsSource = null;
            subject_list = collect_list[3];
            ListViewCollections.ItemsSource = subject_list;
            if (subject_list == null) ListViewCollections.SelectedIndex = -1;
            else ListViewCollections.SelectedIndex = 0;
            NavigationListView.SelectedItem = ((Button)sender).Parent;
            return;
        }
        private void WatchedButtonClick(object sender, RoutedEventArgs e)
        {
            ListViewCollections.ItemsSource = null;
            subject_list = collect_list[2];
            ListViewCollections.ItemsSource = subject_list;
            if (subject_list == null) ListViewCollections.SelectedIndex = -1;
            else ListViewCollections.SelectedIndex = 0;
            NavigationListView.SelectedItem = ((Button)sender).Parent;
            return;
        }
        private void HoldButtonClick(object sender, RoutedEventArgs e)
        {
            ListViewCollections.ItemsSource = null;
            subject_list = collect_list[4];
            ListViewCollections.ItemsSource = subject_list;
            if (subject_list == null) ListViewCollections.SelectedIndex = -1;
            else ListViewCollections.SelectedIndex = 0;
            NavigationListView.SelectedItem = ((Button)sender).Parent;
            return;
        }
        private void DropButtonClick(object sender, RoutedEventArgs e)
        {
            ListViewCollections.ItemsSource = null;
            subject_list = collect_list[5];
            ListViewCollections.ItemsSource = subject_list;
            if (subject_list == null) ListViewCollections.SelectedIndex = -1;
            else ListViewCollections.SelectedIndex = 0;
            NavigationListView.SelectedItem = ((Button)sender).Parent;
            return;
        }


        private async void ListViewCollectionsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (subject_list == null) return;
            var index = ListViewCollections.SelectedIndex;
            if (index == -1) return;
            //if (subject_list[index].subject_detail == null) return;
                //{
            ApiHelper.SubjectResult subject_result = new ApiHelper.SubjectResult();
            subject_result = await ApiHelper.GetSubject(subject_list[index].subject_id);
            if (subject_result.Status != 1) return;

            ApiHelper.ProgressResult progress_result = new ApiHelper.ProgressResult();
            progress_result = await ApiHelper.GetProgress(Settings.Default.UserID, subject_result.Subject.id);
            if (progress_result.Status == 1)
            {
                if (progress_result.SubjectProgress != null)
                {
                    foreach (var ep in progress_result.SubjectProgress.eps)
                    {
                        foreach (var ep_src in subject_result.Subject.eps)
                        {
                            if (ep.id == ep_src.id) ep_src.ep_status = ep.status.id;
                        }
                    }
                }
            }

            subject_list[index].subject_detail = subject_result.Subject;
            //}
            if (SubjectControl == null)
            {
                SubjectControl = new Subject();
                Grid.SetColumn(SubjectControl, 1);
                GridMain.Children.Add(SubjectControl);
                SubjectControl.DataContext = subject_list[index].subject_detail;
                SubjectControl.buttonSummary.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                SubjectControl.DataContext = subject_list[index].subject_detail;
                SubjectControl.buttonSummary.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            return;
        }
    }
}