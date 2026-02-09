using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeautySalon
{
    /// <summary>
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        private int maxPage;
        private int page;
        private int perPage = 9;
        private List<Appointment> appointments;

        public AppointmentPage()
        {
            InitializeComponent();
            appointments = beauty_salonEntities.GetInstance().Appointment.OrderBy(x => x.id).ToList();
            page = maxPage = (int)Math.Ceiling((double)appointments.Count() / perPage);
            MoveToPage(page);
        }

        private void MoveToPage(int page)
        {
            PageStatusTextBlock.Text = $"{page} / {maxPage}";
            AppointmentListView.ItemsSource = appointments.Skip((page - 1) * perPage).Take(perPage).ToList();
            if (page <= 1)
            {
                PreviousPageButton.IsEnabled = false;
            } else
            {
                PreviousPageButton.IsEnabled = true;
            }
            if (page >= maxPage)
            {
                NextPageButton.IsEnabled = false;
            } else
            {
                NextPageButton.IsEnabled = true;
            }
            //if (page < 1)
            //{
            //    PreviousPageButton.IsEnabled = true;
            //} else if (page == 1)
            //{
            //    PreviousPageButton.IsEnabled = false;
            //}
            //if (page >= maxPage)
            //{
            //    NextPageButton.IsEnabled = true;
            //} else
            //{
            //    NextPageButton.IsEnabled = false;
            //}
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            page = page - 1;
            MoveToPage(page);
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            MoveToPage(page);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateAppointmentPage());
        }
    }
}
