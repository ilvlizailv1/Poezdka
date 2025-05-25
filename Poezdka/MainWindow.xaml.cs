using System;
using System.Windows;
using System.Windows.Controls;

namespace TripCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateTrip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string user = UserNameBox.Text;
                string tripType = ((ComboBoxItem)TripTypeBox.SelectedItem)?.Content.ToString();
                float distance = float.Parse(DistanceBox.Text);
                float fuelPrice = float.Parse(FuelPriceBox.Text);
                float fuelConsumption = float.Parse(FuelConsumptionBox.Text);
                int passengers = int.Parse(PassengerBox.Text);
                string transport = ((ComboBoxItem)TransportBox.SelectedItem)?.Content.ToString();

                float fuelUsed = (distance / 100f) * fuelConsumption;
                float totalCost = fuelUsed * fuelPrice;
                float perPerson = totalCost / passengers;

                string message = $"Пользователь: {user}\n" +
                                 $"Тип поездки: {tripType}\n" +
                                 $"Транспорт: {transport}\n" +
                                 $"Расстояние: {distance} км\n" +
                                 $"Итоговая стоимость: {totalCost:F2} ₽\n" +
                                 $"На одного пассажира: {perPerson:F2} ₽\n" +
                                 $"Дата: {DateTime.Now.ToShortDateString()}";

                MessageBox.Show(message, "Отчет о поездке");
            }
            catch (Exception)
            {
                MessageBox.Show("Пожалуйста, корректно заполните все поля.", "Ошибка");
            }
        }
    }
}
