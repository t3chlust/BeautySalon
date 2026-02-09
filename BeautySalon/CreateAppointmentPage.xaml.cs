using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeautySalon
{
    /// <summary>
    /// Логика взаимодействия для CreateAppointmentPage.xaml
    /// </summary>
    public partial class CreateAppointmentPage : Page
    {
        public CreateAppointmentPage()
        {
            InitializeComponent();
            ClientListBox.ItemsSource = beauty_salonEntities.GetInstance().Client.ToList();
            EmployeeListBox.ItemsSource = beauty_salonEntities.GetInstance().Employee.ToList();
            ServiceListBox.ItemsSource = beauty_salonEntities.GetInstance().Service.ToList();
            StatusListBox.ItemsSource = beauty_salonEntities.GetInstance().AppointmentStatus.ToList();
            MainDatePicker.SelectedDate = DateTime.Now.Date;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientListBox.SelectedItem == null || EmployeeListBox.SelectedItem == null || ServiceListBox.SelectedItem == null ||
                StatusListBox.SelectedItem == null || MainDatePicker == null)
            {
                MessageBox.Show("Заполните все поля", "Валидация данных", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                var appointment = new Appointment()
                {
                    client = ((Client)ClientListBox.SelectedItem).id,
                    employee = ((Employee)EmployeeListBox.SelectedItem).id,
                    service = ((Service)ServiceListBox.SelectedItem).id,
                    status = ((AppointmentStatus)StatusListBox.SelectedItem).id,
                    date = MainDatePicker.SelectedDate ?? DateTime.Now.Date
                };
                beauty_salonEntities.GetInstance().Appointment.Add(appointment);
                beauty_salonEntities.GetInstance().SaveChanges();
                MessageBox.Show("Запись успешно создана.", "Создание записи", MessageBoxButton.OK, MessageBoxImage.Information);
                ClientListBox.SelectedItem = null;
                EmployeeListBox.SelectedItem = null;
                ServiceListBox.SelectedItem = null;
                StatusListBox.SelectedItem = null;
                MainDatePicker.SelectedDate = DateTime.Now.Date;
            }
        }
    }
}
